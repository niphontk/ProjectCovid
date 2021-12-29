Imports System.Drawing.Printing
Imports System.Globalization
Imports Microsoft.Office.Interop

Public Class frmReportA4
    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    Private _curCulture As System.Globalization.CultureInfo
    Private Sub frmReportA4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Now
    End Sub
    Sub ExportExcel()
        'https://kasem-mesak.blogspot.com/2016/05/vbnet-export-datagridview-to-excel.html
        _curCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US") 'ภาษาไทย
        Dim pdate As String = DateTime.Now.ToString("yyyyMMddHHmmss")
        Dim excelLocation As String = "C:\ExportVaccince\" & "report" & pdate & ".xlsx"
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pStr As String = DateTimePicker1.Value.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
        Dim sqlSearch As DataTable = executesqlcommandhi("select vaccine_history.hn,pt.fname,pt.lname,concat('วันที่ : ',date(vaccine_history.injection_time)) as date_injection,vaccine_history.lotno,vaccine_history.sn,vaccine_history.exdate,vaccine_history.dose,vaccine_history.vaccine_name from vaccine_history inner join pt on pt.hn=vaccine_history.hn where date(vaccine_history.injection_time) = '" & pStr & "'")
        If sqlSearch.Rows.Count > 0 Then
            DataGridView1.DataSource = sqlSearch
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim fmt As StringFormat = New StringFormat(StringFormatFlags.LineLimit)
        fmt.LineAlignment = StringAlignment.Center
        fmt.Trimming = StringTrimming.EllipsisCharacter
        Dim y As Int32 = e.MarginBounds.Top
        Dim rc As Rectangle
        Dim x As Int32
        Dim h As Int32 = 0
        Dim row As DataGridViewRow

        ' print the header text for a new page
        '   use a grey bg just like the control
        If newpage Then
            row = DataGridView1.Rows(mRow)
            x = e.MarginBounds.Left
            For Each cell As DataGridViewCell In row.Cells
                ' since we are printing the control's view,
                ' skip invidible columns
                If cell.Visible Then
                    rc = New Rectangle(x, y, cell.Size.Width, cell.Size.Height)

                    e.Graphics.FillRectangle(Brushes.LightGray, rc)
                    e.Graphics.DrawRectangle(Pens.Black, rc)

                    ' reused in the data pront - should be a function
                    Select Case DataGridView1.Columns(cell.ColumnIndex).DefaultCellStyle.Alignment
                        Case DataGridViewContentAlignment.BottomRight,
                         DataGridViewContentAlignment.MiddleRight
                            fmt.Alignment = StringAlignment.Far
                            rc.Offset(-1, 0)
                        Case DataGridViewContentAlignment.BottomCenter,
                        DataGridViewContentAlignment.MiddleCenter
                            fmt.Alignment = StringAlignment.Center
                        Case Else
                            fmt.Alignment = StringAlignment.Near
                            rc.Offset(2, 0)
                    End Select

                    e.Graphics.DrawString(DataGridView1.Columns(cell.ColumnIndex).HeaderText,
                                            DataGridView1.Font, Brushes.Black, rc, fmt)
                    x += rc.Width
                    h = Math.Max(h, rc.Height)
                End If
            Next
            y += h

        End If
        newpage = False

        ' now print the data for each row
        Dim thisNDX As Int32
        For thisNDX = mRow To DataGridView1.RowCount - 1
            ' no need to try to print the new row
            If DataGridView1.Rows(thisNDX).IsNewRow Then Exit For

            row = DataGridView1.Rows(thisNDX)
            x = e.MarginBounds.Left
            h = 0

            ' reset X for data
            x = e.MarginBounds.Left

            ' print the data
            For Each cell As DataGridViewCell In row.Cells
                If cell.Visible Then
                    rc = New Rectangle(x, y, cell.Size.Width, cell.Size.Height)

                    ' SAMPLE CODE: How To 
                    ' up a RowPrePaint rule
                    'If Convert.ToDecimal(row.Cells(5).Value) < 9.99 Then
                    '    Using br As New SolidBrush(Color.MistyRose)
                    '        e.Graphics.FillRectangle(br, rc)
                    '    End Using
                    'End If

                    e.Graphics.DrawRectangle(Pens.Black, rc)

                    Select Case DataGridView1.Columns(cell.ColumnIndex).DefaultCellStyle.Alignment
                        Case DataGridViewContentAlignment.BottomRight,
                         DataGridViewContentAlignment.MiddleRight
                            fmt.Alignment = StringAlignment.Far
                            rc.Offset(-1, 0)
                        Case DataGridViewContentAlignment.BottomCenter,
                        DataGridViewContentAlignment.MiddleCenter
                            fmt.Alignment = StringAlignment.Center
                        Case Else
                            fmt.Alignment = StringAlignment.Near
                            rc.Offset(2, 0)
                    End Select

                    e.Graphics.DrawString(cell.FormattedValue.ToString(),
                                      DataGridView1.Font, Brushes.Black, rc, fmt)

                    x += rc.Width
                    h = Math.Max(h, rc.Height)
                End If

            Next
            y += h
            ' next row to print
            mRow = thisNDX + 1

            If y + h > e.MarginBounds.Bottom Then
                e.HasMorePages = True
                ' mRow -= 1   causes last row to rePrint on next page
                newpage = True
                Return
            End If
        Next
    End Sub

    Private Sub PrintDocument1_BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument1.BeginPrint
        mRow = 0
        newpage = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView1.Rows.Count > 0 Then
            PrintDocument1.DefaultPageSettings.Landscape = True
            PrintPreviewDialog1.Document = PrintDocument1
            'PrintDocument1.Print()
            PrintPreviewDialog1.Show()
        Else

        End If
    End Sub
End Class