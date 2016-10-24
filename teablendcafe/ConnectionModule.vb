Imports MySql.Data.MySqlClient

Module ConnectionModule

    Function getConnection() As MySqlConnection
        Dim conn As New MySqlConnection

        If conn.State = ConnectionState.Closed Then
            conn.ConnectionString = "server=localhost; userid=root; password=; database=dbtbc; Allow Zero Datetime=True;"
            conn.Open()
        End If

        Return conn
    End Function

End Module
