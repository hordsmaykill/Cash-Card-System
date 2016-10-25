Imports MySql.Data.MySqlClient
Public Class frmInventoryEdit

    Dim SelectedMember As String
    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String
    Dim SelectedInventory As String


    Private Sub frminvedit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect = ConnectionModule.getConnection()

        'Dim SelecteddQty As Integer = frmMain.inventorydgv.Item(2, frmMain.inventorydgv.CurrentRow.Index).Value

        'upnaddquantity.Value = SelecteddQty

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        SelectedInventory = frmMain.inventorydgv.Item(0, frmMain.inventorydgv.CurrentRow.Index).Value
        ''
        Dim beforemodified As Integer
        Dim addload As Integer
        Dim total As Integer


        With Command
            .Connection = Connect
            .CommandText = "SELECT inv_qty FROM tblinventory WHERE inv_prod_code = '" & SelectedInventory & "'"
        End With
        Reader = Command.ExecuteReader
        Reader.Read()

        If Reader.HasRows Then
            beforemodified = Reader.Item(0)
        End If
        Reader.Close()
        addload = upnaddquantity.Value

        ''
        With Command
            .Connection = Connect
            .CommandText = "INSERT INTO tblinventory_trans( inv_prod_invbefmov,inv_prod_add,ord_code_trans) VALUES('" & beforemodified & "', '" & addload & "','" & SelectedInventory & "')"
            .ExecuteNonQuery()
        End With

        Reader.Close()

        total = beforemodified + addload
        ''insert'

        With Command
            .Connection = Connect
            .CommandText = " UPDATE tblinventory SET inv_qty = " & total & " WHERE inv_prod_code = '" & SelectedInventory & "'"
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