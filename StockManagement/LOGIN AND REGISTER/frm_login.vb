Imports MySql.Data.MySqlClient
Public Class frm_login
    Private Sub frm_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()
    End Sub
    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        If MsgBox("Are You Sure Exit ?", vbQuestion + vbYesNo) = vbYes Then
            Application.Exit()
        Else
            Return
        End If
    End Sub
    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        If txt_username.Text = String.Empty Or txt_password.Text = String.Empty Then
            MessageBox.Show("Warning : Required Missing Field ?", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return
        Else
            Try
                conn.Open()
                cmd = New MySqlCommand("SELECT * FROM `tbluser` WHERE username=@username", conn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@username", txt_username.Text)
                Dim da As New MySqlDataAdapter
                Dim dt As New DataTable
                da.SelectCommand = cmd
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    cmd = New MySqlCommand("SELECT * FROM `tbluser` WHERE username=@username and password=@password", conn)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@username", txt_username.Text)
                    cmd.Parameters.AddWithValue("@password", txt_password.Text)
                    dr = cmd.ExecuteReader
                    If dr.read = True Then
                        Dim name As String = dr.Item("name").ToString
                        Dim username As String = dr.Item("username").ToString
                        Dim password As String = dr.Item("password").ToString
                        Dim role As String = dr.Item("role").ToString
                        conn.Close()
                        If UCase(role) = "ADMIN" Then
                            Me.Hide()
                            frm_AdminMain.Show()
                        ElseIf UCase(role) = "PRODUCTION" Then
                            Me.Hide()
                            frm_ProductionMain.Show()
                        ElseIf UCase(role) = "STORE" Then
                            Me.Hide()
                            frm_StoreMain.Show()
                        End If
                    Else
                        MessageBox.Show("Warning : Username or Password Wrong ", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Warning : Required Missing Field ?", pro_title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
            conn.Close()
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        frm_register.Show()
    End Sub
End Class