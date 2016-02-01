Imports System.Data.SqlServerCe
Public Class CariKodeBarang
    Public retkode, retnama, retharga As String

    Private Sub CariKodeBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainMenu.loadbarang()
    End Sub

    Private Sub pilih()
        Try
            retkode = ListView1.SelectedItems(0).SubItems(0).Text.ToString
            retnama = ListView1.SelectedItems(0).SubItems(1).Text.ToString
            retharga = ListView1.SelectedItems(0).SubItems(2).Text.ToString
            Me.Close()
        Catch ex As Exception
            MsgBox("Pilih salah satu data", MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Call pilih()
    End Sub

End Class