Imports MySql.Data.MySqlClient
Public Class typeadminpassword
    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String

    Private Sub typeadminpassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()
    End Sub

    Private Sub admispasswordcancel_Click(sender As Object, e As EventArgs) Handles admispasswordcancel.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim reader As MySqlDataReader
        With Command
            .Connection = Connect
            .CommandText = "SELECT password FROM tbladministrators WHERE username = 'admin'"
        End With
        reader = Command.ExecuteReader

        If reader.HasRows Then
            reader.Read()
            If txtPass.Text = reader.Item(0) Then
                reader.Close()
                editaccounts.ShowDialog()
            End If
        End If
        reader.Close()
        Me.Close()
    End Sub
End Class