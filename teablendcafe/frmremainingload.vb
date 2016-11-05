Public Class frmremainingload

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        frmMain.dgvorders.Rows.Clear()
        Me.Close()
    End Sub

    Private Sub cancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

End Class
