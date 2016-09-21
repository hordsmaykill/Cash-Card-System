
Imports System.IO
Imports System.Net
Imports System.Net.WebClient
Imports MySql.Data.MySqlClient

Public Class frmCardLoad

    Public customerId As String = "tbc123"

    Dim Connect As New MySqlConnection
    Dim Reader As MySqlDataReader

    Private Sub frmCardLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConnectDB()
    End Sub

    Public Sub ConnectDB()

        Dim str As String
        If Connect.State = ConnectionState.Closed Then
            str = "server=localhost; userid=root; password=; database=dbtbc; Allow Zero Datetime=True;"
            Connect.ConnectionString = str
            Connect.Open()
        End If

    End Sub

    Private Sub closeTransaction()
        Reader.Close()
        tmrCheck.Enabled = False

        Dim Command As New MySqlCommand

        With Command
            .Connection = Connect
            .CommandText = "UPDATE tblcustomers SET isTransacting='false' WHERE cus_no='" & customerId & "'"
            .ExecuteNonQuery()
        End With
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        closeTransaction()
        Me.Close()
    End Sub

    Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick
        ' checks if isTransaction is true

        Dim Command As New MySqlCommand

            With Command
                .Connection = Connect
                .CommandText = "SELECT isTransacting FROM tblcustomers WHERE cus_no='" & customerId & "'"
            End With
            Reader = Command.ExecuteReader()
            Reader.Read()

        If Reader.Item(0) = "true" Then
            tmrCheck.Enabled = False
            Reader.Close()
            MsgBox("NAPALITAN NA!!! BALIK KNA SA MAIN BES.")
            Me.Close()
        End If



        Reader.Close()
    End Sub
End Class