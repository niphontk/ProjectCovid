Public Class frmScanQrcode
    Dim vn As String
    Dim vaccine_name As String
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If TextBox1.Text = "" Then
                TextBox3.Focus()
            Else
                Dim Str As String = TextBox1.Text
                Dim strarr() As String

                strarr = Str.Split("#")
                Try
                    Label1.Text = "HN : "
                    Label2.Text = "ชื่อ - สกุล : "
                    Label3.Text = Nothing
                    Label3.Text = strarr(2)
                    Dim datevisit As String = strarr(6)
                    Dim timevisit As String = strarr(7)

                    GetName(Label3.Text, datevisit, timevisit)

                Catch ex As Exception
                    MsgBox("ไม่พบข้อมูล", vbInformation, "ผลการค้นหา")
                    TextBox1.SelectAll()
                End Try
            End If
        End If
    End Sub

    Sub ClearText()
        For Each tb As TextBox In Me.GroupBox1.Controls.OfType(Of TextBox)()
            tb.Clear()
        Next

        For Each lb As Label In Me.GroupBox1.Controls.OfType(Of Label)()
            lb.Text = ""
        Next
    End Sub

    Sub ClearText1()
        For Each tb As TextBox In Me.GroupBox2.Controls.OfType(Of TextBox)()
            tb.Clear()
        Next

        For Each lb As Label In Me.GroupBox2.Controls.OfType(Of Label)()
            lb.Text = ""
        Next
    End Sub

    Sub GetName(hn As String, datevisit As String, timevisit As String)
        vn = Nothing
        Dim sqlCheckRegister As DataTable = executesqlcommandhi("SELECT o.vn,o.hn,p.fname,p.lname,o.vstdttm
                                                                from ovst o
                                                                INNER JOIN pt p on p.hn=o.hn
                                                                where o.hn='" & hn & "'
                                                                and date(o.vstdttm) = date('" & datevisit & "')
                                                                AND TIME_FORMAT(o.vstdttm,'%H:%i') = TIME_FORMAT('" & timevisit & "' * 100, '%H:%i')")
        Try
            Label7.Text = "LotNo : "
            Label6.Text = "Serial No : "
            Label5.Text = "Expire Date : "
            Label11.Text = "Dose : "
            'MsgBox(sqlCheckRegister.Rows(0)(0)).ToString()
            Label4.Text = sqlCheckRegister.Rows(0)(2) & "  " & sqlCheckRegister.Rows(0)(3)
            vn = sqlCheckRegister.Rows(0)(0)
            TextBox2.Focus()
        Catch ex As Exception
            MsgBox("ไม่พบข้อมูลการลงทะเบียน", vbInformation, "ผลการทำงาน")
            ClearText()
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dim dose_count As Integer

            Dim sqlCheckRegisterEpi As DataTable = executesqlcommandhi("select vn from epi where vn = '" & vn & "'")

            If sqlCheckRegisterEpi.Rows.Count = 0 Then
                MsgBox("ไม่พบข้อมูลการลงทะเบียนรับวัคซีน", vbInformation, "ผลการทำงาน")
                ClearText()
                ClearText1()
                TextBox1.Focus()
            Else
                'Try
                Dim Str As String = TextBox2.Text
                Dim strarr() As String

                strarr = Str.Split(":")
                Label8.Text = Nothing
                Label8.Text = strarr(0)
                Label9.Text = Nothing
                Label9.Text = strarr(1)
                Label10.Text = Nothing
                Label10.Text = strarr(2)

                'Dim xx As Integer = CheckDoseCount(Label8.Text, Label9.Text, Label10.Text, strarr(3), strarr(5))
                vaccine_name = CheckVaccineName(Label8.Text, Label9.Text, Label10.Text, strarr(3), strarr(5))

                'If xx = 0 Then
                'xx = xx + 1
                Label12.Text = Nothing
                Label12.Text = strarr(3) & "/" & strarr(5)

                Try
                    Dim sqlUpdateSlot As DataTable = executesqlcommandhi("update epi set lotno = '" & Label8.Text & "',serial_no = '" & Label9.Text & "',ex_date = '" & Label10.Text & "',bottleno = '" & strarr(3) & "',doseid = '" & strarr(4) & "' where vn = '" & vn & "'")

                    'Dim sqlUpdateDoseCount As DataTable = executesqlcommandhi("update vaccine_genqrcode set dose_count='" & xx & "' where lotno='" & Label8.Text & "' and sn='" & Label9.Text & "' and exp='" & Label10.Text & "' and dose='" & strarr(3) & "' and dose_num= '" & strarr(5) & "'")

                    Dim sqlAddVaccineHistory As DataTable = executesqlcommandhi("insert into vaccine_history(vn,hn,lotno,sn,exdate,dose,vaccine_name) values('" & vn & "','" & Label3.Text & "','" & Label8.Text & "','" & Label9.Text & "','" & Label10.Text & "','" & Label12.Text & "','" & vaccine_name & "')")

                    'PrintNoq()
                    ClearText()
                    ClearText1()
                    TextBox1.Focus()
                Catch ex As Exception

                End Try
                'Else
                'dose_count = strarr(4)
                'If xx = xx - 2 Then
                'MsgBox("จำนวน Slot ใกล้จะหมดแล้ว กรุณาตรวจสอบความถูกต้อง", vbCritical, "แจ้งเตือน")
                'xx = xx + 1
                'Label12.Text = Nothing
                'Label12.Text = strarr(3) & "/" & xx
                'Dim sqlUpdateSlot As DataTable = executesqlcommandhi("update epi set lotno = '" & Label8.Text & "',serial_no = '" & Label9.Text & "',ex_date = '" & Label10.Text & "',bottleno = '" & strarr(3) & "',doseid = '" & strarr(4) & "' where vn = '" & vn & "'")

                'Dim sqlUpdateDoseCount As DataTable = executesqlcommandhi("update vaccine_genqrcode set dose_count='" & xx & "' where lotno='" & Label8.Text & "' and sn='" & Label9.Text & "' and exp='" & Label10.Text & "' and dose='" & strarr(3) & "' and dose_num= '" & strarr(5) & "'")

                'Dim sqlAddVaccineHistory As DataTable = executesqlcommandhi("insert into vaccine_history(vn,hn,lotno,sn,exdate,dose,vaccine_name) values('" & vn & "','" & Label3.Text & "','" & Label8.Text & "','" & Label9.Text & "','" & Label10.Text & "','" & Label12.Text & "','" & vaccine_name & "')")

                'PrintNoq()
                'ClearText()
                'ClearText1()
                'TextBox1.Focus()
                'ElseIf xx < dose_count Then
                'xx = xx + 1
                'Label12.Text = Nothing
                'Label12.Text = strarr(3) & "/" & xx

                'Dim sqlUpdateSlot As DataTable = executesqlcommandhi("update epi set lotno = '" & Label8.Text & "',serial_no = '" & 'Label9.Text & "',ex_date = '" & Label10.Text & "',bottleno = '" & strarr(3) & "',doseid = '" & strarr(4) & "' where vn = '" & vn & "'")

                'Dim sqlUpdateDoseCount As DataTable = executesqlcommandhi("update vaccine_genqrcode set dose_count='" & xx & "' where lotno='" & Label8.Text & "' and sn='" & Label9.Text & "' and exp='" & Label10.Text & "' and dose='" & strarr(3) & "' and dose_num= '" & strarr(5) & "'")

                'Dim sqlAddVaccineHistory As DataTable = executesqlcommandhi("insert into vaccine_history(vn,hn,lotno,sn,exdate,dose,vaccine_name) values('" & vn & "','" & Label3.Text & "','" & Label8.Text & "','" & Label9.Text & "','" & Label10.Text & "','" & Label12.Text & "','" & vaccine_name & "')")

                'PrintNoq()
                'ClearText()
                'ClearText1()
                'TextBox1.Focus()
                'Else
                'MsgBox("จำนวน Slot หมดแล้ว กรุณาเปลี่ยน QR CODE", vbCritical, "แจ้งเตือน")
                'ClearText()
                'ClearText1()
                'TextBox1.Focus()
                'End If
                'End If
                'ClearText()
                'ClearText1()
                'TextBox1.Focus()
                '   Catch ex As Exception
                'ClearText()
                '  End Try
            End If

        End If
    End Sub

    Function CheckDoseCount(lot As String, sn As String, exp As String, dose As String, dosenum As String) As String
        Dim sqlCheckDoseCount As DataTable = executesqlcommandhi("select dose_count from vaccine_genqrcode where lotno='" & lot & "' and sn='" & sn & "' and exp='" & exp & "' and dose='" & dose & "' and dose_num= '" & dosenum & "'")

        If sqlCheckDoseCount.Rows(0)(0) = "0" Then
            Return 0
        Else
            Return sqlCheckDoseCount.Rows(0)(0)
        End If
    End Function

    Function CheckVaccineName(lot As String, sn As String, exp As String, dose As String, dosenum As String) As String
        Dim sqlCheckDoseCount As DataTable = executesqlcommandhi("select vaccine_name from vaccine_genqrcode where lotno='" & lot & "' and sn='" & sn & "' and exp='" & exp & "' and dose='" & dose & "' and dose_num= '" & dosenum & "'")

        If sqlCheckDoseCount.Rows(0)(0) = "0" Then
            Return 0
        Else
            Return sqlCheckDoseCount.Rows(0)(0)
        End If
    End Function

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim qFont As Font = New Drawing.Font("TH SarabunPSK", 30, FontStyle.Bold)
        Dim frFont As Font = New Drawing.Font("TH SarabunPSK", 20, FontStyle.Bold)
        Dim deTailFont As Font = New Drawing.Font("TH SarabunPSK", 20, FontStyle.Bold)
        Dim deTailFont1 As Font = New Drawing.Font("TH SarabunPSK", 8)
        Dim deTailFont2 As Font = New Drawing.Font("TH SarabunPSK", 20, FontStyle.Bold)

        e.Graphics.DrawString("HN : " & Label3.Text, deTailFont, Brushes.Black, 20, 50)
        e.Graphics.DrawString("ชื่อ - สกุล : " & Label4.Text, deTailFont, Brushes.Black, 20, 80)
        e.Graphics.DrawString("ชื่อวัคซีน : " & vaccine_name, deTailFont, Brushes.Black, 20, 110)
        e.Graphics.DrawString("LotNo : " & Label8.Text, deTailFont, Brushes.Black, 20, 140)
        e.Graphics.DrawString("Serial NO : " & Label9.Text, deTailFont, Brushes.Black, 20, 170)
        e.Graphics.DrawString("ExpireDate : " & Label10.Text, deTailFont, Brushes.Black, 20, 200)
        e.Graphics.DrawString("ลำดับ Dose : " & Label12.Text, deTailFont, Brushes.Black, 20, 230)

    End Sub

    Public Sub PrintNoq()

        Try
            PrintDocument1.Print()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If TextBox3.Text = "" Then
                TextBox1.Focus()
            Else
                Dim sqlSearchPt As DataTable = executesqlcommandhi("select ovst.vn,ovst.hn,concat(pt.fname,'  ',pt.lname) as fullname from ovst inner join pt on pt.hn=ovst.hn inner join epi on epi.vn=ovst.vn where ovst.hn='" & TextBox3.Text & "' and date(ovst.vstdttm)=CURDATE()")

                If sqlSearchPt.Rows.Count = 0 Then
                    MsgBox("NO DATA")
                Else
                    vn = sqlSearchPt.Rows(0)(0)
                    Label3.Text = sqlSearchPt.Rows(0)(1)
                    Label4.Text = sqlSearchPt.Rows(0)(2)

                    TextBox2.Focus()
                End If

            End If
        End If
    End Sub
End Class