Imports System.Drawing.Printing
Imports System.Globalization
Imports Microsoft.Office.Interop
Public Class frmReportFIA
    Private _curCulture As System.Globalization.CultureInfo
    Private Sub frmReportFIA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Now
    End Sub
    Sub ExportExcel()
        'https://kasem-mesak.blogspot.com/2016/05/vbnet-export-datagridview-to-excel.html
        _curCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US") 'ภาษาไทย
        Dim pdate As String = DateTime.Now.ToString("yyyyMMddHHmmss")
        Dim excelLocation As String = "C:\ExportLab\" & "report_center_FIA_" & pdate & ".xlsx"
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox3.Text = "2524Trakan" Then
            Dim pStr As String = DateTimePicker1.Value.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
            Dim sqlSearch As DataTable = executesqlcommandhi("SELECT 
concat('\'',DATE_FORMAT(ovst.vstdttm,'%Y/%m/%d ')) as 'ORDERDATE',
concat('\'',TIME(ovst.vstdttm)) as 'ORDERTIME',
concat('\'',pt.pop_id) as 'CID',
ovst.hn as 'HN',
concat('\'',ovst.vn) as 'VN',
(CASE pt.male WHEN 1 THEN IF( pt.mrtlst < 6, IF( DATE_FORMAT( NOW( ) , '%Y' ) - DATE_FORMAT( pt.brthdate, '%Y' ) - ( DATE_FORMAT( NOW( ) , '00-%m-%d' ) < DATE_FORMAT( pt.brthdate, '00-%m-%d' ) ) < 15, 'ด.ช.', 'นาย' ),
IF( DATE_FORMAT( NOW( ) , '%Y' ) - DATE_FORMAT( pt.brthdate, '%Y' ) - ( DATE_FORMAT( NOW( ) , '00-%m-%d' ) < DATE_FORMAT( pt.brthdate, '00-%m-%d' ) ) < 20, 'พระครูสังฆภารวิชัย', 'พระ' )
) WHEN 2 THEN IF( pt.mrtlst = 1,
IF( DATE_FORMAT( NOW( ) , '%Y' ) - DATE_FORMAT( pt.brthdate, '%Y' ) - ( DATE_FORMAT( NOW( ) , '00-%m-%d' ) < DATE_FORMAT( pt.brthdate, '00-%m-%d' ) ) < 15, 'ด.ญ.', 'น.ส.' ),
IF( pt.mrtlst < 6, 'นาง', 'แม่ชี' )) END) AS 'PNAME',
pt.fname as 'FNAME',
pt.lname as 'LNAME',
round(DATEDIFF(date(ovst.vstdttm), pt.brthdate) / 365.25) as 'AGE',
concat('\'',pt.hometel) as 'HOMETEL',
GROUP_CONCAT(DISTINCT CONVERT(lab.labname,char(200))) as 'LAB_ITEM_NAME',
GROUP_CONCAT(DISTINCT CONVERT(labresult.labresult,char(250))) as 'LAB_RESULT',
GROUP_CONCAT(DISTINCT CONVERT(symptm.symptom,char(250))) as 'CC',
GROUP_CONCAT(DISTINCT CONVERT(phistory.phistory,char(250))) as 'HPI',
GROUP_CONCAT(DISTINCT CONVERT(pillness.pillness,char(250))) as 'PMH',
sum(DISTINCT incoth.rcptamt) as 'SERVICE_PRICE',
rcpt.amnt as 'INCOME',
cln.dspname as 'DEP',
cln.dspname as 'ROOM',
CONCAT(ovst.pttype,' : ',pttype.namepttype) as 'PTTYPE',
GROUP_CONCAT(DISTINCT CONVERT(ovstdx.icd10,char(250))) as 'PDX'
from ovst
INNER JOIN pt on pt.hn=ovst.hn
LEFT OUTER JOIN ovstdx on ovstdx.vn=ovst.vn
INNER JOIN pttype on pttype.pttype=ovst.pttype
LEFT OUTER JOIN symptm on symptm.vn=ovst.vn
LEFT OUTER JOIN phistory on phistory.vn=ovst.vn
LEFT OUTER JOIN pillness on pillness.vn=ovst.vn
LEFT OUTER JOIN incoth on incoth.vn=ovst.vn
LEFT OUTER JOIN rcpt on rcpt.vn=ovst.vn
INNER JOIN cln on cln.cln=ovst.cln
INNER JOIN lbbk on lbbk.vn=ovst.vn
INNER JOIN lab on lab.labcode=lbbk.labcode
LEFT OUTER JOIN labresult on labresult.ln=lbbk.ln
WHERE DATE(ovst.vstdttm) ='" & pStr & "' and TIME(ovst.vstdttm) BETWEEN '" & TextBox1.Text & "' and '" & TextBox2.Text & "'
and lbbk.labcode ='887'
GROUP BY ovst.vn")

            If sqlSearch.Rows.Count > 0 Then
                DataGridView1.DataSource = sqlSearch
            End If
        Else
            MsgBox("รหัสผ่านไม่ถูกต้อง", vbCritical, "ผิดพลาด")
            Exit Sub
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.Rows.Count > 0 Then
            ExportExcel()
        Else

        End If
    End Sub
End Class