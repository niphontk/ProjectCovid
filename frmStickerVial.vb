Imports System.Drawing.Printing
Imports System.Globalization

Public Class frmStickerVial
    Private currentpage As Integer = 0
    Private lastindex As Integer = 0
    Dim lot, sn, exdate As String
    Private curPage As Integer

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try
            Dim frFont As Font = New Drawing.Font("TH SarabunPSK", 14, FontStyle.Bold)

            'e.Graphics.DrawString("lot : " & lot & " sn : " & sn & " exdate : " & exdate, frFont, Brushes.Black, 20, 25)

            Dim RowCount As Integer = DataGridView1.Rows.Count - 1

            Static i As Integer
            i = 0
            i = 40

            Dim n As Integer = 0
            Dim j As Integer = 1

            While n < RowCount
                e.Graphics.DrawString(j, frFont, Brushes.Black, 22, i)
                e.Graphics.DrawString(DataGridView1.Rows(n).Cells(0).Value, frFont, Brushes.Black, 40, i)
                e.Graphics.DrawString(DataGridView1.Rows(n).Cells(1).Value & "  " & DataGridView1.Rows(n).Cells(2).Value & " Dose : " & DataGridView1.Rows(n).Cells(4).Value, frFont, Brushes.Black, 100, i)
                i = i + 15
                n = n + 1
                j = j + 1

            End While
            e.Graphics.DrawString("lot : " & lot, frFont, Brushes.Black, 22, i)
            e.Graphics.DrawString("sn : " & sn, frFont, Brushes.Black, 22, i + 15)
            e.Graphics.DrawString("exdate : " & exdate, frFont, Brushes.Black, 22, i + 30)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pStr As String = DateTimePicker1.Value.ToString("yyyy-MM-dd", New CultureInfo("en-US"))

        Dim sqlSearch As DataTable = executesqlcommandhi("SELECT date(v.injection_time) as injection_time,lotno,sn,exdate
                                                            from vaccine_history v
                                                            where date(v.injection_time) = '" & pStr & "'
                                                            GROUP BY lotno,sn,exdate")

        If sqlSearch.Rows.Count > 0 Then
            dgvreciept.DataSource = sqlSearch
            Button2.Enabled = True
        Else
            dgvreciept.DataSource = Nothing
            Button2.Enabled = False
            Button1.Enabled = False
        End If
    End Sub

    Private Sub frmStickerVial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Now
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If lot <> "" Then
            Dim sqlSearch As DataTable = executesqlcommandhi("SELECT vaccine_history.hn,pt.fname,pt.lname,vaccine_history.lotno,vaccine_history.dose
                from vaccine_history
                INNER JOIN pt on pt.hn=vaccine_history.hn
                WHERE vaccine_history.lotno = '" & lot & "'
                and vaccine_history.sn = '" & sn & "'
                and vaccine_history.exdate = '" & exdate & "'")

            If sqlSearch.Rows.Count > 0 Then
                DataGridView1.DataSource = sqlSearch
                Button1.Enabled = True
            Else
                DataGridView1.DataSource = Nothing
                Button1.Enabled = False
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim custom As New PaperSize("custom", 100, 800)
        'PrintDocument1.DefaultPageSettings.PaperSize = custom
        'curPage = 1
        PrintDocument1.Print()
    End Sub

    Private Sub dgvreciept_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvreciept.CellContentClick

    End Sub

    Private Sub dgvreciept_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvreciept.CellClick
        Dim i As Integer

        'DataGridView1.Rows.Clear()
        i = dgvreciept.CurrentRow.Index

        lot = dgvreciept.Item(1, i).Value
        sn = dgvreciept.Item(2, i).Value
        exdate = dgvreciept.Item(3, i).Value

    End Sub
End Class