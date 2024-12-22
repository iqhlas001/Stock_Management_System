Imports MySql.Data.MySqlClient
Public Class frm_jitGenerateList
    Private Sub frm_jitGenerateList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()
        lbl_transactiondate.Text = Date.Now.ToString("yyyy-MM-dd")
        Auto_requestno()
    End Sub
    Sub Auto_requestno()
        lbl_taransactionno.Text = ""
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT * FROM `tbljit` order by id desc", conn)
            dr = cmd.ExecuteReader()
            dr.Read()
            If dr.HasRows Then
                lbl_taransactionno.Text = dr.Item("requestno").ToString
            Else
                lbl_taransactionno.Text = Date.Now.ToString("yyyyMM") & "001"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub
    Private Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
        Try
            conn.Open()
            cmd = New MySqlCommand("INSERT INTO `tbljit`(`requestno`, `requestdate`, `jitno`, `jitdate`, `jittime`, `partno`, `partname`, `group`, `uom`, `location`, `jitqty`) VALUES (@requestno,@requestdate,@jitno,@jitdate,@jittime,@partno,@partname,@group,@uom,@location,@jitqty)", conn)
            For j As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@requestno", lbl_transactiondate.Text)
                cmd.Parameters.AddWithValue("@requestdate", CDate(lbl_transactiondate.Text))
                cmd.Parameters.AddWithValue("@jitno", DataGridView1.Rows(j).Cells(1).Value)
                cmd.Parameters.AddWithValue("@jitdate", DataGridView1.Rows(j).Cells(2).Value)
                cmd.Parameters.AddWithValue("@jittime", DataGridView1.Rows(j).Cells(3).Value)
                cmd.Parameters.AddWithValue("@partno", DataGridView1.Rows(j).Cells(4).Value)
                cmd.Parameters.AddWithValue("@partname", DataGridView1.Rows(j).Cells(5).Value)
                cmd.Parameters.AddWithValue("@group", DataGridView1.Rows(j).Cells(6).Value)
                cmd.Parameters.AddWithValue("@uom", DataGridView1.Rows(j).Cells(7).Value)
                cmd.Parameters.AddWithValue("@location", DataGridView1.Rows(j).Cells(8).Value)
                cmd.Parameters.AddWithValue("@jitqty", DataGridView1.Rows(j).Cells(9).Value)
                i = cmd.ExecuteNonQuery()

            Next
            If i > 0 Then
                MsgBox(" JIT Generate Success !" & vbNewLine & "JIT NO:" & lbl_taransactionno.Text, vbInformation)
            Else
                MsgBox("JIT generate Failed !", vbExclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        frm_reportviewer.TopLevel = False
        frm_ProductionMain.Panel3.Controls.Add(frm_reportviewer)
        frm_reportviewer.BringToFront()
        frm_reportviewer.Show()
        conn.Close()
        Auto_requestno()
        DataGridView1.Rows.Clear()
    End Sub
End Class