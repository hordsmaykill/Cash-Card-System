Public Class frmEnterAmount
    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        ' validate if input value is >= total
        Dim totalamount As Double = Double.Parse(frmMain.txtTotalOrder.Text)
        Dim input As Double = Double.Parse(tbenterpayment.Text)

        If input >= totalamount Then
            frmtotal.ShowDialog()
            Me.Close()
        Else
            MsgBox("The amount is less than the total amount: " & vbNewLine & "Php " & totalamount)
        End If
    End Sub

    Private Sub frmEnterAmount_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class