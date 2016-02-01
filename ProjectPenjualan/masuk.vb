Imports System.Data.SqlServerCe
Public Class masuk
    Dim conn As SqlCeConnection
    Dim dr As SqlCeDataReader
    Dim da As SqlCeDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCeCommand
    Dim cmd2 As SqlCeCommand
    Dim kon As String
    Dim sql As String


    Sub konek()

        kon = "Data Source=|DataDirectory|\Database\admin.sdf;Persist Security Info=False"
        conn = New SqlCeConnection(kon)
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub
#Region "Koneksi database admin"
    Public Sub simpan()
        konek()
        sql = "select * from admin where id='" & TextBox1.Text & "' and pass='" & TextBox2.Text & "'"
        cmd = New SqlCeCommand(sql, conn)
        dr = cmd.ExecuteReader
        If dr.Read Then
            Me.Hide()
            MainMenu.ToolStripStatusLabel1.Text = dr("id")
            MainMenu.ToolStripStatusLabel2.Text = "-" + DateString
            MainMenu.ToolStripStatusLabel8.Text = dr("status")
            If MainMenu.ToolStripStatusLabel8.Text = "USER" Then
                MainMenu.GroupBoxBuatData.Hide()
                '     MainMenu.GroupBoxHapus.Hide()
                MainMenu.Label5.Text = "Panel User"
            Else
                MainMenu.GroupBoxBuatData.Show()
                '    MainMenu.GroupBoxHapus.Show()
            End If
            'Fix otoritas admin dan user
            MainMenu.Show()
        Else
            MessageBox.Show("Password atau Username yang anda masukan salah", "Peringatan", MessageBoxButtons.OK)
            TextBox1.Focus()
            TextBox1.SelectAll()
        End If
    End Sub
    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        simpan()
    End Sub

    Private Sub masuk_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Public Sub login_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) _
    Handles Me.FormClosing
        Select Case MessageBox.Show("Apa Anda yakin ingin menutup aplikasi ini?", "Konfirmasi", _
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Case Windows.Forms.DialogResult.Yes
            Case Windows.Forms.DialogResult.No
                e.Cancel = True
                Me.Show()
        End Select
    End Sub
#End Region
    Private Sub TextBox1_keyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox2.Focus()
            TextBox2.SelectAll()
        End If
    End Sub

    Private Sub TextBox2_Keydown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            simpan()
        End If
    End Sub

    Private Sub masuk_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class