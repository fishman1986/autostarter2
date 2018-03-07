using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AutoStarter
{
    public partial class CommandTextBox : TextBox
    {
        public CommandTextBox()
        {
            InitializeComponent();
        }
        public event EventHandler Run;
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (((keyData & Keys.Control) == Keys.Control))
            {
                Keys keys1 = keyData & Keys.KeyCode;
                if (keys1 == Keys.Return)
                {
                    EventArgs e = new EventArgs();
                    Run.Invoke(this, e);
                    return true;
                }
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
