﻿Imports MySql.Data.MySqlClient
Public Class frmverifypassword
    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String

    Public state As String

    Public Sub ConnectDB()
        If Connect.State = ConnectionState.Closed Then
            str = "server=localhost; userid=root; password=; database=dbtbc; Allow Zero Datetime=True;"
            Connect.ConnectionString = str
            Connect.Open()
        End If
    End Sub


    Private Sub frmverifypassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ConnectDB()
    End Sub


    Private Sub cancelcc_Click(sender As Object, e As EventArgs) Handles cancelcc.Click
        Me.Close()
    End Sub

    Private Sub btnverify_Click(sender As Object, e As EventArgs) Handles btnverify.Click
        ' if tama ung password
        Dim check As String

        With Command
            .Connection = Connect
            .CommandText = "SELECT password FROM tbladministrators WHERE username = 'admin'"

        End With
        Reader = Command.ExecuteReader
        If Reader.HasRows Then
            Reader.Read()
            check = Reader.Item(0)
        End If
        If check = tbbadminpassword.Text Then

            Select Case state
                Case "add"
                    formadmincreatenew.ShowDialog()
                Case "addmember"
                    addcustomer.ShowDialog()
                Case "editmember"
                    frmmemberedit.ShowDialog()

            End Select
            ' end if
        End If
        Me.Close()
    End Sub
End Class