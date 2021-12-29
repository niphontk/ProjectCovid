Imports System.Drawing.Printing
Imports System.Globalization

Public Class frmGenQrCode
    Dim i As Integer
    Private WithEvents oPrintDoc As New System.Drawing.Printing.PrintDocument
    Private hRecPrinted As Short
    Dim sqlS As DataTable
    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    Dim lot, sn, exdate, dose, dose_num, pDose, pname, doseqrcode As String
    Dim qr As New ZXing.BarcodeWriter()

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim qFont As Font = New Drawing.Font("TH SarabunPSK", 30, FontStyle.Bold)
        Dim frFont As Font = New Drawing.Font("TH SarabunPSK", 14, FontStyle.Bold)
        Dim deTailFont As Font = New Drawing.Font("TH SarabunPSK", 10, FontStyle.Bold)
        Dim deTailFont1 As Font = New Drawing.Font("TH SarabunPSK", 8)
        Dim deTailFont2 As Font = New Drawing.Font("TH SarabunPSK", 20, FontStyle.Bold)

        Dim strQrcode As String = lot & ":" & sn & ":" & exdate & ":" & dose

        If RadioButton1.Checked = True Then
            e.Graphics.DrawString("Lot : " & lot, deTailFont, Brushes.Black, 1, 1)
            e.Graphics.DrawString("Serial : " & sn, deTailFont, Brushes.Black, 1, 15)
            e.Graphics.DrawString("ExpireDate : " & exdate, deTailFont, Brushes.Black, 1, 29)
            e.Graphics.DrawString("ชื่อวัคซีน : " & pname, deTailFont, Brushes.Black, 1, 43)
            e.Graphics.DrawString("ลำดับ Dose : " & dose, deTailFont, Brushes.Black, 1, 57)

            qr.Format = ZXing.BarcodeFormat.QR_CODE
            Dim result = New Bitmap(qr.Write(strQrcode.Trim()))
            Dim p As New Bitmap(CInt(result.Width * 1), CInt(result.Height * 1))
            e.Graphics.DrawImage(CType(result, Image), 120, 29, result.Width - 40, CInt(result.Height - 40))
        ElseIf RadioButton2.Checked = True Then
            e.Graphics.DrawString("Lot : " & lot, deTailFont, Brushes.Black, 1, 1)
            e.Graphics.DrawString("Serial : " & sn, deTailFont, Brushes.Black, 1, 15)
            e.Graphics.DrawString("ExpireDate : " & exdate, deTailFont, Brushes.Black, 1, 29)
            e.Graphics.DrawString("ชื่อวัคซีน : " & pname, deTailFont, Brushes.Black, 1, 43)
            e.Graphics.DrawString("ลำดับ Dose : " & dose, deTailFont, Brushes.Black, 1, 57)

            qr.Format = ZXing.BarcodeFormat.QR_CODE
            Dim result = New Bitmap(qr.Write(strQrcode.Trim()))
            Dim p As New Bitmap(CInt(result.Width * 1), CInt(result.Height * 1))
            e.Graphics.DrawImage(CType(result, Image), 120, 29, result.Width - 20, CInt(result.Height - 20))
        ElseIf RadioButton3.Checked = True Then
            e.Graphics.DrawString("Lot : " & lot, deTailFont, Brushes.Black, 5, 1)
            e.Graphics.DrawString("Serial : " & sn, deTailFont, Brushes.Black, 5, 15)
            e.Graphics.DrawString("ExpireDate : " & exdate, deTailFont, Brushes.Black, 5, 29)
            e.Graphics.DrawString("ชื่อวัคซีน : " & pname, deTailFont, Brushes.Black, 5, 43)
            e.Graphics.DrawString("ลำดับ Dose : " & dose_num, deTailFont, Brushes.Black, 5, 57)

            qr.Format = ZXing.BarcodeFormat.QR_CODE
            Dim result = New Bitmap(qr.Write(strQrcode.Trim()))
            Dim p As New Bitmap(CInt(result.Width * 1), CInt(result.Height * 1))
            e.Graphics.DrawImage(CType(result, Image), 115, 29, result.Width - 30, CInt(result.Height - 30))
        ElseIf RadioButton4.Checked = True Then
            e.Graphics.DrawString("Lot : " & lot, deTailFont, Brushes.Black, 5, 1)
            e.Graphics.DrawString("Serial : " & sn, deTailFont, Brushes.Black, 5, 15)
            e.Graphics.DrawString("ExpireDate : " & exdate, deTailFont, Brushes.Black, 5, 29)
            e.Graphics.DrawString("ชื่อวัคซีน : " & pname, deTailFont, Brushes.Black, 5, 43)
            e.Graphics.DrawString("ลำดับ Dose : " & dose_num, deTailFont, Brushes.Black, 5, 57)

            qr.Format = ZXing.BarcodeFormat.QR_CODE
            Dim result = New Bitmap(qr.Write(strQrcode.Trim()))
            Dim p As New Bitmap(CInt(result.Width * 1), CInt(result.Height * 1))
            e.Graphics.DrawImage(CType(result, Image), 120, 27, result.Width - 50, CInt(result.Height - 50))
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim y As Integer = 1
        For x As Integer = 0 To pDose - 1
            With DataGridView1
                .ColumnCount = 7
                Dim row As String() = New String() {lot, sn, exdate, dose, y, dose_num, pname}
                .Rows.Add(row)
            End With
            y = y + 1
        Next
        Button1.Enabled = True
    End Sub

    Private Sub dgvreciept_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvreciept.CellContentClick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pStr As String = DateTimePicker1.Value.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        sqlS = executesqlcommandhi("select id,lotno,sn,exp,create_date,dose,dose_num,dose_count,vaccine_name from vaccine_genqrcode where create_date = '" & pStr & "'")
        If sqlS.Rows.Count > 0 Then
            dgvreciept.DataSource = sqlS
            Button2.Enabled = True
        Else
            dgvreciept.DataSource = Nothing
        End If
    End Sub

    Private PreviewPCancel As Integer = 0
    Public PrintDialog1 As New PrintDialog

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.WindowState = FormWindowState.Maximized
            PreviewPCancel = 3
            'PrintPreviewDialog1.ShowDialog()
            If PreviewPCancel = 3 Then
                'show printer setup dialog
                If PrintDialog1.ShowDialog() = DialogResult.OK Then
                    'set print document to dialog settings
                    PrintDocument2.PrinterSettings = PrintDialog1.PrinterSettings()
                    PrintDocument1.Print()
                    For i As Integer = 0 To (DataGridView1.Rows.Count - 2)

                        lot = DataGridView1.Rows(i).Cells(0).Value
                        sn = DataGridView1.Rows(i).Cells(1).Value
                        exdate = DataGridView1.Rows(i).Cells(2).Value
                        dose = DataGridView1.Rows(i).Cells(3).Value
                        dose_num = DataGridView1.Rows(i).Cells(4).Value
                        doseqrcode = DataGridView1.Rows(i).Cells(5).Value
                        pname = DataGridView1.Rows(i).Cells(6).Value

                        PrintDocument2.Print()

                    Next
                    'PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings()
                    'PrintDocument1.Print()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub PrintDocument2_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage

        Dim qFont As Font = New Drawing.Font("TH SarabunPSK", 30, FontStyle.Bold)
        Dim frFont As Font = New Drawing.Font("TH SarabunPSK", 14, FontStyle.Bold)
        Dim deTailFont As Font = New Drawing.Font("TH SarabunPSK", 10, FontStyle.Bold)
        Dim deTailFont1 As Font = New Drawing.Font("TH SarabunPSK", 8)
        Dim deTailFont2 As Font = New Drawing.Font("TH SarabunPSK", 20, FontStyle.Bold)

        Dim strQrcode As String = lot & ":" & sn & ":" & exdate & ":" & dose & ":" & dose_num & ":" & doseqrcode

        If RadioButton1.Checked = True Then
            e.Graphics.DrawString("Lot : " & lot, deTailFont, Brushes.Black, 1, 1)
            e.Graphics.DrawString("Serial : " & sn, deTailFont, Brushes.Black, 1, 15)
            e.Graphics.DrawString("ExpireDate : " & exdate, deTailFont, Brushes.Black, 1, 29)
            e.Graphics.DrawString("ชื่อวัคซีน : " & pname, deTailFont, Brushes.Black, 1, 43)
            e.Graphics.DrawString("ลำดับ Dose : " & dose & "/" & dose_num, deTailFont, Brushes.Black, 1, 57)

            qr.Format = ZXing.BarcodeFormat.QR_CODE
            Dim result = New Bitmap(qr.Write(strQrcode.Trim()))
            Dim p As New Bitmap(CInt(result.Width * 1), CInt(result.Height * 1))
            e.Graphics.DrawImage(CType(result, Image), 130, 29, result.Width - 30, CInt(result.Height - 30))
        ElseIf RadioButton2.Checked = True Then
            e.Graphics.DrawString("Lot : " & lot, deTailFont, Brushes.Black, 1, 1)
            e.Graphics.DrawString("Serial : " & sn, deTailFont, Brushes.Black, 1, 15)
            e.Graphics.DrawString("ExpireDate : " & exdate, deTailFont, Brushes.Black, 1, 29)
            e.Graphics.DrawString("ชื่อวัคซีน : " & pname, deTailFont, Brushes.Black, 1, 43)
            e.Graphics.DrawString("ลำดับ Dose : " & dose & "/" & dose_num, deTailFont, Brushes.Black, 1, 57)

            qr.Format = ZXing.BarcodeFormat.QR_CODE
            Dim result = New Bitmap(qr.Write(strQrcode.Trim()))
            Dim p As New Bitmap(CInt(result.Width * 1), CInt(result.Height * 1))
            e.Graphics.DrawImage(CType(result, Image), 120, 29, result.Width - 20, CInt(result.Height - 20))
        ElseIf RadioButton3.Checked = True Then
            e.Graphics.DrawString("Lot : " & lot, deTailFont, Brushes.Black, 5, 1)
            e.Graphics.DrawString("Serial : " & sn, deTailFont, Brushes.Black, 5, 15)
            e.Graphics.DrawString("ExpireDate : " & exdate, deTailFont, Brushes.Black, 5, 29)
            e.Graphics.DrawString("ชื่อวัคซีน : " & pname, deTailFont, Brushes.Black, 5, 43)
            e.Graphics.DrawString("ลำดับ Dose : " & dose & "/" & dose_num, deTailFont, Brushes.Black, 5, 57)

            qr.Format = ZXing.BarcodeFormat.QR_CODE
            Dim result = New Bitmap(qr.Write(strQrcode.Trim()))
            Dim p As New Bitmap(CInt(result.Width * 1), CInt(result.Height * 1))
            e.Graphics.DrawImage(CType(result, Image), 115, 28, result.Width - 30, CInt(result.Height - 30))
        ElseIf RadioButton4.Checked = True Then
            e.Graphics.DrawString("Lot : " & lot, deTailFont, Brushes.Black, 5, 1)
            e.Graphics.DrawString("Serial : " & sn, deTailFont, Brushes.Black, 5, 15)
            e.Graphics.DrawString("ExpireDate : " & exdate, deTailFont, Brushes.Black, 5, 29)
            e.Graphics.DrawString("ชื่อวัคซีน : " & pname, deTailFont, Brushes.Black, 5, 43)
            e.Graphics.DrawString("ลำดับ Dose : " & dose & "/" & dose_num, deTailFont, Brushes.Black, 5, 57)

            qr.Format = ZXing.BarcodeFormat.QR_CODE
            Dim result = New Bitmap(qr.Write(strQrcode.Trim()))
            Dim p As New Bitmap(CInt(result.Width * 1), CInt(result.Height * 1))
            e.Graphics.DrawImage(CType(result, Image), 120, 27, result.Width - 50, CInt(result.Height - 50))
        End If

    End Sub

    Private Sub frmGenQrCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'sqlS = executesqlcommandhi("select * from vaccine_genqrcode limit 3")
        'dgvreciept.DataSource = sqlS
        DateTimePicker1.Value = Date.Now
    End Sub

    Private Sub PrintDocument2_BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument2.BeginPrint
        Dim mRow As Integer = 0
        Dim newpage As Boolean = True
    End Sub

    Private Sub dgvreciept_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvreciept.CellClick
        Dim i As Integer

        DataGridView1.Rows.Clear()
        i = dgvreciept.CurrentRow.Index
        pDose = dgvreciept.Item(6, i).Value

        lot = dgvreciept.Rows(i).Cells(1).Value
        sn = dgvreciept.Rows(i).Cells(2).Value
        exdate = dgvreciept.Rows(i).Cells(3).Value
        dose = dgvreciept.Rows(i).Cells(5).Value
        dose_num = dgvreciept.Rows(i).Cells(6).Value
        pname = dgvreciept.Rows(i).Cells(8).Value
    End Sub

    Private Sub dgvreciept_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvreciept.CellEnter

    End Sub
End Class