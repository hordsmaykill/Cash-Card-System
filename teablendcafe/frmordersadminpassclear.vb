Imports MySql.Data.MySqlClient
Public Class frmordersadminpassclear

    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String


    Public Sub ConnectDB()
        If Connect.State = ConnectionState.Closed Then
            str = "server=localhost; userid=root; password=; database=dbtbc; Allow Zero Datetime=True;"
            Connect.ConnectionString = str
            Connect.Open()
        End If
    End Sub

    Private Sub frmordersadminpassclear_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ConnectDB()
    End Sub


    Private Sub adminclearorder_Click(sender As Object, e As EventArgs) Handles adminclearorder.Click
        With Command
            .Connection = Connect
            .CommandText = "SELECT password FROM tbladministrators WHERE username = 'admin'"
            .ExecuteNonQuery()
        End With

        Dim reply As MsgBoxResult

        reply = MsgBox("Do you really want to Clear?", MsgBoxStyle.YesNoCancel, "Clear")
        If reply = MsgBoxResult.Yes Then
            frmMain.dgvorders.Rows.Clear()
            Me.Dispose()
        End If

    End Sub

    Private Sub cancelcc_Click(sender As Object, e As EventArgs) Handles cancelcc.Click
        Me.Dispose()
    End Sub
End Class