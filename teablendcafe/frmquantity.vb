﻿Imports MySql.Data.MySqlClient

Public Class frmquantity

    Dim conn As New MySqlConnection

    Public prodCode As String
    Public qty As Integer

    Private Sub frmquantity_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If conn.State = ConnectionState.Closed Then
            conn.ConnectionString = "server=localhost; userid=root; password=; database=dbtbc; Allow Zero Datetime=True;"
            conn.Open()
        End If


        qty = 1
        txtNum.Text = qty


    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs)
        ' check if the input qty is valid
        Dim cmd As New MySqlCommand
        Dim reader As MySqlDataReader

        Dim qtyFromDB As Integer


        With cmd
            .Connection = conn
            .CommandText = "SELECT inv_qty FROM tblinventory WHERE inv_prod_code='" & prodCode & "'"
        End With
        reader = cmd.ExecuteReader()

        reader.Read()
        If reader.HasRows Then
            qtyFromDB = reader.Item(0)
        End If

        Dim diff As Integer = qtyFromDB - qty
        If diff < 0 Then
            MsgBox("There are only " & qtyFromDB & " remaining")
            frmMain.qtyRetrieved = -1
            reader.Close()
            Exit Sub
        End If

        reader.Close()
        frmMain.qtyRetrieved = qty


        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        frmMain.qtyRetrieved = -1
        Me.Close()
    End Sub

    Private Sub btnMin_Click(sender As Object, e As EventArgs)
        If qty <> 1 Then
            qty -= 1
        End If
        txtNum.Text = qty
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        qty += 1
        txtNum.Text = qty
    End Sub

    Private Sub txtNum_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode >= 65 And e.KeyCode <= 90 Then
            MsgBox("Please enter a number.")
            txtNum.Text = 1
        End If

    End Sub

    Private Sub txtNum_TextChanged(sender As Object, e As EventArgs)
        Integer.TryParse(txtNum.Text, qty)
        txtNum.Text = qty
    End Sub


End Class