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
        ''
        Dim beforemodified As Integer
        Dim addload As Integer
        Dim total As Integer


        With Command
            .Connection = Connect
            .CommandText = "SELECT cus_loadwallet FROM tblcustomers WHERE cus_no = '" & SelectedMember & "'"
        End With
        Reader = Command.ExecuteReader
        Reader.Read()

        If Reader.HasRows Then
            beforemodified = Reader.Item(0)
        End If
        Reader.Close()
        addload = nupdaddload.Value
        If addload < 149 Then
            MsgBox("150 load wallet is the maintaining balance")
        ElseIf addload > 10000
            MsgBox("10000 load wallet is the max load that you can loadup")
        End If

        Exit Sub

            With Command
            .Connection = Connect
            .CommandText = "INSERT INTO tblloadtransactions(inv_prod_loadbefmof, inv_prod_newaddload,cus_no) VALUES('" & beforemodified & "', '" & addload & "','" & SelectedMember & "')"
            .ExecuteNonQuery()
        End With

        Reader.Close()

        total = beforemodified + addload

        ''
        With Command
            .Connection = Connect
            .CommandText = " UPDATE tblcustomers SET cus_loadwallet = " & total & " WHERE cus_no = '" & SelectedMember & "'"
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