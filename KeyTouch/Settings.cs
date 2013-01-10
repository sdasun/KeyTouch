using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
namespace KeyTouch
{
    class Settings
    {
        private string settingFile;
        XmlDocument xSetting = new XmlDocument();

        public Settings(string path)
        {
            settingFile = path;
            xSetting = new XmlDocument();
            try
            {
                //Try To Load Setting Page
                FileStream rSetting = new FileStream(settingFile, FileMode.Open);
                xSetting.Load(rSetting);
                rSetting.Close();
            }
            catch //Assume Setting Page is not exist 
            {
                //Try To Create Setting XML
                if (!XmlManager.createXML(settingFile, "settings"))
                {
                    //Seems Somethings Wrong while tring to create setting xml file
                    //File May Already in use or Lack of permission to Access

                    //Can't skip this step. Need to halt 
                    throw new System.ArgumentException("Error occur while tring to read setting file.", "settingFile");
                }
                else
                {
                    try
                    {
                        //Seems Setting page was created.
                        //Now load it again in to memory ;)
                        FileStream rSetting = new FileStream(settingFile, FileMode.Open);
                        xSetting.Load(rSetting);
                        rSetting.Close();
                    }
                    catch
                    {
                        //Opps!
                        //Some thing goes wrong while tring read created xml 

                        //Can't skip this step should teminate application :(
                        throw new System.ArgumentException("Error occur while tring to read setting file.", "settingFile");
                    }

                }
            }
        }

        public XmlDocument getXmlDocument()
        {
            return xSetting;
        }

        public bool installKeybord(string keylayout)
        {
            try
            {
                XmlElement xeKb = xSetting.CreateElement("keyboard");
                XmlElement xeNm = xSetting.CreateElement("name");
                XmlElement xeSc = xSetting.CreateElement("shortcut");
                XmlElement xeEn = xSetting.CreateElement("isEnable");
                XmlText xtNm = xSetting.CreateTextNode(keylayout);
                XmlText xtSc = xSetting.CreateTextNode("N/A");
                XmlText xtEn = xSetting.CreateTextNode("0");

                xeNm.AppendChild(xtNm);
                xeSc.AppendChild(xtSc);
                xeEn.AppendChild(xtEn);
                xeKb.AppendChild(xeNm);
                xeKb.AppendChild(xeSc);
                xeKb.AppendChild(xeEn);

                xSetting.DocumentElement.AppendChild(xeKb);
                xSetting.Save(settingFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool setShoutcut(string keylayout, int modifier, int key)
        {
            try
            {
                int count = xSetting.GetElementsByTagName("name").Count;
                if (count > 0)
                {
                    for (int j = 0; j < count; j++)
                        if (xSetting.GetElementsByTagName("name")[j].InnerText == keylayout)
                        {
                            XmlElement xeKb = (XmlElement)xSetting.GetElementsByTagName("name")[j].ParentNode;
                            if (xeKb.GetElementsByTagName("shortcut").Count == 1)
                            {
                                xeKb.GetElementsByTagName("shortcut")[0].InnerText = modifier.ToString() + "-" + key.ToString();
                                xSetting.Save(settingFile);
                            }
                            else if (xeKb.GetElementsByTagName("shortcut").Count == 0)
                            {
                                XmlElement xeSc = xSetting.CreateElement("shortcut");
                                XmlText xtSc = xSetting.CreateTextNode(modifier.ToString() + "-" + key.ToString());
                                xeSc.AppendChild(xtSc);
                                xeKb.AppendChild(xeSc);
                                xSetting.Save(settingFile);
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string getShoutcut(string keylayout)
        {
            int modi = 1;
            int key = 1;
            return getShoutcut(keylayout, ref modi, ref key);
        }

        public string getShoutcut(string keylayout, ref int modifier, ref int key)
        {
            try
            {
                int count = xSetting.GetElementsByTagName("name").Count;
                if (count > 0)
                {
                    for (int j = 0; j < count; j++)
                        if (xSetting.GetElementsByTagName("name")[j].InnerText == keylayout)
                        {
                            XmlElement xeKb = (XmlElement)xSetting.GetElementsByTagName("name")[j].ParentNode;
                            if (xeKb.GetElementsByTagName("shortcut").Count == 1)
                            {
                                string[] st = xeKb.GetElementsByTagName("shortcut")[0].InnerText.Split('-');
                                if (st.Length == 2)
                                {
                                    try
                                    {
                                        modifier = Int16.Parse(st[0]);
                                        key = Int16.Parse(st[1]);
                                    }
                                    catch
                                    {
                                        modifier = 0;
                                        key = 0;
                                    }
                                }
                                else
                                {
                                    modifier = 0;
                                    key = 0;
                                }
                            }
                            else
                            {
                                modifier = 0;
                                key = 0;
                            }
                            break;
                        }
                }
                return shortCutToString(modifier, key);
            }
            catch
            {
                return "N/A";
            }
        }

        public int getShoutcutInt(string keylayout)
        {
            int modifier=0;
            int key=0;

            try
            {
                int count = xSetting.GetElementsByTagName("name").Count;
                if (count > 0)
                {
                    for (int j = 0; j < count; j++)
                        if (xSetting.GetElementsByTagName("name")[j].InnerText == keylayout)
                        {
                            XmlElement xeKb = (XmlElement)xSetting.GetElementsByTagName("name")[j].ParentNode;
                            if (xeKb.GetElementsByTagName("shortcut").Count == 1)
                            {
                                string[] st = xeKb.GetElementsByTagName("shortcut")[0].InnerText.Split('-');
                                if (st.Length == 2)
                                {
                                    try
                                    {
                                        modifier = Int16.Parse(st[0]);
                                        key = Int16.Parse(st[1]);
                                    }
                                    catch
                                    {
                                        modifier = 0;
                                        key = 0;
                                    }
                                }
                                else
                                {
                                    modifier = 0;
                                    key = 0;
                                }
                            }
                            else
                            {
                                modifier = 0;
                                key = 0;
                            }
                            break;
                        }
                }
                if (modifier == 0 && key == 0)
                    return -1;
                else
                {
                    return (modifier * 256 + key);
                }
            }
            catch
            {
                return -1;
            }
        }

        public static string shortCutToString(int modifier, int key)
        {
            string shortKey;
            if ((modifier == 0 && key == 0) || modifier == 0)
            {
                key = 0;
                shortKey = "N/A";
            }
            else
            {
                shortKey = ((modifier & 1) != 0 ? "Alt" : "");
                shortKey = shortKey + ((modifier & 2) != 0 ? (shortKey == "" ? "Ctrl" : "+Ctrl") : "");
                shortKey = shortKey + ((modifier & 4) != 0 ? (shortKey == "" ? "Shift" : "+Shift") : "");
                if (key != 0) shortKey = shortKey + " + " + Enum.GetName(typeof(Keys), key);
            }
            return shortKey;
        }

        public bool isKeyboardInstalled(string keylayout)
        {
            int count = xSetting.GetElementsByTagName("name").Count;
            if (count > 0)
            {
                for (int j = 0; j < count; j++)
                {
                    //check is keylayout already installed.
                    if (xSetting.GetElementsByTagName("name")[j].InnerText == keylayout)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool isEnable(string keylayout)
        {
            try
            {
                int count = xSetting.GetElementsByTagName("name").Count;
                if (count > 0)
                {
                    for (int j = 0; j < count; j++)
                        if (xSetting.GetElementsByTagName("name")[j].InnerText == keylayout)
                        {
                            XmlElement xeKb = (XmlElement)xSetting.GetElementsByTagName("name")[j].ParentNode;
                            if (xeKb.GetElementsByTagName("isEnable").Count == 1)
                            {
                                string st = xeKb.GetElementsByTagName("isEnable")[0].InnerText;
                                if (xeKb.GetElementsByTagName("isEnable")[0].InnerText == "1")
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
                                return false;
                            }
                        }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        public bool setEnable(string keylayout,bool isEnable)
        {
            try
            {
                int count = xSetting.GetElementsByTagName("name").Count;
                if (count > 0)
                {
                    for (int j = 0; j < count; j++)
                        if (xSetting.GetElementsByTagName("name")[j].InnerText == keylayout)
                        {
                            XmlElement xeKb = (XmlElement)xSetting.GetElementsByTagName("name")[j].ParentNode;
                            if (xeKb.GetElementsByTagName("isEnable").Count == 1)
                            {
                                xeKb.GetElementsByTagName("isEnable")[0].InnerText = isEnable ? "1" : "0";
                                xSetting.Save(settingFile);
                            }
                            else if (xeKb.GetElementsByTagName("isEnable").Count == 0)
                            {
                                XmlElement xeSc = xSetting.CreateElement("isEnable");
                                XmlText xtSc = xSetting.CreateTextNode(isEnable ? "1" : "0");
                                xeSc.AppendChild(xtSc);
                                xeKb.AppendChild(xeSc);
                                xSetting.Save(settingFile);
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string[] getKeylayoutList()
        {
            try
            {
                XmlNodeList xnlKeyboard = xSetting.GetElementsByTagName("name");
                int count = xnlKeyboard.Count;
                if (count==-1) return null;
                string[] keyList=new string[count];

                for (int i = 0; i < count; i++) 
                {
                    keyList[count] = xnlKeyboard[i].InnerText;
                }
                return keyList;
            }
            catch
            {
                //Some error has ditected
                return null;
            }

            
        }

        public bool setMainShoutcuts(string attribute, int modifier, int key)
        {
            try
            {
                XmlElement root = (XmlElement)xSetting["settings"];
                root.SetAttribute(attribute, modifier.ToString() + "-" + key.ToString());
                xSetting.Save(settingFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string getMainShoutcuts(string attribute, ref int modifier, ref int key)
        {
            try
            {
                XmlElement root = (XmlElement)xSetting["settings"];
                String rt= root.GetAttribute(attribute);
                if (rt != "")
                {
                    string[] st = rt.Split('-');
                    if (st.Length == 2)
                    {
                        try
                        {
                            modifier = Int16.Parse(st[0]);
                            key = Int16.Parse(st[1]);
                        }
                        catch
                        {
                            modifier = 0;
                            key = 0;
                        }
                    }
                    else
                    {
                        modifier = 0;
                        key = 0;
                    }
                }
                else
                {
                    modifier = 0;
                    key = 0;
                }
                return shortCutToString(modifier, key);
            }
            catch
            {
                return "N/A";
            }
        }

        public static void splitKeyCode(int scKeycode, ref int modifier, ref int key)
        {
            key = scKeycode;
            modifier = (key | 255) - 255;
            key = key - modifier;
            modifier = modifier >> 8;
        }
        public static int combineKeyCode(int modifier,int key)
        {
            return modifier * 256 + key;
        }
    }
}
