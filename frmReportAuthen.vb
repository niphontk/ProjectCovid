Imports System.Drawing.Printing
Imports System.Globalization
Imports Microsoft.Office.Interop

Public Class frmReportAuthen
    Private _curCulture As System.Globalization.CultureInfo
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox3.Text = "2524Trakan" Then
            Dim pStr As String = DateTimePicker1.Value.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
            Dim sqlSelect As DataTable = executesqlcommandhi("select pid,prename,fname,lname,authen_code,date_visit from pt_authen where date(pt_authen.date_visit) = '" & pStr & "'")

            If sqlSelect.Rows.Count > 0 Then
                DataGridView1.DataSource = sqlSelect
            End If

        Else
            MsgBox("รหัสผ่านไม่ถูกต้อง", vbCritical, "ผิดพลาด")
            Exit Sub
        End If

    End Sub

    Sub ExportExcel()
        'https://kasem-mesak.blogspot.com/2016/05/vbnet-export-datagridview-to-excel.html
        _curCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US") 'ภาษาไทย
        Dim pdate As String = DateTime.Now.ToString("yyyyMMddHHmmss")
        Dim excelLocation As String = "C:\ExportLab\" & "report_AuthenCode" & pdate & ".xlsx"
        Dim xlApp As Excel.Application = New Microsoft.Office.Interop.Excel.Application()
        If xlApp Is Nothing Then
            MessageBox.Show("Excel is not Install.")
            Return
        End If

        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")
        'Header Names
        Dim columnsCount As Integer = DataGridView1.Columns.Count
        For Each column In DataGridView1.Columns
            xlWorkSheet.Cells(1, column.Index + 1).Value = column.Name
        Next
        'Data
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Dim columnIndex As Integer = 0
            Do Until columnIndex = columnsCount
                xlWorkSheet.Cells(i + 2, columnIndex + 1).Value = DataGridView1.Item(columnIndex, i).Value
                columnIndex += 1
            Loop
        Next

        xlWorkBook.SaveAs(excelLocation)
        xlWorkBook.Close()
        xlApp.Quit()
        MsgBox("ส่งออกสำเร็จ จัดเก็บไฟล์ที่ " & excelLocation, MsgBoxStyle.Information, "ผลการส่งออก")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.Rows.Count > 0 Then
            ExportExcel()
        Else

        End If
    End Sub

    Private Sub frmReportAuthen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Now
    End Sub
End Class