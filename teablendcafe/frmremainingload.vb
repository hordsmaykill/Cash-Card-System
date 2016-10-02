Public Class frmremainingload

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmMain.dgvorders.Rows.Clear()
        Me.Close()
    End Sub
End Class