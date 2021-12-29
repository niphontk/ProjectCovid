Imports System.Globalization
Public Class frmMulti
    Dim qr As New ZXing.BarcodeWriter()
    Dim slotid As String
    Dim slotno, pserial, pexp_date, pdose, pdose_num, pvaccine_name As String

    Private Sub PrintDocument2_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        Dim qFont As Font = New Drawing.Font("TH SarabunPSK", 30, FontStyle.Bold)
        Dim frFont As Font = New Drawing.Font("TH SarabunPSK", 20, FontStyle.Bold)
        Dim deTailFont As Font = New Drawing.Font("TH SarabunPSK", 16, FontStyle.Bold)
        Dim deTailFont1 As Font = New Drawing.Font("TH SarabunPSK", 8)
        Dim deTailFont2 As Font = New Drawing.Font("TH SarabunPSK", 20, FontStyle.Bold)

        Dim strQrcode As String = slotno & "#" & pserial & "#" & pexp_date & "#" & pdose & "#" & pdose_num

        e.Graphics.DrawString("LotNo : " & slotno, deTailFont, Brushes.Black, 20, 40)
        e.Graphics.DrawString("Serial NO : " & pserial, deTailFont, Brushes.Black, 20, 65)
        e.Graphics.DrawString("ExpireDate : " & pexp_date, deTailFont, Brushes.Black, 20, 90)
        e.Graphics.DrawString("ชื่อวัคซีน : " & pvaccine_name, deTailFont, Brushes.Black, 20, 115)
        e.Graphics.DrawString("ลำดับ Dose : " & pdose, deTailFont, Brushes.Black, 20, 140)
        e.Graphics.DrawString("จำนวน Dose : " & pdose_num, deTailFont, Brushes.Black, 20, 165)

        qr.Format = ZXing.BarcodeFormat.QR_CODE
        Dim result = New Bitmap(qr.Write(strQrcode.Trim()))
        e.Graphics.DrawImage(result, 140, 180)
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim qFont As Font = New Drawing.Font("TH SarabunPSK", 30, FontStyle.Bold)
        Dim frFont As Font = New Drawing.Font("TH SarabunPSK", 20, FontStyle.Bold)
        Dim deTailFont As Font = New Drawing.Font("TH SarabunPSK", 16, FontStyle.Bold)
        Dim deTailFont1 As Font = New Drawing.Font("TH SarabunPSK", 8)
        Dim deTailFont2 As Font = New Drawing.Font("TH SarabunPSK", 20, FontStyle.Bold)

        'Dim strQrcode As String = TextBox1.Text & "#" & TextBox2.Text & "#" & DateTimePicker1.Value.ToString("yyyy-MM-dd", New CultureInfo("en-US")) & "#" & TextBox3.Text & "#" & TextBox4.Text

        e.Graphics.DrawString("LotNo : " & TextBox1.Text, deTailFont, Brushes.Black, 20, 40)
        e.Graphics.DrawString("Serial NO : " & TextBox2.Text, deTailFont, Brushes.Black, 20, 65)
        e.Graphics.DrawString("ExpireDate : " & DateTimePicker1.Value.ToString("yyyy-MM-dd", New CultureInfo("en-US")), deTailFont, Brushes.Black, 20, 90)
        e.Graphics.DrawString("ชื่อวัคซีน : " & ComboBox1.Text, deTailFont, Brushes.Black, 20, 115)
        'e.Graphics.DrawString("ลำดับ Dose : " & TextBox3.Text, deTailFont, Brushes.Black, 20, 140)
        e.Graphics.DrawString("จำนวน Dose : " & TextBox4.Text, deTailFont, Brushes.Black, 20, 165)

        qr.Format = ZXing.BarcodeFormat.QR_CODE
        'Dim result = New Bitmap(qr.Write(strQrcode.Trim()))
        'e.Graphics.DrawImage(result, 140, 180)
    End Sub

    Private Sub frmMulti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Now
        DateTimePicker2.Value = Date.Now
        'LoadSlot()
        LoadVaccine()

        With DataGridView1
            .ColumnCount = 6
            .Columns(0).HeaderText = "Lot"
            .Columns(1).HeaderText = "SN"
            .Columns(2).HeaderText = "Exdate"
            .Columns(3).HeaderText = "Dose_No"
            .Columns(4).HeaderText = "Dose_Num"
            .Columns(5).HeaderText = "Name"
        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pStr As String = DateTimePicker1.Value.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        Dim y As Integer = 1
        For x As Integer = 0 To TextBox3.Text - 1
            With DataGridView1
                .ColumnCount = 6
                Dim row As String() = New String() {TextBox1.Text, TextBox2.Text, pStr, y, TextBox4.Text, ComboBox1.Text}
                .Rows.Add(row)
            End With
            y = y + 1
        Next
        Button1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim lotno, sn, exp, dose, dose_num, vaccine_name, create_date As String

            Dim pStr As String = DateTimePicker1.Value.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
            Dim pUseDate As String = DateTimePicker2.Value.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
            For i As Integer = 0 To (DataGridView1.Rows.Count - 2)
                With DataGridView1.Rows(i)
                    lotno = .Cells(0).Value
                    sn = .Cells(1).Value
                    exp = .Cells(2).Value
                    dose = .Cells(3).Value
                    dose_num = .Cells(4).Value
                    vaccine_name = .Cells(5).Value
                End With

                create_date = pUseDate

                Dim sqlInsertData As DataTable = executesqlcommandhi("insert into vaccine_genqrcode(lotno,sn,exp,dose,dose_num,vaccine_name,create_date) values('" & lotno & "','" & sn & "','" & exp & "','" & dose & "','" & dose_num & "','" & vaccine_name & "','" & create_date & "')")
            Next

            ClearText()
            DataGridView1.Rows.Clear()
            TextBox1.Focus()

            With DataGridView1
                .ColumnCount = 6
                .Columns(0).HeaderText = "Lot"
                .Columns(1).HeaderText = "SN"
                .Columns(2).HeaderText = "Exdate"
                .Columns(3).HeaderText = "Dose_No"
                .Columns(4).HeaderText = "Dose_Num"
                .Columns(5).HeaderText = "Name"
            End With

        Catch ex As Exception

        End Try

    End Sub

    Sub LoadVaccine()
        Dim sqlLoadVaccince As DataTable = executesqlcommandhi("select * from vaccine_name")

        ComboBox1.DataSource = sqlLoadVaccince
        ComboBox1.DisplayMember = "name"
        ComboBox1.ValueMember = "name"

    End Sub

    Sub ClearText()
        For Each tb As TextBox In Me.GroupBox1.Controls.OfType(Of TextBox)()
            tb.Clear()
        Next
    End Sub

    Sub LoadSlot()
        Dim sqlLoadSlot As DataTable = executesqlcommandhi("select id,lotno,sn,exp,dose,dose_num,dose_count,vaccine_name from vaccine_genqrcode")

        Try
            DataGridView1.DataSource = sqlLoadSlot
        Catch ex As Exception

        End Try
    End Sub

    Public Sub PrintNoq()

        Try
            PrintDocument1.Print()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub PrintNoq1()

        Try
            PrintDocument2.Print()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class