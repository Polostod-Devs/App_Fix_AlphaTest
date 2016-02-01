Imports System.Data.SqlServerCe
Imports System.Object
Imports System.MarshalByRefObject
Imports System.ComponentModel.Component
Imports System.Windows.Forms.CommonDialog
Imports System.Windows.Forms.FileDialog
Imports System.Windows.Forms.OpenFileDialog

Public Class PrintTransaksi
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
    Dim bcuser As String
    Dim keluar As Integer
    Dim strtemp As String = ""


    Dim strvalue As String = ""

    '-- Fixed Me ASAP
    '-- Need Compile again 
    Private Sub PrintTransaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbguna = MainMenu.ComboBox4.Items(MainMenu.ComboBox1.SelectedIndex).ToString
        z = ""
        MainMenu.konek()
        MainMenu.DataSet1.Tables("DataTransaksi").Clear()
        sql = "SELECT [idtrans],[id_plg],[nm_plg],[kodebrg],[nm_brg]" _
            & ",[hrg_brg],[jml],[total]" _
            & " from transaksi"
        da = New SqlCeDataAdapter(Sql, conn)
        da.Fill(MainMenu.DataSet1, "Report")
        MainMenu.Report2.Preview = PreviewControl1
        MainMenu.Report2.Show()
        PreviewControl1.ZoomPageWidth()
    End Sub
End Class