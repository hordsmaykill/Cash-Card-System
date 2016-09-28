<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cashcard
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btncash = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.btncash)
        Me.Panel1.Location = New System.Drawing.Point(12, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(329, 117)
        Me.Panel1.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(166, 11)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(149, 96)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "CARD"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btncash
        '
        Me.btncash.Location = New System.Drawing.Point(14, 11)
        Me.btncash.Name = "btncash"
        Me.btncash.Size = New System.Drawing.Size(146, 96)
        Me.btncash.TabIndex = 2
        Me.btncash.Text = "CASH"
        Me.btncash.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Tan
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button3.ForeColor = System.Drawing.Color.DarkRed
        Me.Button3.Location = New System.Drawing.Point(269, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 25)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "x"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'cashcard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(353, 168)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "cashcard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "cash_card"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents btncash As Button
    Friend WithEvents Button3 As Button
End Class
