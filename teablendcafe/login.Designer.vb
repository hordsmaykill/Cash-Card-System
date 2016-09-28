<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        Me.tbusername = New System.Windows.Forms.TextBox()
        Me.tbpassword = New System.Windows.Forms.TextBox()
        Me.lDate = New System.Windows.Forms.Label()
        Me.lTime = New System.Windows.Forms.Label()
        Me.tDateTime = New System.Windows.Forms.Timer(Me.components)
        Me.btnlogin = New System.Windows.Forms.Button()
        Me.btnexit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tbusername
        '
        Me.tbusername.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbusername.Location = New System.Drawing.Point(198, 269)
        Me.tbusername.Name = "tbusername"
        Me.tbusername.Size = New System.Drawing.Size(252, 29)
        Me.tbusername.TabIndex = 0
        '
        'tbpassword
        '
        Me.tbpassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbpassword.Location = New System.Drawing.Point(198, 304)
        Me.tbpassword.Name = "tbpassword"
        Me.tbpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbpassword.Size = New System.Drawing.Size(252, 29)
        Me.tbpassword.TabIndex = 1
        '
        'lDate
        '
        Me.lDate.AutoSize = True
        Me.lDate.BackColor = System.Drawing.Color.White
        Me.lDate.ForeColor = System.Drawing.Color.Black
        Me.lDate.Location = New System.Drawing.Point(46, 97)
        Me.lDate.Name = "lDate"
        Me.lDate.Size = New System.Drawing.Size(28, 13)
        Me.lDate.TabIndex = 7
        Me.lDate.Text = "date"
        '
        'lTime
        '
        Me.lTime.AutoSize = True
        Me.lTime.BackColor = System.Drawing.Color.White
        Me.lTime.ForeColor = System.Drawing.Color.Black
        Me.lTime.Location = New System.Drawing.Point(548, 97)
        Me.lTime.Name = "lTime"
        Me.lTime.Size = New System.Drawing.Size(26, 13)
        Me.lTime.TabIndex = 8
        Me.lTime.Text = "time"
        '
        'tDateTime
        '
        Me.tDateTime.Enabled = True
        '
        'btnlogin
        '
        Me.btnlogin.Location = New System.Drawing.Point(198, 355)
        Me.btnlogin.Name = "btnlogin"
        Me.btnlogin.Size = New System.Drawing.Size(114, 39)
        Me.btnlogin.TabIndex = 9
        Me.btnlogin.Text = "LOGIN"
        Me.btnlogin.UseVisualStyleBackColor = True
        '
        'btnexit
        '
        Me.btnexit.Location = New System.Drawing.Point(336, 355)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(114, 39)
        Me.btnexit.TabIndex = 10
        Me.btnexit.Text = "EXIT"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.BackgroundImage = Global.teablendcafe.My.Resources.Resources.login2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(656, 523)
        Me.Controls.Add(Me.btnexit)
        Me.Controls.Add(Me.btnlogin)
        Me.Controls.Add(Me.lTime)
        Me.Controls.Add(Me.lDate)
        Me.Controls.Add(Me.tbpassword)
        Me.Controls.Add(Me.tbusername)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbusername As TextBox
    Friend WithEvents tbpassword As TextBox
    Friend WithEvents lDate As Label
    Friend WithEvents lTime As Label
    Friend WithEvents tDateTime As Timer
    Friend WithEvents btnlogin As Button
    Friend WithEvents btnexit As Button
End Class
