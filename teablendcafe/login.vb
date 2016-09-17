Imports MySql.Data.MySqlClient
Public Class login

    Dim Command As New MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Connect As New MySqlConnection
    Dim str As String


    Public Sub ConnectDB()
        If Connect.State = ConnectionState.Closed Then
            str = "server=localhost; userid=root; password=; database=dbtbc; Allow Zero Datetime=True;"
            Connect.ConnectionString = str
            Connect.Open()

        End If
    End Sub


    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ConnectDB()
        TransparencyKey = BackColor
        Me.AcceptButton = btnlogin
        Me.CancelButton = btnexit
    End Sub

    Private Sub tDateTime_Tick(sender As Object, e As EventArgs) Handles tDateTime.Tick
        lTime.Text = DateTime.Now.ToLongTimeString
        lDate.Text = DateTime.Today.ToLongDateString
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        With Command
            .Connection = Connect
            .CommandText = "SELECT Username,Password FROM tblAdministrators WHERE Username = '" &
                tbusername.Text & "' AND Password = '" &
                tbpassword.Text & "'"
        End With

        Reader = Command.ExecuteReader
        Reader.Read()

        If Reader.HasRows Then
            MsgBox("Welcome" & Reader.Item(0).ToString & "" & Reader.Item(1).ToString, vbInformation + vbOKOnly, "Message")
            Reader.Close()
            frmMain.Show()
            Me.Close()
        Else
            Reader.Close()
            MsgBox("The user id and/or Password are incorrect.", vbInformation + vbOKOnly, "Message")
        End If
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Dim reply As MsgBoxResult

        reply = MsgBox("Do you really want to exit?", MsgBoxStyle.YesNo, "Exit")
        If reply = MsgBoxResult.Yes Then
            Environment.Exit(0)
        End If
    End Sub
End Class