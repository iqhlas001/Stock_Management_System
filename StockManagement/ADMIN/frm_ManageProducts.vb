Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Public Class frm_ManageProducts
    Private Sub frm_ManageProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()
        load_group()
        load_products()
    End Sub
    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub
    Public Sub load_group()
        cbo_group.Items.Clear()
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT * FROM `tblgroup`", conn)
            dr = cmd.ExecuteReader
            While dr.Read = True
                cbo_group.Items.Add(dr.GetString("progroup"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
    Public Sub load_products()
        DataGridView1.Rows.Clear()
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT `partno`, `partname`, `group`, `uom`, `location` FROM `tblproducts`", conn)
            dr = cmd.ExecuteReader()
            While dr.Read = True
                DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, dr.Item("partno").ToString, dr.Item("partname").ToString, dr.Item("group").ToString, dr.Item("uom").ToString, dr.Item("location").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
    Private Sub btn_addgroup_Click(sender As Object, e As EventArgs) Handles btn_addgroup.Click
        frm_addgroup.ShowDialog()
    End Sub
    Sub clear()
        txt_partno.Clear()
        txt_partname.Clear()
        txt_location.Clear()
        cbo_group.SelectedIndex = -1
        cbo_group.SelectedIndex = -1
    End Sub
    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        clear()
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim theText As String = txt_partno.Text
        If txt_partno.Text = String.Empty Or txt_partname.Text = String.Empty Or txt_location.Text = String.Empty Or cbo_group.Text = String.Empty Or cbo_uom.Text = String.Empty Then
            MessageBox.Show("Warnings : Required Missing Filed ?", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        Else
            Try
                conn.Open()
                ''Select a record from DB with existing partno
                cmd = New MySqlCommand("SELECT partno FROM tblproducts where partno=" + txt_partno.Text + "", conn)
                dr = cmd.ExecuteReader()
                Dim Dts As New DataTable
                Dts.Load(dr)
                If Dts.Rows.Count = 0 Then
                    Dim valueExistsInDB As Boolean = CBool(CInt(cmd.ExecuteScalar()) > 0)
                    cmd = New MySqlCommand("INSERT INTO `tblproducts`(`partno`, `partname`, `group`, `uom`, `location`) VALUES (@partno,@partname,@group,@uom,@location)", conn)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@partno", txt_partno.Text)
                    cmd.Parameters.AddWithValue("@partname", txt_partname.Text)
                    cmd.Parameters.AddWithValue("@group", cbo_group.Text)
                    cmd.Parameters.AddWithValue("@uom", cbo_uom.Text)
                    cmd.Parameters.AddWithValue("@location", txt_location.Text)
                    i = cmd.ExecuteNonQuery
                    If i > 0 Then
                        MessageBox.Show("New Product Save Success !", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("New Product Save Failed !", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    End If
                Else
                    MessageBox.Show("Product Already Exists !", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            conn.Close()
            clear()
            load_products()
        End If
    End Sub
    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs)
        DataGridView1.Rows.Clear()
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT `partno`, `partname`, `group`, `uom`, `location` FROM `tblproducts` WHERE partno like '%" & txt_search.Text & "%' or partname like '%" & txt_search.Text & "%' or group like '%" & txt_search.Text & "%' or uom like '%" & txt_search.Text & "%' or location like '%" & txt_search.Text & "%' ", conn)
            dr = cmd.ExecuteReader()
            While dr.Read = True
                DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, dr.Item("partno").ToString, dr.Item("partname").ToString, dr.Item("group").ToString, dr.Item("uom").ToString, dr.Item("location").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
    Private Sub DataGridView1_CellContentClick1(sender As Object, e As DataGridViewCellEventArgs)
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "Column7" Then
            Try
                conn.Open()
                cmd = New MySqlCommand("UPDATE `tblproducts` SET `partname`=@partname,`group`=@group,`uom`=@uom,`location`=@location WHERE `partno`=@partno", conn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@partname", DataGridView1.CurrentRow.Cells(2).Value.ToString + 1)
                cmd.Parameters.AddWithValue("@group", DataGridView1.CurrentRow.Cells(3).Value.ToString + 1)
                cmd.Parameters.AddWithValue("@uom", DataGridView1.CurrentRow.Cells(4).Value.ToString + 1)
                cmd.Parameters.AddWithValue("@location", DataGridView1.CurrentRow.Cells(5).Value.ToString + 1)
                cmd.Parameters.AddWithValue("@partno", DataGridView1.CurrentRow.Cells(1).Value.ToString + 1)
                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MessageBox.Show("Product update Success !", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Product update Failed !", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            conn.Close()
            load_products()
        End If
        If colName = "Column8" Then
            If MsgBox("Are You Suru Delete This Product ?", vbQuestion + vbYesNo) = vbYes Then
                Try
                    conn.Open()
                    cmd = New MySqlCommand("DELETE FROM tblproducts WHERE partno=@partno", conn)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@partno", DataGridView1.CurrentRow.Cells(1).Value.ToString)
                    i = cmd.ExecuteNonQuery
                    If i > 0 Then
                        MessageBox.Show("Product Delete Success !", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Product Delete Failed !", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try
                conn.Close()
                load_products()
            Else
                Return
            End If
        End If
    End Sub
    Private Sub txt_partno_TextChanged(sender As Object, e As EventArgs) Handles txt_partno.TextChanged
        Dim charAllowed As String = "1234567890"

        Dim theText As String = txt_partno.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txt_partno.SelectionStart
        Dim Change As Integer
        For x As Integer = 0 To txt_partno.Text.Length - 1
            Letter = txt_partno.Text.Substring(x, 1)
            If charAllowed.Contains(Letter) = False Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next
        txt_partno.Text = theText
        txt_partno.Select(SelectionIndex - Change, 0)
        txt_partno.Text = theText
        txt_partno.Select(SelectionIndex - Change, 0)
    End Sub
    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "Column7" Then
            Try
                conn.Open()
                cmd = New MySqlCommand("UPDATE `tblproducts` SET `partname`=@partname,`group`=@group,`uom`=@uom,`location`=@location WHERE `partno`=@partno", conn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@partname", DataGridView1.CurrentRow.Cells(2).Value.ToString)
                cmd.Parameters.AddWithValue("@group", DataGridView1.CurrentRow.Cells(3).Value.ToString)
                cmd.Parameters.AddWithValue("@uom", DataGridView1.CurrentRow.Cells(4).Value.ToString)
                cmd.Parameters.AddWithValue("@location", DataGridView1.CurrentRow.Cells(5).Value.ToString)
                cmd.Parameters.AddWithValue("@partno", DataGridView1.CurrentRow.Cells(1).Value.ToString)
                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MessageBox.Show("Product update Success !", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Product update Failed !", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            conn.Close()
            load_products()
        End If
        If colName = "Column8" Then
            If MsgBox("Are You Suru Delete This Product ?", vbQuestion + vbYesNo) = vbYes Then
                Try
                    conn.Open()
                    cmd = New MySqlCommand("DELETE FROM tblproducts WHERE partno=@partno", conn)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@partno", DataGridView1.CurrentRow.Cells(1).Value.ToString)
                    i = cmd.ExecuteNonQuery
                    If i > 0 Then
                        MessageBox.Show("Product Delete Success !", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Product Delete Failed !", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try
                conn.Close()
                load_products()
            Else
                Return
            End If
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub
End Class
