Public Class frmEnterAmoutn
    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        frmtotal.ShowDialog()
        Me.Close()
    End Sub
End Class