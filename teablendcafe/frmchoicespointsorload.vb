Imports MySql.Data.MySqlClient
Public Class frmchoicespointsorload
    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String

    Public Const TRANSACT_LOAD As Integer = 0
    Public Const TRANSACT_POINTS As Integer = 1

    Private Sub frmchoicespointsorload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()
    End Sub
    Private Sub btnmopucl_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        frmCardLoad.transaction = TRANSACT_LOAD
        frmCardLoad.ShowDialog()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnmopucp_Click(sender As Object, e As EventArgs) Handles btnPoints.Click
        frmCardLoad.transaction = TRANSACT_POINTS
        frmCardLoad.ShowDialog()
        Me.Close()
    End Sub
End Class