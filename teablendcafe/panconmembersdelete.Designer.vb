<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class panconmembersdelete
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(panconmembersdelete))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.admispasswordcancel = New System.Windows.Forms.Button()
        Me.dgvlog = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.adminlogs = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvlog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.adminlogs)
        Me.Panel1.Controls.Add(Me.dgvlog)
        Me.Panel1.Controls.Add(Me.admispasswordcancel)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(329, 295)
        Me.Panel1.TabIndex = 0
        '
        'admispasswordcancel
        '
        Me.admispasswordcancel.BackColor = System.Drawing.Color.White
        Me.admispasswordcancel.Location = New System.Drawing.Point(0, 269)
        Me.admispasswordcancel.Name = "admispasswordcancel"
        Me.admispasswordcancel.Size = New System.Drawing.Size(326, 23)
        Me.admispasswordcancel.TabIndex = 6
        Me.admispasswordcancel.Text = "Close"
        Me.admispasswordcancel.UseVisualStyleBackColor = False
        '
        'dgvlog
        '
        Me.dgvlog.AllowUserToAddRows = False
        Me.dgvlog.AllowUserToDeleteRows = False
        Me.dgvlog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvlog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.dgvlog.Location = New System.Drawing.Point(0, 26)
        Me.dgvlog.Name = "dgvlog"
        Me.dgvlog.ReadOnly = True
        Me.dgvlog.Size = New System.Drawing.Size(329, 243)
        Me.dgvlog.TabIndex = 7
        '
        'Column1
        '
        Me.Column1.HeaderText = "TIME"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 145
        '
        'Column2
        '
        Me.Column2.HeaderText = "Description"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 145
        '
        'adminlogs
        '
        Me.adminlogs.AutoSize = True
        Me.adminlogs.Location = New System.Drawing.Point(135, 10)
        Me.adminlogs.Name = "adminlogs"
        Me.adminlogs.Size = New System.Drawing.Size(39, 13)
        Me.adminlogs.TabIndex = 8
        Me.adminlogs.Text = "Label1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(59, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Admin logs of"
        '
        'panconmembersdelete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(6, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(352, 319)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "panconmembersdelete"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "panconmembersdelete"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvlog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents admispasswordcancel As Button
    Friend WithEvents dgvlog As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents adminlogs As Label
End Class
