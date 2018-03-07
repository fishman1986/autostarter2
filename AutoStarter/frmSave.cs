using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AutoStarter
{
    public partial class frmSave : Form
    {
        public frmSave()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxFileName.Text))
            {
                MessageBox.Show("请输入文件名!");
                return;
            }
            if (tbxFileName.Text.IndexOf(' ') > 0)
            {
                MessageBox.Show("文件名不能有空格!");
                return;
            }
            string fileName = Application.StartupPath + "\\cmds\\";
            if (!Directory.Exists(fileName))
            {
                Directory.CreateDirectory(fileName);
            }
            fileName += tbxFileName.Text.IndexOf(".bat") > 0 ? tbxFileName.Text : tbxFileName.Text + ".bat";
            if (File.Exists(fileName))
            {
                DialogResult dr = MessageBox.Show("已存在文件名为\"" + tbxFileName.Text + "\"的文件，要覆盖吗？", "请问", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
            }
            File.WriteAllLines(fileName, tbxCommand.Lines);
            ((frmMain)this.Owner).loadCommands();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
