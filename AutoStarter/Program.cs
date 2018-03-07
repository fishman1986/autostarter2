using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AutoStarter
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #region 注册检测
            if (!Installer.IsInstalled() || !Installer.CheckIfInstallCorrect())
            {
                try
                {
                    Installer.Install();
                }
                catch (Exception er)
                {
                    MessageBox.Show("请以管理员身份运行此程序，以开启从网页启动的功能！", "提示");
                }
            }
            #endregion
            frmMain frmMain = new frmMain();
            if (args != null && args.Length > 0)
            {
                WriteLogs("StartCommand", "Info", args[0]);
                args[0] = args[0].Replace("%20", " ");
                if (args[0].LastIndexOf("/") == args[0].Length-1)
                {
                    args[0] = args[0].Substring(0, args[0].Length - 1);
                }
                args[0] = args[0].Replace("/", "\\");
                
                if (args[0] == "uninstall")
                {
                    Installer.UnInstall();
                    MessageBox.Show("卸载成功！");
                    return;
                }
                if (args[0].IndexOf("Touch") > 0)
                {
                    frmMain.showTouchUIControl();
                }
                if (args[0].IndexOf("DebugRemote") > 0)
                {
                    CommandHelper.startCmd("java", "-jar weinre.jar --httpPort 8081 --boundHost -all-");
                    return;
                }
                if (args[0].IndexOf("Open") >= 0)
                {
                    Process.Start("explorer.exe", args[0].Substring(args[0].IndexOf("Open") + 5));
                    return;
                }

                if (args[0].IndexOf("Run") > 0)
                {
                    string cmdFileName = args[0].Substring(args[0].IndexOf("Run") + 4);
                    frmMain.autoRunCmd = cmdFileName;
                }
            }
            Application.Run(frmMain);
        }

        /// <summary>
        /// 日志部分
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="type"></param>
        /// <param name="content"></param>
        public static void WriteLogs(string fileName, string type, string content)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (!string.IsNullOrEmpty(path))
            {
                path = AppDomain.CurrentDomain.BaseDirectory + fileName;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "\\" + DateTime.Now.ToString("yyyyMMdd");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                if (!File.Exists(path))
                {
                    FileStream fs = File.Create(path);
                    fs.Close();
                }
                if (File.Exists(path))
                {
                    StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + type + "-->" + content);
                    //  sw.WriteLine("----------------------------------------");
                    sw.Close();
                }
            }
        }
    }
}
