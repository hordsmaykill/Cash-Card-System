<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class typeadminpassworddelete
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
        Me.admindeleteorder = New System.Windows.Forms.Button()
        Me.cancelc = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.Controls.Add(Me.admindeleteorder)
        Me.Panel1.Controls.Add(Me.cancelc)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(300, 75)
        Me.Panel1.TabIndex = 0
        '
        'admindeleteorder
        '
        Me.admindeleteorder.Location = New System.Drawing.Point(29, 38)
        Me.admindeleteorder.Name = "admindeleteorder"
        Me.admindeleteorder.Size = New System.Drawing.Size(112, 23)
        Me.admindeleteorder.TabIndex = 5
        Me.admindeleteorder.Text = "Verify"
        Me.admindeleteorder.UseVisualStyleBackColor = True
        '
        'cancelc
        '
        Me.cancelc.Location = New System.Drawing.Point(159, 38)
        Me.cancelc.Name = "cancelc"
        Me.cancelc.Size = New System.Drawing.Size(112, 23)
        Me.cancelc.TabIndex = 6
        Me.cancelc.Text = "Cancel"
        Me.cancelc.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(145, 26)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox1.Size = New System.Drawing.Size(157, 20)
        Me.TextBox1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(20, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Administrator Password:"
        '
        'typeadminpassworddelete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(323, 98)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "typeadminpassworddelete"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "typeadminpassworddelete"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents cancelc As Button
    Friend WithEvents admindeleteorder As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
End Class
