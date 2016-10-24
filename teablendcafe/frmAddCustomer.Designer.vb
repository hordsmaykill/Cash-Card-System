<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddCustomer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddCustomer))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbnewcusname = New System.Windows.Forms.TextBox()
        Me.btnmembers_addcustomer_submit = New System.Windows.Forms.Button()
        Me.btnmembers_addcustomer_cancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(220, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter Customer name"
        '
        'tbnewcusname
        '
        Me.tbnewcusname.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnewcusname.Location = New System.Drawing.Point(27, 75)
        Me.tbnewcusname.Name = "tbnewcusname"
        Me.tbnewcusname.Size = New System.Drawing.Size(215, 31)
        Me.tbnewcusname.TabIndex = 1
        '
        'btnmembers_addcustomer_submit
        '
        Me.btnmembers_addcustomer_submit.Location = New System.Drawing.Point(27, 112)
        Me.btnmembers_addcustomer_submit.Name = "btnmembers_addcustomer_submit"
        Me.btnmembers_addcustomer_submit.Size = New System.Drawing.Size(107, 48)
        Me.btnmembers_addcustomer_submit.TabIndex = 0
        Me.btnmembers_addcustomer_submit.Text = "Submit"
        Me.btnmembers_addcustomer_submit.UseVisualStyleBackColor = True
        '
        'btnmembers_addcustomer_cancel
        '
        Me.btnmembers_addcustomer_cancel.Location = New System.Drawing.Point(135, 112)
        Me.btnmembers_addcustomer_cancel.Name = "btnmembers_addcustomer_cancel"
        Me.btnmembers_addcustomer_cancel.Size = New System.Drawing.Size(107, 48)
        Me.btnmembers_addcustomer_cancel.TabIndex = 2
        Me.btnmembers_addcustomer_cancel.Text = "Cancel"
        Me.btnmembers_addcustomer_cancel.UseVisualStyleBackColor = True
        '
        'addcustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.teablendcafe.My.Resources.Resources.frm_edit_accounts1
        Me.ClientSize = New System.Drawing.Size(269, 183)
        Me.Controls.Add(Me.btnmembers_addcustomer_cancel)
        Me.Controls.Add(Me.btnmembers_addcustomer_submit)
        Me.Controls.Add(Me.tbnewcusname)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "addcustomer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "addcustomer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tbnewcusname As TextBox
    Friend WithEvents btnmembers_addcustomer_submit As Button
    Friend WithEvents btnmembers_addcustomer_cancel As Button
End Class
