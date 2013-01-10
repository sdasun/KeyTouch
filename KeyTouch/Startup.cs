using System;
using System.IO;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace KeyTouch
{
    public static class Startup
    {
        private static RegistryKey key;
        const int HKLM = 1;
        const int HKCU = 2;

        private static RegistryKey getKeySection(int Section)
        {
            switch (Section)
            {
                case 1:
                    // HKEY_LOCALMACHINE
                    key = Registry.LocalMachine;
                    break;
                case 2:
                    // Current User
                    key = Registry.CurrentUser;
                    break;
                default:
                    key = Registry.LocalMachine;
                    break;
            }
            return key;
        }
        private static string getValue(int Section, string Location, string Value)
        {
            key = getKeySection(Section);
            object val;
            try
            {
                key = key.OpenSubKey(Location);
                val = key.GetValue(Value);
                return val.ToString();
            }
            catch (Exception e)
            {
                return "error " + e.Message;
            }
            finally
            {
                key.Close();
            }
        }
        private static bool setValue(int Section, string Location, string Value,string  Name)
        {
            key = getKeySection(Section);
            try
            {
                key = key.OpenSubKey(Location, true);
                key.SetValue(Name, Value);
            }
            catch
            {
                return false;
            }
            finally
            {
                key.Close();
            }
            return true;
        }
        private static bool deleteValue(int Section, string Location, string Value)
        {
            key = getKeySection(Section);
            try
            {
                key = key.OpenSubKey(Location,true);
                key.DeleteValue(Value, false);
            }
            catch
            {
                return false;
            }
            finally
            {
                key.Close();
            }
            return true;
        }
        public static bool regRun(int Section, string Path,string Name)
        {
            return setValue(Section, @"Software\Microsoft\Windows\CurrentVersion\Run", Path, Name);
        }
        public static bool removeRegRun(int Section, string Name)
        {
            return deleteValue(Section, @"Software\Microsoft\Windows\CurrentVersion\Run", Name);
        }
        public static string getRegRun(int Section, string Name)
        {
            return getValue(Section, @"Software\Microsoft\Windows\CurrentVersion\Run", Name);
        }

    }
}
