
Imports MySql.Data.MySqlClient
Public Class frmtotal

    Public Const CASH As Integer = 0
    Public Const ADD_CASH As Integer = 1
    Public action As Integer

    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String

    Dim tendered As Double
    Dim totalamount As Double
    Dim change As Double

    Public total As Double

    Private Sub frmtotal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()

        Select Case action
            Case CASH
                paymenttendered.Text = frmEnterAmount.tbenterpayment.Text
                tendered = Double.Parse(paymenttendered.Text)

                tbtotal.Text = frmMain.txtTotalOrder.Text
                totalamount = Double.Parse(tbtotal.Text)

                change = tendered - totalamount
                tbchangee.Text = change

            Case ADD_CASH
                Dim enteredAmt As Double = Double.Parse(frmEnterAmount.tbenterpayment.Text)
                enteredAmt += frmCardLoad.load
                paymenttendered.Text = enteredAmt
                tendered = Double.Parse(paymenttendered.Text)


        End Select

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim reader As MySqlDataReader
        Dim cmd As New MySqlCommand
        cmd.Connection = Connect

        total = frmMain.txtTotalOrder.Text

        ' update products and inventories
        Dim curDate As String = Date.Today.ToString("yyyy-MM-dd")

        ' generate random
        Randomize()
        Dim rand As Integer = CInt(Int((99999 * Rnd()))) + 1
        Dim dateConcat As String = (DateTime.Now()).ToString("ddMMyyhhmmss")
        Dim ord_code As String = dateConcat & "-" & rand


        ' get data


        ' insert id and date
        cmd.CommandText = "INSERT INTO tblorders VALUES('" & ord_code & "', " & total & ",'" & change & "','" & paymenttendered.Text & "','" & curDate & "')"
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
        MsgBox("Success!")
        frmMain.dgvorders.Rows.Clear()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class