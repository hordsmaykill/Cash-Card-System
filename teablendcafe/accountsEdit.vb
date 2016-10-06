Imports MySql.Data.MySqlClient
Public Class accountsEdit
    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String

    Private Sub accountsEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()

        frmMain.AccountsDGV()
        lUsername.Text = "Enter new password for " & frmMain.userSelected
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    'Private Sub AccountsDGV()
    '    frmMain.accounts_dgv.Rows.Clear()

    '    With Command
    '        .Connection = Connect
    '        .CommandText = "SELECT * FROM tbladministrators"
    '    End With
    '    Reader = Command.ExecuteReader

    '    If Reader.HasRows Then

    '        While Reader.Read
    '            frmMain.accounts_dgv.Rows.Add(Reader.Item(0), Reader.Item(1))
    '        End While
    '    End If
    '    Reader.Close()

    'End Sub
    'submit'
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If tboxPassword.Text = "" Or tboxRPassword.Text = "" Then
            MsgBox("Please make sure all password boxes are filled.", vbOKOnly + vbInformation, "Message")
        ElseIf tboxPassword.Text = tboxRPassword.Text Then
            With Command
                .Connection = Connect
                .CommandText = "UPDATE tbladministrators SET password = '" &
                    frmMain.userSelected & "' WHERE username = '" &
                    tboxPassword.Text & "'"
                .ExecuteNonQuery()
            End With
            frmMain.AccountsDGV()
            MsgBox("Password successfully changed!", vbOKOnly + vbInformation, "Message")
            Me.Close()
        Else
            MsgBox("Please make sure the entered passwords are the same!", vbOKOnly + vbInformation, "Message")
            tboxPassword.Text = ""
            tboxRPassword.Text = ""
        End If
    End Sub




End Class