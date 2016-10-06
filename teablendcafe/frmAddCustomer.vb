Imports MySql.Data.MySqlClient
Public Class frmAddCustomer
    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String

    Private Sub addcustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()
    End Sub

    Private Sub btnmembers_addcustomer_cancel_Click(sender As Object, e As EventArgs) Handles btnmembers_addcustomer_cancel.Click
        Me.Close()

    End Sub

    Private Sub btnmembers_addcustomer_submit_Click(sender As Object, e As EventArgs) Handles btnmembers_addcustomer_submit.Click
        If tbnewcusname.Text = "" Then
            MsgBox("Please make sure the box ais filled.", vbOKOnly + vbInformation, "Message")
        Else

            With Command
                .Connection = Connect
                .CommandText = "INSERT INTO tblcustomers(cus_no, cus_name, cus_loadwallet) VALUES('tbc1', '" & tbnewcusname.Text & "', 0)"
                .ExecuteNonQuery()
            End With
            MsgBox("Administrator " + tbnewcusname.Text + " successfully created!", vbOKOnly + vbInformation, "Message")
            frmMain.membersDGV()
            Me.Close()
        End If
    End Sub


End Class