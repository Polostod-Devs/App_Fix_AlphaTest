Imports System.Data.SqlServerCe
Public Class RecentUser
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
    Dim bcuser As String
    Dim keluar As Integer

#End Region

    Sub konek2()
        kon = "Data Source=|DataDirectory|\Database\admin.sdf;Persist Security Info=False"
        conn = New SqlCeConnection(kon)
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub

    Private Sub RecentUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainMenu.loaduser()
        DataSet1.Tables("akses").Clear()
        konek2()
        sql = "select nama, status, masuk, keluar, akses.id from admin inner join akses on" & _
                " (admin.id = akses.nama) order by id desc"
        da = New SqlCeDataAdapter(sql, conn)
        da.Fill(DataSet1, "akses")
        Dim dRow As DataRow
        Dim drsi As Integer
        Dim drsi2 As Integer
        Dim drsi3 As Decimal
        Dim durasi As String
        For Each dRow In DataSet1.Tables("akses").Rows
            If Not dRow.Item("keluar") Is DBNull.Value Then
                drsi = DateDiff(DateInterval.Hour, dRow.Item("masuk"), dRow.Item("keluar"))
                drsi2 = DateDiff(DateInterval.Minute, dRow.Item("masuk"), dRow.Item("keluar"))
                drsi3 = drsi2 - (drsi * 60)
                durasi = "" & drsi & " jam " & drsi3 & " Menit"
                dRow.Item("durasi") = durasi
            Else
                dRow.Item("keluar") = "User Login"
                dRow.Item("durasi") = "User Login"
            End If
        Next
        conn.Close()
        DataGridView1.DataSource = DataSet1.Tables("akses")
        DataGridView1.Refresh()
    End Sub

End Class