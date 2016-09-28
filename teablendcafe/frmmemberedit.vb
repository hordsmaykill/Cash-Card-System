Imports MySql.Data.MySqlClient
Public Class frmmemberedit
    Dim SelectedMember As String
    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String


    Public Sub ConnectDB()

        Dim str As String
        If Connect.State = ConnectionState.Closed Then
            str = "server=localhost; userid=root; password=; database=dbtbc; Allow Zero Datetime=True;"
            Connect.ConnectionString = str
            Connect.Open()
        End If
    End Sub

    Private Sub frmmemberedit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ConnectDB()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SelectedMember = frmMain.dgv_members.Item(0, frmMain.dgv_members.CurrentRow.Index).Value


        With Command
            .Connection = Connect
            .CommandText = " UPDATE tblcustomers SET cus_name = '" & tbcusnewname.Text & "' WHERE cus_no = '" & SelectedMember & "'"
            .ExecuteNonQuery()
        End With
        frmMain.membersDGV()
        MsgBox("Member " & SelectedMember & "has successfully been updated!", vbOKOnly + vbInformation, "Message")
        Me.Close()

        frmmemers_editchoices.Hide()

    End Sub


End Class