Public Class frm_AdminMain
    Private Sub btn_managestock_Click(sender As Object, e As EventArgs) Handles btn_managestock.Click
        frm_managestock.TopLevel = False
        Panel3.Controls.Add(frm_managestock)
        frm_managestock.BringToFront()
        frm_managestock.Show()
    End Sub

    Private Sub btn_manageusers_Click(sender As Object, e As EventArgs) Handles btn_manageusers.Click
        frm_ManageUsers.TopLevel = False
        Panel3.Controls.Add(frm_ManageUsers)
        frm_ManageUsers.BringToFront()
        frm_ManageUsers.Show()
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

    Private Sub btn_manageproducts_Click(sender As Object, e As EventArgs) Handles btn_manageproducts.Click
        frm_ManageProducts.TopLevel = False
        Panel3.Controls.Add(frm_ManageProducts)
        frm_ManageProducts.BringToFront()
        frm_ManageProducts.Show()
    End Sub
End Class