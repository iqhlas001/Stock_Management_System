Imports MySql.Data.MySqlClient
Public Class frm_addsuppliers
    Private Sub frm_addsuppliers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            conn.Open()
            cmd = New MySqlCommand("INSERT INTO `tblsupplier`(`suppliername`) VALUES (@suppliername)", conn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@suppliername", txt_suppliername.Text)
            i = cmd.ExecuteNonQuery
            txt_suppliername.Clear()
            txt_suppliername.focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
        frm_goodsreceipt.Load_supplier()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub
End Class