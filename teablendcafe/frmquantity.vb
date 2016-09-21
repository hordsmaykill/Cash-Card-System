Public Class frmquantity

    Dim qty As Integer

    Private Sub frmquantity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        qty = 1
        txtNum.Text = qty
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        frmMain.qtyRetrieved = qty
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        frmMain.qtyRetrieved = -1
        Me.Close()
    End Sub

    Private Sub btnMin_Click(sender As Object, e As EventArgs) Handles btnMin.Click
        If qty <> 1 Then
            qty -= 1
        End If
        txtNum.Text = qty
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        qty += 1
        txtNum.Text = qty
    End Sub

    Private Sub txtNum_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNum.KeyDown
        If e.KeyCode >= 65 And e.KeyCode <= 90 Then
            MsgBox("Please enter a number.")
            txtNum.Text = 1
        End If

    End Sub

    Private Sub txtNum_TextChanged(sender As Object, e As EventArgs) Handles txtNum.TextChanged
        Integer.TryParse(txtNum.Text, qty)
        txtNum.Text = qty
    End Sub
End Class