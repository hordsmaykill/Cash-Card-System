Imports MySql.Data.MySqlClient
Public Class cash_card

    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String

    Private Sub cash_card_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ConnectDB()
    End Sub

    Public Sub ConnectDB()
        If Connect.State = ConnectionState.Closed Then
            str = "server=localhost; userid=root; password=; database=dbtbc; Allow Zero Datetime=True;"
            Connect.ConnectionString = str
            Connect.Open()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmCardLoad.ShowDialog()
    End Sub
End Class