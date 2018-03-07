using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using TomcatConfig.model;
using System.Xml;
using TomcatConfig;

namespace AutoStarter
{
    public partial class frmMain : Form
    {
        public string autoRunCmd = "";
        public frmMain()
        {
            InitializeComponent();
        }
        private Process mainCMD = null;//存放主CMD进程
        private void frmMain_Load(object sender, EventArgs e)
        {
            #region 启动CMD
            try
            {
                mainCMD = CommandHelper.createStandardProcess();

                // 异步获取命令行内容  
                mainCMD.BeginOutputReadLine();
                // 为异步获取订阅事件  
                mainCMD.OutputDataReceived += new DataReceivedEventHandler(mainCMD_OutputDataReceived);
            }
            catch (Exception exception)
            {
            }
            #endregion
            #region 加载历史命令包
            loadCommands();
            tvMain.ExpandAll();
            #endregion
            #region 自动运行
            if (!string.IsNullOrEmpty(this.autoRunCmd))
            {
                tbxCommand.Text = Application.StartupPath + "\\cmds\\" + this.autoRunCmd;
                RunCommand();
                this.autoRunCmd = "";
            }
            #endregion
            #region Load Tomcat
            //LoadTomcatConfig();
            #endregion
        }

        public void loadCommands()
        {
            string path = Application.StartupPath + "\\cmds\\";
            string[] files = Directory.GetFiles(path, "*.bat");
            TreeNode nodeC = tvMain.Nodes[0].Nodes[0];
            nodeC.Nodes.Clear();
            foreach (var file in files)
            {
                TreeNode tn = new TreeNode(Path.GetFileNameWithoutExtension(file));
                tn.Tag = file;
                nodeC.Nodes.Add(tn);
            }
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        public void RunCommand()
        {
            mainCMD.StandardInput.WriteLine(tbxCommand.Text);
        }
        private void tbxCommand_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                //Last Command
            }
        }
        private void tbxCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                e.Handled = true;
                RunCommand();
                //RunCommand(tbxCommand.Text);
            }
        }
        void mainCMD_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // 这里仅做输出的示例，实际上您可以根据情况取消获取命令行的内容  
            // 参考：process.CancelOutputRead()  
            if (String.IsNullOrEmpty(e.Data) == false)
                this.AppendText(e.Data + "\r\n");
        }
        #region 多线程文本显示
        public delegate void AppendTextCallback(string text);
        const int EM_LINESCROLL = 0x00B6;
        [DllImport("user32.dll")]
        static extern int SetScrollPos(IntPtr hWnd, int nBar,
                                       int nPos, bool bRedraw);
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int wMsg,
                                       int wParam, int lParam);
        public void AppendText(string text)
        {
            if (this.tbxConsole.InvokeRequired)
            {
                AppendTextCallback d = new AppendTextCallback(AppendText);
                this.tbxConsole.Invoke(d, text);
            }
            else
            {
                int selectionStart = 0;
                int selectionLength = this.tbxConsole.SelectionLength;
                if (selectionLength > 0)
                {
                    selectionStart = this.tbxConsole.SelectionStart;
                }
                this.tbxConsole.AppendText(text);
                if (selectionStart > 0)
                {
                    this.tbxConsole.SelectionStart = selectionStart;
                    this.tbxConsole.SelectionLength = selectionLength;
                }
                else
                {
                    this.tbxConsole.ScrollToCaret();
                }

                //SetScrollPos(myTextBox.Handle, 1, myTextBox.Lines.Length - 1, true);
                //SendMessage(myTextBox.Handle, EM_LINESCROLL, 0,
                //                             myTextBox.Lines.Length - 1);
            }
        }
        #endregion
        #region Tomcat
        private void LoadTomcatConfig()
        {
            string sPath = Environment.GetEnvironmentVariable("TOMCAT_HOME");
            if (string.IsNullOrEmpty(sPath))
            {
                MessageBox.Show("未检测到Tomcat，请添加环境变量\"TOMCAT_HOME\"");
                return;
            }
            string configDirPath = sPath + "\\conf\\Catalina\\localhost";
            string backUpDirPath = Application.StartupPath + "\\tomcatconfig";
            if (!Directory.Exists(backUpDirPath))
            {
                Directory.CreateDirectory(backUpDirPath);
            }
            string[] nowFiles = Directory.GetFiles(configDirPath);
            foreach (var file in nowFiles)
            {
                File.Copy(file, backUpDirPath + "\\" + Path.GetFileName(file), true);
            }
            pnlWebSites.Controls.Clear();
            string[] backUpFiles = Directory.GetFiles(backUpDirPath);
            int locationX = 10;
            for (int j = 0; j < backUpFiles.Length; j++)
            {
                string name = Path.GetFileNameWithoutExtension(backUpFiles[j]);
                CheckBox cbxT = new CheckBox();
                cbxT.Text = name;
                cbxT.Tag = backUpFiles[j];
                for (int i = 0; i < nowFiles.Length; i++)
                {
                    if (Path.GetFileNameWithoutExtension(nowFiles[i]) == name)
                    {
                        cbxT.Checked = true;
                        break;
                    }
                }
                cbxT.Width = name.Length * 6 + 25;
                cbxT.Left = locationX;
                cbxT.ContextMenuStrip = cmsWebSite;
                locationX += cbxT.Width;
                pnlWebSites.Controls.Add(cbxT);
                cbxT.CheckedChanged += new EventHandler(cbxT_CheckedChanged);
            }
        }
        void cbxT_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            string configDirPath = Environment.GetEnvironmentVariable("TOMCAT_HOME") + "\\conf\\Catalina\\localhost";
            if (cbx.Checked)
            {
                //copy from backup to tomcat config
                File.Copy(cbx.Tag + "", configDirPath + "\\" + Path.GetFileName(cbx.Tag + ""));
            }
            else
            {
                //remove tomcat config
                File.Delete(configDirPath + "\\" + Path.GetFileName(cbx.Tag + ""));
            }
        }
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            frmSave frm = new frmSave();
            if (tvMain.SelectedNode.Tag != null)
            {
                frm.tbxFileName.Text = tvMain.SelectedNode.Text;
            }
            frm.tbxCommand.Lines = tbxCommand.Lines;
            frm.ShowDialog(this);
        }

        public void showTouchUIControl()
        {
            TouchUIControl tuc = new TouchUIControl();
            tuc.Owner = this;
            tuc.Show();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            this.Close();
        }

        private void tvMain_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name == "batSaved")
            {
                Process.Start("explorer.exe", Application.StartupPath + "\\cmds\\");
                e.Node.Expand();
                return;
            }
            if (e.Node.Tag != null)
            {
                RunCommand();
            }
            else
            {
                MessageBox.Show("请双击带命令的节点！");
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            tbxCommand.Focus();
            Application.DoEvents();
        }

        private void tvMain_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                tbxCommand.Lines = File.ReadAllLines((string)e.Node.Tag);
                tvMain.SelectedNode = e.Node;
            }
            else
            {
                tvMain.SelectedNode = e.Node;
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete((string)tvMain.SelectedNode.Tag);
            loadCommands();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (tvMain.SelectedNode.Tag == null)
            {
                e.Cancel = true;
            }
        }

        private void btnRestartTomcat_Click(object sender, EventArgs e)
        {
            Process[] allprocess = Process.GetProcesses();
            for (int i = 0; i < allprocess.Length; i++)
            {
                if (allprocess[i].MainWindowTitle == "Tomcat")
                {
                    allprocess[i].Kill();
                    break;
                }
            }
            Application.DoEvents();
            System.Threading.Thread.Sleep(100);
            tbxCommand.Text = Environment.GetEnvironmentVariable("TOMCAT_HOME") + "\\bin\\startup.bat";
            RunCommand();
        }
        private void OpenExplorer(string path)
        {
            Process.Start("explorer.exe", path);
        }
        private void 打开WebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBox cbTmp = (CheckBox)cmsWebSite.SourceControl;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load((string)cbTmp.Tag);
            Context ct = ContextHelper.parse(xmlDoc);
            if (ct != null)
            {
                OpenExplorer(ct.docBase);
            }
        }

        private void cmsWebSite_Opening(object sender, CancelEventArgs e)
        {
            CheckBox cbTmp = (CheckBox)cmsWebSite.SourceControl;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load((string)cbTmp.Tag);
            Context ct = ContextHelper.parse(xmlDoc);
            if (ct == null)
            {
                e.Cancel = true;
                return;
            }
            //对比当前连接文件和remote、local目录下的文件
            //\WEB-INF\classes\config\webtop-config.xml
            //\WEB-INF\etc\settings-conf-upsv2.xml
            string dirPath = Application.StartupPath + "\\tomcatconfig\\" + cbTmp.Text;
            FileInfo fiCurrent = new FileInfo(ct.docBase + "\\WEB-INF\\classes\\config\\webtop-config.xml");
            FileInfo fiRemote = new FileInfo(dirPath + "\\remote\\webtop-config.xml");
            FileInfo fiLocal = new FileInfo(dirPath + "\\local\\webtop-config.xml");
            if (!fiCurrent.Exists)
            {
                tsmiBackup.Visible = false;
                tsmiCompare.Visible = false;
                tsmiUseLocalOrRemote.Visible = false;
                return;
            }
            if (!fiRemote.Exists)
            {
                tsmiCompare.Visible = false;
                tsmiUseLocalOrRemote.Visible = false;
                return;
            }
            if (!fiLocal.Exists)
            {
                //remote file is here,but not local file
                MessageBox.Show("稍后会打开一个文件夹，请将修改好的本地连接文件放到该目录下");
                if (!Directory.Exists(dirPath + "\\local"))
                {
                    Directory.CreateDirectory(dirPath + "\\local");
                    OpenExplorer(dirPath + "\\local");
                }
                e.Cancel = true;
                return;
            }
            if (fiCurrent.LastWriteTime > fiRemote.LastWriteTime && fiCurrent.LastWriteTime > fiLocal.LastWriteTime)
            {
                //new build files
                tsmiBackup.Visible = true;
                tsmiCompare.Visible = false;
                tsmiUseLocalOrRemote.Visible = false;
                return;
            }
            tsmiBackup.Visible = false;
            tsmiCompare.Visible = true;
            tsmiUseLocalOrRemote.Visible = true;
            //check using local or remote
            if (fiCurrent.LastWriteTime == fiRemote.LastWriteTime)
            {
                tsmiUseLocalOrRemote.Text = "使用本地连接";
                tsmiUseLocalOrRemote.ToolTipText = "当前正在使用远程连接，单击可替换为本地连接";
                return;
            }
            if (fiCurrent.LastWriteTime == fiLocal.LastWriteTime)
            {
                tsmiUseLocalOrRemote.Text = "使用远程连接";
                tsmiUseLocalOrRemote.ToolTipText = "当前正在使用本地连接，单击可替换为远程连接";
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            CheckBox cbTmp = (CheckBox)cmsWebSite.SourceControl;
            if (cbTmp.Checked)
            {
                MessageBox.Show("请先将该网站卸载！");
                return;
            }
            File.Delete((string)cbTmp.Tag);
            LoadTomcatConfig();
        }

        private void tsmiBackup_Click(object sender, EventArgs e)
        {
            //\WEB-INF\classes\config\webtop-config.xml
            //\WEB-INF\etc\settings-conf-upsv2.xml
            CheckBox cbTmp = (CheckBox)cmsWebSite.SourceControl;
            string dirPath = Application.StartupPath + "\\tomcatconfig\\" + cbTmp.Text + "\\remote\\";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load((string)cbTmp.Tag);
            Context ct = ContextHelper.parse(xmlDoc);
            if (ct == null)
            {
                return;
            }
            File.Copy(ct.docBase + "\\WEB-INF\\classes\\config\\webtop-config.xml", dirPath + "webtop-config.xml", true);
            File.Copy(ct.docBase + "\\WEB-INF\\etc\\settings-conf-upsv2.xml", dirPath + "settings-conf-upsv2.xml", true);
            MessageBox.Show("备份完成！");
        }

        private void tsmiCompare_Click(object sender, EventArgs e)
        {
        }

        private void tsmiUseLocalOrRemote_Click(object sender, EventArgs e)
        {
            CheckBox cbTmp = (CheckBox)cmsWebSite.SourceControl;
            string dirPath = Application.StartupPath + "\\tomcatconfig\\" + cbTmp.Text;
            if (tsmiUseLocalOrRemote.Text == "使用本地连接")
            {
                //copy local to current
                dirPath += "\\local\\";
            }
            else
            {
                dirPath += "\\remote\\";
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load((string)cbTmp.Tag);
            Context ct = ContextHelper.parse(xmlDoc);
            File.Copy(dirPath + "webtop-config.xml", ct.docBase + "\\WEB-INF\\classes\\config\\webtop-config.xml", true);
            File.Copy(dirPath + "settings-conf-upsv2.xml", ct.docBase + "\\WEB-INF\\etc\\settings-conf-upsv2.xml", true);
            DialogResult dr = MessageBox.Show("替换完成，是否要重启Tomcat?", "提示", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                btnRestartTomcat_Click(null, null);
            }
        }

        private void tsmiSearchBackendError_Click(object sender, EventArgs e)
        {
            CheckBox cbTmp = (CheckBox)cmsWebSite.SourceControl;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load((string)cbTmp.Tag);
            Context ct = ContextHelper.parse(xmlDoc);
            string logFile = ct.docBase + "\\WEB-INF\\logs\\webtop.log";
            using (StreamReader sr = new StreamReader(logFile))
            {
                string content = "";
                int searchIndex = -1; long readPos = sr.BaseStream.Length; int readLength = 2048;
                int readCount = 0;
                int startPos = Convert.ToInt32(sr.BaseStream.Length);
                char[] buffer = new char[2048];
                do
                {
                    startPos = startPos - readLength;
                    if (startPos < 0)
                    {
                        readLength = startPos + readLength;
                        startPos = 0;
                    }
                    sr.BaseStream.Position = startPos;
                    readCount = sr.Read(buffer, 0, readLength);
                    content = new string(buffer) + content;
                    searchIndex = content.IndexOf("error");
                    if (searchIndex >= 0)
                    {
                        searchIndex = startPos + searchIndex;

                    }
                } while (searchIndex < 0 && (readCount == 2048));
                if (searchIndex >= 0)
                {
                    MessageBox.Show("找到了" + (startPos + searchIndex));
                }
                else
                {
                    MessageBox.Show("没有找到，请自行查找！");
                    Process.Start("explorer.exe", logFile + ",/select ");
                }
            }
        }

        private void tbxCommand_Run(object sender, EventArgs e)
        {
            RunCommand();
        }
    }
}
