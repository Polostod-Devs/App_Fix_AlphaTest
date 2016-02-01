Imports System.Data.SqlServerCe
Public Class GantiPassword
    Dim conn As SqlCeConnection
    Dim dr As SqlCeDataReader
    Dim da As SqlCeDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCeCommand
    Dim cmd2 As SqlCeCommand
    Dim kon As String
    Dim sql As String

    Sub koneklogin()

        kon = "Data Source=|DataDirectory|\Database\admin.sdf;Persist Security Info=False"
        conn = New SqlCeConnection(kon)
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub
    Private Sub TextBox38_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            TextBox37.Focus()
        End If
    End Sub
    Private Sub TextBox37_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox37.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            TextBox36.Focus()
        End If
    End Sub
    Private Sub TextBox36_TextChanged(sender As Object, e As EventArgs) Handles TextBox36.TextChanged
        If Not TextBox36.Text = "" Then
            If TextBox36.Text = TextBox37.Text Then
                Label168.Show()
                Label168.Text = "Password Cocok"
                Label168.ForeColor = Color.Green
                Button38.Enabled = True
            Else
                Label168.Show()
                Label168.Text = "Password Tidak Cocok"
                Label168.ForeColor = Color.Red
                Button38.Enabled = False
            End If
        Else
            Label168.Hide()
            Button38.Enabled = False
        End If
    End Sub
    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        If TextBox36.Text = TextBox37.Text Then
            koneklogin()
            sql = "update admin set pass='" & TextBox36.Text & "' where id='" & MainMenu.ComboBox16.Items _
                (MainMenu.ComboBox16.SelectedIndex).ToString & "'"
            cmd = New SqlCeCommand(sql, conn)
            Dim xn As Integer = cmd.ExecuteNonQuery()
            If xn = 1 Then
                MessageBox.Show("Password Di Ganti")
            End If
        Else
            MessageBox.Show("Password Tidak Cocok")
        End If
    End Sub
    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        If TextBox36.UseSystemPasswordChar = True Then
            TextBox36.UseSystemPasswordChar = False
            TextBox37.UseSystemPasswordChar = False
        Else
            TextBox36.UseSystemPasswordChar = True
            TextBox37.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub GantiPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class