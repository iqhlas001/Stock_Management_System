Imports System.IO
Imports MySql.Data.MySqlClient
Public Class frm_manageschedule
    Private Sub frm_manageschedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()
        lbl_heading.Text = "SCHEDULE - " & Date.Now.ToString("MMMM-yyyy")
        DataGridView1.RowTemplate.Height = 27
        load_schedule()
    End Sub
    Sub load_schedule()
        DataGridView1.Rows.Clear()
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT `partno`, `partname`, `group`, `uom`, `location`, `hitrate`, `schedule` FROM `tblproducts`", conn)
            dr = cmd.ExecuteReader()
            While dr.Read = True
                DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, dr.Item("partno").ToString, dr.Item("partname").ToString, dr.Item("group").ToString, dr.Item("uom").ToString, dr.Item("location").ToString, dr.Item("hitrate").ToString, dr.Item("schedule").ToString)
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
            cmd = New MySqlCommand("SELECT `partno`, `partname`, `group`, `uom`, `location`, `hitrate`, `schedule` FROM `tblproducts` WHERE  partno like '%" & txt_search.Text & "%' or partname like '%" & txt_search.Text & "%' or group like '%" & txt_search.Text & "%' or location like '%" & txt_search.Text & "%'", conn)
            dr = cmd.ExecuteReader
            While dr.Read = True
                DataGridView1.Rows.Add(0, DataGridView1.Rows.Count + 1, dr.Item("partno"), dr.Item("partname"), dr.Item("group"), dr.Item("uom"), dr.Item("location"), dr.Item("hitrate"), dr.Item("schedule"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub
    Private Sub btn_updateschdule_Click(sender As Object, e As EventArgs) Handles btn_updateschdule.Click
        If MsgBox("Are You Sure Update " & Date.Now.ToString("MMM-yyyy") & " Schudule ?", vbQuestion + vbYesNo) = vbYes Then
            Try
                conn.Open()
                For j As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
                    cmd = New MySqlCommand("UPDATE `tblproducts` SET `hitrate`=@hitrate,`schedule`=@schedule WHERE `partno`=@partno", conn)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@hitrate", DataGridView1.Rows(j).Cells(6).Value)
                    cmd.Parameters.AddWithValue("@schedule", DataGridView1.Rows(j).Cells(7).Value)
                    cmd.Parameters.AddWithValue("@partno", DataGridView1.Rows(j).Cells(1).Value)
                    i = cmd.ExecuteNonQuery
                Next
                If i > 0 Then
                    MsgBox("" & Date.Now.ToString("MMMM-yyyy") & " Schedule Update Success !", vbInformation)
                Else
                    MsgBox("Schedule Update Failed !", vbExclamation)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            conn.Close()
        Else
            Return
        End If
        load_schedule()
    End Sub
    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Try
            DataGridView1.CurrentRow.Cells(6).Value = DataGridView1.CurrentRow.Cells(7).Value / 26
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btn_deleteschedule_Click(sender As Object, e As EventArgs) Handles btn_deleteschedule.Click
        If MsgBox("Warning : Are You Sure Wand to Clear " & Date.Now.ToString("MMM-yyyy") & " Schudule ?", vbQuestion + vbYesNo) = vbYes Then
            Try
                conn.Open()
                For j As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
                    cmd = New MySqlCommand("UPDATE `tblproducts` SET `hitrate`=@hitrate,`schedule`=@schedule WHERE `partno`=@partno ", conn)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@hitrate", 0)
                    cmd.Parameters.AddWithValue("@schedule", 0)
                    cmd.Parameters.AddWithValue("@partno", DataGridView1.Rows(j).Cells(1).Value)
                    i = cmd.ExecuteNonQuery
                Next
                If i > 0 Then
                    MsgBox("" & Date.Now.ToString("MMMM-yyyy") & " Schedule Clear Success !", vbInformation)
                Else
                    MsgBox("Schedule Clear Failed !", vbExclamation)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            conn.Close()
        Else
            Return
        End If
        load_schedule()
    End Sub
End Class