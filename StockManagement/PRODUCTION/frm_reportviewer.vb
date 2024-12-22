Imports MySql.Data.MySqlClient
Imports System.IO
Imports Microsoft.Reporting.WinForms
Public Class frm_reportviewer
    Private Sub frm_reportviewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
        Load_JITReport()
    End Sub
    Sub Load_JITReport()
        Dim rptDs As ReportDataSource
        Me.ReportViewer1.RefreshReport()
        Try
            ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\report\Report1.rdlc"
            ReportViewer1.LocalReport.DataSources.Clear()

            Dim ds As New DataSet1
            Dim da As New MySqlDataAdapter
            da.SelectCommand = New MySqlCommand("SELECT * FROM `tbljit` WHERE `requestno`='" & frm_jitGenerateList.lbl_taransactionno.Text & "'", conn)
            da.Fill(ds.Tables("DataTable1"))

            rptDs = New ReportDataSource("DataSet1", ds.Tables("DataTable1"))
            ReportViewer1.LocalReport.DataSources.Add(rptDs)

            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            ReportViewer1.ZoomMode = ZoomMode.Percent
            ReportViewer1.ZoomMode = 100
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub
End Class