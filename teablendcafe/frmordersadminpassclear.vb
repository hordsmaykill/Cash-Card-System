Imports MySql.Data.MySqlClient
Public Class frmordersadminpassclear

    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String

    Private Sub frmordersadminpassclear_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()
    End Sub


    Private Sub adminclearorder_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        Dim reader As MySqlDataReader

        With Command
            .Connection = Connect
            .CommandText = "SELECT password FROM tbladministrators WHERE username = 'admin'"
        End With
        reader = Command.ExecuteReader

        If reader.HasRows Then
            reader.Read()
            frmMain.dgvorders.Rows.Clear()
            Me.Close()
        End If

    End Sub

    Private Sub cancelcc_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class