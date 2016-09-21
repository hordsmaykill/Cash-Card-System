
Imports System.IO
Imports System.Net
Imports System.Net.WebClient
Imports MySql.Data.MySqlClient

Public Class frmCardLoad

    Dim customerId As String = ""

    Private Sub frmCardLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub ConnectDB()
        Dim Command As New MySqlCommand
        Dim Reader As MySqlDataReader
        Dim Connect As New MySqlConnection
        Dim str As String

        If Connect.State = ConnectionState.Closed Then
            str = "server=localhost; userid=root; password=; database=dbtbc; Allow Zero Datetime=True;"
            Connect.ConnectionString = str
            Connect.Open()

        End If

    End Sub


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Close()
    End Sub
End Class