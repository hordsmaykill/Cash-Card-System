Public Class frmremainingpoints
    Private Sub cancel_Click(sender As Object, e As EventArgs) Handles cancel.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmMain.dgvorders.Rows.Clear()
        Me.Close()
    End Sub
End Class