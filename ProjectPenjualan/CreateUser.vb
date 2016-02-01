Imports System.Data.SqlServerCe
Public Class CreateUser
#Region "Deklarasi variable"

    Dim conn As SqlCeConnection
    Dim dr As SqlCeDataReader
    Dim da As SqlCeDataAdapter
    Dim ds As DataSet
    Dim cmd As SqlCeCommand
    Dim cmd2 As SqlCeCommand
    Dim kon As String
    Dim sql As String
    Dim x, i As Integer
    Dim z, r As String
    Dim tbc As String
    Dim tab2 As Integer
    Dim isidb As String
    Dim cb As ComboBox
    Dim sortirlv As Integer
    Dim nm As String
    Dim dbguna As String
    Dim keluar As Integer

#End Region

    Sub hapus()
        TextBox1.Clear()
        BoxAddUser.Clear()
        BoxPassword.Clear()
        ComboBoxOtoritasUser.SelectedIndex = -1
        PictureBoxAddUser.BackgroundImageLayout = PictureBoxAddUser.Visible = False
    End Sub

#Region "Koneksi Database"

    Sub konek()
        kon = "Data Source=|DataDirectory|\Database\xxx.sdf;Persist Security Info=False;" & _
    "Max Database Size = 256"
        conn = New SqlCeConnection(kon)
        If conn.State = ConnectionState.Closed Then conn.Open()
        conn.ChangeDatabase("|DataDirectory|\Database\" & dbguna & ".sdf")
    End Sub

    Sub konek2()
        kon = "Data Source=|DataDirectory|\Database\admin.sdf;Persist Security Info=False"
        conn = New SqlCeConnection(kon)
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub

#End Region

    Private Sub BtnPilihPoto_Click(sender As Object, e As EventArgs) Handles BtnPilihPoto.Click
        Me.OpenFileDialog1.Reset()
        Me.OpenFileDialog1.Title = "Silahkan pilih foto"
        Me.OpenFileDialog1.InitialDirectory = "c:\Me" ' My.Settings.ImageDirectory 
        Me.OpenFileDialog1.Filter = "JPEG|*.jpg|PNG|*.png"
        Me.OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PictureBoxAddUser.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub
    Private Sub BtnBuatUser_Click(sender As Object, e As EventArgs) Handles BtnBuatUser.Click
        If BoxAddUser.Text = "" Then
            MsgBox("Masukan ID / NAMA !", MsgBoxStyle.Critical)
        ElseIf BoxPassword.Text = "" Then
            MsgBox("Masukan password", MsgBoxStyle.Critical)
        ElseIf ComboBoxOtoritasUser.Text = Nothing Then
            MsgBox("Masukan Otoritas !", MsgBoxStyle.Critical)
        Else
            konek2()
            sql = "select * from admin where id='" & MainMenu.TextBox1.Text & "' and pass='" & MainMenu.BoxIDTrans.Text & "'"
            cmd = New SqlCeCommand(sql, conn)
            cmd.ExecuteNonQuery()
            sql = "insert into admin (id, pass, status) values('" & BoxAddUser.Text & "', '" & BoxPassword.Text & "', '" & ComboBoxOtoritasUser.Items(ComboBoxOtoritasUser.SelectedIndex).ToString() & "')"
            cmd = New SqlCeCommand(sql, conn)
            cmd.ExecuteNonQuery()
            If Not PictureBoxAddUser.BackgroundImage Is Nothing Then
                Dim myImage As Image = PictureBoxAddUser.BackgroundImage
                Dim imgMemoryStream As IO.MemoryStream = New IO.MemoryStream()
                myImage.Save(imgMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim imgByteData As Byte() = imgMemoryStream.GetBuffer()
                sql = "Update admin Set gambar=@myPicture Where id='" & BoxAddUser.Text & "'"
                cmd = New SqlCeCommand(sql, conn)
                cmd.Parameters.Add("@myPicture", SqlDbType.Image).Value = imgByteData
                cmd.ExecuteNonQuery()
            End If
            conn.Close()
            MessageBox.Show("User terbuat", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            hapus()
            BoxAddUser.Focus()
            Label5.Visible = False
            MainMenu.loaduser()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = BoxPassword.Text Then
            Label5.Visible = True
            Label5.Text = "Password cocok"
            BtnBuatUser.Enabled = True
            BtnPilihPoto.Enabled = True
            ComboBoxOtoritasUser.Enabled = True
            Label5.ForeColor = Color.Green
        Else
            Label5.Visible = True
            Label5.Text = "Password tidak cocok"
            BtnBuatUser.Enabled = False
            BtnPilihPoto.Enabled = False
            ComboBoxOtoritasUser.Enabled = False
            Label5.ForeColor = Color.Red
        End If
    End Sub

    Private Sub BoxPassword_TextChanged(sender As Object, e As EventArgs) Handles BoxPassword.TextChanged
        If BoxPassword.TextLength >= 6 Then
            Label5.Visible = False
            TextBox1.Enabled = True
            ComboBoxOtoritasUser.Enabled = True
        Else
            Label5.Text = "Panjang password setidaknya harus 6-16 karakter"
            Label5.Visible = True
            Label5.ForeColor = Color.Red
            TextBox1.Enabled = False
            ComboBoxOtoritasUser.Enabled = False
        End If
    End Sub

    Private Sub BtnCancleUser_Click(sender As Object, e As EventArgs) Handles BtnCancleUser.Click
        Me.Close()
    End Sub
End Class