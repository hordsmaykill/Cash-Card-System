Imports MySql.Data.MySqlClient

Public Class frmquantity

    Dim conn As New MySqlConnection

    Public prodCode As String
    Public qty As Integer

    Private Sub frmquantity_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If conn.State = ConnectionState.Closed Then
            conn.ConnectionString = "server=localhost; userid=root; password=; database=dbtbc; Allow Zero Datetime=True;"
            conn.Open()
        End If

        txtNum.Text = ""
        qty = 0

    End Sub

    Private Sub numClicked(n As String)
        If txtNum.Text = "0" Then
            txtNum.Text = ""
        End If
        txtNum.Text &= n
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        ' check if the input qty is valid
        Dim cmd As New MySqlCommand
        Dim reader As MySqlDataReader

        Dim qtyFromDB As Integer

        If txtNum.Text = "0" Then
            MsgBox("Invalid quantity. quantity must be >= 1")
            Exit Sub
        End If


        With cmd
            .Connection = conn
            .CommandText = "SELECT inv_qty FROM tblinventory WHERE inv_prod_code='" & prodCode & "'"
        End With
        reader = cmd.ExecuteReader()

        reader.Read()
        If reader.HasRows Then
            qtyFromDB = reader.Item(0)
        End If

        ' update qty
        If txtNum.Text = "" Then
            qty = 1
        Else
            qty = Integer.Parse(txtNum.Text)
        End If


        Dim diff As Integer = qtyFromDB - qty
        If diff < 0 Then
            MsgBox("There are only " & qtyFromDB & " remaining")
            frmMain.qtyRetrieved = -1
            reader.Close()
            Exit Sub
        End If

        reader.Close()
        frmMain.qtyRetrieved = qty


        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        frmMain.qtyRetrieved = -1
        Me.Close()
    End Sub

    Private Sub btnMin_Click(sender As Object, e As EventArgs) Handles btnMin.Click
        If txtNum.Text = "" Then
            qty = 0
        Else
            qty = Integer.Parse(txtNum.Text)
        End If

        If qty <> 1 Then
            qty -= 1
        End If
        txtNum.Text = qty
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtNum.Text = "" Then
            qty = 0
        Else
            qty = Integer.Parse(txtNum.Text)
        End If

        qty += 1
        txtNum.Text = qty
    End Sub

    Private Sub txtNum_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode >= 65 And e.KeyCode <= 90 Then
            MsgBox("Please enter a number.")
            txtNum.Text = 1
        End If

    End Sub

    Private Sub txtNum_TextChanged(sender As Object, e As EventArgs)
        Integer.TryParse(txtNum.Text, qty)
        txtNum.Text = qty
    End Sub

    Private Sub num0_Click(sender As Object, e As EventArgs) Handles num0.Click
        numClicked("0")
    End Sub

    Private Sub num1_Click(sender As Object, e As EventArgs) Handles num1.Click
        numClicked("1")
    End Sub

    Private Sub num2_Click(sender As Object, e As EventArgs) Handles num2.Click
        numClicked("2")
    End Sub

    Private Sub num3_Click(sender As Object, e As EventArgs) Handles num3.Click
        numClicked("3")
    End Sub

    Private Sub num4_Click(sender As Object, e As EventArgs) Handles num4.Click
        numClicked("4")
    End Sub

    Private Sub num5_Click(sender As Object, e As EventArgs) Handles num5.Click
        numClicked("5")
    End Sub

    Private Sub num6_Click(sender As Object, e As EventArgs) Handles num6.Click
        numClicked("6")
    End Sub

    Private Sub num7_Click(sender As Object, e As EventArgs) Handles num7.Click
        numClicked("7")
    End Sub

    Private Sub num8_Click(sender As Object, e As EventArgs) Handles num8.Click
        numClicked("8")
    End Sub

    Private Sub num9_Click(sender As Object, e As EventArgs) Handles num9.Click
        numClicked("9")
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtNum.Text = ""
        qty = 0
    End Sub
End Class