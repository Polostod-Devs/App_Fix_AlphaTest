Imports System.Data.SqlServerCe
Imports System.Object
Imports System.MarshalByRefObject
Imports System.ComponentModel.Component
Imports System.Windows.Forms.CommonDialog
Imports System.Windows.Forms.FileDialog
Imports System.Windows.Forms.OpenFileDialog
Public Class MainMenu

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
    Dim tab3 As Integer
    Dim dbguna As String
    Dim dd As String
    Dim bcuser As String
    Dim keluar As Integer
    Dim strtemp As String = ""
    Dim strvalue As String = ""

#End Region

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

#Region "Buat databases"
    Public Sub buatdatabase()
        If TextBox1.Text = "" Then
            MessageBox.Show("Harap ketik nama dulu sebelum tekan 'Buat Data'!", "Peringatan")
            TextBox1.Focus()
        Else
            konek2()
            sql = "select datadb from data where datadb='" & TextBox1.Text & "'"
            cmd = New SqlCeCommand(sql, conn)
            dr = cmd.ExecuteReader()
            If Not dr.Read() Then
                Dim connString As String = "Data Source=|DataDirectory|\Database\" _
                                           & TextBox1.Text & ".sdf;Persist Security " _
                                           & "Info=False; Max Database Size = 1024; " _
                                           & "Max Buffer Size = 1024"
                Dim engine As New SqlCeEngine(connString)
                engine.CreateDatabase()
                konek2()
                conn.ChangeDatabase("|DataDirectory|\Database\" & TextBox1.Text & ".sdf")
                sql = "CREATE TABLE [stockbrg] ([kodebrg] nvarchar(50) NOT NULL, [merk] " _
                   & "nvarchar(100) NOT NULL, " _
                   & "[jns_spt] nvarchar(50) NULL, [warna] nvarchar(50) NULL, " _
                   & "[size] nvarchar(50) NULL, [jml_stok] nvarchar(50) NULL, [hrg_modal] nvarchar(50) NULL, " _
                   & "[hrg_jual]nvarchar(50) NULL)"
                cmd = New SqlCeCommand(sql, conn)
                cmd.ExecuteNonQuery()
                sql = "ALTER TABLE [stokbrg] ADD CONSTRAINT [PK_stokbrg] PRIMARY KEY " _
                   & "([kodebrg])"
                sql = "CREATE TABLE [transaksi] ([idtrans] nvarchar(50) NOT NULL, [id_plg] nvarchar(50) NOT NULL,[nm_plg] nvarchar(100) NULL," _
                   & "[kodebrg] nvarchar(50) NULL, [nm_brg] nvarchar(50) NULL, " _
                   & "[hrg_brg] nvarchar(50) NULL, [jml] nvarchar(50) NULL, [total] nvarchar(50) NULL)"
                cmd = New SqlCeCommand(sql, conn)
                cmd.ExecuteNonQuery()
                sql = "ALTER TABLE [transaksi] ADD CONSTRAINT [PK_idtrans] PRIMARY KEY " _
                   & "([id_plg])"
                cmd = New SqlCeCommand(sql, conn)
                cmd.ExecuteNonQuery()
                konek2()
                sql = "insert into data (datadb) values ('" & TextBox1.Text & "')"
                cmd = New SqlCeCommand(sql, conn)
                Dim konfir As Integer = cmd.ExecuteNonQuery
                If konfir = 1 Then
                    MessageBox.Show("Data dengan nama '" & TextBox1.Text & "' berhasil dibuat", _
                                    "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                ToolStripStatusLabel9.Text = "Data terbuat!"
                ToolStripStatusLabel9.ForeColor = Color.Red
            Else
                MessageBox.Show("Gagal membuat data! Pastikan nama data yang anda buat belum " _
                                & "ada dan coba lagi", "Peringatan", MessageBoxButtons.OK, _
                                MessageBoxIcon.Exclamation)
                TextBox1.Focus()
                ToolStripStatusLabel9.Text = "Gagal buat Data!"
                ToolStripStatusLabel9.ForeColor = Color.Red
            End If
            TextBox1.Clear()
        End If
        conn.Close()
    End Sub
#End Region

#Region "DataGirdView Menu App & Fix Rupiah"
    Private Sub BoxHargaTrans_TextChanged(sender As Object, e As EventArgs)
        Dim f As Long
        If BoxHargaTrans.Text = "" Or Not IsNumeric(BoxHargaTrans.Text) Then
            Exit Sub
        End If
        f = BoxHargaTrans.Text
        BoxHargaTrans.Text = Format(f, "##,##0")
        BoxHargaTrans.SelectionStart = Len(BoxHargaTrans.Text)
    End Sub

    Private Sub BoxHasilTrans_TextChanged(sender As Object, e As EventArgs)
        Dim f As Long
        If BoxHasilTrans.Text = "" Or Not IsNumeric(BoxHasilTrans.Text) Then
            Exit Sub
        End If
        f = BoxHasilTrans.Text
        BoxHasilTrans.Text = Format(f, "##,##0")
        BoxHasilTrans.SelectionStart = Len(BoxHasilTrans.Text)
    End Sub
    Private Sub DataGridView1_CellMouseClick1(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        BoxBrgTrans.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        BoxNamaTrans.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
    End Sub
#End Region

#Region "Koding panggil / baca Database"
    Public Sub isicbdb()
        ComboBox1.Items.Clear()
        konek2()
        sql = "select datadb from data order by datadb desc"
        cmd = New SqlCeCommand(sql, conn)
        dr = cmd.ExecuteReader()
        Try
            While dr.Read = True
                ComboBox1.Items.Add(dr.Item("datadb"))
            End While
        Finally
            dr.Close()
            conn.Close()
        End Try
    End Sub

    Public Sub isicbdb2()
        ComboBox4.Items.Clear()
        konek2()
        sql = "select datadb from data order by datadb desc"
        cmd = New SqlCeCommand(sql, conn)
        dr = cmd.ExecuteReader()
        Try
            While dr.Read = True
                ComboBox4.Items.Add(dr.Item("datadb"))
            End While
        Finally
            dr.Close()
            conn.Close()
        End Try
    End Sub
    Public Sub loaddata()
        ComboBoxHpsData.Items.Clear()
        konek2()
        sql = "select datadb from data order by datadb desc"
        cmd = New SqlCeCommand(sql, conn)
        dr = cmd.ExecuteReader()
        Try
            While dr.Read = True
                ComboBoxHpsData.Items.Add(dr.Item("datadb"))
            End While
        Finally
            dr.Close()
            conn.Close()
        End Try
    End Sub
    Sub transaksi()
        konek()
        sql = "select * from transaksi order by idtrans desc"
        cmd = New SqlCeCommand(sql, conn)
        dr = cmd.ExecuteReader
        If dr.Read Then
            strtemp = Mid(dr.Item("idtrans"), 3, 5)
        Else
            BoxIDTrans.Text = "TR00001"
            Exit Sub
        End If
        strvalue = Val(strtemp) + 1
        BoxIDTrans.Text = "TR" & Mid("00000", 1, 5 - strvalue.Length) & strvalue
        'FixMe not load id by default :(
        konek()
        sql = "select * from transaksi order by idtrans desc"
        cmd = New SqlCeCommand(sql, conn)
        dr = cmd.ExecuteReader
        If dr.Read Then
            strtemp = Mid(dr.Item("id_plg"), 3, 5)
        Else
            BoxIDPelTrans.Text = "PG00001"
            Exit Sub
        End If
        strvalue = Val(strtemp) + 1
        BoxIDPelTrans.Text = "PG" & Mid("00000", 1, 5 - strvalue.Length) & strvalue
    End Sub

    Sub hapustrans()
        BoxNMPelTrans.Clear()
        BoxJumlahTrans.Clear()
        BoxBrgTrans.Clear()
        BoxNamaTrans.Clear()
        BoxHargaTrans.Clear()
        Label28.Text = Nothing
    End Sub

    Sub tampilgambar()
        konek2()
        sql = "select gambar from admin where id='" & ComboBox16.Items(ComboBox16.SelectedIndex).ToString & "'"
        cmd = New SqlCeCommand(sql, conn)
        dr = cmd.ExecuteReader()
        dr.Read()
        If Not dr.Item("gambar") Is DBNull.Value Then
            Dim imgByteData As Byte() = CType(dr.Item("gambar"), Byte())
            Dim imgMemoryStream As New IO.MemoryStream(imgByteData)
            Dim bitmap As Bitmap = New Bitmap(imgMemoryStream)
            PictureBox10.BackgroundImage = bitmap
            dr.Close()
            conn.Close()
        Else
            PictureBox10.BackgroundImage = My.Resources.user
        End If
        BtnGantiPoto.Enabled = True
        Button28.Enabled = True
        Button29.Enabled = True
    End Sub
    Sub loaduser()
        ComboBox16.Items.Clear()
        konek2()
        sql = "select id from admin order by id desc"
        cmd = New SqlCeCommand(sql, conn)
        dr = cmd.ExecuteReader()
        Try
            While dr.Read = True
                ComboBox16.Items.Add(dr.Item("id"))
            End While
        Finally
            dr.Close()
            conn.Close()
        End Try
    End Sub
    Public Sub hapus(Optional ByVal ctlcol As Control.ControlCollection = Nothing)
        If ctlcol Is Nothing Then ctlcol = Me.Controls
        For Each ctl As Control In ctlcol
            If TypeOf (ctl) Is TextBox Then
                DirectCast(ctl, TextBox).Clear()
            Else
                If Not ctl.Controls Is Nothing OrElse ctl.Controls.Count <> 0 Then
                    hapus(ctl.Controls)
                End If
            End If
        Next
        ComboBoxJnsSpt.SelectedIndex = -1
        ComboBoxSeri.SelectedIndex = -1
    End Sub
    Sub fixdb()
        konek()
        Dim x As Integer
        x = 0
        ListViewTampilBarang.Items.Clear()
        sql = "select * from stockbrg order by kodebrg"
        cmd = New SqlCeCommand(sql, conn)
        dr = cmd.ExecuteReader
        Try
            While dr.Read = True
                With ListViewTampilBarang
                    .Items.Add(dr.Item("kodebrg"))
                    .Items(x).SubItems.Add(dr.Item("merk"))
                    .Items(x).SubItems.Add(dr.Item("jns_spt"))
                    .Items(x).SubItems.Add(dr.Item("warna"))
                    .Items(x).SubItems.Add(dr.Item("size"))
                    .Items(x).SubItems.Add(dr.Item("jml_stok"))
                    '.Items(x).SubItems.Add(dr.Item("sisa_stok"))
                    .Items(x).SubItems.Add(dr.Item("hrg_modal"))
                    .Items(x).SubItems.Add(dr.Item("hrg_jual"))
                End With
                x = x + 1
            End While
        Finally
            dr.Close()
            conn.Close()
        End Try
    End Sub
    Sub loaddat()
        ComboBox2.Items.Clear()
        konek()
        sql = "select * from transaksi order by idtrans desc "
        cmd = New SqlCeCommand(sql, conn)
        dr = cmd.ExecuteReader()
        Try
            While dr.Read = True
                ComboBox2.Items.Add(dr.Item("idtrans"))
            End While
        Finally
            dr.Close()
            conn.Close()
        End Try
        ComboBox16.SelectedIndex = -1
    End Sub
#End Region

#Region "Input Data selection"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBoxBrg.Text = Nothing Then
            MessageBox.Show("Anda belum memasukan kode barang !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf BoxMerk.Text = Nothing Then
            MessageBox.Show("Anda belum memasukan Merk !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf ComboBoxJnsSpt.Text = Nothing Then
            MessageBox.Show("Anda belum memasukan jenis sepatu !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf BoxWarna.Text = Nothing Then
            MessageBox.Show("Anda belum memasukan warna !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf ComboBoxSeri.Text = Nothing Then
            MessageBox.Show("Anda belum memasukan ukuran sepatu !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf BoxJml.Text = Nothing Then
            MessageBox.Show("Anda belum memasukan jumlah !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf BoxHrgMdl.Text = Nothing Then
            MessageBox.Show("Anda belum memasukan harga modal !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf BoxHrgJual.Text = Nothing Then
            MessageBox.Show("Anda belum memasukan harga jual !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            konek()
            sql = " insert into stockbrg values('" & ComboBoxBrg.Items(ComboBoxJnsSpt.SelectedIndex).ToString & "','" & BoxMerk.Text & "','" & ComboBoxJnsSpt.Items(ComboBoxJnsSpt.SelectedIndex).ToString & "','" & BoxWarna.Text & "','" & ComboBoxSeri.Items(ComboBoxSeri.SelectedIndex).ToString & "','" & BoxJml.Text & "', '" & BoxHrgMdl.Text & "','" & BoxHrgJual.Text & "')"
            cmd = New SqlCeCommand(sql, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Tersimpan", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ToolStripStatusLabel9.Text = "Data tersimpan"
            fixdb()
            loaddat()
            ComboBoxBrg.Focus()
            ToolStripStatusLabel5.ForeColor = Color.Black
            conn.Close()
            hapus()
        End If
    End Sub
    Sub jamtanggal()
        Timer1.Start()
        ToolStripStatusLabel2.Text = DateString
        ToolStripStatusLabel3.Text = TimeOfDay
    End Sub

    Private Sub StokBrg_Click(sender As Object, e As EventArgs) Handles BtnStokBrg.Click
        TabPilihan.SelectedTab = StokMenu
    End Sub
    Private Sub TransaksiBtn_Click(sender As Object, e As EventArgs) Handles BtnTransaksi.Click
        TabPilihan.SelectedTab = TransaksiMenu
    End Sub

    Private Sub LaporanBtn_Click(sender As Object, e As EventArgs) Handles BtnLaporan.Click
        TabPilihan.SelectedTab = LaporanMenu
    End Sub
    Private Sub DataMenuBtn_Click_1(sender As Object, e As EventArgs) Handles DataMenuBtn.Click
        TabPilihan.SelectedTab = PilihDataMenu
    End Sub
    Private Sub MainMenu_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked

        Help.ShowHelp(sender, "help.chm")
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnInput.Click
        TabPilihan.SelectedTab = InputMenu
    End Sub

    Private Sub ButtonData_Click(sender As Object, e As EventArgs) Handles ButtonData.Click
        buatdatabase()
        isicbdb()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        CreateUser.Show()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        RecentUser.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        jamtanggal()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        MessageBox.Show("Untuk menampilkan data silahkan pilih data di bagian PENGATURAN ADMIN !", "BANTUAN", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub TabPilihan_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPilihan.SelectedIndexChanged
        TabPilihan.SelectedTab = TabPilihan.TabPages.Item(tab3)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Keterangan.Show()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        keluar = 1
        Me.Hide()
        Me.Close()
    End Sub
   
#End Region

#Region "MainMenu App"
    Private Sub MainMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If keluar = 1 Then
            konek2()
            Dim dd As String = Format(Now, "HH:mm dd MMMM yyyy")
            sql = "update akses set keluar='" & dd & "' where nama='" & masuk.TextBox1.Text & "' and masuk='" & ToolStripStatusLabel5.Text & "'"
            cmd = New SqlCeCommand(sql, conn)
            cmd.ExecuteNonQuery()
            masuk.TextBox1.Clear()
            masuk.TextBox2.Clear()
            masuk.TextBox1.Focus()
            masuk.Show()
        Else
            Me.Hide()
            konek2()
            Dim dd As String = Format(Now, "HH:mm dd MMMM yyyy")
            sql = "update akses set keluar='" & dd & "' where nama='" & masuk.TextBox1.Text & "' and masuk='" & ToolStripStatusLabel5.Text & "'"
            cmd = New SqlCeCommand(sql, conn)
            cmd.ExecuteNonQuery()
            masuk.TextBox1.Clear()
            masuk.TextBox2.Clear()
            masuk.TextBox1.Focus()
            masuk.Close()
            Application.Exit()
        End If
    End Sub

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tab3 = 5
        If tab3 < TabPilihan.TabPages.Count - 1 Then
            TabPilihan.SelectedTab = TabPilihan.TabPages.Item(tab3)
        End If
        TabPilihan.SelectedTab = Blank
        konek2()
        sql = "select gambar, status from admin where id='" & masuk.TextBox1.Text & "'"
        cmd = New SqlCeCommand(sql, conn)
        dr = cmd.ExecuteReader()
        dr.Read()
        Label25.Text = ToolStripStatusLabel1.Text
        If Not dr.Item("gambar") Is DBNull.Value Then
            Dim imgByteData As Byte() = CType(dr.Item("gambar"), Byte())
            Dim imgMemoryStream As New IO.MemoryStream(imgByteData, imgByteData.IsFixedSize)
            Dim bitmap As Bitmap = New Bitmap(imgMemoryStream)
            PictureBox7.BackgroundImage = bitmap
            PictureBox7.BackgroundImageLayout = ImageLayout.Stretch
        Else
            PictureBox7.BackgroundImage = My.Resources.user
        End If
        isicbdb()
        isicbdb2()
        jamtanggal()
        loaduser()
        loaddata()
        Dim dd As String = Format(Now, "HH:mm dd MMMM yyyy")
        ToolStripStatusLabel5.Text = dd
        konek2()
        sql = "insert into akses (nama, masuk) values ('" & masuk.TextBox1.Text & "'," _
            & "'" & dd & "')"
        cmd = New SqlCeCommand(sql, conn)
        cmd.ExecuteNonQuery()
        dr.Close()
        conn.Close()
    End Sub
#End Region

#Region "ComboBox Menu App"
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex >= 0 Then
            dbguna = ComboBox1.Items(ComboBox1.SelectedIndex).ToString
            z = ""
            hapus()
            DataMenuBtn.Enabled = True
            BtnInput.Enabled = True
            BtnStokBrg.Enabled = True
            BtnLaporan.Enabled = True
            BtnTransaksi.Enabled = True
            konek()
            DataSet1.Tables("Report").Clear()
            sql = "SELECT [kodebrg],[merk],[jns_spt],[warna],[size]" _
                & ",[jml_stok],[hrg_modal],[hrg_jual]" _
                & " from stockbrg"
            da = New SqlCeDataAdapter(sql, conn)
            Dim dRow As DataRow
            da.Fill(DataSet1, "Report")
            For Each dRow In DataSet1.Tables("Report").Rows
            Next
            Label7.Text = "" & dbguna & ""
            ToolStripStatusLabel9.Text = "Data yang  anda gunakan : " & dbguna & ""
            transaksi()
            loaddat()
            fixdb()
            loaduser()
            isicbdb2()

        End If
    End Sub
    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs)
        'FixMe
        If Not ComboBox4.SelectedIndex = 1 Then
            dbguna = ComboBox4.Items(ComboBox4.SelectedIndex).ToString
            z = ""
            konek()
            DataSet1.Tables("Report").Clear()
            sql = "SELECT [kodebrg],[merk],[jns_spt],[warna],[size]" _
                & ",[jml_stok],[hrg_modal],[hrg_jual]" _
                & " from stockbrg"
            da = New SqlCeDataAdapter(sql, conn)
            da.Fill(DataSet1, "Report")
            Report1.Preview = PreviewControl1
            Report1.Show()
            PreviewControl1.ZoomPageWidth()
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
        If Not ComboBox2.SelectedIndex = 1 Then
            dbguna = ComboBox1.Items(ComboBox1.SelectedIndex).ToString
            z = ""
            konek()
            DataSet1.Tables("DataTransaksi").Clear()
            sql = "SELECT [idtrans],[id_plg],[nm_plg],[kodebrg],[nm_brg]" _
                & ",[hrg_brg],[jml],[total]" _
                & " from transaksi where idtrans='" & ComboBox2.Items(ComboBox2.SelectedIndex).ToString & "'"
            da = New SqlCeDataAdapter(sql, conn)
            da.Fill(DataSet1, "DataTransaksi")
            Report2.Preview = PreviewControl1
            Report2.Show()
            PreviewControl1.Refresh()
            PreviewControl1.ZoomPageWidth()
        End If
    End Sub

#End Region

#Region "Button Menu App"
    Private Sub ComboBox16_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox16.SelectedIndexChanged
        tampilgambar()
    End Sub

    Private Sub BtnGantiPoto_Click(sender As Object, e As EventArgs) Handles BtnGantiPoto.Click
        Me.OpenFileDialog1.Reset()
        Me.OpenFileDialog1.Title = "Silahkan pilih foto"
        Me.OpenFileDialog1.InitialDirectory = "c:\Me" ' My.Settings.ImageDirectory 
        Me.OpenFileDialog1.Filter = "JPEG|*.jpg|PNG|*.png"
        Me.OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            konek2()
            Dim myImage As Image = Image.FromFile(OpenFileDialog1.FileName)
            Dim imgMemoryStream As IO.MemoryStream = New IO.MemoryStream()
            myImage.Save(imgMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim imgByteData As Byte() = imgMemoryStream.GetBuffer()
            sql = "Update admin Set gambar=@myPicture Where id='" & ComboBox16.Items(ComboBox16.SelectedIndex).ToString & "'"
            cmd = New SqlCeCommand(sql, conn)
            cmd.Parameters.Add("@myPicture", SqlDbType.Image).Value = imgByteData
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Gambar di ganti", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tampilgambar()
        End If
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        If ComboBox16.Text = Nothing Then
            MessageBox.Show("Anda belum memilih user !", "PEMBERITAHUAN", MessageBoxButtons.OK
                            )

        Else
            Select Case MessageBox.Show("Apa Anda yakin ingin menghapus user '" & ComboBox16.Items(ComboBox16.SelectedIndex) _
                                   .ToString & "'?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes
                    konek2()
                    sql = "delete from admin where id='" & ComboBox16.Items(ComboBox16.SelectedIndex).ToString & "'"
                    cmd = New SqlCeCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("User Terhapus", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PictureBox5.BackgroundImage = Nothing
                Case Windows.Forms.DialogResult.No
            End Select
            loaduser()
        End If
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        GantiPassword.Show()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub BtnHapusData_Click(sender As Object, e As EventArgs) Handles BtnHapusData.Click
        Select Case MessageBox.Show("Apa Anda yakin ingin menghapus data '" & ComboBoxHpsData.Items(ComboBoxHpsData.SelectedIndex) _
                                    .ToString & "'?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Case Windows.Forms.DialogResult.Yes
                konek2()
                sql = "delete from data where datadb='" & ComboBoxHpsData.Items(ComboBoxHpsData.SelectedIndex).ToString & "'"
                cmd = New SqlCeCommand(sql, conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Data Terhapus", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                PictureBox5.BackgroundImage = Nothing
                loaddata()
                isicbdb()
            Case Windows.Forms.DialogResult.No
        End Select

    End Sub

    Public Sub loadbarang()
        konek()
        sql = "select * from stockbrg"
        cmd = New SqlCeCommand(sql, conn)
        dr = cmd.ExecuteReader
        CariKodeBarang.ListView1.Items.Clear()
        x = 0
        Try
            While dr.Read = True
                With CariKodeBarang.ListView1
                    .Items.Add(dr.Item("kodebrg"))
                    .Items(x).SubItems.Add(dr.Item("merk"))
                    .Items(x).SubItems.Add(dr.Item("hrg_jual"))
                End With
                x = x + 1
            End While
        Finally
            dr.Close()
            conn.Close()
        End Try
        z = ""
    End Sub
    Public Sub prosesbayar()
        konek()
        sql = "insert into pelanggan (idtransaksi, id_pel, nama_pel, total) values" _
            & "('" & BoxIDTrans.Text & "','" & BoxIDPelTrans.Text & "','" & BoxNMPelTrans.Text & "'," _
            & "'" & Label28.Text & "')"
        cmd = New SqlCeCommand(sql, conn)
        cmd.ExecuteNonQuery()
        conn.Close()
        konek()
        Try
            For rw As Integer = 0 To DataGridView1.Rows.Count - 2
                konek()
                sql = "insert into barang (idtransaksi, kodebarang, nm_barang, jumlah, harga)values" _
                & "('" & DataGridView1.Rows(rw).Cells(0).Value & "','" & DataGridView1.Rows(rw).Cells(1).Value & "','" & DataGridView1.Rows(rw).Cells(2).Value & "'," _
                & "'" & DataGridView1.Rows(rw).Cells(3).Value & "','" & DataGridView1.Rows(rw).Cells(4).Value & "')"
                cmd = New SqlCeCommand(sql, conn)
                cmd.ExecuteNonQuery()
                'konek
                konek()
                sql = "select * from stockbrg where kodebrg='" & DataGridView1.Rows(rw).Cells(1).Value & "'"
                cmd = New SqlCeCommand(sql, conn)
                dr = cmd.ExecuteReader()
                If dr.Read Then
                    Dim kurangistok As String = "update stockbrg set jml_stok= '" & dr.Item(5) - DataGridView1.Rows(rw).Cells(3).Value & "' where kodebrg='" & DataGridView1.Rows(rw).Cells(1).Value & "'"
                    cmd = New SqlCeCommand(kurangistok, conn)
                    cmd.ExecuteNonQuery()
                End If
                loaddata()
                loadbarang()
            Next rw
            MessageBox.Show("Pembayaran dengan Nama Sdr : '" & BoxNMPelTrans.Text & "' telah melakukan pembayaran",
                                "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Try
            Catch rollBackEx As Exception
                MessageBox.Show(rollBackEx.Message)
            End Try
        End Try
        conn.Close()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        If BoxIDTrans.Text = Nothing Then
            MessageBox.Show(" ", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf BoxIDPelTrans.Text = Nothing Then
            MessageBox.Show(" ", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf BoxNMPelTrans.Text = Nothing Then
            MessageBox.Show("Anda belum memasukan Nama pelangan !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf BoxBrgTrans.Text = Nothing Then
            MessageBox.Show(" ", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf BoxNamaTrans.Text = Nothing Then
            MessageBox.Show(" ", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf BoxHargaTrans.Text = Nothing Then
            MessageBox.Show("Anda belum memasukan harga barang !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf BoxJumlahTrans.Text = Nothing Then
            MessageBox.Show("Anda belum memasukan jumlah barang !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            prosesbayar()

            transaksi()
            hapustrans()
            loaddat()
            BoxNMPelTrans.Focus()
        End If

    End Sub
#End Region

    Private Sub ComboBox4_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        'FixMe
        If ComboBox4.SelectedIndex >= 0 Then
            dbguna = ComboBox4.Items(ComboBox4.SelectedIndex).ToString
            z = ""
            konek()
            DataSet1.Tables("Report").Clear()
            sql = "SELECT [kodebrg],[merk],[jns_spt],[warna],[size]" _
                & ",[jml_stok],[hrg_modal],[hrg_jual]" _
                & " from stockbrg"
            da = New SqlCeDataAdapter(sql, conn)
            da.Fill(DataSet1, "Report")
            Report1.Preview = PreviewControl1
            Report1.Show()
            PreviewControl1.ZoomPageWidth()
        End If
    End Sub

    Sub totaltransaksi()
        Dim jumlah As Integer
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            jumlah = jumlah + Val(DataGridView1.Rows(i).Cells(4).Value)
            Label28.Text = Format(jumlah, "##,##")
        Next
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)

        Dim kali As Integer
        kali = BoxJumlahTrans.Text * BoxHargaTrans.Text
        DataGridView1.ColumnCount = 5
        DataGridView1.Columns(0).Name = "ID Transaksi"
        DataGridView1.Columns(1).Name = "Kode Barang"
        DataGridView1.Columns(2).Name = "Nama Barang"
        DataGridView1.Columns(3).Name = "Jumlah"
        DataGridView1.Columns(4).Name = "Harga"
        Dim row As String() = New String() {BoxIDTrans.Text, BoxBrgTrans.Text, BoxNamaTrans.Text, BoxJumlahTrans.Text, kali}
        DataGridView1.Rows.Add(row)
        totaltransaksi()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged_1(sender As Object, e As EventArgs)
        If Not ComboBox2.SelectedIndex = 1 Then
            dbguna = ComboBox1.Items(ComboBox1.SelectedIndex).ToString
            z = ""
            konek()
            DataSet1.Tables("DataTransaksi").Clear()
            sql = "SELECT [idtrans],[id_plg],[nm_plg],[kodebrg],[nm_brg]" _
                & ",[hrg_brg],[jml],[total]" _
                & " from transaksi where idtrans='" & ComboBox2.Items(ComboBox2.SelectedIndex).ToString & "'"
            da = New SqlCeDataAdapter(sql, conn)
            da.Fill(DataSet1, "DataTransaksi")
            Report2.Preview = PreviewControl2
            Report2.Show()
            PreviewControl2.Refresh()
            PreviewControl2.ZoomPageWidth()
        End If
    End Sub


    Private Sub ComboBox2_SelectedIndexChanged_2(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedIndex >= 0 Then
            dbguna = ComboBox1.Items(ComboBox1.SelectedIndex).ToString
            z = ""
            konek()
            DataSet1.Tables("DataTransaksi").Clear()
            sql = "SELECT [idtrans],[id_plg],[nm_plg],[kodebrg],[nm_brg]" _
                & ",[hrg_brg],[jml],[total]" _
                & " from transaksi where idtrans='" & ComboBox2.Items(ComboBox2.SelectedIndex).ToString & "'"
            da = New SqlCeDataAdapter(sql, conn)
            da.Fill(DataSet1, "DataTransaksi")
            Report2.Preview = PreviewControl2
            Report2.Show()
            PreviewControl2.Refresh()
            PreviewControl2.ZoomPageWidth()
        End If
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs)
        CariKodeBarang.ShowDialog()
        If CariKodeBarang.retkode <> "" Then
            BoxBrgTrans.Text = CariKodeBarang.retkode
            BoxNamaTrans.Text = CariKodeBarang.retnama
            BoxHargaTrans.Text = CariKodeBarang.retharga
        End If
    End Sub

    Private Sub btnCari_Click_1(sender As Object, e As EventArgs) Handles btnCari.Click

    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub
End Class