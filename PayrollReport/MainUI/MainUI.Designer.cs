namespace MainUI
{
    partial class MainUI
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_menu = new System.Windows.Forms.Panel();
            this.btn_command = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.panel_table = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_last = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.txb_pager = new System.Windows.Forms.TextBox();
            this.btn_before = new System.Windows.Forms.Button();
            this.btn_firstPage = new System.Windows.Forms.Button();
            this.lbl_RecordCount = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel_command = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button11 = new System.Windows.Forms.Button();
            this.btn_shuaixuan = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_gangweizhiji = new System.Windows.Forms.Button();
            this.btn_suozaigangwei = new System.Windows.Forms.Button();
            this.btn_nianyue = new System.Windows.Forms.Button();
            this.btn_xiashudanwei = new System.Windows.Forms.Button();
            this.cmb_gangweizhiji = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_suozaigangwei = new System.Windows.Forms.ComboBox();
            this.cmb_nianyue = new System.Windows.Forms.ComboBox();
            this.cmb_xiashudanwei = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_menu.SuspendLayout();
            this.panel_table.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_command.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_menu
            // 
            this.panel_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_menu.Controls.Add(this.btn_command);
            this.panel_menu.Controls.Add(this.btn_export);
            this.panel_menu.Controls.Add(this.btn_import);
            this.panel_menu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_menu.Location = new System.Drawing.Point(0, 0);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(984, 67);
            this.panel_menu.TabIndex = 0;
            // 
            // btn_command
            // 
            this.btn_command.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_command.FlatAppearance.BorderSize = 0;
            this.btn_command.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_command.Image = global::MainUI.Properties.Resources.search_folder;
            this.btn_command.Location = new System.Drawing.Point(172, 0);
            this.btn_command.Name = "btn_command";
            this.btn_command.Size = new System.Drawing.Size(74, 64);
            this.btn_command.TabIndex = 4;
            this.btn_command.Text = "筛选";
            this.btn_command.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_command.UseVisualStyleBackColor = true;
            this.btn_command.Click += new System.EventHandler(this.btn_command_Click);
            // 
            // btn_export
            // 
            this.btn_export.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_export.FlatAppearance.BorderSize = 0;
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export.Image = global::MainUI.Properties.Resources.export__1_;
            this.btn_export.Location = new System.Drawing.Point(92, 0);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(74, 64);
            this.btn_export.TabIndex = 3;
            this.btn_export.Text = "导出";
            this.btn_export.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_import
            // 
            this.btn_import.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_import.FlatAppearance.BorderSize = 0;
            this.btn_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_import.Image = global::MainUI.Properties.Resources.import__1_;
            this.btn_import.Location = new System.Drawing.Point(12, 0);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(74, 64);
            this.btn_import.TabIndex = 2;
            this.btn_import.Text = "导入";
            this.btn_import.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // panel_table
            // 
            this.panel_table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_table.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_table.Controls.Add(this.panel1);
            this.panel_table.Controls.Add(this.dataGridView1);
            this.panel_table.Location = new System.Drawing.Point(0, 70);
            this.panel_table.Name = "panel_table";
            this.panel_table.Size = new System.Drawing.Size(983, 349);
            this.panel_table.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_last);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.btn_next);
            this.panel1.Controls.Add(this.txb_pager);
            this.panel1.Controls.Add(this.btn_before);
            this.panel1.Controls.Add(this.btn_firstPage);
            this.panel1.Controls.Add(this.lbl_RecordCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 315);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(979, 30);
            this.panel1.TabIndex = 1;
            // 
            // btn_last
            // 
            this.btn_last.BackColor = System.Drawing.Color.Silver;
            this.btn_last.Location = new System.Drawing.Point(589, 4);
            this.btn_last.Name = "btn_last";
            this.btn_last.Size = new System.Drawing.Size(60, 23);
            this.btn_last.TabIndex = 11;
            this.btn_last.Text = "尾页";
            this.btn_last.UseVisualStyleBackColor = false;
            this.btn_last.Click += new System.EventHandler(this.btn_last_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(696, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "设置";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // btn_next
            // 
            this.btn_next.BackColor = System.Drawing.Color.Silver;
            this.btn_next.Location = new System.Drawing.Point(513, 4);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(60, 23);
            this.btn_next.TabIndex = 10;
            this.btn_next.Text = "下一页";
            this.btn_next.UseVisualStyleBackColor = false;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // txb_pager
            // 
            this.txb_pager.Location = new System.Drawing.Point(475, 5);
            this.txb_pager.Name = "txb_pager";
            this.txb_pager.Size = new System.Drawing.Size(22, 21);
            this.txb_pager.TabIndex = 3;
            this.txb_pager.TextChanged += new System.EventHandler(this.txb_pager_TextChanged);
            // 
            // btn_before
            // 
            this.btn_before.BackColor = System.Drawing.Color.Silver;
            this.btn_before.Location = new System.Drawing.Point(399, 4);
            this.btn_before.Name = "btn_before";
            this.btn_before.Size = new System.Drawing.Size(60, 23);
            this.btn_before.TabIndex = 2;
            this.btn_before.Text = "上一页";
            this.btn_before.UseVisualStyleBackColor = false;
            this.btn_before.Click += new System.EventHandler(this.btn_before_Click);
            // 
            // btn_firstPage
            // 
            this.btn_firstPage.BackColor = System.Drawing.Color.Silver;
            this.btn_firstPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_firstPage.Location = new System.Drawing.Point(322, 4);
            this.btn_firstPage.Name = "btn_firstPage";
            this.btn_firstPage.Size = new System.Drawing.Size(60, 23);
            this.btn_firstPage.TabIndex = 1;
            this.btn_firstPage.Text = "首页";
            this.btn_firstPage.UseVisualStyleBackColor = false;
            this.btn_firstPage.Click += new System.EventHandler(this.btn_firstPage_Click);
            // 
            // lbl_RecordCount
            // 
            this.lbl_RecordCount.AutoSize = true;
            this.lbl_RecordCount.Location = new System.Drawing.Point(35, 10);
            this.lbl_RecordCount.Name = "lbl_RecordCount";
            this.lbl_RecordCount.Size = new System.Drawing.Size(0, 12);
            this.lbl_RecordCount.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(983, 316);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel_command
            // 
            this.panel_command.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_command.Controls.Add(this.listView1);
            this.panel_command.Controls.Add(this.button11);
            this.panel_command.Controls.Add(this.btn_shuaixuan);
            this.panel_command.Controls.Add(this.button9);
            this.panel_command.Controls.Add(this.comboBox8);
            this.panel_command.Controls.Add(this.label8);
            this.panel_command.Controls.Add(this.button8);
            this.panel_command.Controls.Add(this.comboBox7);
            this.panel_command.Controls.Add(this.label7);
            this.panel_command.Controls.Add(this.button7);
            this.panel_command.Controls.Add(this.comboBox6);
            this.panel_command.Controls.Add(this.label6);
            this.panel_command.Controls.Add(this.button5);
            this.panel_command.Controls.Add(this.comboBox5);
            this.panel_command.Controls.Add(this.label5);
            this.panel_command.Controls.Add(this.btn_gangweizhiji);
            this.panel_command.Controls.Add(this.btn_suozaigangwei);
            this.panel_command.Controls.Add(this.btn_nianyue);
            this.panel_command.Controls.Add(this.btn_xiashudanwei);
            this.panel_command.Controls.Add(this.cmb_gangweizhiji);
            this.panel_command.Controls.Add(this.label4);
            this.panel_command.Controls.Add(this.cmb_suozaigangwei);
            this.panel_command.Controls.Add(this.cmb_nianyue);
            this.panel_command.Controls.Add(this.cmb_xiashudanwei);
            this.panel_command.Controls.Add(this.label3);
            this.panel_command.Controls.Add(this.label2);
            this.panel_command.Controls.Add(this.label1);
            this.panel_command.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_command.Location = new System.Drawing.Point(0, 425);
            this.panel_command.Name = "panel_command";
            this.panel_command.Size = new System.Drawing.Size(984, 136);
            this.panel_command.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(545, 15);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(217, 101);
            this.listView1.TabIndex = 28;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // button11
            // 
            this.button11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button11.Location = new System.Drawing.Point(805, 78);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 26;
            this.button11.Text = "复原";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_shuaixuan
            // 
            this.btn_shuaixuan.Location = new System.Drawing.Point(805, 30);
            this.btn_shuaixuan.Name = "btn_shuaixuan";
            this.btn_shuaixuan.Size = new System.Drawing.Size(75, 23);
            this.btn_shuaixuan.TabIndex = 25;
            this.btn_shuaixuan.Text = "筛选";
            this.btn_shuaixuan.UseVisualStyleBackColor = true;
            this.btn_shuaixuan.Click += new System.EventHandler(this.btn_shuaixuan_Click);
            // 
            // button9
            // 
            this.button9.Image = global::MainUI.Properties.Resources._103;
            this.button9.Location = new System.Drawing.Point(480, 93);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(38, 23);
            this.button9.TabIndex = 24;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // comboBox8
            // 
            this.comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(353, 94);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(121, 20);
            this.comboBox8.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(294, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "条件4：";
            // 
            // button8
            // 
            this.button8.Image = global::MainUI.Properties.Resources._103;
            this.button8.Location = new System.Drawing.Point(480, 66);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(38, 23);
            this.button8.TabIndex = 21;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // comboBox7
            // 
            this.comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(353, 67);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(121, 20);
            this.comboBox7.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "条件3：";
            // 
            // button7
            // 
            this.button7.Image = global::MainUI.Properties.Resources._103;
            this.button7.Location = new System.Drawing.Point(480, 40);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(38, 23);
            this.button7.TabIndex = 18;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // comboBox6
            // 
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(353, 41);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(121, 20);
            this.comboBox6.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(294, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "条件2：";
            // 
            // button5
            // 
            this.button5.Image = global::MainUI.Properties.Resources._103;
            this.button5.Location = new System.Drawing.Point(480, 14);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(38, 23);
            this.button5.TabIndex = 15;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(353, 15);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 20);
            this.comboBox5.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "条件1：";
            // 
            // btn_gangweizhiji
            // 
            this.btn_gangweizhiji.Image = global::MainUI.Properties.Resources._103;
            this.btn_gangweizhiji.Location = new System.Drawing.Point(224, 92);
            this.btn_gangweizhiji.Name = "btn_gangweizhiji";
            this.btn_gangweizhiji.Size = new System.Drawing.Size(38, 23);
            this.btn_gangweizhiji.TabIndex = 12;
            this.btn_gangweizhiji.UseVisualStyleBackColor = true;
            this.btn_gangweizhiji.Click += new System.EventHandler(this.btn_gangweizhiji_Click);
            // 
            // btn_suozaigangwei
            // 
            this.btn_suozaigangwei.Image = global::MainUI.Properties.Resources._103;
            this.btn_suozaigangwei.Location = new System.Drawing.Point(224, 67);
            this.btn_suozaigangwei.Name = "btn_suozaigangwei";
            this.btn_suozaigangwei.Size = new System.Drawing.Size(38, 23);
            this.btn_suozaigangwei.TabIndex = 11;
            this.btn_suozaigangwei.UseVisualStyleBackColor = true;
            this.btn_suozaigangwei.Click += new System.EventHandler(this.btn_suozaigangwei_Click);
            // 
            // btn_nianyue
            // 
            this.btn_nianyue.Image = global::MainUI.Properties.Resources._103;
            this.btn_nianyue.Location = new System.Drawing.Point(224, 39);
            this.btn_nianyue.Name = "btn_nianyue";
            this.btn_nianyue.Size = new System.Drawing.Size(38, 23);
            this.btn_nianyue.TabIndex = 10;
            this.btn_nianyue.UseVisualStyleBackColor = true;
            this.btn_nianyue.Click += new System.EventHandler(this.btn_nianyue_Click);
            // 
            // btn_xiashudanwei
            // 
            this.btn_xiashudanwei.Image = global::MainUI.Properties.Resources._103;
            this.btn_xiashudanwei.Location = new System.Drawing.Point(224, 15);
            this.btn_xiashudanwei.Name = "btn_xiashudanwei";
            this.btn_xiashudanwei.Size = new System.Drawing.Size(38, 23);
            this.btn_xiashudanwei.TabIndex = 9;
            this.btn_xiashudanwei.UseVisualStyleBackColor = true;
            this.btn_xiashudanwei.Click += new System.EventHandler(this.btn_xiashudanwei_Click);
            // 
            // cmb_gangweizhiji
            // 
            this.cmb_gangweizhiji.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_gangweizhiji.FormattingEnabled = true;
            this.cmb_gangweizhiji.Location = new System.Drawing.Point(97, 93);
            this.cmb_gangweizhiji.Name = "cmb_gangweizhiji";
            this.cmb_gangweizhiji.Size = new System.Drawing.Size(121, 20);
            this.cmb_gangweizhiji.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "岗位职级：";
            // 
            // cmb_suozaigangwei
            // 
            this.cmb_suozaigangwei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_suozaigangwei.FormattingEnabled = true;
            this.cmb_suozaigangwei.Location = new System.Drawing.Point(97, 67);
            this.cmb_suozaigangwei.Name = "cmb_suozaigangwei";
            this.cmb_suozaigangwei.Size = new System.Drawing.Size(121, 20);
            this.cmb_suozaigangwei.TabIndex = 5;
            // 
            // cmb_nianyue
            // 
            this.cmb_nianyue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_nianyue.FormattingEnabled = true;
            this.cmb_nianyue.Location = new System.Drawing.Point(97, 41);
            this.cmb_nianyue.Name = "cmb_nianyue";
            this.cmb_nianyue.Size = new System.Drawing.Size(121, 20);
            this.cmb_nianyue.TabIndex = 4;
            // 
            // cmb_xiashudanwei
            // 
            this.cmb_xiashudanwei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xiashudanwei.FormattingEnabled = true;
            this.cmb_xiashudanwei.Location = new System.Drawing.Point(97, 15);
            this.cmb_xiashudanwei.Name = "cmb_xiashudanwei";
            this.cmb_xiashudanwei.Size = new System.Drawing.Size(121, 20);
            this.cmb_xiashudanwei.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "所在岗位：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "年月：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "下属单位：";
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel_command);
            this.Controls.Add(this.panel_table);
            this.Controls.Add(this.panel_menu);
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工资报表统计系统";
            this.panel_menu.ResumeLayout(false);
            this.panel_table.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_command.ResumeLayout(false);
            this.panel_command.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_menu;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_command;
        private System.Windows.Forms.Panel panel_table;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel_command;
        private System.Windows.Forms.ComboBox cmb_gangweizhiji;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_suozaigangwei;
        private System.Windows.Forms.ComboBox cmb_nianyue;
        private System.Windows.Forms.ComboBox cmb_xiashudanwei;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_xiashudanwei;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txb_pager;
        private System.Windows.Forms.Button btn_before;
        private System.Windows.Forms.Button btn_firstPage;
        private System.Windows.Forms.Label lbl_RecordCount;
        private System.Windows.Forms.Button btn_last;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_gangweizhiji;
        private System.Windows.Forms.Button btn_suozaigangwei;
        private System.Windows.Forms.Button btn_nianyue;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button btn_shuaixuan;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listView1;
    }
}

