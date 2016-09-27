Imports MySql.Data.MySqlClient
Public Class editaccounts
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
    Private Sub editaccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ConnectDB()
        Call frmMain.AccountsDGV()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim SelectedAccount As String = frmMain.accounts_dgv.Item(0, frmMain.accounts_dgv.CurrentRow.Index).Value

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
        Me.Dispose()
    End Sub
End Class