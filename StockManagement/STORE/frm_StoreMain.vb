Imports MySql.Data.MySqlClient
Public Class frm_StoreMain
    Private WithEvents panel As New Panel
    Private WithEvents lblparto As New Label
    Private WithEvents lblpartname As New Label
    Private WithEvents lblgroup As New Label
    Private WithEvents lblLocation As Label
    Private WithEvents lblStock As Label
    Private Sub frm_StoreMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()
        Load_data()
    End Sub

    Private Sub btn_goodsreceipt_Click(sender As Object, e As EventArgs) Handles btn_goodsreceipt.Click
        frm_goodsreceipt.TopLevel = False
        FlowLayoutPanel1.Controls.Add(frm_goodsreceipt)
        frm_goodsreceipt.BringToFront()
        frm_goodsreceipt.Show()
    End Sub

    Private Sub btn_jitissue_Click(sender As Object, e As EventArgs) Handles btn_jitissue.Click
        frm_jitissue.TopLevel = False
        FlowLayoutPanel1.Controls.Add(frm_jitissue)
        frm_jitissue.BringToFront()
        frm_jitissue.Show()
    End Sub
    Private Sub btn_report_Click(sender As Object, e As EventArgs) Handles btn_report.Click
        frm_reportstore.TopLevel = False
        FlowLayoutPanel1.Controls.Add(frm_reportstore)
        frm_reportstore.BringToFront()
        frm_reportstore.Show()
    End Sub

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Hide()
        frm_login.Show()
    End Sub

    Sub Add_Controls()
        panel = New Panel
        With panel
            .BackColor = Color.White
            .Size = New Drawing.Size(280, 145)
        End With

        lblpartname = New Label
        With lblpartname
            .ForeColor = Color.DimGray
            .BackColor = Color.Transparent
            .TextAlign = ContentAlignment.MiddleLeft
            .Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .Dock = DockStyle.Top
        End With

        lblparto = New Label
        With lblparto
            .ForeColor = Color.DimGray
            .BackColor = Color.Transparent
            .TextAlign = ContentAlignment.MiddleLeft
            .Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .Dock = DockStyle.Top
        End With

        lblgroup = New Label
        With lblgroup
            .ForeColor = Color.DimGray
            .BackColor = Color.Transparent
            .TextAlign = ContentAlignment.MiddleLeft
            .Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .Dock = DockStyle.Top
        End With

        lblLocation = New Label
        With lblLocation
            .ForeColor = Color.DimGray
            .BackColor = Color.Transparent
            .TextAlign = ContentAlignment.MiddleLeft
            .Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .Dock = DockStyle.Top
        End With

        lblStock = New Label
        With lblStock
            .ForeColor = Color.Orange
            .BackColor = Color.Transparent
            .TextAlign = ContentAlignment.MiddleLeft
            .Font = New Font("Segoe UI", 12, FontStyle.Bold)
            .Dock = DockStyle.Bottom
        End With
        '`partno`, `partname`, `group`, `uom`, `location`, `stock`, `hitrate`, `schedule`
        lblpartname.Text = "PART NAME : " & dr.Item("partname").ToString
        lblparto.Text = "PART NO : " & dr.Item("partno").ToString
        lblgroup.Text = "GROUP : " & dr.Item("group").ToString
        lblLocation.Text = "LOCATION : " & dr.Item("location").ToString
        lblStock.Text = "STOCK : " & dr.Item("stock").ToString & dr.Item("uom").ToString

        panel.Controls.Add(lblLocation)
        panel.Controls.Add(lblgroup)
        panel.Controls.Add(lblparto)
        panel.Controls.Add(lblpartname)
        panel.Controls.Add(lblStock)

    End Sub
    Sub Load_data()
        FlowLayoutPanel1.Controls.Clear()
        FlowLayoutPanel1.AutoScroll = True
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT `partno`, `partname`, `group`, `uom`,`hitrate`, `location`, `stock` FROM `tblproducts` ", conn)
            dr = cmd.ExecuteReader
            While dr.Read = True
                Add_Controls()
                FlowLayoutPanel1.Controls.Add(panel)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs)
        FlowLayoutPanel1.Controls.Clear()
        FlowLayoutPanel1.AutoScroll = True
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT `partno`, `partname`, `group`, `uom`, `location`, `stock` FROM `tblproducts` WHERE partno like '%" & txt_search.Text & "%' or partname like '%" & txt_search.Text & "%' or group like '%" & txt_search.Text & "%' or location like '%" & txt_search.Text & "%' ", conn)
            dr = cmd.ExecuteReader
            While dr.Read = True
                Add_Controls()
                FlowLayoutPanel1.Controls.Add(panel)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
    Private Sub btn_allstocks_Click(sender As Object, e As EventArgs) Handles btn_allstocks.Click
        Load_data()
    End Sub

    Private Sub btn_criticalstocks_Click(sender As Object, e As EventArgs) Handles btn_criticalstocks.Click
        FlowLayoutPanel1.Controls.Clear()
        FlowLayoutPanel1.AutoScroll = True
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT `partno`, `partname`, `group`, `uom`, `location`, `stock`, `hitrate` FROM `tblproducts` WHERE stock<hitrate*2 ", conn)
            dr = cmd.ExecuteReader
            While dr.Read = True
                Add_Controls()
                FlowLayoutPanel1.Controls.Add(panel)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub btn_zerostocks_Click(sender As Object, e As EventArgs) Handles btn_zerostocks.Click
        FlowLayoutPanel1.Controls.Clear()
        FlowLayoutPanel1.AutoScroll = True
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT `partno`, `partname`, `group`, `uom`, `location`, `stock`, `hitrate` FROM `tblproducts` WHERE stock=0 ", conn)
            dr = cmd.ExecuteReader
            While dr.Read = True
                Add_Controls()
                FlowLayoutPanel1.Controls.Add(panel)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Private Sub btn_allstocks_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub btn_criticalstocks_Click_1(sender As Object, e As EventArgs)

    End Sub
End Class