using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace AutoStarter
{
    public partial class TouchUIControl : Form
    {
        const string DIR_NAME_FORMAT = "yyyy-MM-dd HH-mm-ss";
        public TouchUIControl()
        {
            InitializeComponent();
        }
        string configPath = Application.StartupPath + "\\config.ini";
        ArrayList alBackUps = new ArrayList();
        private void TouchUIControl_Load(object sender, EventArgs e)
        {
            LoadConfiguration();
            LoadBackups();
            LoadLastUpdateTime();
            LoadTomcatConfig();
        }
        private void LoadTomcatConfig()
        {
            string sPath = Environment.GetEnvironmentVariable("TOMCAT_HOME");
            if (string.IsNullOrEmpty(sPath))
            {
                MessageBox.Show("未检测到Tomcat");
                return;
            }
            string configDirPath = sPath + "\\conf\\Catalina\\localhost";
            string backUpDirPath = tbxPath.Text + "\\tomcatconfig";
            string[] backUpFiles = Directory.GetFiles(backUpDirPath);
            string[] nowFiles = Directory.GetFiles(configDirPath);
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
                cbxT.Width = name.Length * 7 + 20;
                cbxT.Left = locationX;
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
        private void LoadLastUpdateTime()
        {
            if (alBackUps.Count > 0)
            {
                dtLater.Value = ((BackUpDir)alBackUps[alBackUps.Count - 1]).LastUpdateTime;
            }
        }
        private void SaveConfiguration()
        {
            string[] configs = new string[6];
            configs[0] = tbxPath.Text;
            for (int i = 0; i < tbxConfigFiles.Lines.Length; i++)
            {
                configs[i + 1] = tbxConfigFiles.Lines[i];
            }
            for (int i = 0; i < tbxKiwiConfig.Lines.Length; i++)
            {
                configs[i + 3] = tbxKiwiConfig.Lines[i];
            }
            configs[5] = tbxKiwiAntCmd.Text;
           
            File.WriteAllLines(configPath, configs);
        }
        private void LoadConfiguration()
        {
            if (!File.Exists(configPath))
            {
                File.Create(configPath);
            }
            String[] path = File.ReadAllLines(configPath);
            tbxPath.Text = path[0];
            path = ArrayRemove(path, 0);
            string[] strMelon = { path[0], path[1] };
            tbxConfigFiles.Lines = strMelon;
            path = ArrayRemove(path, 0);
            path = ArrayRemove(path, 0);
            string[] strKiwi = { path[0], path[1] };
            tbxKiwiConfig.Lines = strKiwi;
            path = ArrayRemove(path, 0);
            path = ArrayRemove(path, 0);
            tbxKiwiAntCmd.Lines = path;
        }
        string[] ArrayRemove(string[] old, int index)
        {
            if (index < 0 || index >= old.Length - 1) return old;
            string[] n = new string[old.Length - 1];
            for (int i = 0; i < old.Length - 1; i++)
            {
                if (i < index)
                    n[i] = old[i];
                else
                    n[i] = old[i + 1];
            }
            return n;
        }

        private void TouchUIControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfiguration();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((frmMain)this.Owner).tbxCommand.Text = "cd " + tbxPath.Text + "\\nephrite\\trunk\\";
            ((frmMain)this.Owner).RunCommand();
            ((frmMain)this.Owner).tbxCommand.Text = "ant build-dev";
            ((frmMain)this.Owner).RunCommand();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((frmMain)this.Owner).tbxCommand.Text = "cd " + tbxPath.Text + "\\melon\\trunk\\";
            ((frmMain)this.Owner).RunCommand();
            if (cbxProduction.Checked)
            {
                ((frmMain)this.Owner).tbxCommand.Text = "ant -Dclient=touch -Dtouch.testing=true ubi";
            }
            else
            {
                ((frmMain)this.Owner).tbxCommand.Text = "ant -Dclient=touch -Dtouch.dev=true ubi";
            }
            ((frmMain)this.Owner).RunCommand();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "替换本地连接";
            Application.DoEvents();
            string localPath = tbxPath.Text + "\\localconfig\\";
            if (!Directory.Exists(localPath))
            {
                Directory.CreateDirectory(localPath);
            }
            for (int i = 0; i < tbxConfigFiles.Lines.Length; i++)
            {
                string fileName = tbxConfigFiles.Lines[i].Substring(tbxConfigFiles.Lines[i].LastIndexOf("\\") + 1);
                if (!File.Exists(localPath + fileName))
                {
                    MessageBox.Show("本地连接文件(" + localPath + fileName + ")不存在", "错误");
                    return;
                }
                File.Copy(localPath + fileName, tbxPath.Text + tbxConfigFiles.Lines[i], true);
            }
            toolStripStatusLabel1.Text = "替换本地连接，完成";
            tryToReStartTomcat();
            Application.DoEvents();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "替换美国连接";
            Application.DoEvents();
            string remotePath = tbxPath.Text + "\\remoteconfig\\";
            if (!Directory.Exists(remotePath))
            {
                Directory.CreateDirectory(remotePath);
            }
            for (int i = 0; i < tbxConfigFiles.Lines.Length; i++)
            {
                string fileName = tbxConfigFiles.Lines[i].Substring(tbxConfigFiles.Lines[i].LastIndexOf("\\") + 1);
                if (!File.Exists(remotePath + fileName))
                {
                    MessageBox.Show("远程连接文件(" + remotePath + fileName + ")不存在", "错误");
                    return;
                }
                File.Copy(remotePath + fileName, tbxPath.Text + tbxConfigFiles.Lines[i], true);
            }
            toolStripStatusLabel1.Text = "替换美国连接，完成";
            tryToReStartTomcat();
            Application.DoEvents();
        }
        private void tryToReStartTomcat()
        {
            if (cbxRestart.Checked)
            {
                button6_Click(null, null);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "备份连接";
            Application.DoEvents();
            string remotePath = tbxPath.Text + "\\remoteconfig\\";
            if (!Directory.Exists(remotePath))
            {
                Directory.CreateDirectory(remotePath);
            }
            for (int i = 0; i < tbxConfigFiles.Lines.Length; i++)
            {
                string fileName = tbxConfigFiles.Lines[i].Substring(tbxConfigFiles.Lines[i].LastIndexOf("\\") + 1);
                File.Copy(tbxPath.Text + tbxConfigFiles.Lines[i], remotePath + fileName, true);
            }
            toolStripStatusLabel1.Text = "备份连接，完成";
            Application.DoEvents();
        }

        private void button6_Click(object sender, EventArgs e)
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
            ((frmMain)this.Owner).tbxCommand.Text = "startup";
            ((frmMain)this.Owner).RunCommand();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ((frmMain)this.Owner).tbxCommand.Text = "cd " + Application.StartupPath;
            ((frmMain)this.Owner).RunCommand();
            ((frmMain)this.Owner).tbxCommand.Text = "java -jar weinre.jar --httpPort 8081 --boundHost -all-";
            ((frmMain)this.Owner).RunCommand();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ((frmMain)this.Owner).tbxCommand.Text = "cd \"C:\\Program Files (x86)\\Beyond Compare 3\\\"";
            ((frmMain)this.Owner).RunCommand();
            ((frmMain)this.Owner).tbxCommand.Text = "BCompare.exe " + this.tbxPath.Text + "\\localconfig\\ " + this.tbxPath.Text + "\\remoteconfig\\";
            ((frmMain)this.Owner).RunCommand();
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            //backup melon
            backUpDirsAndFiles("\\melon\\trunk\\src\\main\\sencha");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="auto"></param>
        private void backUpDirsAndFiles(string subDir)
        {
            string backUpPath = tbxPath.Text + "\\backups\\";
            string newBackUpDirectoryName = DateTime.Now.ToString(DIR_NAME_FORMAT);

            newBackUpDirectoryName = backUpPath + newBackUpDirectoryName + "\\";

            DateTime dtFilter = DateTime.MinValue;//first time back up all files
            if (alBackUps.Count > 0)
            {
                dtFilter = ((BackUpDir)alBackUps[alBackUps.Count - 1]).LastUpdateTime;
            }
            tsProgress.Value = 0;
            //Get Files count
            tsProgress.Maximum = GetFileCount(tbxPath.Text + subDir, dtFilter);
            if (tsProgress.Maximum == 0)
            {
                MessageBox.Show("上次备份以来，没有任何文件发生过修改");
                return;
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("找到 " + tsProgress.Maximum + " 个最近更新的文件，需要备份吗？", "提示", MessageBoxButtons.YesNo))
                {
                    backUpDirsAndFiles(tbxPath.Text + subDir, newBackUpDirectoryName + subDir, dtFilter);
                    MessageBox.Show("备份完成！");
                    tsProgress.Value = 0;
                    LoadBackups();
                    LoadLastUpdateTime();
                }
            }
        }
        private void backUpDirsAndFiles(string sourceDir, string destDir, DateTime dtFilter)
        {
            //定义一个DirectoryInfo对象
            DirectoryInfo di = new DirectoryInfo(sourceDir);
            ArrayList alNewFiles = getLatestUpdatedFiles(sourceDir, dtFilter);
            for (int i = 0; i < alNewFiles.Count; i++)
            {
                FileInfo fi = (FileInfo)alNewFiles[i];
                string newDest = fi.Directory.FullName.Replace(sourceDir, destDir);
                if (!Directory.Exists(newDest))
                {
                    Directory.CreateDirectory(newDest);
                }
                fi.CopyTo(fi.FullName.Replace(sourceDir, destDir), true);
                tsProgress.Value++;
                Application.DoEvents();
            }
            return;
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }
            foreach (FileInfo fi in di.GetFiles())
            {
                if (fi.LastWriteTime > dtFilter)
                {
                    File.Copy(fi.FullName, destDir + "\\" + fi.Name, true);
                    tsProgress.Value++;
                    Application.DoEvents();
                }
            }

            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    backUpDirsAndFiles(dis[i].FullName + "\\", destDir + "\\" + dis[i].Name + "\\", dtFilter);
                }
            }
        }

        private int GetFileCount(string dir, DateTime dtFilter)
        {
            int len = 0;
            //定义一个DirectoryInfo对象
            DirectoryInfo di = new DirectoryInfo(dir);
            foreach (FileInfo fi in di.GetFiles())
            {
                if (fi.LastWriteTime > dtFilter)
                {
                    len++;
                }
            }

            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    len += GetFileCount(dis[i].FullName, dtFilter);
                }
            }
            return len;
        }
        private void LoadBackups()
        {
            string backUpPath = tbxPath.Text + "\\backups\\";
            string[] dirs = Directory.GetDirectories(backUpPath);
            foreach (string dir in dirs)
            {
                alBackUps.Add(new BackUpDir(dir));
            }
            alBackUps.Sort();
        }
        private class BackUpDir : IComparable
        {
            public BackUpDir(string path)
            {
                this.Name = Path.GetFileName(path);
                this.DirPath = path;
                try
                {
                    this.LastUpdateTime = DateTime.ParseExact(this.Name, DIR_NAME_FORMAT, null);
                }
                catch
                {
                }
            }
            public string Name { get; set; }
            public string DirPath { get; set; }
            public DateTime LastUpdateTime { get; set; }

            public int CompareTo(object obj)
            {
                BackUpDir bud = (BackUpDir)obj;
                if (this.LastUpdateTime > bud.LastUpdateTime)
                {
                    return 1;
                }
                else if (this.LastUpdateTime < bud.LastUpdateTime)
                {
                    return -1;
                }
                return 0;
            }
        }
        private void btnPostReview_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxChangelist.Text))
            {
                MessageBox.Show("请输入ChagngeList号", "提示");
                tbxChangelist.Focus();
                return;
            }

        }

        private void btnGetLatest_Click(object sender, EventArgs e)
        {
            dgFiles.Rows.Clear();
            ArrayList files = getLatestUpdatedFiles(tbxPath.Text + "\\melon\\trunk\\src\\main", dtLater.Value);
            dgFiles.DataSource = files;
            dgFiles.Refresh();
            //foreach (FileInfo fi in files) { 
            //    fi.Name
            //    DataGridViewRow dgvr=new DataGridViewRow();
            //    dgvr.c
            //dgFiles.Rows.Add(
            //}
        }
        private ArrayList getLatestUpdatedFiles(string directory, DateTime date)
        {
            if (!Directory.Exists(directory))
            {
                return new ArrayList();
            }
            ArrayList files = new ArrayList();
            loadCurrentDirectoryLatestUpdateFiles(files, directory, date);
            return files;
        }
        private void loadCurrentDirectoryLatestUpdateFiles(ArrayList files, string directory, DateTime date)
        {
            DirectoryInfo di = new DirectoryInfo(directory);
            foreach (DirectoryInfo ddi in di.GetDirectories())
            {
                loadCurrentDirectoryLatestUpdateFiles(files, ddi.FullName, date);
            }
            foreach (FileInfo fi in di.GetFiles())
            {
                if (fi.LastWriteTime > date)
                {
                    files.Add(fi);
                    toolStripStatusLabel1.Text = "Found:" + files.Count;
                    Application.DoEvents();
                }
            }
        }

        private void btnBuildAll_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);//build nephire

        }

        private void button10_Click(object sender, EventArgs e)
        {
            ((frmMain)this.Owner).tbxCommand.Text = "cd " + tbxPath.Text + "\\kiwi\\trunk\\";
            ((frmMain)this.Owner).RunCommand();
            ((frmMain)this.Owner).tbxCommand.Text = tbxKiwiAntCmd.Text;
            ((frmMain)this.Owner).RunCommand();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ((frmMain)this.Owner).tbxCommand.Text = "cd \"C:\\Program Files (x86)\\Beyond Compare 3\\\"";
            ((frmMain)this.Owner).RunCommand();
            ((frmMain)this.Owner).tbxCommand.Text = "BCompare.exe " + this.tbxPath.Text + "\\localconfig-k\\ " + this.tbxPath.Text + "\\remoteconfig-k\\";
            ((frmMain)this.Owner).RunCommand();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "备份连接";
            Application.DoEvents();
            string remotePath = tbxPath.Text + "\\remoteconfig-k\\";
            if (!Directory.Exists(remotePath))
            {
                Directory.CreateDirectory(remotePath);
            }
            for (int i = 0; i < tbxConfigFiles.Lines.Length; i++)
            {
                string fileName = tbxKiwiConfig.Lines[i].Substring(tbxKiwiConfig.Lines[i].LastIndexOf("\\") + 1);
                File.Copy(tbxPath.Text + tbxKiwiConfig.Lines[i], remotePath + fileName, true);
            }
            toolStripStatusLabel1.Text = "备份连接，完成";
            Application.DoEvents();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "替换本地连接";
            Application.DoEvents();
            string localPath = tbxPath.Text + "\\localconfig-k\\";
            if (!Directory.Exists(localPath))
            {
                Directory.CreateDirectory(localPath);
            }
            for (int i = 0; i < tbxKiwiConfig.Lines.Length; i++)
            {
                string fileName = tbxKiwiConfig.Lines[i].Substring(tbxKiwiConfig.Lines[i].LastIndexOf("\\") + 1);
                if (!File.Exists(localPath + fileName))
                {
                    MessageBox.Show("本地连接文件(" + localPath + fileName + ")不存在", "错误");
                    return;
                }
                File.Copy(localPath + fileName, tbxPath.Text + tbxKiwiConfig.Lines[i], true);
            }
            toolStripStatusLabel1.Text = "替换本地连接，完成";
            tryToReStartTomcat();
            Application.DoEvents();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "替换美国连接";
            Application.DoEvents();
            string remotePath = tbxPath.Text + "\\remoteconfig-k\\";
            if (!Directory.Exists(remotePath))
            {
                Directory.CreateDirectory(remotePath);
            }
            for (int i = 0; i < tbxKiwiConfig.Lines.Length; i++)
            {
                string fileName = tbxKiwiConfig.Lines[i].Substring(tbxKiwiConfig.Lines[i].LastIndexOf("\\") + 1);
                if (!File.Exists(remotePath + fileName))
                {
                    MessageBox.Show("远程连接文件(" + remotePath + fileName + ")不存在", "错误");
                    return;
                }
                File.Copy(remotePath + fileName, tbxPath.Text + tbxKiwiConfig.Lines[i], true);
            }
            toolStripStatusLabel1.Text = "替换美国连接，完成";
            tryToReStartTomcat();
            Application.DoEvents();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            backUpDirsAndFiles("\\peridot\\trunk\\src\\main\\sencha");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ((frmMain)this.Owner).tbxCommand.Text = "cd " + tbxPath.Text + "\\peridot\\trunk\\src\\main\\sencha\\richui";
            ((frmMain)this.Owner).RunCommand();
            ((frmMain)this.Owner).tbxCommand.Text = "sencha app refresh";
            ((frmMain)this.Owner).RunCommand();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ((frmMain)this.Owner).tbxCommand.Text = "cd " + tbxPath.Text + "\\peridot\\trunk\\src\\main\\sencha\\richui";
            ((frmMain)this.Owner).RunCommand();
            ((frmMain)this.Owner).tbxCommand.Text = "sencha app build native";
            ((frmMain)this.Owner).RunCommand();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string logPath = tbxPath.Text + @"\\kiwi\trunk\target\webapp\WEB-INF\logs\webtop.log";
            FileStream fs = new FileStream(logPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            byte[] buffer = new byte[10240];
            int fLen = (int)fs.Length;
            fs.Read(buffer, fLen - buffer.Length, buffer.Length);
            string tmpStr = Encoding.Default.GetString(buffer);
            MessageBox.Show(tmpStr);
            fs.Close();
        }

    }
}
