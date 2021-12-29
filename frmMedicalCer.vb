Imports System.Globalization
Imports System.Drawing.Printing
Public Class frmMedicalCer
    Dim lcno As String
    Private _curCulture As System.Globalization.CultureInfo
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim qFont As Font = New Drawing.Font("TH SarabunPSK", 18, FontStyle.Bold)
        Dim frFont As Font = New Drawing.Font("TH SarabunPSK", 16, FontStyle.Bold)
        Dim deTailFont As Font = New Drawing.Font("TH SarabunPSK", 16, FontStyle.Regular)
        Dim deTailFont1 As Font = New Drawing.Font("TH SarabunPSK", 8, FontStyle.Regular)
        Dim deTailFont2 As Font = New Drawing.Font("TH SarabunPSK", 20, FontStyle.Regular)
        Dim pStr As String = DateTimePicker1.Value.ToString("dd-MM-yyyy", New CultureInfo("en-US"))
        Dim pStp As String = DateTimePicker2.Value.ToString("dd-MM-yyyy", New CultureInfo("en-US"))
        Dim dStr As String = DateTimePicker3.Value.ToString("dd-MM-yyyy", New CultureInfo("en-US"))
        Dim dStp As String = DateTimePicker4.Value.ToString("dd-MM-yyyy", New CultureInfo("en-US"))
        lcno = ComboBox1.SelectedValue

        Dim ptime As String
        Dim pdate As String

        ptime = DateTime.Now.ToString("HH:mm:ss")
        pdate = DateTime.Now.ToString("dd/MM/yyyy")

        Dim pic As New Bitmap(40, 40)
        pic = PictureBox1.Image
        e.Graphics.DrawImage(pic, 315, 20)

        e.Graphics.DrawString("ใบรับรองแพทย์ (Medical  Certificate)", qFont, Brushes.Black, 240, 130)
        e.Graphics.DrawString("โรงพยาบาลตระการพืชผล (Trakanphuetpol Hospital)", deTailFont, Brushes.Black, 220, 150)
        e.Graphics.DrawString("ที่อยู่ เลขที่ 207 หมู่ที่ 8 ถนนมาศนิวงศ์  ต.ขุหลุ  อ.ตระการพืชผล  จ.อุบลราชธานี  34130", deTailFont, Brushes.Black, 130, 180)
        e.Graphics.DrawString("โทรศัพท์ : (045) 481777 ,(045) 481012 ,(045) 251804", deTailFont, Brushes.Black, 220, 210)
        'e.Graphics.DrawString("โรงพยาบาลน้ำยืน (NAMYUEN Hospital)", deTailFont, Brushes.Black, 250, 160)
        'e.Graphics.DrawString("ที่อยู่ เลขที่ 234 หมู่ 7 ต.สีวิเชียร อ.น้ำยืน จ.อุบลราชธานี 34260", deTailFont, Brushes.Black, 190, 180)
        'e.Graphics.DrawString("โทรศัพท์ : 0-4537-1097-8", deTailFont, Brushes.Black, 250, 210)
        e.Graphics.DrawString("ข้าพเจ้า " & ComboBox1.Text & "  แพทย์แผนปัจจุบันชั้นหนึ่ง Physicialty's signature", deTailFont, Brushes.Black, 50, 240)
        e.Graphics.DrawString("ใบประกอบวิชาชีพเวชกรรม เลขที่ " & lcno & " Medical License No. " & lcno, frFont, Brushes.Black, 50, 260)
        e.Graphics.DrawString("ได้ตรวจร่างกายของ " & Label6.Text, deTailFont, Brushes.Black, 50, 290)
        e.Graphics.DrawString("(Examined)    " & "      (Patient name)", deTailFont, Brushes.Black, 50, 320)
        e.Graphics.DrawString("ได้มารับการตรวจ ณ โรงพยาบาลตระการพืชผล (At Trakanphuetpol Hospital)", frFont, Brushes.Black, 50, 350)
        'e.Graphics.DrawString("ได้มารับการตรวจ ณ โรงพยาบาลน้ำยืน (At NAMYUEN Hospital)", frFont, Brushes.Black, 50, 350)
        e.Graphics.DrawString("ผู้ป่วยใน (In - Patient) ตั้งแต่วันที่ (From Date) " & pStr & "  ถึงวันที่ (To Date) " & pStp, deTailFont, Brushes.Black, 50, 380)
        e.Graphics.DrawString("การวินิจฉัยโรค (Diagnosis) : โรคติดเชื้อไวรัสโคโรนา 2019 coronavirus disease-2019 (COVID-19)", frFont, Brushes.Black, 50, 410)
        e.Graphics.DrawString("รับการตรวจ (Has been treated on)", frFont, Brushes.Black, 50, 440)
        e.Graphics.DrawString("[ ] ให้ยา (Medication) [ ] เอกซเรย์ (X-Ray) [ ] การตรวจทางห้องปฏิบัติการ (Laboratory Investigation)", deTailFont, Brushes.Black, 50, 470)
        e.Graphics.DrawString("[ ] RT-PCR (Real-Time Polymerase chain reaction) [ ] อื่น ๆ (Other)...........................................", deTailFont, Brushes.Black, 50, 500)
        e.Graphics.DrawString("ส่งตัวไปรักษาต่อที่สถานพยาบาลอื่น (Refer to other Hospital)", frFont, Brushes.Black, 50, 530)
        e.Graphics.DrawString("[ ] ไม่มี (No)", deTailFont, Brushes.Black, 50, 560)
        e.Graphics.DrawString("[ ] มี (Yes) ส่งไปโรงพยาบาล (Refer to) ......................................เมื่อวันที่ (Date)..........................", deTailFont, Brushes.Black, 50, 590)
        e.Graphics.DrawString("ความเห็นของแพทย์ (Physician's opinion and Recommendation)", frFont, Brushes.Black, 50, 620)
        e.Graphics.DrawString("[/] สมควรให้หยุดพักรักษา (Patient should have illness leave) : " & Label15.Text & " วัน (Day)", deTailFont, Brushes.Black, 50, 640)
        e.Graphics.DrawString("ตั้งแต่วันที่ (From Date) " & dStr & "  ถึงวันที่ (To Date) " & dStp, deTailFont, Brushes.Black, 70, 670)
        e.Graphics.DrawString("[/] แนะนำ (Recommendation) : ", deTailFont, Brushes.Black, 50, 700)
        e.Graphics.DrawString("- กักตัวให้ครบในระยะเวลาที่กำหนด", deTailFont, Brushes.Black, 100, 730)
        e.Graphics.DrawString("- สวมหน้ากากอนามัย หลีกเลี่ยงการเข้าไปในสถานที่มีคนหนาแน่น", deTailFont, Brushes.Black, 100, 760)
        e.Graphics.DrawString("- ล้างมือด้วยสบู่เป็นประจำ", deTailFont, Brushes.Black, 100, 790)
        e.Graphics.DrawString("- ไม่ใช้อุปกรณ์รับประทานอาหารหรือแก้วน้ำร่วมกับผู้อื่น", deTailFont, Brushes.Black, 100, 820)
        e.Graphics.DrawString("- ทำความสะอาดพื้นผิวสัมผัสบ่อย ๆ", deTailFont, Brushes.Black, 100, 840)
        e.Graphics.DrawString("- หากมีอาการป่วยขึ้นใหม่หรือมีอาการเดิมมากขึ้น  ให้ติดต่อสถานพยาบาลใกล้บ้าน", deTailFont, Brushes.Black, 100, 860)
        e.Graphics.DrawString("- กักตัวตามระยะเวลาที่กำหนดให้ครบ 28 วัน", deTailFont, Brushes.Black, 100, 890)
        e.Graphics.DrawString("ลงชื่อ................................แพทย์ผู้ตรวจ", deTailFont, Brushes.Black, 500, 920)
        e.Graphics.DrawString("    " & ComboBox1.Text, deTailFont, Brushes.Black, 500, 940)
        e.Graphics.DrawString("ว." & lcno, deTailFont, Brushes.Black, 570, 970)
        e.Graphics.DrawString("หมายเหตุ : ใบรับรองนี้หากมีรอยขูดลบถือว่าใช้ไม่ได้ หากมีรอยขีดฆ่าแก้ไขต้องมีลายมือแพทย์ผู้ตรวจลงชื่อกำกับ", deTailFont, Brushes.Black, 50, 1000)

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
                    PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings()
                    PrintDocument1.Print()
                    TextBox1.SelectAll()
                    TextBox1.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text <> "" Then
            Dim sqlSelPt As DataTable = executesqlcommandhi("SELECT pt.hn,(CASE pt.male WHEN 1 THEN IF( pt.mrtlst < 6, IF( DATE_FORMAT( NOW( ) , '%Y' ) - DATE_FORMAT( pt.brthdate, '%Y' ) - ( DATE_FORMAT( NOW( ) , '00-%m-%d' ) < DATE_FORMAT( pt.brthdate, '00-%m-%d' ) ) < 15, 'ด.ช.', 'นาย' ),
            IF( DATE_FORMAT( NOW( ) , '%Y' ) - DATE_FORMAT( pt.brthdate, '%Y' ) - ( DATE_FORMAT( NOW( ) , '00-%m-%d' ) < DATE_FORMAT( pt.brthdate, '00-%m-%d' ) ) < 20, 'พระครูสังฆภารวิชัย', 'พระ' )
            ) WHEN 2 THEN IF( pt.mrtlst = 1,
            IF( DATE_FORMAT( NOW( ) , '%Y' ) - DATE_FORMAT( pt.brthdate, '%Y' ) - ( DATE_FORMAT( NOW( ) , '00-%m-%d' ) < DATE_FORMAT( pt.brthdate, '00-%m-%d' ) ) < 15, 'ด.ญ.', 'น.ส.' ),
            IF( pt.mrtlst < 6, 'นาง', 'แม่ชี' )) END) AS prename,pt.fname,pt.lname,timestampdiff(year,pt.brthdate,now()) as age,if(pt.male=1,'ชาย','หญิง'),o.bw,o.height,o.tt,o.pr,o.rr,o.sbp,o.dbp,o.bmi
            from pt
            INNER JOIN ovst o on o.hn = pt.hn             
            where pt.hn ='" & TextBox1.Text & "' order by o.vstdttm desc limit 1")

            Try
                Label4.Text = sqlSelPt.Rows(0)(0)
                Label6.Text = sqlSelPt.Rows(0)(1) & sqlSelPt.Rows(0)(2) & "  " & sqlSelPt.Rows(0)(3)
                Label7.Text = sqlSelPt.Rows(0)(4)

                TextBox1.Focus()
                TextBox1.SelectAll()
                Button1.Enabled = True
                GroupBox3.Enabled = True
                GroupBox1.Enabled = True
                ComboBox1.Focus()
                Button2.Enabled = True
            Catch ex As Exception
                MsgBox("ไม่พบ HN : " & TextBox1.Text & " กรุณาตรวจสอบ")
                TextBox1.Focus()
                TextBox1.SelectAll()
                Button1.Enabled = False
                GroupBox3.Enabled = False
                GroupBox1.Enabled = False
            End Try
        Else
            Dim sqlSelPt As DataTable = executesqlcommandhi("SELECT pt.hn,(CASE pt.male WHEN 1 THEN IF( pt.mrtlst < 6, IF( DATE_FORMAT( NOW( ) , '%Y' ) - DATE_FORMAT( pt.brthdate, '%Y' ) - ( DATE_FORMAT( NOW( ) , '00-%m-%d' ) < DATE_FORMAT( pt.brthdate, '00-%m-%d' ) ) < 15, 'ด.ช.', 'นาย' ),
            IF( DATE_FORMAT( NOW( ) , '%Y' ) - DATE_FORMAT( pt.brthdate, '%Y' ) - ( DATE_FORMAT( NOW( ) , '00-%m-%d' ) < DATE_FORMAT( pt.brthdate, '00-%m-%d' ) ) < 20, 'พระครูสังฆภารวิชัย', 'พระ' )
            ) WHEN 2 THEN IF( pt.mrtlst = 1,
            IF( DATE_FORMAT( NOW( ) , '%Y' ) - DATE_FORMAT( pt.brthdate, '%Y' ) - ( DATE_FORMAT( NOW( ) , '00-%m-%d' ) < DATE_FORMAT( pt.brthdate, '00-%m-%d' ) ) < 15, 'ด.ญ.', 'น.ส.' ),
            IF( pt.mrtlst < 6, 'นาง', 'แม่ชี' )) END) AS prename,pt.fname,pt.lname,timestampdiff(year,pt.brthdate,now()) as age,if(pt.male=1,'ชาย','หญิง'),o.bw,o.height,o.tt,o.pr,o.rr,o.sbp,o.dbp,o.bmi
            from pt
            INNER JOIN ovst o on o.hn = pt.hn             
            where pt.pop_id ='" & TextBox2.Text & "' order by o.vstdttm desc limit 1")

            Try
                Label4.Text = sqlSelPt.Rows(0)(0)
                Label6.Text = sqlSelPt.Rows(0)(1) & sqlSelPt.Rows(0)(2) & "  " & sqlSelPt.Rows(0)(3)
                Label7.Text = sqlSelPt.Rows(0)(4)

                TextBox1.Focus()
                TextBox1.SelectAll()
                Button1.Enabled = True
                GroupBox3.Enabled = True
                GroupBox1.Enabled = True
                ComboBox1.Focus()
                Button2.Enabled = True
            Catch ex As Exception
                MsgBox("ไม่พบ HN : " & TextBox1.Text & " กรุณาตรวจสอบ")
                TextBox1.Focus()
                TextBox1.SelectAll()
                Button1.Enabled = False
                GroupBox3.Enabled = False
                GroupBox1.Enabled = False
            End Try
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If TextBox1.Text = "" Then
                TextBox2.Focus()
            Else
                Button3_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub frmMedicalCer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Now
        DateTimePicker2.Value = Date.Now

        DateTimePicker3.Value = Date.Now
        DateTimePicker4.Value = Date.Now

        Dim sqlLoadch As DataTable = executesqlcommandhi("select concat(fname,'  ',lname) as fname,lcno from dct")

        Try
            If sqlLoadch.Rows.Count > 0 Then
                ComboBox1.DataSource = sqlLoadch
                ComboBox1.DisplayMember = "fname"
                ComboBox1.ValueMember = "lcno"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim y1 As New DateTime
        Dim y2 As New DateTime
        y2 = DateTimePicker4.Value.ToString("MM/dd/yyyy")
        y1 = DateTimePicker3.Value.ToString("MM/dd/yyyy")
        Dim year As Integer = DateDiff(DateInterval.Year, CDate(y1), CDate(y2))
        Dim Month As Integer = DateDiff(DateInterval.Month, CDate(y1), CDate(y2))
        Dim Day As Integer = DateDiff(DateInterval.Day, CDate(y1), CDate(y2))
        Label15.Text = Day
        Exit Sub
    End Sub

    Private Sub DateTimePicker4_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker4.ValueChanged
        Dim y1 As New DateTime
        Dim y2 As New DateTime
        y2 = DateTimePicker4.Value.ToString("MM/dd/yyyy")
        y1 = DateTimePicker3.Value.ToString("MM/dd/yyyy")
        Dim year As Integer = DateDiff(DateInterval.Year, CDate(y1), CDate(y2))
        Dim Month As Integer = DateDiff(DateInterval.Month, CDate(y1), CDate(y2))
        Dim Day As Integer = DateDiff(DateInterval.Day, CDate(y1), CDate(y2))
        Label15.Text = Day
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If TextBox2.Text = "" Then
                TextBox1.Focus()
            Else
                Button3_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.SelectAll()
        TextBox1.Focus()
    End Sub
End Class