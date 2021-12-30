<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuthenCode
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
        Me.Button5 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.age = New System.Windows.Forms.Label()
        Me.subInscl = New System.Windows.Forms.Label()
        Me.mainInscl = New System.Windows.Forms.Label()
        Me.sex = New System.Windows.Forms.Label()
        Me.lname = New System.Windows.Forms.Label()
        Me.fname = New System.Windows.Forms.Label()
        Me.pid = New System.Windows.Forms.Label()
        Me.PrintDocument3 = New System.Drawing.Printing.PrintDocument()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDocument4 = New System.Drawing.Printing.PrintDocument()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("JS Sadayu", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(24, 24)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(276, 128)
        Me.Button5.TabIndex = 7
        Me.Button5.Text = "อ่านบัตร"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.age)
        Me.GroupBox1.Controls.Add(Me.subInscl)
        Me.GroupBox1.Controls.Add(Me.mainInscl)
        Me.GroupBox1.Controls.Add(Me.sex)
        Me.GroupBox1.Controls.Add(Me.lname)
        Me.GroupBox1.Controls.Add(Me.fname)
        Me.GroupBox1.Controls.Add(Me.pid)
        Me.GroupBox1.Font = New System.Drawing.Font("JS Sadayu", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(306, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(915, 196)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ข้อมูลบุคคล"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("JS Sadayu", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(567, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 36)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "นามสกุล :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("JS Sadayu", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(307, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 36)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "อายุ :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("JS Sadayu", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(317, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 36)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "ชื่อ :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("JS Sadayu", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(54, 151)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 36)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "สิทธิเบิก :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("JS Sadayu", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(54, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 36)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "สิทธิหลัก :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("JS Sadayu", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(54, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 36)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "เพศ :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("JS Sadayu", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(54, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 36)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "PID :"
        '
        'age
        '
        Me.age.AutoSize = True
        Me.age.Font = New System.Drawing.Font("JS Sadayu", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.age.Location = New System.Drawing.Point(379, 68)
        Me.age.Name = "age"
        Me.age.Size = New System.Drawing.Size(49, 36)
        Me.age.TabIndex = 8
        Me.age.Text = "age"
        '
        'subInscl
        '
        Me.subInscl.AutoSize = True
        Me.subInscl.Font = New System.Drawing.Font("JS Sadayu", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.subInscl.Location = New System.Drawing.Point(156, 151)
        Me.subInscl.Name = "subInscl"
        Me.subInscl.Size = New System.Drawing.Size(91, 36)
        Me.subInscl.TabIndex = 7
        Me.subInscl.Text = "subInscl"
        '
        'mainInscl
        '
        Me.mainInscl.AutoSize = True
        Me.mainInscl.Font = New System.Drawing.Font("JS Sadayu", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.mainInscl.Location = New System.Drawing.Point(156, 108)
        Me.mainInscl.Name = "mainInscl"
        Me.mainInscl.Size = New System.Drawing.Size(102, 36)
        Me.mainInscl.TabIndex = 6
        Me.mainInscl.Text = "mainInscl"
        '
        'sex
        '
        Me.sex.AutoSize = True
        Me.sex.Font = New System.Drawing.Font("JS Sadayu", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.sex.Location = New System.Drawing.Point(116, 68)
        Me.sex.Name = "sex"
        Me.sex.Size = New System.Drawing.Size(46, 36)
        Me.sex.TabIndex = 5
        Me.sex.Text = "sex"
        '
        'lname
        '
        Me.lname.AutoSize = True
        Me.lname.Font = New System.Drawing.Font("JS Sadayu", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lname.Location = New System.Drawing.Point(665, 29)
        Me.lname.Name = "lname"
        Me.lname.Size = New System.Drawing.Size(70, 36)
        Me.lname.TabIndex = 4
        Me.lname.Text = "lname"
        '
        'fname
        '
        Me.fname.AutoSize = True
        Me.fname.Font = New System.Drawing.Font("JS Sadayu", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.fname.Location = New System.Drawing.Point(379, 29)
        Me.fname.Name = "fname"
        Me.fname.Size = New System.Drawing.Size(71, 36)
        Me.fname.TabIndex = 3
        Me.fname.Text = "fname"
        '
        'pid
        '
        Me.pid.AutoSize = True
        Me.pid.Font = New System.Drawing.Font("JS Sadayu", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.pid.Location = New System.Drawing.Point(116, 29)
        Me.pid.Name = "pid"
        Me.pid.Size = New System.Drawing.Size(44, 36)
        Me.pid.TabIndex = 2
        Me.pid.Text = "pid"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Font = New System.Drawing.Font("JS Sadayu", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Panel1.Location = New System.Drawing.Point(306, 223)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(915, 472)
        Me.Panel1.TabIndex = 9
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("JS Sadayu", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button3.Location = New System.Drawing.Point(705, 382)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(195, 74)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "ยกเลิก"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'frmAuthenCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 721)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button5)
        Me.Name = "frmAuthenCode"
        Me.Text = "frmAuthenCode"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button5 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents age As Label
    Friend WithEvents subInscl As Label
    Friend WithEvents mainInscl As Label
    Friend WithEvents sex As Label
    Friend WithEvents lname As Label
    Friend WithEvents fname As Label
    Friend WithEvents pid As Label
    Friend WithEvents PrintDocument3 As Printing.PrintDocument
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents PrintDocument2 As Printing.PrintDocument
    Friend WithEvents PrintDocument4 As Printing.PrintDocument
End Class
