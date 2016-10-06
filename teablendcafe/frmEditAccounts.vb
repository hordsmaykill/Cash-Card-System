Imports MySql.Data.MySqlClient
Public Class frmEditAccounts
    Dim SelectedMember As String
    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String

    Private Sub editaccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()

        Call frmMain.AccountsDGV()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim SelectedAccount As String = frmMain.userSelected
        With Command
            .Connection = Connect
            .CommandText = "UPDATE tbladministrators SET username='" & tbusernameeditac.Text & "',password='" & tbusernameeditpass.Text & "',type='" & cbnewusertype.Text & "' WHERE username= '" & SelectedAccount & "'"
            .ExecuteNonQuery()
        End With
        frmMain.AccountsDGV()
        MsgBox("Account " & SelectedAccount & "has successfully been updated!", vbOKOnly + vbInformation, "Message")
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class