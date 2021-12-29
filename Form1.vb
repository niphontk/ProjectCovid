Imports System.Globalization
Public Class Form1
    Dim qr As New ZXing.BarcodeWriter()
    Dim slotid As String
    Dim slotno, pserial, pexp_date, pdose, pdose_num, pvaccine_name As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Now
        DateTimePicker2.Value = Date.Now
        LoadSlot()
        LoadVaccine()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pStr As String = DateTimePicker1.Value.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        Dim pUseDate As String = DateTimePicker2.Value.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        If TextBox1.Text = "" Then
            MsgBox("กรุณาระบุ Lot No", vbCritical, "แจ้งเตือน")
            TextBox1.Focus()
            Exit Sub
        End If

        If TextBox2.Text = "" Then
            MsgBox("กรุณาระบุ Serial No", vbCritical, "แจ้งเตือน")
            TextBox2.Focus()
            Exit Sub
        End If

        If TextBox3.Text = "" Then
            MsgBox("กรุณาระบุ Dose", vbCritical, "แจ้งเตือน")
            TextBox3.Focus()
            Exit Sub
        End If

        If TextBox4.Text = "" Then
            MsgBox("กรุณาระบุ จำนวน Dose", vbCritical, "แจ้งเตือน")
            TextBox4.Focus()
            Exit Sub
        End If

        Dim sqlInsertData As DataTable = executesqlcommandhi("insert into vaccine_genqrcode(lotno,sn,exp,dose,dose_num,vaccine_name,create_date) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & pStr & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "','" & pUseDate & "')")
        'PrintNoq()
        ClearText()
        TextBox1.Focus()
        LoadSlot()
    End Sub

    Sub LoadSlot()
        Dim sqlLoadSlot As DataTable = executesqlcommandhi("select id,lotno,sn,exp,dose,dose_num,dose_count,vaccine_name from vaccine_genqrcode")

        Try
            DataGridView1.DataSource = sqlLoadSlot
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim qFont As Font = New Drawing.Font("TH SarabunPSK", 30, FontStyle.Bold)
        Dim frFont As Font = New Drawing.Font("TH SarabunPSK", 20, FontStyle.Bold)
        Dim deTailFont As Font = New Drawing.Font("TH SarabunPSK", 16, FontStyle.Bold)
        Dim deTailFont1 As Font = New Drawing.Font("TH SarabunPSK", 8)
        Dim deTailFont2 As Font = New Drawing.Font("TH SarabunPSK", 20, FontStyle.Bold)

        Dim strQrcode As String = TextBox1.Text & "#" & TextBox2.Text & "#" & DateTimePicker1.Value.ToString("yyyy-MM-dd", New CultureInfo("en-US")) & "#" & TextBox3.Text & "#" & TextBox4.Text

        e.Graphics.DrawString("LotNo : " & TextBox1.Text, deTailFont, Brushes.Black, 20, 40)
        e.Graphics.DrawString("Serial NO : " & TextBox2.Text, deTailFont, Brushes.Black, 20, 65)
        e.Graphics.DrawString("ExpireDate : " & DateTimePicker1.Value.ToString("yyyy-MM-dd", New CultureInfo("en-US")), deTailFont, Brushes.Black, 20, 90)
        e.Graphics.DrawString("ชื่อวัคซีน : " & ComboBox1.Text, deTailFont, Brushes.Black, 20, 115)
        e.Graphics.DrawString("ลำดับ Dose : " & TextBox3.Text, deTailFont, Brushes.Black, 20, 140)
        e.Graphics.DrawString("จำนวน Dose : " & TextBox4.Text, deTailFont, Brushes.Black, 20, 165)

        qr.Format = ZXing.BarcodeFormat.QR_CODE
        Dim result = New Bitmap(qr.Write(strQrcode.Trim()))
        e.Graphics.DrawImage(result, 140, 180)
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

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Dim sqlLoadSlot As DataTable = executesqlcommandhi("select id,lotno,sn,exp,dose,dose_num,dose_count from vaccine_genqrcode where lotno like '%" & TextBox5.Text & "%' or sn like '%" & TextBox5.Text & "%'")

        Try
            DataGridView1.DataSource = sqlLoadSlot
        Catch ex As Exception

        End Try
    End Sub

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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        slotid = Nothing
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        slotid = DataGridView1.Item(0, i).Value
        SearchSlot(slotid)
    End Sub
    Sub SearchSlot(slotid As String)
        Dim sqlSearchSlot As DataTable = executesqlcommandhi("select id,lotno,sn,exp,dose,dose_num,vaccine_name from vaccine_genqrcode where id = '" & slotid & "'")

        Try
            slotno = sqlSearchSlot.Rows(0)(1).ToString
            pserial = sqlSearchSlot.Rows(0)(2).ToString
            pexp_date = sqlSearchSlot.Rows(0)(3).ToString
            pdose = sqlSearchSlot.Rows(0)(4).ToString
            pdose_num = sqlSearchSlot.Rows(0)(5).ToString
            pvaccine_name = sqlSearchSlot.Rows(0)(6).ToString
            PrintNoq1()
        Catch ex As Exception

        End Try

    End Sub

End Class
