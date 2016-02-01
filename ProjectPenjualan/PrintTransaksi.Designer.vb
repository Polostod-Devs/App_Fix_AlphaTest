<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintTransaksi
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
        Me.PreviewControl1 = New FastReport.Preview.PreviewControl()
        Me.DataSet11 = New ProjectPenjualan.DataSet1()
        CType(Me.DataSet11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PreviewControl1
        '
        Me.PreviewControl1.BackColor = System.Drawing.Color.White
        Me.PreviewControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PreviewControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PreviewControl1.Buttons = CType(((((((((FastReport.PreviewButtons.Print Or FastReport.PreviewButtons.Save) _
            Or FastReport.PreviewButtons.Email) _
            Or FastReport.PreviewButtons.Find) _
            Or FastReport.PreviewButtons.Zoom) _
            Or FastReport.PreviewButtons.Outline) _
            Or FastReport.PreviewButtons.PageSetup) _
            Or FastReport.PreviewButtons.Watermark) _
            Or FastReport.PreviewButtons.Navigator), FastReport.PreviewButtons)
        Me.PreviewControl1.FastScrolling = True
        Me.PreviewControl1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PreviewControl1.Location = New System.Drawing.Point(3, 14)
        Me.PreviewControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.PreviewControl1.Name = "PreviewControl1"
        Me.PreviewControl1.PageOffset = New System.Drawing.Point(10, 10)
        Me.PreviewControl1.Size = New System.Drawing.Size(778, 429)
        Me.PreviewControl1.TabIndex = 359
        Me.PreviewControl1.UIStyle = FastReport.Utils.UIStyle.VisualStudio2005
        Me.PreviewControl1.UseBackColor = True
        '
        'DataSet11
        '
        Me.DataSet11.DataSetName = "DataSet1"
        Me.DataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PrintTransaksi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 457)
        Me.Controls.Add(Me.PreviewControl1)
        Me.Name = "PrintTransaksi"
        Me.Text = "PrintTransaksi"
        CType(Me.DataSet11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents PreviewControl1 As FastReport.Preview.PreviewControl
    Friend WithEvents DataSet11 As DataSet1
End Class
