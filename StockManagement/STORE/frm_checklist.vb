Imports MySql.Data.MySqlClient
Public Class frm_checklist
    Private Sub frm_checklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()
        Auto_ISSUENO()
        lbl_issuedate.Text = Date.Now.ToString("yyyy-MM-dd")
    End Sub

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub
    Sub Auto_ISSUENO()
        lbl_issueno.Text = ""
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT issueno FROM `tblissue` ORDER BY ID DESC", conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                lbl_issueno.Text = dr.Item("issueno").ToString + 1
            Else
                lbl_issueNo.Text = Date.Now.ToString("yyyyMMdd") & "001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            conn.Open()
            For j As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
                cmd = New MySqlCommand("INSERT INTO `tblissue`(`issueno`, `issuedate`, `issuetime`, `requestno`, `requestdate`, `jitno`, `jitdate`, `jittime`, `partno`, `partname`, `group`, `uom`, `location`, `jitqty`, `issueqty`) VALUES (@issueno,@issuedate,@issuetime,@requestno,@requestdate,@jitno,@jitdate,@jittime,@partno,@partname,@group,@uom,@location,@jitqty,@issueqty)", conn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@issueno", lbl_issueno.Text)
                cmd.Parameters.AddWithValue("@issuedate", lbl_issuedate.Text)
                cmd.Parameters.AddWithValue("@issuetime", Date.Now.ToString("hh:mm:ss tt"))
                cmd.Parameters.AddWithValue("@requestno", DataGridView1.Rows(j).Cells(1).Value)
                cmd.Parameters.AddWithValue("@requestdate", DataGridView1.Rows(j).Cells(2).Value)
                cmd.Parameters.AddWithValue("@jitno", DataGridView1.Rows(j).Cells(3).Value)
                cmd.Parameters.AddWithValue("@jitdate", DataGridView1.Rows(j).Cells(4).Value)
                cmd.Parameters.AddWithValue("@jittime", DataGridView1.Rows(j).Cells(5).Value)
                cmd.Parameters.AddWithValue("@partno", DataGridView1.Rows(j).Cells(6).Value)
                cmd.Parameters.AddWithValue("@partname", DataGridView1.Rows(j).Cells(7).Value)
                cmd.Parameters.AddWithValue("@group", DataGridView1.Rows(j).Cells(8).Value)
                cmd.Parameters.AddWithValue("@uom", DataGridView1.Rows(j).Cells(9).Value)
                cmd.Parameters.AddWithValue("@location", DataGridView1.Rows(j).Cells(10).Value)
                cmd.Parameters.AddWithValue("@jitqty", DataGridView1.Rows(j).Cells(11).Value)
                cmd.Parameters.AddWithValue("@issueqty", DataGridView1.Rows(j).Cells(12).Value)
                i = cmd.ExecuteNonQuery

            Next
            If i > 0 Then
                MsgBox("Issue Save Success", vbInformation)
            Else
                MsgBox("Issue Save Faile", vbCritical)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
        update_jitdata()
        frm_jitissue.Load_JITDate()
        Auto_ISSUENO()
        DataGridView1.Rows.Clear()
    End Sub
    Sub update_jitdata()
        Try
            conn.Open()
            For j As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
                cmd = New MySqlCommand("UPDATE `tbljit` SET `jitqty`=@jitqty WHERE `partno`=@partno", conn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@partno", DataGridView1.Rows(j).Cells(6).Value)
                cmd.Parameters.AddWithValue("@jitqty", DataGridView1.Rows(j).Cells(12).Value)
                i = cmd.ExecuteNonQuery
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
    Sub Update_stockData()
        Try
            conn.Open()
            For j As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
                cmd = New MySqlCommand("UPDATE `tblproducts` SET `stock`=stock+@stock WHERE `partno`=@partno", conn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@partno", DataGridView1.Rows(j).Cells(6).Value)
                cmd.Parameters.AddWithValue("@stock", DataGridView1.Rows(j).Cells(12).Value)
                i = cmd.ExecuteNonQuery
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

End Class