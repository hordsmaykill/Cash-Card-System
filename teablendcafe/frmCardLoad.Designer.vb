<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCardLoad
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCardLoad))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tmrCheck = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTransacting = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(97, 141)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(97, 40)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Cancel"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tmrCheck
        '
        Me.tmrCheck.Enabled = True
        Me.tmrCheck.Interval = 500
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblTransacting)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Location = New System.Drawing.Point(12, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(296, 201)
        Me.Panel1.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.teablendcafe.My.Resources.Resources._default
        Me.PictureBox1.Location = New System.Drawing.Point(97, 49)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(93, 77)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'lblTransacting
        '
        Me.lblTransacting.Location = New System.Drawing.Point(3, 15)
        Me.lblTransacting.Name = "lblTransacting"
        Me.lblTransacting.Size = New System.Drawing.Size(293, 16)
        Me.lblTransacting.TabIndex = 4
        Me.lblTransacting.Text = "Transacting"
        Me.lblTransacting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCardLoad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(319, 249)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCardLoad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmCardLoad"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnClose As Button
    Friend WithEvents tmrCheck As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblTransacting As Label
End Class
