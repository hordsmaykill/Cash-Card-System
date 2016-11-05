Public Class frmMembersEditChoices


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        frmMemberEdit.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        FrmaddLoad.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


End Class