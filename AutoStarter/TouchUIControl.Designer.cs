namespace AutoStarter
{
    partial class TouchUIControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbxPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxRestart = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuildAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.tbxConfigFiles = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.cbxProduction = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbxChangelist = new System.Windows.Forms.TextBox();
            this.btnPostReview = new System.Windows.Forms.Button();
            this.tvBackUpPaths = new System.Windows.Forms.TreeView();
            this.dgFiles = new System.Windows.Forms.DataGridView();
            this.clFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDirectory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGetLatest = new System.Windows.Forms.Button();
            this.dtLater = new System.Windows.Forms.DateTimePicker();
            this.btnBackUp = new System.Windows.Forms.Button();
            this.pnlWebSites = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbxKiwiAntCmd = new System.Windows.Forms.TextBox();
            this.button18 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button11 = new System.Windows.Forms.Button();
            this.tbxKiwiConfig = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(105, 24);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 21);
            this.button4.TabIndex = 10;
            this.button4.Text = "替换美国连接";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 21);
            this.button3.TabIndex = 9;
            this.button3.Text = "替换本地连接";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(112, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 21);
            this.button2.TabIndex = 8;
            this.button2.Text = "编译melon";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 21);
            this.button1.TabIndex = 7;
            this.button1.Text = "编译nephrite";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxPath
            // 
            this.tbxPath.Location = new System.Drawing.Point(50, 11);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.Size = new System.Drawing.Size(365, 21);
            this.tbxPath.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "目录";
            // 
            // cbxRestart
            // 
            this.cbxRestart.AutoSize = true;
            this.cbxRestart.Checked = true;
            this.cbxRestart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxRestart.Location = new System.Drawing.Point(6, 52);
            this.cbxRestart.Name = "cbxRestart";
            this.cbxRestart.Size = new System.Drawing.Size(132, 15);
            this.cbxRestart.TabIndex = 13;
            this.cbxRestart.Text = "替换完成重启Tomcat";
            this.cbxRestart.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuildAll);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(16, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 116);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "编译Melon";
            // 
            // btnBuildAll
            // 
            this.btnBuildAll.Location = new System.Drawing.Point(213, 26);
            this.btnBuildAll.Name = "btnBuildAll";
            this.btnBuildAll.Size = new System.Drawing.Size(86, 21);
            this.btnBuildAll.TabIndex = 10;
            this.btnBuildAll.Text = "一键Build";
            this.btnBuildAll.UseVisualStyleBackColor = true;
            this.btnBuildAll.Click += new System.EventHandler(this.btnBuildAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.tbxConfigFiles);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.cbxRestart);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(306, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 99);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "连接控制";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(140, 71);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(58, 21);
            this.button8.TabIndex = 17;
            this.button8.Text = "对比";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // tbxConfigFiles
            // 
            this.tbxConfigFiles.Location = new System.Drawing.Point(216, 18);
            this.tbxConfigFiles.Multiline = true;
            this.tbxConfigFiles.Name = "tbxConfigFiles";
            this.tbxConfigFiles.Size = new System.Drawing.Size(177, 76);
            this.tbxConfigFiles.TabIndex = 16;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 72);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(127, 21);
            this.button5.TabIndex = 14;
            this.button5.Text = "备份当前连接文件";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cbxProduction
            // 
            this.cbxProduction.AutoSize = true;
            this.cbxProduction.Location = new System.Drawing.Point(427, 14);
            this.cbxProduction.Name = "cbxProduction";
            this.cbxProduction.Size = new System.Drawing.Size(120, 16);
            this.cbxProduction.TabIndex = 9;
            this.cbxProduction.Text = "Production Build";
            this.cbxProduction.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 561);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(733, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel1.Text = "状态";
            // 
            // tsProgress
            // 
            this.tsProgress.Name = "tsProgress";
            this.tsProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 35);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 21);
            this.button6.TabIndex = 17;
            this.button6.Text = "重启Tomcat";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(632, 6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 21);
            this.button7.TabIndex = 18;
            this.button7.Text = "启动Weinre";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbxChangelist);
            this.groupBox3.Controls.Add(this.btnPostReview);
            this.groupBox3.Controls.Add(this.tvBackUpPaths);
            this.groupBox3.Location = new System.Drawing.Point(16, 403);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(136, 157);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "管理工作空间";
            // 
            // tbxChangelist
            // 
            this.tbxChangelist.Location = new System.Drawing.Point(227, 185);
            this.tbxChangelist.Name = "tbxChangelist";
            this.tbxChangelist.Size = new System.Drawing.Size(78, 21);
            this.tbxChangelist.TabIndex = 3;
            // 
            // btnPostReview
            // 
            this.btnPostReview.Location = new System.Drawing.Point(309, 183);
            this.btnPostReview.Name = "btnPostReview";
            this.btnPostReview.Size = new System.Drawing.Size(75, 21);
            this.btnPostReview.TabIndex = 2;
            this.btnPostReview.Text = "Post Review";
            this.btnPostReview.UseVisualStyleBackColor = true;
            this.btnPostReview.Click += new System.EventHandler(this.btnPostReview_Click);
            // 
            // tvBackUpPaths
            // 
            this.tvBackUpPaths.Location = new System.Drawing.Point(6, 18);
            this.tvBackUpPaths.Name = "tvBackUpPaths";
            this.tvBackUpPaths.Size = new System.Drawing.Size(121, 186);
            this.tvBackUpPaths.TabIndex = 1;
            // 
            // dgFiles
            // 
            this.dgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clFileName,
            this.clDirectory,
            this.clUpdateTime});
            this.dgFiles.Location = new System.Drawing.Point(173, 427);
            this.dgFiles.Name = "dgFiles";
            this.dgFiles.RowHeadersWidth = 16;
            this.dgFiles.RowTemplate.Height = 23;
            this.dgFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgFiles.Size = new System.Drawing.Size(558, 133);
            this.dgFiles.TabIndex = 6;
            // 
            // clFileName
            // 
            this.clFileName.DataPropertyName = "Name";
            this.clFileName.HeaderText = "FileName";
            this.clFileName.Name = "clFileName";
            // 
            // clDirectory
            // 
            this.clDirectory.DataPropertyName = "Directory";
            this.clDirectory.FillWeight = 200F;
            this.clDirectory.HeaderText = "Directory";
            this.clDirectory.Name = "clDirectory";
            this.clDirectory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clDirectory.Width = 200;
            // 
            // clUpdateTime
            // 
            this.clUpdateTime.DataPropertyName = "LastWriteTime";
            this.clUpdateTime.HeaderText = "UpdateTime";
            this.clUpdateTime.Name = "clUpdateTime";
            // 
            // btnGetLatest
            // 
            this.btnGetLatest.Location = new System.Drawing.Point(319, 403);
            this.btnGetLatest.Name = "btnGetLatest";
            this.btnGetLatest.Size = new System.Drawing.Size(35, 21);
            this.btnGetLatest.TabIndex = 5;
            this.btnGetLatest.Text = "R";
            this.btnGetLatest.UseVisualStyleBackColor = true;
            this.btnGetLatest.Click += new System.EventHandler(this.btnGetLatest_Click);
            // 
            // dtLater
            // 
            this.dtLater.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtLater.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLater.Location = new System.Drawing.Point(173, 403);
            this.dtLater.Name = "dtLater";
            this.dtLater.Size = new System.Drawing.Size(139, 21);
            this.dtLater.TabIndex = 4;
            // 
            // btnBackUp
            // 
            this.btnBackUp.Location = new System.Drawing.Point(358, 403);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(75, 21);
            this.btnBackUp.TabIndex = 0;
            this.btnBackUp.Text = "备份项目";
            this.btnBackUp.UseVisualStyleBackColor = true;
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // pnlWebSites
            // 
            this.pnlWebSites.Location = new System.Drawing.Point(218, 35);
            this.pnlWebSites.Name = "pnlWebSites";
            this.pnlWebSites.Size = new System.Drawing.Size(515, 25);
            this.pnlWebSites.TabIndex = 20;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbxKiwiAntCmd);
            this.groupBox4.Controls.Add(this.button18);
            this.groupBox4.Controls.Add(this.button17);
            this.groupBox4.Controls.Add(this.button16);
            this.groupBox4.Controls.Add(this.button15);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.Location = new System.Drawing.Point(16, 182);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(709, 216);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "编译kiwi";
            // 
            // tbxKiwiAntCmd
            // 
            this.tbxKiwiAntCmd.Location = new System.Drawing.Point(13, 115);
            this.tbxKiwiAntCmd.Multiline = true;
            this.tbxKiwiAntCmd.Name = "tbxKiwiAntCmd";
            this.tbxKiwiAntCmd.Size = new System.Drawing.Size(686, 80);
            this.tbxKiwiAntCmd.TabIndex = 22;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(13, 57);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(98, 21);
            this.button18.TabIndex = 20;
            this.button18.Text = "查看错误日志";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(213, 86);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(52, 21);
            this.button17.TabIndex = 19;
            this.button17.Text = "Build";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(98, 87);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(103, 21);
            this.button16.TabIndex = 18;
            this.button16.Text = "Sencha Refresh";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(13, 86);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 21);
            this.button15.TabIndex = 17;
            this.button15.Text = "备份项目";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button11);
            this.groupBox5.Controls.Add(this.tbxKiwiConfig);
            this.groupBox5.Controls.Add(this.button12);
            this.groupBox5.Controls.Add(this.checkBox1);
            this.groupBox5.Controls.Add(this.button13);
            this.groupBox5.Controls.Add(this.button14);
            this.groupBox5.Location = new System.Drawing.Point(300, 15);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(399, 99);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "连接控制";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(140, 71);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(58, 21);
            this.button11.TabIndex = 17;
            this.button11.Text = "对比";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // tbxKiwiConfig
            // 
            this.tbxKiwiConfig.Location = new System.Drawing.Point(216, 18);
            this.tbxKiwiConfig.Multiline = true;
            this.tbxKiwiConfig.Name = "tbxKiwiConfig";
            this.tbxKiwiConfig.Size = new System.Drawing.Size(177, 76);
            this.tbxKiwiConfig.TabIndex = 16;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(6, 72);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(127, 21);
            this.button12.TabIndex = 14;
            this.button12.Text = "备份当前连接文件";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(6, 52);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(132, 15);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "替换完成重启Tomcat";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(6, 24);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(93, 21);
            this.button13.TabIndex = 9;
            this.button13.Text = "替换本地连接";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(105, 24);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(93, 21);
            this.button14.TabIndex = 10;
            this.button14.Text = "替换美国连接";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(115, 18);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(86, 21);
            this.button10.TabIndex = 9;
            this.button10.Text = "编译Kiwi";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(13, 18);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(86, 21);
            this.button9.TabIndex = 8;
            this.button9.Text = "编译nephrite";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button1_Click);
            // 
            // TouchUIControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 583);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cbxProduction);
            this.Controls.Add(this.btnGetLatest);
            this.Controls.Add(this.dgFiles);
            this.Controls.Add(this.dtLater);
            this.Controls.Add(this.pnlWebSites);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnBackUp);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxPath);
            this.Name = "TouchUIControl";
            this.Text = "TouchUIControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TouchUIControl_FormClosing);
            this.Load += new System.EventHandler(this.TouchUIControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbxPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxRestart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox tbxConfigFiles;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBackUp;
        private System.Windows.Forms.TreeView tvBackUpPaths;
        private System.Windows.Forms.TextBox tbxChangelist;
        private System.Windows.Forms.Button btnPostReview;
        private System.Windows.Forms.DateTimePicker dtLater;
        private System.Windows.Forms.Button btnGetLatest;
        private System.Windows.Forms.DataGridView dgFiles;
        private System.Windows.Forms.CheckBox cbxProduction;
        private System.Windows.Forms.Button btnBuildAll;
        private System.Windows.Forms.ToolStripProgressBar tsProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDirectory;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUpdateTime;
        private System.Windows.Forms.Panel pnlWebSites;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox tbxKiwiConfig;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.TextBox tbxKiwiAntCmd;
    }
}