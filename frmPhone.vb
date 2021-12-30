Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json.Linq

Public Class frmPhone
    Dim pid_save, claim_save, correlationId_save, ReturnclaimCode, rtnauthencode, fname_save, lname_save As String

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        SaveAuthen()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pid_save = Nothing
        claim_save = Nothing
        correlationId_save = Nothing
        TextBox1.Text = ""
        Me.Close()
    End Sub

    Private Sub frmPhone_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pid_save = frmAuthenCode.pid_
        claim_save = frmAuthenCode.claimtype_
        correlationId_save = frmAuthenCode.correlationId_
        fname_save = frmAuthenCode.fname_
        lname_save = frmAuthenCode.lname_
    End Sub

    Sub SaveAuthen()
        Dim postData As String
        Dim mobile As String
        Dim xx As String

        Try
            Dim url As String = host_api & "/api/nhso-service/confirm-save"
            Dim request As WebRequest = WebRequest.Create(url)

            request.Method = "POST"

            postData = "{""pid"":""" & pid_save & """,""claimType"":""" & claim_save & """,""mobile"":""" & TextBox1.Text & """,""correlationId"":""" & correlationId_save & """}"

            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
            request.ContentType = "application/json"
            request.ContentLength = byteArray.Length
            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
            Dim response As WebResponse = request.GetResponse()
            Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
            dataStream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()

            xx = responseFromServer
            Dim json As JObject = JObject.Parse(xx)

            ReturnclaimCode = json.SelectToken("claimCode")

            'MsgBox(ReturnclaimCode)

            rtnauthencode = ReturnclaimCode

            SaveLog()

            pid_save = Nothing
            claim_save = Nothing
            correlationId_save = Nothing
            TextBox1.Text = ""
            ReturnclaimCode = Nothing
            rtnauthencode = Nothing
            fname_save = Nothing
            lname_save = Nothing
            Me.Close()

        Catch ex As Exception

            MessageBox.Show("PID เดียวกัน ขอ Authen HI/CI ได้มากสุด 2 ครั้ง", "ลงทะเบียนซ้ำ",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()

        End Try
    End Sub

    Sub SaveLog()
        Dim sqlInsert As DataTable = executesqlcommandhi("insert into pt_authen (pid,fname,lname,authen_code) values('" & pid_save & "','" & fname_save & "','" & lname_save & "','" & rtnauthencode & "')")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = TextBox1.Text & "1"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = TextBox1.Text & "2"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text = TextBox1.Text & "3"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox1.Text = TextBox1.Text & "4"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox1.Text = TextBox1.Text & "5"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = TextBox1.Text & "6"
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        TextBox1.Text = TextBox1.Text & "7"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        TextBox1.Text = TextBox1.Text & "8"
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        TextBox1.Text = ""
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox1.Text = TextBox1.Text & "9"
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        TextBox1.Text = TextBox1.Text & "0"
    End Sub

End Class