
Imports System.IO
Imports System.Net
Imports System.Net.WebClient
Imports MySql.Data.MySqlClient

Public Class frmCardLoad

    Dim Connect As New MySqlConnection
    Dim TransactionReader As MySqlDataReader

    Private Sub frmCardLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConnectDB()

        ' reset db
        closeTransaction()
        'tmrCheck.Enabled = True

        ' test code for adding
        Dim curDate As String = Date.Today.ToString("yyyy-MM-dd")

        ' generate random
        Randomize()
        Dim rand As Integer = CInt(Int((99999 * Rnd()))) + 1
        Dim dateConcat As String = (Date.Now()).ToString("ddMMyy")
        Dim ord_code As String = dateConcat & "-" & rand

        Dim total As Double = frmMain.txtTotalOrder.Text
        ' get data
        ' insert all product codes with qty
        Dim cmd As New MySqlCommand
        cmd.Connection = Connect


        ' insert id and date
        cmd.CommandText = "INSERT INTO tblorders VALUES('" & ord_code & "', " & total & ", '" & curDate & "')"
        cmd.ExecuteNonQuery()

        For i As Integer = 0 To frmMain.dgvorders.RowCount - 1
            Dim prodCode As String = frmMain.dgvorders.Item(0, i).Value
            Dim prodName As String = frmMain.dgvorders.Item(1, i).Value
            Dim qty As Integer = frmMain.dgvorders.Item(2, i).Value
            Dim price As Integer = frmMain.dgvorders.Item(3, i).Value
            cmd.CommandText = "INSERT INTO tblorder_prod VALUES('" & ord_code & "', '" & prodCode & "', '" & prodName & "', " & qty & ", " & price & ")"
            cmd.ExecuteNonQuery()
        Next



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

    Private Sub insertTest()

        Dim command As New MySqlCommand

        With command
            .Connection = Connect
            .CommandText = "INSERT INTO tblorders(ord_code, ord_date) VALUES (2, '2008-11-11')"
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
            .CommandText = "SELECT cus_no FROM tbltransaction WHERE id=1"
        End With
        TransactionReader = Command.ExecuteReader()
        TransactionReader.Read()

        Dim customerNumber As String = TransactionReader.Item(0)

        If customerNumber <> "0" Then
            tmrCheck.Enabled = False
            TransactionReader.Close()

            ' minus here


            Me.Close()
        End If

        TransactionReader.Close()
    End Sub


End Class