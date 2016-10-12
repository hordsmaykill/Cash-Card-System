<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminCreateNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdminCreateNew))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btncreate_newuser = New System.Windows.Forms.Button()
        Me.btncancel_newbtn = New System.Windows.Forms.Button()
        Me.tbnewuser = New System.Windows.Forms.TextBox()
        Me.tbnewpassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbadminpreviledges = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "username:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "password:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(111, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "New User"
        '
        'btncreate_newuser
        '
        Me.btncreate_newuser.Location = New System.Drawing.Point(30, 148)
        Me.btncreate_newuser.Name = "btncreate_newuser"
        Me.btncreate_newuser.Size = New System.Drawing.Size(90, 23)
        Me.btncreate_newuser.TabIndex = 3
        Me.btncreate_newuser.Text = "Create"
        Me.btncreate_newuser.UseVisualStyleBackColor = True
        '
        'btncancel_newbtn
        '
        Me.btncancel_newbtn.Location = New System.Drawing.Point(145, 148)
        Me.btncancel_newbtn.Name = "btncancel_newbtn"
        Me.btncancel_newbtn.Size = New System.Drawing.Size(98, 23)
        Me.btncancel_newbtn.TabIndex = 4
        Me.btncancel_newbtn.Text = "Cancel"
        Me.btncancel_newbtn.UseVisualStyleBackColor = True
        '
        'tbnewuser
        '
        Me.tbnewuser.Location = New System.Drawing.Point(114, 86)
        Me.tbnewuser.Name = "tbnewuser"
        Me.tbnewuser.Size = New System.Drawing.Size(121, 20)
        Me.tbnewuser.TabIndex = 1
        '
        'tbnewpassword
        '
        Me.tbnewpassword.Location = New System.Drawing.Point(114, 115)
        Me.tbnewpassword.Name = "tbnewpassword"
        Me.tbnewpassword.Size = New System.Drawing.Size(121, 20)
        Me.tbnewpassword.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Admin Priviledges:"
        '
        'cbadminpreviledges
        '
        Me.cbadminpreviledges.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbadminpreviledges.FormattingEnabled = True
        Me.cbadminpreviledges.Items.AddRange(New Object() {"cashier ", "manager"})
        Me.cbadminpreviledges.Location = New System.Drawing.Point(141, 59)
        Me.cbadminpreviledges.Name = "cbadminpreviledges"
        Me.cbadminpreviledges.Size = New System.Drawing.Size(94, 21)
        Me.cbadminpreviledges.TabIndex = 0
        '
        'frmAdminCreateNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.teablendcafe.My.Resources.Resources.frm
        Me.ClientSize = New System.Drawing.Size(274, 186)
        Me.Controls.Add(Me.cbadminpreviledges)
        Me.Controls.Add(Me.tbnewpassword)
        Me.Controls.Add(Me.tbnewuser)
        Me.Controls.Add(Me.btncancel_newbtn)
        Me.Controls.Add(Me.btncreate_newuser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAdminCreateNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "formadmincreatenew"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btncreate_newuser As Button
    Friend WithEvents btncancel_newbtn As Button
    Friend WithEvents tbnewuser As TextBox
    Friend WithEvents tbnewpassword As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cbadminpreviledges As ComboBox
End Class
