Public Class SplashScreen1
    Private Sub SplashScreen1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        ProgressBar1.ForeColor = Color.Red
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim hilang As Double
        hilang = Me.Opacity = 100%

        If ProgressBar1.Value < 11 Then
            ProgressBar1.Value += 1
            Label9.Text = "Menyiapkan Database..."
            If ProgressBar1.Value < 8 Then
                ProgressBar1.Value += 2
                Label9.Text = "Menyiapkan Konfigurasi Aplikasi..."
            End If
            If ProgressBar1.Value < 6 Then
                ProgressBar1.Value += 2
                Label9.Text = " Menyiapkan Data User..."
            End If
            Me.SuspendLayout()

            ElseIf ProgressBar1.Value = 11 Then
                Timer1.Stop()
            masuk.Show()
            Me.Hide()
        End If
    End Sub
End Class
