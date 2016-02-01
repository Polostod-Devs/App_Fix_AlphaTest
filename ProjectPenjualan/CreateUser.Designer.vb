<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateUser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BoxAddUser = New System.Windows.Forms.TextBox()
        Me.BoxPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxOtoritasUser = New System.Windows.Forms.ComboBox()
        Me.BtnBuatUser = New System.Windows.Forms.Button()
        Me.BtnCancleUser = New System.Windows.Forms.Button()
        Me.BtnPilihPoto = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBoxAddUser = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.PictureBoxAddUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(148, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID/NAMA"
        '
        'BoxAddUser
        '
        Me.BoxAddUser.Location = New System.Drawing.Point(275, 12)
        Me.BoxAddUser.Name = "BoxAddUser"
        Me.BoxAddUser.Size = New System.Drawing.Size(100, 20)
        Me.BoxAddUser.TabIndex = 1
        '
        'BoxPassword
        '
        Me.BoxPassword.Location = New System.Drawing.Point(275, 41)
        Me.BoxPassword.Name = "BoxPassword"
        Me.BoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.BoxPassword.Size = New System.Drawing.Size(100, 20)
        Me.BoxPassword.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(148, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "KATA SANDI"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(148, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "OTORITAS"
        '
        'ComboBoxOtoritasUser
        '
        Me.ComboBoxOtoritasUser.FormattingEnabled = True
        Me.ComboBoxOtoritasUser.Items.AddRange(New Object() {"ADMIN", "USER"})
        Me.ComboBoxOtoritasUser.Location = New System.Drawing.Point(275, 92)
        Me.ComboBoxOtoritasUser.Name = "ComboBoxOtoritasUser"
        Me.ComboBoxOtoritasUser.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxOtoritasUser.TabIndex = 6
        '
        'BtnBuatUser
        '
        Me.BtnBuatUser.BackColor = System.Drawing.Color.DarkCyan
        Me.BtnBuatUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnBuatUser.ForeColor = System.Drawing.SystemColors.Control
        Me.BtnBuatUser.Location = New System.Drawing.Point(235, 148)
        Me.BtnBuatUser.Name = "BtnBuatUser"
        Me.BtnBuatUser.Size = New System.Drawing.Size(75, 23)
        Me.BtnBuatUser.TabIndex = 9
        Me.BtnBuatUser.Text = "BUAT"
        Me.BtnBuatUser.UseVisualStyleBackColor = False
        '
        'BtnCancleUser
        '
        Me.BtnCancleUser.BackColor = System.Drawing.Color.DarkCyan
        Me.BtnCancleUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCancleUser.ForeColor = System.Drawing.SystemColors.Control
        Me.BtnCancleUser.Location = New System.Drawing.Point(335, 148)
        Me.BtnCancleUser.Name = "BtnCancleUser"
        Me.BtnCancleUser.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancleUser.TabIndex = 10
        Me.BtnCancleUser.Text = "BATAL"
        Me.BtnCancleUser.UseVisualStyleBackColor = False
        '
        'BtnPilihPoto
        '
        Me.BtnPilihPoto.BackColor = System.Drawing.Color.DarkCyan
        Me.BtnPilihPoto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnPilihPoto.ForeColor = System.Drawing.SystemColors.Control
        Me.BtnPilihPoto.Location = New System.Drawing.Point(151, 148)
        Me.BtnPilihPoto.Name = "BtnPilihPoto"
        Me.BtnPilihPoto.Size = New System.Drawing.Size(75, 23)
        Me.BtnPilihPoto.TabIndex = 8
        Me.BtnPilihPoto.Text = "PILIH FOTO"
        Me.BtnPilihPoto.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PictureBoxAddUser
        '
        Me.PictureBoxAddUser.BackColor = System.Drawing.Color.DarkCyan
        Me.PictureBoxAddUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxAddUser.Location = New System.Drawing.Point(12, 12)
        Me.PictureBoxAddUser.Name = "PictureBoxAddUser"
        Me.PictureBoxAddUser.Size = New System.Drawing.Size(122, 141)
        Me.PictureBoxAddUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxAddUser.TabIndex = 359
        Me.PictureBoxAddUser.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(275, 67)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(148, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 16)
        Me.Label4.TabIndex = 361
        Me.Label4.Text = "ULANGI KATA SANDI"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(187, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Label5"
        Me.Label5.Visible = False
        '
        'CreateUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(446, 191)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnPilihPoto)
        Me.Controls.Add(Me.PictureBoxAddUser)
        Me.Controls.Add(Me.BtnCancleUser)
        Me.Controls.Add(Me.BtnBuatUser)
        Me.Controls.Add(Me.ComboBoxOtoritasUser)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BoxPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BoxAddUser)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CreateUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CreateUser"
        CType(Me.PictureBoxAddUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BoxAddUser As System.Windows.Forms.TextBox
    Friend WithEvents BoxPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxOtoritasUser As System.Windows.Forms.ComboBox
    Friend WithEvents BtnBuatUser As System.Windows.Forms.Button
    Friend WithEvents BtnCancleUser As System.Windows.Forms.Button
    Friend WithEvents PictureBoxAddUser As System.Windows.Forms.PictureBox
    Friend WithEvents BtnPilihPoto As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
