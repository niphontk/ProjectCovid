Public Class frmMain
    Private Sub พมพQRCODEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles พมพQRCODEToolStripMenuItem.Click
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next

        Dim f As New Form1
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub สแกนQRCODEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles สแกนQRCODEToolStripMenuItem.Click
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next

        Dim f As New frmScanQrcode
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub พมพQRCODEToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles พมพQRCODEToolStripMenuItem1.Click
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next

        Dim f As New frmGenQrCode
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub พมพใบสรปตดซองToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles พมพใบสรปตดซองToolStripMenuItem.Click
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next

        Dim f As New frmReportA4
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub พมพใยสรปรวมToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles พมพใยสรปรวมToolStripMenuItem.Click
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next

        Dim f As New frmStickerVial
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub ผพฒนาToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ผพฒนาToolStripMenuItem.Click
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next

        Dim f As New frmAbout
        f.MdiParent = Me
        f.WindowState = FormWindowState.Normal
        f.Show()
    End Sub

    Private Sub เพมวคซนMultiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles เพมวคซนMultiToolStripMenuItem.Click
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next

        Dim f As New frmMulti
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub รายงานสงตรวจToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub พมพใบรบรองแพทยToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles พมพใบรบรองแพทยToolStripMenuItem.Click
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next

        Dim f As New frmMedicalCer
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub รายงานสงตรวจATKToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub รายงานการตรวจPCRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานการตรวจPCRToolStripMenuItem.Click
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next

        Dim f As New frmReportPCR
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub รายงานการตรวจATKToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next

        Dim f As New frmReportATK
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub รายงานการตรวจFIAToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next

        Dim f As New frmReportFIA
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub รายงานการสงตรวจPCRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานการสงตรวจPCRToolStripMenuItem.Click
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next

        Dim f As New frmSendTest
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub รายงานการสงตรวจATKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานการสงตรวจATKToolStripMenuItem.Click
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next

        Dim f As New frmAtk
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub รายงานการขอAuthenCOdeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานการขอAuthenCOdeToolStripMenuItem.Click
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next

        Dim f As New frmReportAuthen
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub ขอAuthenCodeเทานนToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ขอAuthenCodeเทานนToolStripMenuItem.Click
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next

        Dim f As New frmAuthenCode
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub รายงานการสงตรวจATKFIAPCRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานการสงตรวจATKFIAPCRToolStripMenuItem.Click
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next

        Dim f As New frmReportATKFIAPCR
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub
    Dim version As String
    Sub GetVersion()
        Dim sqlSelect As DataTable = executesqlcommandhi("select version from check_version_covid")
        Try
            If sqlSelect.Rows.Count > 0 Then
                version = sqlSelect.Rows(0)(0)
            Else
                version = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GetVersion()

        If My.Application.Info.Version.ToString <> version Then
            Dim result As DialogResult = MessageBox.Show("โปรแกรมมีเวอร์ชั่นที่ใหม่กว่า กด Yes ถ้าต้องการอัปเดต", "แจ้งอัปเดต", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                'updateAuto()
                End
            Else

            End If
        End If
    End Sub
    Sub updateAuto()
        Dim appPath As String = My.Application.Info.DirectoryPath
        Dim info As New ProcessStartInfo()
        info.FileName = appPath + "\" + "updatecovid.exe"
        info.WorkingDirectory = appPath
        info.Arguments = "<specify the command line arguments here if necessary>"
        Process.Start(info)
    End Sub

    Private Sub รายงานการตรวจแยกTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานการตรวจแยกTestToolStripMenuItem.Click
        Dim frm As Form
        For Each frm In Me.MdiChildren
            frm.Close()
        Next

        Dim f As New frmReportByTest
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub
End Class