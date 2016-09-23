
Imports System.IO
Imports System.Net
Imports System.Net.WebClient
Imports MySql.Data.MySqlClient

Public Class frmCardLoad

    Public customerId As String = "tbc123"

    Dim Connect As New MySqlConnection
    Dim TransactionReader As MySqlDataReader

    Private Sub frmCardLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConnectDB()

        ' reset db
        closeTransaction()
        tmrCheck.Enabled = True
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
        tmrCheck.Enabled = False

        Dim Command As New MySqlCommand

        With Command
            .Connection = Connect
            .CommandText = "UPDATE tbltransaction SET cus_no='0' WHERE id=1"
            .ExecuteNonQuery()
        End With
    End Sub

    Function getName(cusNo As String) As String
        Dim name As String
        Dim command As New MySqlCommand
        Dim reader As MySqlDataReader

        With command
            .Connection = Connect
            .CommandText = "SELECT cus_name FROM tblcustomers WHERE cus_no='" & cusNo & "'"
        End With
        reader = command.ExecuteReader()
        reader.Read()
        name = reader.Item(0)

        Return name
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        closeTransaction()
        Me.Close()
    End Sub

    Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick
        ' checks if isTransaction is true

        Dim Command As New MySqlCommand

        With Command
            .Connection = Connect
            .CommandText = "SELECT cus_no FROM tbltransaction WHERE id=1"
        End With
        TransactionReader = Command.ExecuteReader()
        TransactionReader.Read()

        Dim customerNumber As String = TransactionReader.Item(0)

        If customerNumber <> "0" Then
            tmrCheck.Enabled = False
            TransactionReader.Close()
            MsgBox("NAPALITAN NA!!! MAG MINUS KNA BES.")

            ' minus here
            MsgBox("ANG MABABAWASAN AY SI " & getName(customerNumber))

            Me.Close()
        End If

        TransactionReader.Close()
    End Sub


End Class