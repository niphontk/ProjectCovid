<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSendTest
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSendTest))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(935, 524)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(470, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 22)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "รหัสผ่าน"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(522, 24)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.TextBox3.Size = New System.Drawing.Size(118, 29)
        Me.TextBox3.TabIndex = 9
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(302, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 22)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "ถึงเวลา"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(165, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 22)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "เวลา"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(354, 23)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(93, 29)
        Me.TextBox2.TabIndex = 6
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(203, 23)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(93, 29)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(339, 482)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(117, 31)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Excel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(11, 67)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(912, 409)
        Me.DataGridView1.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(646, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 31)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "ค้นหา"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(11, 22)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(148, 29)
        Me.DateTimePicker1.TabIndex = 0
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'frmSendTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(959, 563)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmSendTest"
        Me.Text = "รายงานส่งตรวจ PCR"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox3 As TextBox
End Class
