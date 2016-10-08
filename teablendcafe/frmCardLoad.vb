
Imports System.IO
Imports System.Net
Imports System.Net.WebClient
Imports MySql.Data.MySqlClient

Public Class frmCardLoad

    Dim Connect As New MySqlConnection
    Dim TransactionReader As MySqlDataReader

    Public transaction As Integer

    Private Sub frmCardLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()

        ' update label
        Select Case transaction
            Case frmchoicespointsorload.TRANSACT_LOAD
                lblTransacting.Text = "Transacting: Load in card will be used."
            Case frmchoicespointsorload.TRANSACT_POINTS
                lblTransacting.Text = "Transacting: Points in card will be used."
        End Select

        ' reset db
        resetTransaction()
        ' tmp comment
        'tmrCheck.Enabled = True

        Dim cusNo As String = "tbc123"
        updateDatabase(cusNo) ' remove if finished debugging
    End Sub

    Private Sub updateDatabase(customerNumber As String)
        ' check if member still have remaining money
        Dim reader As MySqlDataReader
        Dim cmd As New MySqlCommand
        cmd.Connection = Connect

        ' get total and set a points
        Dim total As Double = frmMain.txtTotalOrder.Text
        Dim pointsComputed As Integer
        If total >= 200 Then
            pointsComputed = total / 200
        End If

        ' get customer wallet and points
        Dim wallet As Double
        Dim points As Integer
        cmd.CommandText = "SELECT cus_loadwallet, cus_points FROM tblcustomers WHERE cus_no='" & customerNumber & "'"
        reader = cmd.ExecuteReader()

        reader.Read()
        If reader.HasRows Then
            wallet = reader.Item(0)
            points = reader.Item(1)
        End If

        ' check load
        If wallet < total Then
            MsgBox("Not enough balance in account" & vbNewLine & "Remaining account load is: " & wallet)
            reader.Close()
            Exit Sub
        End If
        reader.Close()

        ' don't update if points is selected

        ' update points
        points = points + pointsComputed

        ' update load
        Dim walletTotal As Double = wallet - total

        With cmd
            .CommandText = "UPDATE tblcustomers SET cus_loadwallet = " & walletTotal & ", cus_points = " & points & " WHERE cus_no='" & customerNumber & "'"
            .ExecuteNonQuery()
        End With

        ' update products and inventories
        Dim curDate As String = Date.Today.ToString("yyyy-MM-dd")

        ' generate random
        Randomize()
        Dim rand As Integer = CInt(Int((99999 * Rnd()))) + 1
        Dim dateConcat As String = (DateTime.Now()).ToString("ddMMyyhhmmss")
        Dim ord_code As String = dateConcat & "-" & rand

        ' get data

        ' insert id and date
        cmd.CommandText = "INSERT INTO tblorders(ord_code, total, ord_date) VALUES('" & ord_code & "', " & total & ", '" & curDate & "')"
        cmd.ExecuteNonQuery()

        For i As Integer = 0 To frmMain.dgvorders.RowCount - 1
            Dim prodCode As String = frmMain.dgvorders.Item(0, i).Value
            Dim prodName As String = frmMain.dgvorders.Item(1, i).Value
            Dim qty As Integer = frmMain.dgvorders.Item(2, i).Value
            Dim price As Integer = frmMain.dgvorders.Item(3, i).Value

            ' insert all product codes with qty
            cmd.CommandText = "INSERT INTO tblorder_prod VALUES('" & ord_code & "', '" & prodCode & "', '" & prodName & "', " & qty & ", " & price & ")"
            cmd.ExecuteNonQuery()

            ' decrement a qty in tblinventory
            With cmd
                .Connection = Connect
                .CommandText = "SELECT inv_qty FROM tblinventory WHERE inv_prod_code='" & prodCode & "'"
            End With


            Dim qtyFromDB As Integer
            reader = cmd.ExecuteReader()

            reader.Read()
            If reader.HasRows Then
                qtyFromDB = reader.Item(0)
            End If
            reader.Close()

            Dim qtyVal As Integer = qtyFromDB - qty
            cmd.CommandText = "UPDATE tblinventory SET inv_qty=" & qtyVal & " WHERE inv_prod_code='" & prodCode & "'"
            cmd.ExecuteNonQuery()

        Next

        ' update wallet value
        cmd.CommandText = "SELECT cus_loadwallet FROM tblcustomers WHERE cus_no='" & customerNumber & "'"
        reader = cmd.ExecuteReader()

        reader.Read()
        If reader.HasRows Then
            wallet = reader.Item(0)
        End If
        reader.Close()

        frmremainingload.tbtotal.Text = total
        frmremainingload.tbchange.Text = wallet
        frmremainingload.tbpointsadded.Text = pointsComputed
        frmremainingload.tbpoints.Text = points
        frmremainingload.ShowDialog()
        Me.Close()
    End Sub

    Private Sub resetTransaction()
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
        resetTransaction()
        Me.Close()
    End Sub

    Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick

        ' checks if isTransaction is open
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
            updateDatabase(customerNumber)
            Me.Close()
        End If

        TransactionReader.Close()
    End Sub


End Class