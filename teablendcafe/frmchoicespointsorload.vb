Imports MySql.Data.MySqlClient
Public Class frmchoicespointsorload
    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String

    Private Sub frmchoicespointsorload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()
    End Sub
    Private Sub btnmopucl_Click(sender As Object, e As EventArgs) Handles btnmopucl.Click
        frmCardLoad.ShowDialog()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub btnmopucp_Click(sender As Object, e As EventArgs) Handles btnmopucp.Click
        frmtransactingpoints.ShowDialog()
        Me.Close()
    End Sub
End Class