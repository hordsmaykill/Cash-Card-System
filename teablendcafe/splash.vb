Public Class splash
    Dim X As Boolean

    Private Sub splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TransparencyKey = BackColor
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        X = True
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If X = True Then
            Me.Opacity = Me.Opacity - 0.1
            If Me.Opacity <= 0 Then
                login.Show()
                Me.Close()
            End If
        End If
    End Sub
End Class
