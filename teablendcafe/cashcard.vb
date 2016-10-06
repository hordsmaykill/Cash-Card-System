Imports MySql.Data.MySqlClient
Public Class cashcard

    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String

    Private Sub cashcardLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmCardLoad.ShowDialog()
        Me.Close()
    End Sub

    Private Sub btncash_Click(sender As Object, e As EventArgs) Handles btncash.Click
        frmetramount.ShowDialog()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class