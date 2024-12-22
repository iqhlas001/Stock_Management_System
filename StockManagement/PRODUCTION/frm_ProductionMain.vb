Public Class frm_ProductionMain
    Private Sub btn_manageschedule_Click(sender As Object, e As EventArgs) Handles btn_manageschedule.Click
        frm_manageschedule.TopLevel = False
        Panel3.Controls.Add(frm_manageschedule)
        frm_manageschedule.BringToFront()
        frm_manageschedule.Show()
    End Sub
    Private Sub btn_jitgenerate_Click(sender As Object, e As EventArgs) Handles btn_jitgenerate.Click
        frm_jitGenerate.TopLevel = False
        Panel3.Controls.Add(frm_jitGenerate)
        frm_jitGenerate.BringToFront()
        frm_jitGenerate.Show()
    End Sub
    Private Sub btn_report_Click(sender As Object, e As EventArgs) Handles btn_report.Click
        frm_Report.TopLevel = False
        Panel3.Controls.Add(frm_Report)
        frm_Report.BringToFront()
        frm_Report.Show()
    End Sub
    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Hide()
        frm_login.Show()
    End Sub
End Class