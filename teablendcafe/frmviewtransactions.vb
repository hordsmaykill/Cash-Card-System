Imports MySql.Data.MySqlClient
Public Class frmviewtransactions

    Dim Connect As New MySqlConnection

    Private Sub frmviewtransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()

        updateDGV()
    End Sub

    Private Sub updateDGV()

        Dim cmd As New MySqlCommand
        Dim reader As MySqlDataReader
        With cmd
            .Connection = Connect
            .CommandText = "SELECT * FROM tblorders"
        End With
        reader = cmd.ExecuteReader()
        dgvordrtransactions.Rows.Clear()
        If reader.HasRows Then
            While reader.Read()
                dgvordrtransactions.Rows.Add(reader.Item(0), reader.Item(1), reader.Item(2), reader.Item(3), reader.Item(4))
            End While
        End If

        reader.Close()
    End Sub
End Class