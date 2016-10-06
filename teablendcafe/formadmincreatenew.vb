Imports MySql.Data.MySqlClient
Public Class formadmincreatenew
    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String

    Private Sub formadmincreatenew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()
        frmMain.AccountsDGV()
    End Sub


    'Private Sub UpdateDGV()
    '    frmMain.accounts_dgv.Rows.Clear()

    '    With Command
    '        .Connection = Connect
    '        .CommandText = "SELECT * FROM tbladministrators"
    '    End With
    '    Reader = Command.ExecuteReader

    '    If Reader.HasRows Then
    '        While Reader.Read
    '            frmMain.accounts_dgv.Rows.Add(Reader.Item(0), Reader.Item(1))
    '        End While
    '    End If
    '    Reader.Close()
    'End Sub
    Private Sub btncreate_newuser_Click(sender As Object, e As EventArgs) Handles btncreate_newuser.Click
        If tbnewuser.Text = "" Or tbnewpassword.Text = "" Then
            MsgBox("Please make sure all boxes are filled.", vbOKOnly + vbInformation, "Message")
        Else

            With Command
                .Connection = Connect
                .CommandText = "INSERT INTO tbladministrators VALUES('" &
                    tbnewuser.Text & "', '" &
                    tbnewpassword.Text & "', '" &
                     cbadminpreviledges.Text & "')"
                .ExecuteNonQuery()
            End With
            MsgBox("Administrator " + cbadminpreviledges.Text + " successfully created!", vbOKOnly + vbInformation, "Message")
            frmMain.AccountsDGV()
            Me.Close()
        End If
    End Sub

    Private Sub btncancel_newbtn_Click(sender As Object, e As EventArgs) Handles btncancel_newbtn.Click
        Me.Close()
    End Sub


End Class