Imports System.Drawing.Printing
Imports System.Globalization
Imports Microsoft.Office.Interop
Public Class frmReportATKFIAPCR
    Private _curCulture As System.Globalization.CultureInfo

    Private Sub frmReportATKFIAPCR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Now
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox3.Text = "2524Trakan" Then
            Dim pStr As String = DateTimePicker1.Value.ToString("yyyy-MM-dd", New CultureInfo("en-US"))
            Dim sqlSearch As DataTable = executesqlcommandhi("SELECT
	                                        concat('\'',p.pop_id) AS 'cid',
	                                        p.passport AS 'passport',
	                                        concat('\'',DATE_FORMAT(p.brthdate, '%Y/%m/%d')) AS birth,
                                        concat('\'',(CASE p.male WHEN 1 THEN IF( p.mrtlst < 6, IF( DATE_FORMAT( NOW( ) , '%Y' ) - DATE_FORMAT( p.brthdate, '%Y' ) - ( DATE_FORMAT( NOW( ) , '00-%m-%d' ) < DATE_FORMAT( p.brthdate, '00-%m-%d' ) ) < 15, '1','3' ),
                                        IF( DATE_FORMAT( NOW( ) , '%Y' ) - DATE_FORMAT( p.brthdate, '%Y' ) - ( DATE_FORMAT( NOW( ) , '00-%m-%d' ) < DATE_FORMAT( p.brthdate, '00-%m-%d' ) ) < 20, '368', '376' )
                                        ) WHEN 2 THEN IF( p.mrtlst = 1,
                                        IF( DATE_FORMAT( NOW( ) , '%Y' ) - DATE_FORMAT( p.brthdate, '%Y' ) - ( DATE_FORMAT( NOW( ) , '00-%m-%d' ) < DATE_FORMAT( p.brthdate, '00-%m-%d' ) ) < 15, '2', '4' ),
                                        IF( p.mrtlst < 6, '5', '408' )) END)) AS pre_name,
                                        p.fname as 'name',
                                        p.lname as 'lname',
                                        p.engfname as 'name_eng',
                                        p.englname as 'lname_eng',
                                        concat('\'',p.hometel) as 'telephone',
                                        pttype.namepttype,
                                        concat('\'',p.addrpart) as 'address',
                                        '' as 'address_eng',
                                        concat('\'',((case LENGTH(p.ntnlty) when 2 then concat('0', p.ntnlty) end))) as 'nation',
                                        concat('\'',p.chwpart) as 'province',
                                        concat('\'',(CONCAT(p.chwpart,p.amppart))) as 'district',
                                        concat('\'',(CONCAT(p.chwpart,p.amppart,p.tmbpart))) as 'sub-district',
                                        concat('\'','2') as 'objective',
                                        '7' as 'scpeciment_type',
                                        concat('\'',o.hn) as hn,
                                        '' as lab_no,
                                        concat('\'',DATE_FORMAT(l.senddate,'%Y/%m/%d '),TIME_FORMAT(l.sendtime * 100, '%H:%i')) as 'collection_date',    
                                        concat('\'','') as 'recieve_date',
                                        concat('\'',o.vn) as 'vn'
                                        FROM
	                                        ovst o
                                        INNER JOIN pt p ON p.hn = o.hn
                                        INNER JOIN lbbk l ON l.vn = o.vn
                                        INNER JOIN pttype on pttype.pttype=o.pttype
                                        WHERE
	                                        l.labcode IN ('634', '635', '636','904','863','887')
                                        and DATE(l.senddate) = '" & pStr & "'
                                        and TIME_FORMAT(l.sendtime * 100, '%H:%i') between '" & TextBox1.Text & "' and '" & TextBox2.Text & "'
UNION
SELECT
	                                        concat('\'',p.pop_id) AS 'cid',
	                                        p.passport AS 'passport',
	                                        concat('\'',DATE_FORMAT(p.brthdate, '%Y/%m/%d')) AS birth,
                                        concat('\'',(CASE p.male WHEN 1 THEN IF( p.mrtlst < 6, IF( DATE_FORMAT( NOW( ) , '%Y' ) - DATE_FORMAT( p.brthdate, '%Y' ) - ( DATE_FORMAT( NOW( ) , '00-%m-%d' ) < DATE_FORMAT( p.brthdate, '00-%m-%d' ) ) < 15, '1','3' ),
                                        IF( DATE_FORMAT( NOW( ) , '%Y' ) - DATE_FORMAT( p.brthdate, '%Y' ) - ( DATE_FORMAT( NOW( ) , '00-%m-%d' ) < DATE_FORMAT( p.brthdate, '00-%m-%d' ) ) < 20, '368', '376' )
                                        ) WHEN 2 THEN IF( p.mrtlst = 1,
                                        IF( DATE_FORMAT( NOW( ) , '%Y' ) - DATE_FORMAT( p.brthdate, '%Y' ) - ( DATE_FORMAT( NOW( ) , '00-%m-%d' ) < DATE_FORMAT( p.brthdate, '00-%m-%d' ) ) < 15, '2', '4' ),
                                        IF( p.mrtlst < 6, '5', '408' )) END)) AS pre_name,
                                        p.fname as 'name',
                                        p.lname as 'lname',
                                        p.engfname as 'name_eng',
                                        p.englname as 'lname_eng',
                                        concat('\'',p.hometel) as 'telephone',
                                        pttype.namepttype,
                                        concat('\'',p.addrpart) as 'address',
                                        '' as 'address_eng',
                                        concat('\'',((case LENGTH(p.ntnlty) when 2 then concat('0', p.ntnlty) end))) as 'nation',
                                        concat('\'',p.chwpart) as 'province',
                                        concat('\'',(CONCAT(p.chwpart,p.amppart))) as 'district',
                                        concat('\'',(CONCAT(p.chwpart,p.amppart,p.tmbpart))) as 'sub-district',
                                        concat('\'','2') as 'objective',
                                        '7' as 'scpeciment_type',
                                        concat('\'',i.hn) as hn,
                                        '' as lab_no,
                                        concat('\'',DATE_FORMAT(l.senddate,'%Y/%m/%d '),TIME_FORMAT(l.sendtime * 100, '%H:%i')) as 'collection_date',                                        
                                        concat('\'','') as 'recieve_date',
                                        concat('\'',i.vn) as 'vn'
                                        FROM
	                                        ipt i
                                        INNER JOIN pt p ON p.hn = i.hn
                                        INNER JOIN lbbk l ON l.vn = i.vn
                                        INNER JOIN pttype on pttype.pttype=i.pttype
                                        WHERE
	                                        l.labcode IN ('634', '635', '636','904','863','887')
                                        and DATE(l.senddate) = '" & pStr & "'
                                        and TIME_FORMAT(l.sendtime * 100, '%H:%i') between '" & TextBox1.Text & "' and '" & TextBox2.Text & "'")
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
    Sub ExportExcel()
        'https://kasem-mesak.blogspot.com/2016/05/vbnet-export-datagridview-to-excel.html
        _curCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US") 'ภาษาไทย
        Dim pdate As String = DateTime.Now.ToString("yyyyMMddHHmmss")
        Dim excelLocation As String = "C:\ExportLab\" & "report_ATK_FIA_PCR" & pdate & ".xlsx"
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
End Class