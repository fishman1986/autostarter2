using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace AutoStarter
{
    public class Installer
    {
        public static bool IsInstalled()
        {
            RegistryKey key = RegistryHelper.GetRegistryKey(WRegisterRootKeyType.HKEY_CLASSES_ROOT, "AutoStart");
            if (key != null)
            {
                return true;
            }
            return false;
        }
        public static void UnInstall()
        {
            RegistryKey root = RegistryHelper.GetRootRegisterKey(WRegisterRootKeyType.HKEY_CLASSES_ROOT);
            root.DeleteSubKeyTree("AutoStart");
        }
        public static bool CheckIfInstallCorrect()
        {
            string exeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string installPath = RegistryHelper.GetRegistryValue(WRegisterRootKeyType.HKEY_CLASSES_ROOT, "AutoStart", "URL Protocol");
            return installPath == exeFilePath;
        }
        public static void Install()
        {
            string exeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            RegistryKey autoRootKey = RegistryHelper.CreateRegistryKey(RegistryHelper.GetRootRegisterKey(WRegisterRootKeyType.HKEY_CLASSES_ROOT), "AutoStart");
            autoRootKey.SetValue("", "AutoStart");
            autoRootKey.SetValue("URL Protocol", exeFilePath);
            RegistryKey iconKey = autoRootKey.CreateSubKey("DefaultIcon");
            iconKey.SetValue("", exeFilePath);
            RegistryKey shellKey = RegistryHelper.CreateRegistryKey(autoRootKey, "shell");
            RegistryKey open = shellKey.CreateSubKey("open");
            RegistryKey command = open.CreateSubKey("command");
            command.SetValue("", exeFilePath + "   \"%1\"");
        }
    }
}
