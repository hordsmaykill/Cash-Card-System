Imports MySql.Data.MySqlClient
Public Class frmCashCard

    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String

    Private Sub cashcardLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCard.Click
        frmchoicespointsorload.ShowDialog()
        Me.Close()
    End Sub

    Private Sub btncash_Click(sender As Object, e As EventArgs) Handles btnCash.Click
        frmtotal.action = frmtotal.CASH
        frmEnterAmount.ShowDialog()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class