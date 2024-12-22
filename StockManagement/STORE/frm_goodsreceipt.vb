Imports MySql.Data.MySqlClient
Public Class frm_goodsreceipt
    Private Sub frm_goodsreceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dbconn()
        DataGridView1.RowTemplate.Height = 27
        Load_supplier()
        Auto_GRNno()
        Load_partname()
    End Sub
    Sub Load_supplier()
        cbo_suppliername.Items.Clear()
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT * FROM `tblsupplier`", conn)
            dr = cmd.ExecuteReader
            While dr.Read = True
                cbo_suppliername.Items.Add(dr.GetString("suppliername"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
    Sub Auto_GRNno()
        txt_grnno.Clear()
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT * FROM `tblgoodsreceipt` order by id desc", conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows = True Then
                txt_grnno.Text = dr.Item("grnno") + 1
            Else
                txt_grnno.Text = Date.Now.ToString("yyyyMM") & "001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
    Sub Load_partname()
        Try
            conn.Open()
            Dim da As New MySqlDataAdapter("SELECT `partname` FROM `tblproducts`", conn)
            Dim dt As New DataTable
            Dim ds As New DataSet
            ds.Tables.Add(dt)
            da.Fill(dt)
            Dim r As DataRow
            txt_partname.AutoCompleteCustomSource.Clear()
            For Each r In dt.Rows
                txt_partname.AutoCompleteCustomSource.Add(r.Item("partname").ToString)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
    Private Sub txt_partname_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_partname.KeyDown
        If txt_partname.Text = String.Empty Then
            Return
        Else
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                txt_qty.Focus()
            End If
        End If
    End Sub
    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Hide()
    End Sub
    Sub Load_DatagridviewData()
        If cbo_suppliername.Text = String.Empty Then
            MsgBox("Warning : Required Supplier Name ?", vbExclamation)
            Return
        Else
            Dim exist As Boolean = False, numrow As Integer = 0, numtext As Integer
            For Each itm As DataGridViewRow In DataGridView1.Rows
                If itm.Cells(2).Value IsNot Nothing Then
                    If itm.Cells(1).Value.ToString = txt_partname.Text Or itm.Cells(2).Value.ToString = txt_partname.Text Then
                        exist = True
                        numrow = itm.Index
                        numtext = CInt(itm.Cells(6).Value)
                        Exit For
                    End If
                End If
            Next
            If exist = False Then
                Try
                    conn.Open()
                    cmd = New MySqlCommand("SELECT `partno`, `partname`, `group`, `uom`, `location` FROM `tblproducts` WHERE partname='" & txt_partname.Text & "' or partno='" & txt_partname.Text & "'", conn)
                    dr = cmd.ExecuteReader
                    While dr.Read = True
                        DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, dr.Item("partno"), dr.Item("partname"), dr.Item("group"), dr.Item("uom"), dr.Item("location"), txt_qty.Text)
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                conn.Close()
            Else
                DataGridView1.Rows(numrow).Cells(6).Value = CInt(txt_qty.Text) + numtext
            End If
        End If
    End Sub

    Private Sub txt_qty_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_qty.KeyDown
        If txt_qty.Text = String.Empty Then
            Return
        Else
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                Load_DatagridviewData()
                txt_partname.Clear()
                txt_qty.Clear()
                txt_partname.Focus()
            End If
        End If
    End Sub

    Private Sub btn_addsuppliers_Click(sender As Object, e As EventArgs) Handles btn_addsuppliers.Click
        frm_addsuppliers.ShowDialog()
    End Sub
    Sub clear()
        cbo_suppliername.SelectedIndex = -1
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            conn.Open()
            cmd = New MySqlCommand("INSERT INTO `tblgoodsreceipt`(`grnno`, `grndate`, `suppliername`, `partno`, `partname`, `group`, `uom`, `location`, `qty`) VALUES (@grnno,@grndate,@suppliername,@partno,@partname,@group,@uom,@location,@qty)", conn)

            For j As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@grnno", txt_grnno.Text)
                cmd.Parameters.AddWithValue("@grndate", CDate(dtp_grndate.Text))
                cmd.Parameters.AddWithValue("@suppliername", cbo_suppliername.Text)

                cmd.Parameters.AddWithValue("@partno", DataGridView1.Rows(j).Cells(1).Value)
                cmd.Parameters.AddWithValue("@partname", DataGridView1.Rows(j).Cells(2).Value)
                cmd.Parameters.AddWithValue("@group", DataGridView1.Rows(j).Cells(3).Value)
                cmd.Parameters.AddWithValue("@uom", DataGridView1.Rows(j).Cells(4).Value)
                cmd.Parameters.AddWithValue("@location", DataGridView1.Rows(j).Cells(5).Value)
                cmd.Parameters.AddWithValue("@qty", DataGridView1.Rows(j).Cells(6).Value)
                i = cmd.ExecuteNonQuery
            Next
            If i > 0 Then
                MsgBox("GRN Save Success !", vbInformation, pro_title)
            Else
                MsgBox("GRN Save Failed !", vbExclamation, pro_title)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
        Auto_GRNno()
        stock_update()
        clear()
    End Sub
    Sub stock_update()
        Try
            conn.Open()
            cmd = New MySqlCommand("UPDATE `tblproducts` SET `stock`=stock-@stock WHERE `partno`=@partno", conn)

            For j As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@stock", DataGridView1.Rows(j).Cells(6).Value)
                cmd.Parameters.AddWithValue("@partno", DataGridView1.Rows(j).Cells(1).Value)
                i = cmd.ExecuteNonQuery
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
End Class