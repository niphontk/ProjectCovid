Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class frmAuthenCode
    Public Shared correlationId_, pid_, claimtype_, fname_, lname_ As String
    Dim correlationId As String
    Dim CheckConn As Boolean
    Private Const C_DIFF_X = 200
    Private Const C_DIFF_Y = 150
    Private Const C_ROW = 4
    Private Const C_COLUMN = 4
    Private lbl_size As New Size(C_DIFF_X, C_DIFF_Y)
    Public pday As String
    Public pvn As String
    Public pcln As String
    Dim qr As New ZXing.BarcodeWriter()
    Dim qhn As String
    Dim qvn As String
    Dim queueNumber As String
    Dim queueId As String
    Dim strQueueNumber As String
    Dim localcode As String
    Dim localname As String
    Dim apiqueuereg As String
    Dim hospcode As String
    Dim hospname As String
    Dim lqToken As String
    Dim queue_pr As String
    Dim checkBtn As String
    Dim chkClinic As Integer

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CheckConn = CheckForInternetConnection()

        If CheckConn = True Then
            'MsgBox("Read Card Online")

            Dim objValue As String

            Dim url As String = host_api & "/api/smartcard/read"

            Dim request As WebRequest = WebRequest.Create(url)

            request.Method = "GET"

            request.ContentType = "application/json"

            Try
                Dim response As WebResponse = request.GetResponse()
                Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)

                Dim reader As StreamReader
                reader = New StreamReader(response.GetResponseStream())

                Dim responseFromServer As String
                responseFromServer = reader.ReadToEnd()

                Dim readData As String = responseFromServer

                pid.Text = JObject.Parse(readData)("pid")
                fname.Text = JObject.Parse(readData)("fname")
                lname.Text = JObject.Parse(readData)("lname")
                sex.Text = JObject.Parse(readData)("sex")
                age.Text = JObject.Parse(readData)("age")
                mainInscl.Text = JObject.Parse(readData)("mainInscl")
                subInscl.Text = JObject.Parse(readData)("subInscl")
                correlationId = JObject.Parse(readData)("correlationId")

                Dim json As JObject = JObject.Parse(responseFromServer)

                objValue = json.SelectToken("claimTypes").ToString

                Dim node As DataTable = TryCast(JsonConvert.DeserializeObject(objValue, (GetType(DataTable))), DataTable)

                Try
                    Dim cmd As Button

                    For d = 0 To C_ROW * C_COLUMN - 1
                        cmd = New Button
                        cmd.Size = lbl_size
                        cmd.Font = New Font(cmd.Font.FontFamily, 18, FontStyle.Bold)
                        cmd.Location = New Point((d Mod C_COLUMN) * C_DIFF_X, (d \ C_COLUMN) * C_DIFF_Y)
                        cmd.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))

                        For g = 0 To node.Rows.Count
                            cmd.Name = node.Rows(d)(0)
                            cmd.Text = node.Rows(d)(1)
                        Next
                        AddHandler cmd.Click, AddressOf Me.Label_Click1
                        Me.Panel1.Controls.Add(cmd)
                    Next
                Catch ex As Exception

                End Try

            Catch ex As Exception
                MessageBox.Show("กรุณาเสียบบัตรประชาชน", "Error Card",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        Else
            'MsgBox("Read Card Only")

            Dim url As String = host_api & "/api/smartcard/read-card-only"

            Dim request As WebRequest = WebRequest.Create(url)

            request.Method = "GET"

            request.ContentType = "application/json"

            Try
                Dim response As WebResponse = request.GetResponse()
                Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)

                Dim reader As StreamReader
                reader = New StreamReader(response.GetResponseStream())

                Dim responseFromServer As String
                responseFromServer = reader.ReadToEnd()

                Dim ReadData As String = responseFromServer

                pid.Text = JObject.Parse(ReadData)("pid")
                fname.Text = JObject.Parse(ReadData)("fname")
                lname.Text = JObject.Parse(ReadData)("lname")

            Catch ex As Exception
                MessageBox.Show("กรุณาเสียบบัตรประชาชน", "Error Card",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
    End Sub

    Dim claimType, rtnauthencode As String
    Private Sub frmAuthenCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect_Api_Nhso()
    End Sub

    Public Shared Function CheckForInternetConnection() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function

    Private Sub Label_Click1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim st As String
        Dim cmd As Button = CType(sender, Button)
        Dim pDateTime As String
        Dim pdate As String
        Dim ppriorityId As String
        Dim ptime As String
        Dim save_cln As String = "10100"

        ptime = DateTime.Now.ToString("HH:mm:ss")

        pdate = DateTime.Now.ToString("yyyy/MM/dd")

        pDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

        st = DateTime.Now.ToString("HHmm")

        ppriorityId = "1"

        pcln = save_cln

        claimType = cmd.Name
        claimtype_ = claimType
        pid_ = pid.Text
        correlationId_ = correlationId
        fname_ = fname.Text
        lname_ = lname.Text

        frmPhone.ShowDialog()
        'SaveAuthen()

    End Sub

End Class