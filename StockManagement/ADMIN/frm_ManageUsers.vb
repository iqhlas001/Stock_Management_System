Imports MySql.Data.MySqlClient
Public Class frm_ManageUsers
    Private Sub frm_ManageUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()
    End Sub
    Private Sub btn_login_Click(sender As Object, e As EventArgs)
        Me.Hide()
        frm_login.Show()
    End Sub
    Sub clear()
        txt_name.Clear()
        txt_password.Clear()
        txt_username.Clear()
        cbo_role.SelectedIndex = -1
    End Sub
    Private Sub btn_register_Click(sender As Object, e As EventArgs) Handles btn_register.Click
        Try
            conn.Open()
            cmd = New MySqlCommand("INSERT INTO `tbluser`(`name`, `username`, `password`, `role`) VALUES (@name,@username,@password,@role)", conn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@name", txt_name.Text)
            cmd.Parameters.AddWithValue("@username", txt_username.Text)
            cmd.Parameters.AddWithValue("password", txt_password.Text)
            cmd.Parameters.AddWithValue("role", cbo_role.Text)
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MessageBox.Show("New User Register Success !", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("New User Register Failed !", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
        clear()
    End Sub
    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Hide()
    End Sub
End Class

