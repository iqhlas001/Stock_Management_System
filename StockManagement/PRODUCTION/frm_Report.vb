Imports MySql.Data.MySqlClient
Public Class frm_Report
    Private Sub frm_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()
        DataGridView1.RowTemplate.Height = 27

        Load_JITReport()
        Get_ReportDashboard()
    End Sub
    Sub Load_JITReport()
        DataGridView1.Rows.Clear()
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT `requestno`, `requestdate`, `jitno`, `jitdate`, `jittime`, `partno`, `partname`, `group`, `uom`, `location`, `jitqty` FROM `tbljit`", conn)
            dr = cmd.ExecuteReader
            While dr.Read = True
                DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, dr.Item("requestno"), dr.Item("requestdate"), dr.Item("jitno"), dr.Item("jitdate"), dr.Item("jittime"), dr.Item("partno"), dr.Item("partname"), dr.Item("group"), dr.Item("uom"), dr.Item("location"), dr.Item("jitqty"))
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
            cmd = New MySqlCommand("SELECT `requestno`, `requestdate`, `jitno`, `jitdate`, `jittime`, `partno`, `partname`, `group`, `uom`, `location`, `jitqty` FROM `tbljit`  WHERE  requestno like '%" & txt_search.Text & "%' or jitno like '%" & txt_search.Text & "%' or partname like '%" & txt_search.Text & "%'", conn)
            dr = cmd.ExecuteReader
            While dr.Read = True
                DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, dr.Item("requestno"), dr.Item("requestdate"), dr.Item("jitno"), dr.Item("jitdate"), dr.Item("jittime"), dr.Item("partno"), dr.Item("partname"), dr.Item("group"), dr.Item("uom"), dr.Item("location"), dr.Item("jitqty"), conn)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
    Private Sub btn_filter_Click(sender As Object, e As EventArgs) Handles btn_filter.Click
        Dim date1 As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim date2 As String = DateTimePicker2.Value.ToString("yyyy-MM-dd")
        DataGridView1.Rows.Clear()
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT `requestno`, `requestdate`, `jitno`, `jitdate`, `jittime`, `partno`, `partname`, `group`, `uom`, `location`, `jitqty` FROM `tbljit` WHERE requestdate between '" & date1 & "' and '" & date2 & "'", conn)
            dr = cmd.ExecuteReader
            While dr.Read = True
                DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, dr.Item("requestno"), dr.Item("requestdate"), dr.Item("jitno"), dr.Item("jitdate"), dr.Item("jittime"), dr.Item("partno"), dr.Item("partname"), dr.Item("group"), dr.Item("uom"), dr.Item("location"), dr.Item("jitqty"), conn)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
    Sub Get_ReportDashboard()
        conn.Open()
        cmd = New MySqlCommand("SELECT COUNT(`requestno`) FROM `tbljit` WHERE `requestdate`='" & Date.Now.ToString("yyyy-MM-dd") & "' GROUP BY `requestno`", conn)
        lbl_todayRequest.Text = cmd.ExecuteScalar
        conn.Close()

        conn.Open()
        cmd = New MySqlCommand("SELECT COUNT(`jitno`) FROM `tbljit` WHERE `requestdate`= '" & Date.Now.ToString("yyyy-MM-dd") & "'", conn)
        lbl_todayJit.Text = cmd.ExecuteScalar
        conn.Close()

        conn.Open()
        cmd = New MySqlCommand("SELECT COUNT(`jitno`) FROM `tbljit` WHERE `jitqty`<0 AND `requestdate`= '" & Date.Now.ToString("yyyy-MM-dd") & "'", conn)
        lbl_finishJit.Text = cmd.ExecuteScalar
        conn.Close()

        conn.Open()
        cmd = New MySqlCommand("SELECT COUNT(`jitno`) FROM `tbljit` WHERE `jitqty`>0 AND `requestdate`= '" & Date.Now.ToString("yyyy-MM-dd") & "'", conn)
        lbl_pendingJit.Text = cmd.ExecuteScalar
        conn.Close()
    End Sub
    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Hide()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class