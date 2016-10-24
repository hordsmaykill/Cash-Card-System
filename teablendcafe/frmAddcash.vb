Imports System.IO
Imports System.Net
Imports System.Net.WebClient
Imports MySql.Data.MySqlClient
Public Class frmAddcash
    Dim Connect As New MySqlConnection
    Dim TransactionReader As MySqlDataReader
    Dim total As Double = frmMain.txtTotalOrder.Text
    Dim pointsComputed As Integer


    Public transaction As Integer
    Private Sub frmAddcash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()
    End Sub

    Private Sub updateDatabase(customerNumber As String)
        Dim reader As MySqlDataReader
        Dim cmd As New MySqlCommand
        cmd.Connection = Connect


        Dim wallet As Double

        cmd.CommandText = "SELECT cus_loadwallet FROM tblcustomers WHERE cus_no='" & customerNumber & "'"
        reader = cmd.ExecuteReader()

        reader.Read()
        If reader.HasRows Then
            wallet = reader.Item(0)
        End If
        reader.Close()


    End Sub
End Class