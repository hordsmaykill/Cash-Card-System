Imports MySql.Data.MySqlClient
Public Class typeadminpassworddelete

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

    Private Sub typeadminpassworddelete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ConnectDB()
    End Sub
    Private Sub admindeleteorder_Click(sender As Object, e As EventArgs) Handles admindeleteorder.Click
        With Command
            .Connection = Connect
            .CommandText = "SELECT password FROM tbladministrators WHERE username = 'admin'"
            .ExecuteNonQuery()
        End With
        'del'
        Dim reply As String


        reply = MsgBox("Do you really want to Delete this current order(s)?", MsgBoxStyle.YesNoCancel, "Clear")
        If reply = MsgBoxResult.Yes Then
            frmMain.dgvorders.Rows.RemoveAt(frmMain.dgvorders.CurrentRow.Index)
            Me.Close()
        End If
    End Sub



    Private Sub cancelc_Click(sender As Object, e As EventArgs) Handles cancelc.Click
        Me.Close()
    End Sub


End Class