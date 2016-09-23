Public Class frmmemers_editchoices
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmmemberedit.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmaddLoad.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Dispose()
    End Sub
End Class