Imports MySql.Data.MySqlClient
Public Class frm_jitGenerate
    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub
    Private Sub frm_jitGenerate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()
        DataGridView1.RowTemplate.Height = 27
        load_jitgenerate()
    End Sub
    Sub load_jitgenerate()
        DataGridView1.Rows.Clear()
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT `partno`, `partname`, `group`, `uom`, `location` FROM `tblproducts`", conn)
            dr = cmd.ExecuteReader
            While dr.Read = True
                DataGridView1.Rows.Add(0, DataGridView1.Rows.Count + 1, dr.Item("partno").ToString, dr.Item("partname").ToString, dr.Item("group").ToString, dr.Item("uom").ToString, dr.Item("location").ToString)
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
            cmd = New MySqlCommand("SELECT `partno`, `partname`, `group`, `uom`, `location` FROM `tblproducts` WHERE partno like '%" & txt_search.Text & "%' or partname like '%" & txt_search.Text & "%' or group like '%" & txt_search.Text & "%'or location like '%" & txt_search.Text & "%'", conn)
            dr = cmd.ExecuteReader()
            While dr.Read = True
                DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, dr.Item("partno").ToString, dr.Item("partname").ToString, dr.Item("group").ToString, dr.Item("uom").ToString, dr.Item("location").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
    Private Sub btn_generate_Click(sender As Object, e As EventArgs) Handles btn_generate.Click
        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim selected As Boolean = Convert.ToBoolean(row.Cells("colCheck").Value)
            If selected = True Then
                If row.Cells(7).Value = String.Empty Then
                    MsgBox("Warning : Some JIT qty Missing ?", vbExclamation)
                    Return
                Else
                    frm_jitGenerateList.DataGridView1.Rows.Add(frm_jitGenerateList.DataGridView1.Rows.Count + 1, Date.Now.ToString("yyyyddmmss"), Date.Now.ToString("yyyy-MM-dd"), Date.Now.ToString("hh:mm:ss tt"), row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value)
                End If
                frm_jitGenerateList.TopLevel = False
                frm_ProductionMain.Panel3.Controls.Add(frm_jitGenerateList)
                frm_jitGenerateList.BringToFront()
                frm_jitGenerateList.Show()
            End If
        Next
        load_jitgenerate()
    End Sub
End Class