Imports MySql.Data.MySqlClient
Public Class FrmaddLoad
    Dim SelectedMember As String
    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String

    Private Sub FrmaddLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SelectedMember = frmMain.dgv_members.Item(0, frmMain.dgv_members.CurrentRow.Index).Value


        With Command
            .Connection = Connect
            .CommandText = " UPDATE tblcustomers SET cus_loadwallet = " & nupdaddload.Value & " WHERE cus_no = '" & SelectedMember & "'"
            .ExecuteNonQuery()
        End With
        frmMain.membersDGV()
        MsgBox("Load " & SelectedMember & " successfully added!", vbOKOnly + vbInformation, "Message")
        Me.Close()

        frmMembersEditChoices.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class