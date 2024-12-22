Imports MySql.Data.MySqlClient
Public Class frm_addgroup
    Private Sub frm_addgroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()
    End Sub
    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            conn.Open()
            cmd = New MySqlCommand("INSERT INTO `tblgroup`(`progroup`) VALUES (@progroup)", conn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@progroup", TextBox1.Text)
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MessageBox.Show("New Group Save Success !", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("New Group Save Failed !", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            TextBox1.Clear()
            TextBox1.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
        frm_ManageProducts.load_group()
    End Sub
End Class