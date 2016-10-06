Imports MySql.Data.MySqlClient
Public Class frmPanConMembersDelete

    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String

    Private Sub panconmembersdelete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With Command
            .Connection = Connect
            .CommandText = "SELECT password FROM tbladministrators WHERE username = 'admin'"
            .ExecuteNonQuery()
        End With
        Me.Close()


    End Sub

    Private Sub admispasswordcancel_Click(sender As Object, e As EventArgs) Handles admispasswordcancel.Click
        Me.Close()
    End Sub
End Class