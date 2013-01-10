/*
 * Programmer: Dasun Sameera Weerasinghe
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KeyboardLibrary;
using System.Runtime.InteropServices;
using System.Xml;
using System.IO;

namespace KeyTouch
{
    public partial class frmConfig : Form
    {
        Settings setting;
        KeyboardHook keyboardHook = new KeyboardHook();
        List<string> keyboardName = new List<string>();
        List<string> keyboardPath = new List<string>();
        List<int> keyboardScKey = new List<int>();
        List<bool> keyboardList = new List<bool>();
        int keyboardRotateScKey = 0;
        int keyboardOnScKey = 0;
        int keyboardOffScKey = 0;
        bool halting = false;
        int keyboardIndex = -1;

        bool hooked = false;
        const int HOTKEY_ID = 162164; //any number to be used as an id within this app
        const int WM_HOTKEY = 0x0312;
        const string SETTING_FILE = "settings.xml"; //setting file name

        #region Windows API Imports
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
            IntPtr hWnd, // handle to window    
            int id, // hot key identifier    
            int fsModifiers, // key-modifier options    
            int vk    // virtual-key code    
            );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd, // handle to window    
            int id      // hot key identifier    
            );
        #endregion

        #region Custom Methods

        //Use for Clean termination. :)
        //Freeing memory from Keyboard Hooks (and other unmanaged codes) goes to here.
        private void halt()
        {
            halting = true;
            try
            {
                // Remove icon on system tray
                niSystem.Dispose();
                // UnHook keyboard if allready hooked
                if (hooked) keyboardHook.Stop();
            }
            catch { }
            Application.Exit();

        }

        private void loadKeybords()
        {

            //Register HotKey
            //

            //Get All files on Keyboards Directory
            string[] files = System.IO.Directory.GetFiles("keyboards");
            string keylayout; // Keyboard layout name
            string extension;
            XmlDocument xDoc = new XmlDocument();

            // Add all keyboards Layout in to List box(chkKeyboard)
            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    int len = files[i].Length;
                    extension = files[i].Substring(len - 4, 4).ToLower();

                    //Checking the file extension 
                    if (extension == ".xml")
                    {
                        string fullpath = Application.StartupPath + "\\" + files[i];
                        FileStream rfile = new FileStream(fullpath, FileMode.Open);
                        xDoc.Load(rfile);
                        rfile.Close(); //let to be free keyboard layout file. Because it's already in memory.
                        int mod = 0, key = 0;
                        //Get keyboard layout name from keyboard layout file.
                        //It's in root eliment(layout), under 'name' attribute
                        keylayout = xDoc.DocumentElement.GetAttribute("name").Trim();

                        if (keylayout == "") continue;
                        if (keyboardName.IndexOf(keylayout) == -1)
                        {
                            //Add Key Layout to lists
                            keyboardName.Add(keylayout);
                            keyboardPath.Add(fullpath);
                            chkKeyboard.Items.Add(keylayout);
                            if (!setting.isKeyboardInstalled(keylayout))
                            {
                                //Nothing on Setting page yet. Update it ;)
                                if (!setting.installKeybord(keylayout))
                                {
                                    //Opps! got an error while updateing setting page!
                                    //Need to halt :(
                                    MessageBox.Show(
                                        "Error occur while tring to update setting file. Application will halt now.");
                                    halt();
                                    break;
                                }
                            }
                            setting.getShoutcut(keylayout, ref mod, ref key);
                            keyboardScKey.Add(Settings.combineKeyCode(mod,key));
                            keyboardList.Add(setting.isEnable(keylayout));
                            chkKeyboard.SetItemChecked(keyboardName.Count - 1,
                                keyboardList[keyboardList.Count - 1]);
                        }
                        else continue;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    continue;
                }
            }
        }

        //Registering Shourt Cut Keys
        //Note: Remember to set check list first
        private void registerShortcutKeys()
        {
            int k = 0;
            int l = 0;
            bool bcheck;
            if (keyboardRotateScKey > 0)
            {
                k = keyboardRotateScKey;
                l = (k | 255) - 255;
                k = k - l;
                l = l >> 8;
                bcheck = RegisterHotKey(Handle, HOTKEY_ID, l, k);
            }
            if (keyboardOnScKey > 0)
            {
                k = keyboardOnScKey;
                l = (k | 255) - 255;
                k = k - l;
                l = l >> 8;
                bcheck = RegisterHotKey(Handle, HOTKEY_ID + 1, l, k);
            }
            if (keyboardOffScKey > 0)
            {
                k = keyboardOffScKey;
                l = (k | 255) - 255;
                k = k - l;
                l = l >> 8;
                bcheck = RegisterHotKey(Handle, HOTKEY_ID + 2, l, k);
            }

            for (int i = 0; i < chkKeyboard.Items.Count; i++)
            {
                if (chkKeyboard.GetItemCheckState(i) == CheckState.Checked)
                {

                    k = keyboardScKey[i];
                    l = (k | 255) - 255;
                    k = k - l;
                    l = l >> 8;

                    bcheck = RegisterHotKey(Handle, i, l, k);
                }
            }
        }

        private void unregisterShortcutKeys()
        {
            //int k = 0;
            //int l = 0;
            for (int i = 0; i < chkKeyboard.Items.Count; i++)
            {
                if (chkKeyboard.GetItemCheckState(i) == CheckState.Checked)
                {
                    try
                    {
                        bool bcheck = UnregisterHotKey(Handle, i);
                    }
                    catch { }
                }
            }
        }
        //having registered a hotkey the thread that registered it receives a WM_HOTKEY message upon the keypress which has to be caught by overwriting the WndProc method
        protected override void WndProc(ref Message msg)
        {
            // Listen for operating system messages.
            int id = msg.Msg;
            switch (msg.Msg)
            {
                case WM_HOTKEY:
                    id = (int)msg.WParam;
                    if (id >= HOTKEY_ID)
                    {
                        if (id == HOTKEY_ID + 1)
                        {
                            if (keyboardIndex != -1)
                            {
                                keyboardHook.setKeyboard(keyboardPath[keyboardIndex],
                                    keyboardName[keyboardIndex]);
                                keyboardHook.Start();
                                hooked = true;
                                lblStatus.Text = keyboardName[keyboardIndex] + 
                                    " is running.";
                            }
                        }
                        else if (id == HOTKEY_ID + 2)
                        {
                            keyboardHook.Stop();
                            hooked = false;
                            lblStatus.Text = " Key Touch is off.";
                        }
                        else if (id == HOTKEY_ID)
                        {
                            int kID = keyboardIndex;
                            for (int i = 0; i < keyboardList.Count - 1; i++)
                            {
                                if (kID == keyboardList.Count - 1)
                                {
                                    keyboardIndex = -1;
                                    keyboardHook.Stop();
                                    hooked = false;
                                    lblStatus.Text = "Key Touch is off.";
                                    break;
                                }
                                //else if (kID == keyboardList.Count)
                                //    kID = -1;
                                kID++;
                                if (keyboardList[kID])
                                {
                                    keyboardIndex = kID;
                                    keyboardHook.setKeyboard(keyboardPath[keyboardIndex],
                                        keyboardName[keyboardIndex]);
                                    keyboardHook.Start();
                                    hooked = true;
                                    lblStatus.Text = keyboardName[keyboardIndex] +
                                        " is running.";
                                    break;
                                }
                            }
                            //keyboardHook.Stop();
                            //hooked = false;
                        }

                    }
                    else
                    {
                        if (keyboardIndex == id)
                        {
                            keyboardIndex = -1;
                            keyboardHook.Stop();
                            hooked = false;
                            lblStatus.Text = "Key Touch is off.";
                            break;
                        }
                        else
                        {
                            keyboardIndex = id;
                            keyboardHook.setKeyboard(keyboardPath[keyboardIndex],
                                keyboardName[keyboardIndex]);

                            keyboardHook.Start();
                            hooked = true;
                            lblStatus.Text = keyboardName[keyboardIndex] +
                                            " is running.";
                        }
                    }
                    break;



            }
            base.WndProc(ref msg);
        }

        private bool isScKeyAvailale(int scKeycode)
        {
            if (keyboardScKey.IndexOf(scKeycode) == -1)
            {
                if ( keyboardRotateScKey == scKeycode
                    || keyboardOnScKey == scKeycode 
                    || keyboardOffScKey == scKeycode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private bool isScKeyAvailale(int modifier, int key)
        {
            return isScKeyAvailale(Settings.combineKeyCode(modifier,key));
        }

        private void setKeyList()
        {
            for (int i = 0; i < chkKeyboard.Items.Count; i++)
            {
                chkKeyboard.SetItemChecked(i, 
                    setting.isEnable(chkKeyboard.Items[i].ToString()));
            }
        }

        private void setShortcutList()
        {
            for (int i = 0; i < chkKeyboard.Items.Count; i++)
            {
                keyboardScKey[i] = setting.getShoutcutInt(keyboardName[i]);
            }
        }

        #endregion

        #region Events
        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            //reset hotkey if exit  (return value here only for debugging)
            bool bcheck = UnregisterHotKey(Handle, HOTKEY_ID);
        }

        public frmConfig()
        {
            InitializeComponent();

            //keyboardHook = new KeyboardHook(keyboardPath.ToArray()[0]);
            setting = new Settings(Application.StartupPath + "\\" + SETTING_FILE);
            loadKeybords();
            int mod = 0, key = 0;
            lblKeyTouchOff.Text = setting.getMainShoutcuts("keyboardOffScKey",
                ref mod, ref key);
            keyboardOffScKey = mod * 256 + key;
            lblKeyTouchOn.Text = setting.getMainShoutcuts("keyboardOnScKey",
                ref mod, ref key);
            keyboardOnScKey = mod * 256 + key;
            lblGlobleShortcut.Text = setting.getMainShoutcuts("keyboardRotateScKey",
                ref mod, ref key);
            keyboardRotateScKey = mod * 256 + key;
            registerShortcutKeys();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //keyboardHook.Start();
            //hooked = true;
        }

        private void chkKeyboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkKeyboard.SelectedIndex != -1)
            {
                try
                {
                    string fullpath = keyboardPath.ToArray()[chkKeyboard.SelectedIndex];
                    XmlDocument xdoc = new XmlDocument();
                    FileStream rfile = new FileStream(fullpath, FileMode.Open);

                    lblFileName.Text = System.IO.Path.GetFileName(fullpath);
                    xdoc.Load(rfile);

                    lblVersion.Text = ((XmlElement)xdoc.GetElementsByTagName(
                        "layout")[0]).GetAttribute("version");
                    lblDescription.Text = ((XmlElement)xdoc.GetElementsByTagName(
                        "layout")[0]).GetAttribute("info");
                    lblCreatedBy.Text = ((XmlElement)xdoc.GetElementsByTagName("layout")[0]).GetAttribute("createdby");

                    int k = 0;
                    int l = 0;
                    k = keyboardScKey[chkKeyboard.SelectedIndex];
                    l = (k | 255) - 255;
                    k = k - l;
                    l = l >> 8;
                    lblShortcut.Text = Settings.shortCutToString(l, k);
                    rfile.Close();

                    btnSKShortcut.Enabled = true;
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else btnSKShortcut.Enabled = false;
        }

        private void btnSKShortcut_Click(object sender, EventArgs e)
        {
            int modifier = 0;
            int key = 0;
            //DialogResult rs=(new frmHotKey()).ShowDialog();
            setting.getShoutcut(chkKeyboard.SelectedItem.ToString(), ref modifier, ref key);

            frmHotKey form1 = new frmHotKey(modifier, key);
            // Display the form as a modal dialog box.
            form1.ShowDialog();

            // Determine if the OK button was clicked on the dialog box.
            if (form1.DialogResult == DialogResult.OK)
            {
                form1.getHotKeys(ref modifier, ref key);

                // Optional
                form1.Dispose();
                if (isScKeyAvailale(modifier, key))
                {
                    MessageBox.Show("Shortcut Key combination already in use. Please select a new combination.");
                    btnSKShortcut_Click(sender, e);
                }
                else
                {
                    lblShortcut.Text = Settings.shortCutToString(modifier, key);
                    keyboardScKey[chkKeyboard.SelectedIndex] = modifier * 256 + key;
                }
            }
            else
            {
                //Optional
                form1.Dispose();
            }
        }

        private void niSystem_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //cmsKeyboards.Show(Control.MousePosition);
            }
        }

        private void tsmConfig_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            halt();
        }

        private void btnKbInstaller_Click(object sender, EventArgs e)
        {
            DialogResult dr = ofdKbInstaller.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string fN = ofdKbInstaller.FileName;
                FileInfo fI = new FileInfo(fN);
                if (fI.Extension.ToLower() == ".xml")
                {
                    try
                    {
                        File.Copy(fN,
                            Application.StartupPath + "\\keyboards\\" + fI.Name, true);
                        MessageBox.Show("Application will restart now.");
                        Application.Restart();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //Add Shortcut keys details to setting xml via setting object
            int modifier;
            int key;
            for (int i = 0; i < keyboardScKey.Count; i++)
            {
                key = keyboardScKey[i];
                modifier = (key | 255) - 255;
                key = key - modifier;
                modifier = modifier >> 8;
                setting.setShoutcut(keyboardName[i], modifier, key);
                setting.setEnable(keyboardName[i],
                    (int)chkKeyboard.GetItemCheckState(i) == 1 ? true : false);
            }
            key = keyboardOffScKey;
            modifier = (key | 255) - 255;
            key = key - modifier;
            modifier = modifier >> 8;
            setting.setMainShoutcuts("keyboardOffScKey", modifier, key);
            key = keyboardOnScKey;
            modifier = (key | 255) - 255;
            key = key - modifier;
            modifier = modifier >> 8;
            setting.setMainShoutcuts("keyboardOnScKey", modifier, key);
            key = keyboardRotateScKey;
            modifier = (key | 255) - 255;
            key = key - modifier;
            modifier = modifier >> 8;
            setting.setMainShoutcuts("keyboardRotateScKey", modifier, key);


            //Reload changed settings to the application memory
            registerShortcutKeys();


            //Set Application run on windows startup or not
            if (chkStartUp.Checked)
            {
                Startup.regRun(2, Application.ExecutablePath, "UniKeyBoard");
            }
            else Startup.removeRegRun(2, "UniKeyBoard");

            Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setKeyList();
            setShortcutList();
            chkKeyboard_SelectedIndexChanged(sender, e);
            Hide();
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            setKeyList();
            setShortcutList();
            chkKeyboard_SelectedIndexChanged(sender, e);
        }

        private void btnKBUninstall_Click(object sender, EventArgs e)
        {
            int index = chkKeyboard.SelectedIndex;
            if (index != -1)
            {
                try
                {
                    File.Delete(keyboardPath[index]);
                    MessageBox.Show("Application will restart now.");
                    Application.Restart();

                }
                catch
                {
                    MessageBox.Show(
                        "Error Occour while tring to delete keyboard layout.");
                }
            }

        }

        private void frmConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!halting)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void btnGlobleShortcut_Click(object sender, EventArgs e)
        {
            int modifier = 0;
            int key = 0;
            //DialogResult rs=(new frmHotKey()).ShowDialog();

            Settings.splitKeyCode(keyboardRotateScKey, ref modifier, ref key);

            frmHotKey form1 = new frmHotKey(modifier, key);
            // Display the form as a modal dialog box.
            form1.ShowDialog();

            // Determine if the OK button was clicked on the dialog box.
            if (form1.DialogResult == DialogResult.OK)
            {
                form1.getHotKeys(ref modifier, ref key);

                // Optional
                form1.Dispose();
                if (isScKeyAvailale(modifier,key))
                {
                    MessageBox.Show("Shortcut Key combination already in use. Please select a new combination.");
                    btnGlobleShortcut_Click(sender,e);
                }
                else
                {
                    lblGlobleShortcut.Text = Settings.shortCutToString(modifier, key);
                    keyboardRotateScKey = modifier * 256 + key;
                }
            }
            else
            {
                //Optional
                form1.Dispose();
            }
        }

        private void btnKeyTouchOff_Click(object sender, EventArgs e)
        {
            int modifier = 0;
            int key = 0;
            //DialogResult rs=(new frmHotKey()).ShowDialog();
            Settings.splitKeyCode(keyboardOffScKey, ref modifier, ref key);

            frmHotKey form1 = new frmHotKey(modifier, key);
            // Display the form as a modal dialog box.
            form1.ShowDialog();

            // Determine if the OK button was clicked on the dialog box.
            if (form1.DialogResult == DialogResult.OK)
            {
                form1.getHotKeys(ref modifier, ref key);
                // Optional
                form1.Dispose();
                if (isScKeyAvailale(modifier, key))
                {
                    MessageBox.Show("Shortcut Key combination already in use. Please select a new combination.");
                    btnKeyTouchOff_Click(sender, e);
                }
                else
                {
                    lblKeyTouchOff.Text = Settings.shortCutToString(modifier, key);
                    keyboardOffScKey = modifier * 256 + key;
                }
            }
            else
            {
                //Optional
                form1.Dispose();
            }
        }

        private void btnKeyTouchOn_Click(object sender, EventArgs e)
        {
            int modifier = 0;
            int key = 0;
            //DialogResult rs=(new frmHotKey()).ShowDialog();
            Settings.splitKeyCode(keyboardOnScKey, ref modifier, ref key);

            frmHotKey form1 = new frmHotKey(modifier, key);
            // Display the form as a modal dialog box.
            form1.ShowDialog();

            // Determine if the OK button was clicked on the dialog box.
            if (form1.DialogResult == DialogResult.OK)
            {
                form1.getHotKeys(ref modifier, ref key);
                // Optional
                form1.Dispose();
                if (isScKeyAvailale(modifier, key))
                {
                    MessageBox.Show("Shortcut Key combination already in use. Please select a new combination.");
                    btnKeyTouchOn_Click(sender, e);
                }
                else
                {
                    lblKeyTouchOn.Text = Settings.shortCutToString(modifier, key);
                    keyboardOnScKey = modifier * 256 + key;
                }
            }
            else
            {
                //Optional
                form1.Dispose();
            }

        }

        #endregion

        private void tsmAbout_Click(object sender, EventArgs e)
        {
            frmAbout frAbout = new frmAbout();
            frAbout.ShowDialog();
        }



    }
}