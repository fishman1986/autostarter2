namespace AutoStarter
{
    partial class frmMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("保存的命令(双击打开)");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("常用命令");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("所有命令包", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tvMain = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxCommand = new AutoStarter.CommandTextBox();
            this.pnlWebSites = new System.Windows.Forms.Panel();
            this.btnRestartTomcat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCommand = new System.Windows.Forms.Label();
            this.tbxConsole = new System.Windows.Forms.RichTextBox();
            this.cmsWebSite = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开WebToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSearchBackendError = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCompare = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUseLocalOrRemote = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.cmsWebSite.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbxConsole);
            this.splitContainer1.Size = new System.Drawing.Size(802, 435);
            this.splitContainer1.SplitterDistance = 191;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvMain);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.tbxCommand);
            this.splitContainer2.Panel2.Controls.Add(this.pnlWebSites);
            this.splitContainer2.Panel2.Controls.Add(this.btnRestartTomcat);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.btnRestart);
            this.splitContainer2.Panel2.Controls.Add(this.btnSave);
            this.splitContainer2.Panel2.Controls.Add(this.lblCommand);
            this.splitContainer2.Size = new System.Drawing.Size(802, 191);
            this.splitContainer2.SplitterDistance = 195;
            this.splitContainer2.TabIndex = 0;
            // 
            // tvMain
            // 
            this.tvMain.ContextMenuStrip = this.contextMenuStrip1;
            this.tvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMain.FullRowSelect = true;
            this.tvMain.Location = new System.Drawing.Point(0, 0);
            this.tvMain.Name = "tvMain";
            treeNode1.Name = "batSaved";
            treeNode1.Text = "保存的命令(双击打开)";
            treeNode2.Name = "batCommon";
            treeNode2.Text = "常用命令";
            treeNode3.Name = "节点0";
            treeNode3.Text = "所有命令包";
            this.tvMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.tvMain.Size = new System.Drawing.Size(195, 191);
            this.tvMain.TabIndex = 1;
            this.tvMain.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvMain_NodeMouseClick);
            this.tvMain.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvMain_NodeMouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(525, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "←试试右键";
            // 
            // tbxCommand
            // 
            this.tbxCommand.Location = new System.Drawing.Point(41, 5);
            this.tbxCommand.Multiline = true;
            this.tbxCommand.Name = "tbxCommand";
            this.tbxCommand.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxCommand.Size = new System.Drawing.Size(550, 92);
            this.tbxCommand.TabIndex = 22;
            this.tbxCommand.Run += new System.EventHandler(this.tbxCommand_Run);
            this.tbxCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCommand_KeyDown);
            this.tbxCommand.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxCommand_KeyUp);
            // 
            // pnlWebSites
            // 
            this.pnlWebSites.Location = new System.Drawing.Point(10, 132);
            this.pnlWebSites.Name = "pnlWebSites";
            this.pnlWebSites.Size = new System.Drawing.Size(519, 25);
            this.pnlWebSites.TabIndex = 21;
            // 
            // btnRestartTomcat
            // 
            this.btnRestartTomcat.Location = new System.Drawing.Point(10, 163);
            this.btnRestartTomcat.Name = "btnRestartTomcat";
            this.btnRestartTomcat.Size = new System.Drawing.Size(75, 21);
            this.btnRestartTomcat.TabIndex = 18;
            this.btnRestartTomcat.Text = "重启Tomcat";
            this.btnRestartTomcat.UseVisualStyleBackColor = true;
            this.btnRestartTomcat.Click += new System.EventHandler(this.btnRestartTomcat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(502, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ctrl+Enter运行";
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(139, 105);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 21);
            this.btnRestart.TabIndex = 4;
            this.btnRestart.Text = "重启程序";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(44, 105);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 21);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "←保存命令(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCommand
            // 
            this.lblCommand.AutoSize = true;
            this.lblCommand.Location = new System.Drawing.Point(3, 8);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(35, 12);
            this.lblCommand.TabIndex = 1;
            this.lblCommand.Text = "命令:";
            // 
            // tbxConsole
            // 
            this.tbxConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxConsole.Location = new System.Drawing.Point(0, 0);
            this.tbxConsole.Name = "tbxConsole";
            this.tbxConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbxConsole.Size = new System.Drawing.Size(802, 240);
            this.tbxConsole.TabIndex = 1;
            this.tbxConsole.Text = "";
            // 
            // cmsWebSite
            // 
            this.cmsWebSite.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开WebToolStripMenuItem,
            this.tsmiSearchBackendError,
            this.tsmiDelete,
            this.tsmiBackup,
            this.tsmiCompare,
            this.tsmiUseLocalOrRemote});
            this.cmsWebSite.Name = "contextMenuStrip1";
            this.cmsWebSite.Size = new System.Drawing.Size(151, 136);
            this.cmsWebSite.Opening += new System.ComponentModel.CancelEventHandler(this.cmsWebSite_Opening);
            // 
            // 打开WebToolStripMenuItem
            // 
            this.打开WebToolStripMenuItem.Name = "打开WebToolStripMenuItem";
            this.打开WebToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.打开WebToolStripMenuItem.Text = "打开Web目录";
            this.打开WebToolStripMenuItem.Click += new System.EventHandler(this.打开WebToolStripMenuItem_Click);
            // 
            // tsmiSearchBackendError
            // 
            this.tsmiSearchBackendError.Name = "tsmiSearchBackendError";
            this.tsmiSearchBackendError.Size = new System.Drawing.Size(150, 22);
            this.tsmiSearchBackendError.Text = "查找后端异常";
            this.tsmiSearchBackendError.Click += new System.EventHandler(this.tsmiSearchBackendError_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(150, 22);
            this.tsmiDelete.Text = "删除";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiBackup
            // 
            this.tsmiBackup.Name = "tsmiBackup";
            this.tsmiBackup.Size = new System.Drawing.Size(150, 22);
            this.tsmiBackup.Text = "备份远程连接";
            this.tsmiBackup.Click += new System.EventHandler(this.tsmiBackup_Click);
            // 
            // tsmiCompare
            // 
            this.tsmiCompare.Name = "tsmiCompare";
            this.tsmiCompare.Size = new System.Drawing.Size(150, 22);
            this.tsmiCompare.Text = "对比连接文件";
            this.tsmiCompare.Click += new System.EventHandler(this.tsmiCompare_Click);
            // 
            // tsmiUseLocalOrRemote
            // 
            this.tsmiUseLocalOrRemote.Name = "tsmiUseLocalOrRemote";
            this.tsmiUseLocalOrRemote.Size = new System.Drawing.Size(150, 22);
            this.tsmiUseLocalOrRemote.Text = "使用连接";
            this.tsmiUseLocalOrRemote.Click += new System.EventHandler(this.tsmiUseLocalOrRemote_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 435);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMain";
            this.Text = "超级控制台";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.cmsWebSite.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.RichTextBox tbxConsole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Button btnRestartTomcat;
        private System.Windows.Forms.Panel pnlWebSites;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip cmsWebSite;
        private System.Windows.Forms.ToolStripMenuItem 打开WebToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearchBackendError;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiBackup;
        private System.Windows.Forms.ToolStripMenuItem tsmiCompare;
        private System.Windows.Forms.ToolStripMenuItem tsmiUseLocalOrRemote;
        public CommandTextBox tbxCommand;
    }
}

