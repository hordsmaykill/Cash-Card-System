<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmverifypassword
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbbadminpassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnverify = New System.Windows.Forms.Button()
        Me.cancelcc = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.Controls.Add(Me.tbbadminpassword)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnverify)
        Me.Panel1.Controls.Add(Me.cancelcc)
        Me.Panel1.Location = New System.Drawing.Point(12, 21)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(304, 75)
        Me.Panel1.TabIndex = 1
        '
        'tbbadminpassword
        '
        Me.tbbadminpassword.Location = New System.Drawing.Point(134, 12)
        Me.tbbadminpassword.Name = "tbbadminpassword"
        Me.tbbadminpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbbadminpassword.Size = New System.Drawing.Size(157, 20)
        Me.tbbadminpassword.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Administrator Password:"
        '
        'btnverify
        '
        Me.btnverify.Location = New System.Drawing.Point(28, 40)
        Me.btnverify.Name = "btnverify"
        Me.btnverify.Size = New System.Drawing.Size(112, 23)
        Me.btnverify.TabIndex = 0
        Me.btnverify.Text = "Verify"
        Me.btnverify.UseVisualStyleBackColor = True
        '
        'cancelcc
        '
        Me.cancelcc.Location = New System.Drawing.Point(158, 40)
        Me.cancelcc.Name = "cancelcc"
        Me.cancelcc.Size = New System.Drawing.Size(112, 23)
        Me.cancelcc.TabIndex = 2
        Me.cancelcc.Text = "Cancel"
        Me.cancelcc.UseVisualStyleBackColor = True
        '
        'frmverifypassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(327, 108)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmverifypassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmverifypassword"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents tbbadminpassword As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnverify As Button
    Friend WithEvents cancelcc As Button
End Class
