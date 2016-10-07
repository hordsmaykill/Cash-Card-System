<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmremainingpoints
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
        Me.cancel = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblchange = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbchange = New System.Windows.Forms.TextBox()
        Me.tbtotal = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.cancel)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.lblchange)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.tbchange)
        Me.Panel1.Controls.Add(Me.tbtotal)
        Me.Panel1.Location = New System.Drawing.Point(12, 21)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(288, 216)
        Me.Panel1.TabIndex = 2
        '
        'cancel
        '
        Me.cancel.Location = New System.Drawing.Point(158, 159)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(75, 41)
        Me.cancel.TabIndex = 2
        Me.cancel.Text = "CANCEL"
        Me.cancel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(54, 159)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 41)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "PROCEED"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblchange
        '
        Me.lblchange.AutoSize = True
        Me.lblchange.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblchange.Location = New System.Drawing.Point(76, 96)
        Me.lblchange.Name = "lblchange"
        Me.lblchange.Size = New System.Drawing.Size(137, 20)
        Me.lblchange.TabIndex = 1
        Me.lblchange.Text = "Remaining Points "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(105, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Total Bill"
        '
        'tbchange
        '
        Me.tbchange.Enabled = False
        Me.tbchange.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbchange.Location = New System.Drawing.Point(54, 120)
        Me.tbchange.Name = "tbchange"
        Me.tbchange.Size = New System.Drawing.Size(179, 26)
        Me.tbchange.TabIndex = 0
        '
        'tbtotal
        '
        Me.tbtotal.Enabled = False
        Me.tbtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbtotal.Location = New System.Drawing.Point(54, 56)
        Me.tbtotal.Name = "tbtotal"
        Me.tbtotal.Size = New System.Drawing.Size(179, 26)
        Me.tbtotal.TabIndex = 0
        '
        'frmremainingpoints
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(313, 250)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmremainingpoints"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmremainingpoints"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents cancel As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents lblchange As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tbchange As TextBox
    Friend WithEvents tbtotal As TextBox
End Class
