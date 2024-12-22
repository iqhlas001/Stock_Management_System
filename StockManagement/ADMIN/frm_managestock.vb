Imports MySql.Data.MySqlClient
Public Class frm_managestock
    Private Sub frm_managestock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()
        DataGridView1.RowTemplate.Height = 27
        load_stockdata()
    End Sub
    Sub load_stockdata()
        DataGridView1.Rows.Clear()
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT * FROM `tblproducts` ", conn)
            dr = cmd.ExecuteReader()
            While dr.Read = True
                DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, dr.Item("partno").ToString, dr.Item("partname").ToString, dr.Item("group").ToString, dr.Item("uom").ToString, dr.Item("location").ToString, dr.Item("stock").ToString)

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
            cmd = New MySqlCommand("SELECT `partno`, `partname`, `group`, `uom`, `location` FROM `tblproducts` WHERE partno like '%" & txt_search.Text & "%' or partname like '%" & txt_search.Text & "%' or group like '%" & txt_search.Text & "%' uom like '%" & txt_search.Text & "%' location like '%" & txt_search.Text & "%'", conn)
            dr = cmd.ExecuteReader()
            While dr.Read = True
                DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, dr.Item("partno").ToString, dr.Item("partname").ToString, dr.Item("group").ToString, dr.Item("uom").ToString, dr.Item("location").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub btn_updatestock_Click(sender As Object, e As EventArgs) Handles btn_updatestock.Click
        Try
            conn.Open()
            For j As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
                cmd = New MySqlCommand("UPDATE `tblproducts` SET `stock`=@stock WHERE `partno`=@partno", conn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@stock", DataGridView1.Rows(j).Cells(6).Value)
                cmd.Parameters.AddWithValue("@partno", DataGridView1.Rows(j).Cells(1).Value)
                i = cmd.ExecuteNonQuery
            Next
            If i > 0 Then
                MsgBox("Product Update Success !", vbInformation)
            Else
                MsgBox("Product Update Failed !", vbInformation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
        load_stockdata()
    End Sub

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub
End Class