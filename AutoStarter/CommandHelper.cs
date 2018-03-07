using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace AutoStarter
{
    class CommandHelper
    {
        public static string startCmd(string command, params string[] argument)
        {
            string output = "";
            try
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = command;
                if (argument != null && argument.Length > 0)
                {
                    cmd.StartInfo.Arguments = argument[0];
                }
                cmd.StartInfo.UseShellExecute = true;

                //cmd.StartInfo.RedirectStandardInput = true;

                //cmd.StartInfo.RedirectStandardOutput = true;

                cmd.StartInfo.CreateNoWindow = true;

                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

                cmd.Start();
                //output = cmd.StandardOutput.ReadToEnd();
                //Console.WriteLine(output);
                //cmd.WaitForExit();
                //cmd.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return output;
        }

        internal static Process createStandardProcess()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            return p;
        }
    }
}
