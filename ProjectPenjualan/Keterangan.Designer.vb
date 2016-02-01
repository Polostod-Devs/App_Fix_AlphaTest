<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Keterangan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Keterangan))
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Items.AddRange(New Object() {"SPNAM " & Global.Microsoft.VisualBasic.ChrW(9) & "= Nike Air Max", "SPNL " & Global.Microsoft.VisualBasic.ChrW(9) & "= Nike Lokal ", "SPNC" & Global.Microsoft.VisualBasic.ChrW(9) & "= Nike Crocodile", "SPNB" & Global.Microsoft.VisualBasic.ChrW(9) & "= New Balance", "SPARD" & Global.Microsoft.VisualBasic.ChrW(9) & "= Ardiles", "SPATT" & Global.Microsoft.VisualBasic.ChrW(9) & "= ATT", "SPRAF" & Global.Microsoft.VisualBasic.ChrW(9) & "= Raffa", "SPWIN" & Global.Microsoft.VisualBasic.ChrW(9) & "= Win", "SPTRA" & Global.Microsoft.VisualBasic.ChrW(9) & "= Traccer", "SPVAS" & Global.Microsoft.VisualBasic.ChrW(9) & "= Vans All School", "SPVAST" & Global.Microsoft.VisualBasic.ChrW(9) & "= Vans All School Tinggi", "SPV" & Global.Microsoft.VisualBasic.ChrW(9) & "= Vans", "SPVSL" & Global.Microsoft.VisualBasic.ChrW(9) & "= Vans Sloop", "SPADD" & Global.Microsoft.VisualBasic.ChrW(9) & "= Adidas", "SPVSN" & Global.Microsoft.VisualBasic.ChrW(9) & "= Vans Sniccer", "SPADDSN  = Adidas Sniccer", "SPADDB" & Global.Microsoft.VisualBasic.ChrW(9) & "= Adidas Biasa", "SPMC" & Global.Microsoft.VisualBasic.ChrW(9) & "= MacBeth", "SPDC" & Global.Microsoft.VisualBasic.ChrW(9) & "= DC", "SPLVS" & Global.Microsoft.VisualBasic.ChrW(9) & "= Levis", "SPAND" & Global.Microsoft.VisualBasic.ChrW(9) & "= Ando", "SPNPF" & Global.Microsoft.VisualBasic.ChrW(9) & "= New Plus Futsal", "SPADDF" & Global.Microsoft.VisualBasic.ChrW(9) & "= Ardiles Futsal", "SPADDBL= Ardiles Bola", "SPMGBL " & Global.Microsoft.VisualBasic.ChrW(9) & "= Mogul Bola", "SPCPP" & Global.Microsoft.VisualBasic.ChrW(9) & "= Catter Pilar Pendek", "SPCPTC" & Global.Microsoft.VisualBasic.ChrW(9) & "= Catter Pilar Tinggi Casual", "SPSHPC" & Global.Microsoft.VisualBasic.ChrW(9) & "= Shop Casual ", "SPDKPC = Down Keys Pendek Cassual", "SPPNTWC = Panataw Cassual", "SPDKTC" & Global.Microsoft.VisualBasic.ChrW(9) & "  = Down Keys Tinggi Casual", "SPPTL" & Global.Microsoft.VisualBasic.ChrW(9) & "= Pantopel", "SPDLLTS" & Global.Microsoft.VisualBasic.ChrW(9) & "= Dallas Tinggi School", "SPNBS" & Global.Microsoft.VisualBasic.ChrW(9) & "= New Basket School"})
        Me.ListBox1.Location = New System.Drawing.Point(12, 49)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(317, 224)
        Me.ListBox1.TabIndex = 0
        '
        'Keterangan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(341, 325)
        Me.Controls.Add(Me.ListBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Keterangan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Keterangan"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
End Class
