Imports MySql.Data.MySqlClient
Public Class deletemem

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
    Private Sub deletemem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ConnectDB()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With Command
            .Connection = Connect
            .CommandText = "SELECT password FROM tbladministrators WHERE username = 'admin'"
            .ExecuteNonQuery()
        End With
        'del'
        Dim reply As String


        reply = MsgBox("Do you really want to Delete this current order(s)?", MsgBoxStyle.YesNoCancel, "Clear")
        If reply = MsgBoxResult.Yes Then
            frmMain.dgv_members.Rows.RemoveAt(frmMain.dgvorders.CurrentRow.Index)
            Me.Dispose()
        End If
    End Sub

    Private Sub admispasswordcancel_Click(sender As Object, e As EventArgs) Handles admispasswordcancel.Click
        Me.Dispose()
    End Sub
End Class