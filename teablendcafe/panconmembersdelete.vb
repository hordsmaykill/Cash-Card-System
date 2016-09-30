Imports MySql.Data.MySqlClient
Public Class panconmembersdelete

    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String
    Dim SelectedAdmin As String


    Public Sub ConnectDB()
        If Connect.State = ConnectionState.Closed Then
            str = "server=localhost; userid=root; password=; database=dbtbc; Allow Zero Datetime=True;"
            Connect.ConnectionString = str
            Connect.Open()


        End If
    End Sub
    Private Sub panconmembersdelete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ConnectDB()
        Call logdgvupdate()
    End Sub

    Public Sub logdgvupdate()
        SelectedAdmin = frmMain.accounts_dgv.Item(0, frmMain.accounts_dgv.CurrentRow.Index).Value
        adminlogs.Text = SelectedAdmin
        With Command
            .Connection = Connect
            .CommandText = "SELECT time,description FROM tbltimeintimeout Where user ='" & SelectedAdmin & "'"
     
        End With
        Reader = Command.ExecuteReader

        If Reader.HasRows Then
            While Reader.Read
                dgvlog.Rows.Add(Reader.Item(0), Reader.Item(1))
            End While
        End If
        Reader.Close()

    End Sub

    Private Sub admispasswordcancel_Click(sender As Object, e As EventArgs) Handles admispasswordcancel.Click
        Me.Close()
    End Sub
End Class