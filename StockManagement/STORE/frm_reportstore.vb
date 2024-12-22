Imports MySql.Data.MySqlClient
Public Class frm_reportstore
    Private Sub frm_reportstore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()
        DataGridView1.RowTemplate.Height = 27
        DataGridView2.RowTemplate.Height = 27
        Load_inwordReport()
        Load_IssueData()
    End Sub
    Sub Load_inwordReport()
        DataGridView1.Rows.Clear()
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT `grnno`, `grndate`, `suppliername`, `partno`, `partname`, `group`, `uom`, `location`, `qty` FROM `tblgoodsreceipt` ", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, dr.Item("grnno"), dr.Item("grndate"), dr.Item("suppliername"), dr.Item("partno"), dr.Item("partname"), dr.Item("group"), dr.Item("uom"), dr.Item("location"), dr.Item("qty"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        DataGridView1.Rows.Clear()
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT `grnno`, `grndate`, `suppliername`, `partno`, `partname`, `group`, `uom`, `location`, `qty` FROM `tblgoodsreceipt` WHERE grnno like '%" & txt_search.Text & "%' or grndate like '%" & txt_search.Text & "%' or suppliername like '%" & txt_search.Text & "%' or partno like '%" & txt_search.Text & "%' or partname like '%" & txt_search.Text & "%' or partgroup like '%" & txt_search.Text & "%' or uom like '%" & txt_search.Text & "%' or location like '%" & txt_search.Text & "%' ", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, dr.Item("grnno"), dr.Item("grndate"), dr.Item("suppliername"), dr.Item("partno"), dr.Item("partname"), dr.Item("group"), dr.Item("uom"), dr.Item("location"), dr.Item("qty"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
    Sub Load_IssueData()
        DataGridView2.Rows.Clear()
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT `issueno`, `issuedate`, `issuetime`, `requestno`, `requestdate`, `jitno`, `jitdate`, `jittime`, `partno`, `partname`, `group`, `uom`, `location`, `jitqty`, `issueqty` FROM `tblissue`", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView2.Rows.Add(DataGridView2.Rows.Count + 1, dr.Item("issueno"), dr.Item("issuedate"), dr.Item("issuetime"), dr.Item("requestno"), dr.Item("requestdate"), dr.Item("jitno"), dr.Item("jitdate"), dr.Item("jittime"), dr.Item("partno"), dr.Item("partname"), dr.Item("group"), dr.Item("uom"), dr.Item("location"), dr.Item("jitqty"), dr.Item("issueqty"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub txt_issuereportsearch_TextChanged(sender As Object, e As EventArgs) Handles txt_issuereportsearch.TextChanged
        DataGridView2.Rows.Clear()
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT `issueno`, `issuedate`, `issuetime`, `requestno`, `requestdate`, `jitno`, `jitdate`, `jittime`, `partno`, `partname`, `group`, `uom`, `location`, `jitqty`, `issueqty` FROM `tblissue` WHERE issueno like '%" & txt_issuereportsearch.Text & "%' or requestno like '%" & txt_issuereportsearch.Text & "%' or jitno like '%" & txt_issuereportsearch.Text & "%' or partno like '%" & txt_issuereportsearch.Text & "%' or partname  like '%" & txt_issuereportsearch.Text & "%'", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView2.Rows.Add(DataGridView2.Rows.Count + 1, dr.Item("issueno"), dr.Item("issuedate"), dr.Item("issuetime"), dr.Item("requestno"), dr.Item("requestdate"), dr.Item("jitno"), dr.Item("jitdate"), dr.Item("jittime"), dr.Item("partno"), dr.Item("partname"), dr.Item("group"), dr.Item("uom"), dr.Item("location"), dr.Item("jitqty"), dr.Item("issueqty"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Hide()
    End Sub
End Class