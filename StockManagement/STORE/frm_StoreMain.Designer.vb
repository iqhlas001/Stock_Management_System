<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_StoreMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_logintime = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_userinfo = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_exit = New System.Windows.Forms.Button()
        Me.btn_report = New System.Windows.Forms.Button()
        Me.btn_jitissue = New System.Windows.Forms.Button()
        Me.btn_goodsreceipt = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_allstocks = New System.Windows.Forms.Button()
        Me.Search = New System.Windows.Forms.Label()
        Me.btn_criticalstocks = New System.Windows.Forms.Button()
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.btn_zerostocks = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lbl_logintime)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.lbl_userinfo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 821)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1450, 26)
        Me.Panel2.TabIndex = 3
        '
        'lbl_logintime
        '
        Me.lbl_logintime.AutoSize = True
        Me.lbl_logintime.Location = New System.Drawing.Point(159, 6)
        Me.lbl_logintime.Name = "lbl_logintime"
        Me.lbl_logintime.Size = New System.Drawing.Size(85, 17)
        Me.lbl_logintime.TabIndex = 4
        Me.lbl_logintime.Text = "Login User :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Login User :"
        '
        'lbl_userinfo
        '
        Me.lbl_userinfo.AutoSize = True
        Me.lbl_userinfo.Location = New System.Drawing.Point(98, 6)
        Me.lbl_userinfo.Name = "lbl_userinfo"
        Me.lbl_userinfo.Size = New System.Drawing.Size(51, 17)
        Me.lbl_userinfo.TabIndex = 2
        Me.lbl_userinfo.Text = "Label2"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btn_exit, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_report, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_jitissue, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_goodsreceipt, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(908, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(542, 66)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.SystemColors.Highlight
        Me.btn_exit.FlatAppearance.BorderSize = 0
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exit.ForeColor = System.Drawing.Color.Black
        Me.btn_exit.Location = New System.Drawing.Point(408, 3)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(129, 60)
        Me.btn_exit.TabIndex = 7
        Me.btn_exit.Text = "Logout"
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'btn_report
        '
        Me.btn_report.BackColor = System.Drawing.SystemColors.Highlight
        Me.btn_report.FlatAppearance.BorderSize = 0
        Me.btn_report.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_report.ForeColor = System.Drawing.Color.Black
        Me.btn_report.Location = New System.Drawing.Point(273, 3)
        Me.btn_report.Name = "btn_report"
        Me.btn_report.Size = New System.Drawing.Size(128, 60)
        Me.btn_report.TabIndex = 4
        Me.btn_report.Text = "Report"
        Me.btn_report.UseVisualStyleBackColor = False
        '
        'btn_jitissue
        '
        Me.btn_jitissue.BackColor = System.Drawing.SystemColors.Highlight
        Me.btn_jitissue.FlatAppearance.BorderSize = 0
        Me.btn_jitissue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_jitissue.ForeColor = System.Drawing.Color.Black
        Me.btn_jitissue.Location = New System.Drawing.Point(138, 3)
        Me.btn_jitissue.Name = "btn_jitissue"
        Me.btn_jitissue.Size = New System.Drawing.Size(128, 60)
        Me.btn_jitissue.TabIndex = 8
        Me.btn_jitissue.Text = "JIT Issue"
        Me.btn_jitissue.UseVisualStyleBackColor = False
        '
        'btn_goodsreceipt
        '
        Me.btn_goodsreceipt.BackColor = System.Drawing.SystemColors.Highlight
        Me.btn_goodsreceipt.FlatAppearance.BorderSize = 0
        Me.btn_goodsreceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_goodsreceipt.ForeColor = System.Drawing.Color.Black
        Me.btn_goodsreceipt.Location = New System.Drawing.Point(3, 3)
        Me.btn_goodsreceipt.Name = "btn_goodsreceipt"
        Me.btn_goodsreceipt.Size = New System.Drawing.Size(129, 60)
        Me.btn_goodsreceipt.TabIndex = 3
        Me.btn_goodsreceipt.Text = "Goods Receipt"
        Me.btn_goodsreceipt.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1450, 72)
        Me.Panel1.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(173, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "  Mangement System  "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Century", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(31, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 23)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "STOCK"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btn_allstocks)
        Me.Panel3.Controls.Add(Me.Search)
        Me.Panel3.Controls.Add(Me.btn_criticalstocks)
        Me.Panel3.Controls.Add(Me.txt_search)
        Me.Panel3.Controls.Add(Me.btn_zerostocks)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 72)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1450, 58)
        Me.Panel3.TabIndex = 6
        '
        'btn_allstocks
        '
        Me.btn_allstocks.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_allstocks.FlatAppearance.BorderSize = 0
        Me.btn_allstocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_allstocks.Location = New System.Drawing.Point(1003, 11)
        Me.btn_allstocks.Name = "btn_allstocks"
        Me.btn_allstocks.Size = New System.Drawing.Size(126, 32)
        Me.btn_allstocks.TabIndex = 5
        Me.btn_allstocks.Text = "ALL STOCK'S"
        Me.btn_allstocks.UseVisualStyleBackColor = False
        '
        'Search
        '
        Me.Search.AutoSize = True
        Me.Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search.Location = New System.Drawing.Point(26, 16)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(61, 18)
        Me.Search.TabIndex = 10
        Me.Search.Text = "Search"
        '
        'btn_criticalstocks
        '
        Me.btn_criticalstocks.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_criticalstocks.FlatAppearance.BorderSize = 0
        Me.btn_criticalstocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_criticalstocks.Location = New System.Drawing.Point(1152, 11)
        Me.btn_criticalstocks.Name = "btn_criticalstocks"
        Me.btn_criticalstocks.Size = New System.Drawing.Size(139, 32)
        Me.btn_criticalstocks.TabIndex = 6
        Me.btn_criticalstocks.Text = "CRITICAL STOCK"
        Me.btn_criticalstocks.UseVisualStyleBackColor = False
        '
        'txt_search
        '
        Me.txt_search.Location = New System.Drawing.Point(93, 14)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.Size = New System.Drawing.Size(182, 23)
        Me.txt_search.TabIndex = 9
        '
        'btn_zerostocks
        '
        Me.btn_zerostocks.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_zerostocks.FlatAppearance.BorderSize = 0
        Me.btn_zerostocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_zerostocks.Location = New System.Drawing.Point(1309, 11)
        Me.btn_zerostocks.Name = "btn_zerostocks"
        Me.btn_zerostocks.Size = New System.Drawing.Size(129, 32)
        Me.btn_zerostocks.TabIndex = 6
        Me.btn_zerostocks.Text = "ZERO STOCK'S"
        Me.btn_zerostocks.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 72)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1450, 749)
        Me.FlowLayoutPanel1.TabIndex = 5
        '
        'frm_StoreMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1450, 847)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_StoreMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_StoreMain"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lbl_logintime As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lbl_userinfo As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btn_exit As Button
    Friend WithEvents btn_goodsreceipt As Button
    Friend WithEvents btn_report As Button
    Friend WithEvents btn_jitissue As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txt_search As TextBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents btn_zerostocks As Button
    Friend WithEvents Search As Label
    Friend WithEvents btn_criticalstocks As Button
    Friend WithEvents btn_allstocks As Button
End Class
