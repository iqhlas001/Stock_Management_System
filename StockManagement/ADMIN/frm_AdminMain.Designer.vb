<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_AdminMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_exit = New System.Windows.Forms.Button()
        Me.btn_manageproducts = New System.Windows.Forms.Button()
        Me.btn_report = New System.Windows.Forms.Button()
        Me.btn_managestock = New System.Windows.Forms.Button()
        Me.btn_manageusers = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_userinfo = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(179, 800)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Impact", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(22, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 18)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "................................"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btn_exit, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_manageproducts, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_report, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_managestock, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_manageusers, 0, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 95)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(179, 254)
        Me.TableLayoutPanel1.TabIndex = 8
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.SystemColors.Highlight
        Me.btn_exit.FlatAppearance.BorderSize = 0
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exit.Location = New System.Drawing.Point(3, 203)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(173, 48)
        Me.btn_exit.TabIndex = 7
        Me.btn_exit.Text = "Logout"
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'btn_manageproducts
        '
        Me.btn_manageproducts.BackColor = System.Drawing.SystemColors.Highlight
        Me.btn_manageproducts.FlatAppearance.BorderSize = 0
        Me.btn_manageproducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_manageproducts.Location = New System.Drawing.Point(3, 3)
        Me.btn_manageproducts.Name = "btn_manageproducts"
        Me.btn_manageproducts.Size = New System.Drawing.Size(173, 44)
        Me.btn_manageproducts.TabIndex = 2
        Me.btn_manageproducts.Text = "Manage products"
        Me.btn_manageproducts.UseVisualStyleBackColor = False
        '
        'btn_report
        '
        Me.btn_report.BackColor = System.Drawing.SystemColors.Highlight
        Me.btn_report.FlatAppearance.BorderSize = 0
        Me.btn_report.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_report.Location = New System.Drawing.Point(3, 153)
        Me.btn_report.Name = "btn_report"
        Me.btn_report.Size = New System.Drawing.Size(173, 44)
        Me.btn_report.TabIndex = 6
        Me.btn_report.Text = "Report"
        Me.btn_report.UseVisualStyleBackColor = False
        '
        'btn_managestock
        '
        Me.btn_managestock.BackColor = System.Drawing.SystemColors.Highlight
        Me.btn_managestock.FlatAppearance.BorderSize = 0
        Me.btn_managestock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_managestock.Location = New System.Drawing.Point(3, 53)
        Me.btn_managestock.Name = "btn_managestock"
        Me.btn_managestock.Size = New System.Drawing.Size(173, 44)
        Me.btn_managestock.TabIndex = 3
        Me.btn_managestock.Text = "Manage Stock"
        Me.btn_managestock.UseVisualStyleBackColor = False
        '
        'btn_manageusers
        '
        Me.btn_manageusers.BackColor = System.Drawing.SystemColors.Highlight
        Me.btn_manageusers.FlatAppearance.BorderSize = 0
        Me.btn_manageusers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_manageusers.Location = New System.Drawing.Point(3, 103)
        Me.btn_manageusers.Name = "btn_manageusers"
        Me.btn_manageusers.Size = New System.Drawing.Size(173, 44)
        Me.btn_manageusers.TabIndex = 4
        Me.btn_manageusers.Text = "Manage Users"
        Me.btn_manageusers.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Century", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(42, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 23)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "STOCK"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(173, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "  Mangement System  "
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lbl_userinfo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(179, 777)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1271, 23)
        Me.Panel2.TabIndex = 1
        '
        'lbl_userinfo
        '
        Me.lbl_userinfo.AutoSize = True
        Me.lbl_userinfo.Location = New System.Drawing.Point(3, 8)
        Me.lbl_userinfo.Name = "lbl_userinfo"
        Me.lbl_userinfo.Size = New System.Drawing.Size(74, 17)
        Me.lbl_userinfo.TabIndex = 2
        Me.lbl_userinfo.Text = "User Info"
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(179, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1271, 777)
        Me.Panel3.TabIndex = 2
        '
        'frm_AdminMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1450, 800)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "frm_AdminMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_AdminMain"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btn_manageproducts As Button
    Friend WithEvents btn_exit As Button
    Friend WithEvents btn_report As Button
    Friend WithEvents btn_managestock As Button
    Friend WithEvents btn_manageusers As Button
    Friend WithEvents lbl_userinfo As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
End Class
