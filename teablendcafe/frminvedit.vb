﻿Imports MySql.Data.MySqlClient
Public Class frminvedit

    Dim SelectedMember As String
    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String
    Dim SelectedInventory As String


    Private Sub frminvedit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ConnectDB()
        Dim SelecteddQty As Integer = frmMain.inventorydgv.Item(2, frmMain.inventorydgv.CurrentRow.Index).Value

        upnaddquantity.Value = SelecteddQty

    End Sub

    Public Sub ConnectDB()

        Dim str As String
        If Connect.State = ConnectionState.Closed Then
            str = "server=localhost; userid=root; password=; database=dbtbc; Allow Zero Datetime=True;"
            Connect.ConnectionString = str
            Connect.Open()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        SelectedInventory = frmMain.inventorydgv.Item(0, frmMain.inventorydgv.CurrentRow.Index).Value


        With Command
            .Connection = Connect
            .CommandText = " UPDATE tblinventory SET inv_qty = " & upnaddquantity.Value & " WHERE inv_prod_code = '" & SelectedInventory & "'"
            .ExecuteNonQuery()
        End With
        frmMain.DGVINV()
        MsgBox("Quantity " & SelectedInventory & " successfully added!", vbOKOnly + vbInformation, "Message")
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class