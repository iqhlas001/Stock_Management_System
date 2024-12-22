Imports MySql.Data.MySqlClient
Public Class frm_jitissue
    Private Sub frm_jitissue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()
        DataGridView1.RowTemplate.Height = 27
        Load_JITDate()
    End Sub
    Sub Load_JITDate()
        DataGridView1.Rows.Clear()
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT * FROM `tbljit` WHERE `jitqty`>0", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(0, DataGridView1.Rows.Count + 1, dr.Item("requestno"), dr.Item("requestdate"), dr.Item("jitno"), dr.Item("jitdate"), dr.Item("jittime"), dr.Item("partno"), dr.Item("partname"), dr.Item("group"), dr.Item("uom"), dr.Item("location"), dr.Item("jitqty"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub btn_filter_Click(sender As Object, e As EventArgs) Handles btn_filter.Click
        Dim date1 As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim date2 As String = DateTimePicker2.Value.ToString("yyyy-MM-dd")
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT * FROM `tbljit` WHERE `jitqty`>0 and requestdate between '" & date1 & "' and '" & date2 & "'", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(0, DataGridView1.Rows.Count + 1, dr.Item("requestno"), dr.Item("requestdate"), dr.Item("jitno"), dr.Item("jitdate"), dr.Item("jittime"), dr.Item("partno"), dr.Item("partname"), dr.Item("group"), dr.Item("uom"), dr.Item("location"), dr.Item("jitqty"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub btn_issue_Click(sender As Object, e As EventArgs) Handles btn_issue.Click
        frm_checklist.DataGridView1.RowTemplate.Height = 27
        frm_checklist.DataGridView1.Rows.Clear()
        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("colcheck").Value)
            If isSelected = True Then
                If row.Cells(12).Value < row.Cells(13).Value Then
                    MsgBox("Warning : Some JIT Qty Excess ?", vbExclamation, pro_title)
                    Return
                Else
                    If row.Cells(13).Value = String.Empty Then
                        MsgBox("Warning : Some JIT Qty Missing ?", vbExclamation, pro_title)
                        Return
                    Else
                        frm_checklist.DataGridView1.Rows.Add(frm_checklist.DataGridView1.Rows.Count + 1, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(8).Value, row.Cells(9).Value, row.Cells(10).Value, row.Cells(11).Value, row.Cells(12).Value, row.Cells(13).Value)
                    End If
                End If
            End If

        Next
        frm_checklist.ShowDialog()
        Load_JITDate()
    End Sub
    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Hide()
    End Sub
End Class