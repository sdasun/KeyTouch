using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml;
using System.IO;
using System.Collections.Generic;
namespace KeyboardLibrary
{

    /// <summary>
    /// Captures global keyboard events
    /// </summary>
    public class KeyboardHook : GlobalHook
    {
        bool isAltGrUsed = false;
        bool rAltDown = false;
        int oldState = 0;
        bool skipOnce =false;
        string keyboardName = "";
        byte[] keyStates = new byte[255];

        #region KeyArrays
            public string[] defaultKeyArray;
            public string[] shiftKeyArray;
            public string[] capsKeyArray;
            public string[] capsAndShiftKeyArray;
            public string[] altGrKeyArray;
            public int[,] stateArray;
            public List<string> stateList= new List<string>();
            public List<string>[] sequenceInput;
            public List<string>[] sequenceOutput;
            public List<int>[] sequenceState;
        #endregion

        #region Constructor

        public KeyboardHook()
        {
            _hookType = WH_KEYBOARD_LL;
        }

        public void setKeyboard(string path,string keylayout)
        {
            fetchXML(path);
            keyboardName = keylayout;
        }

        public string getKeyboard()
        {
            return keyboardName;
        }

        #endregion

        #region Methods

        protected override int HookCallbackProcedure(int nCode, int wParam, IntPtr lParam)
        {
            int state = 0;
            bool handled = false;
            string inKey="";
            int tmp_i;
            if (nCode > -1)
            {

                KeyboardHookStruct keyboardHookStruct =
                    (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));

                // Is Control being held down?
                bool control = ((GetKeyState(VK_LCONTROL) & 0x80) != 0) ||
                    ((GetKeyState(VK_RCONTROL) & 0x80) != 0);

                // Is Shift being held down?
                bool shift = ((GetKeyState(VK_LSHIFT) & 0x80) != 0) ||
                             ((GetKeyState(VK_RSHIFT) & 0x80) != 0);

                // Is Alt being held down?
                bool lAlt = ((GetKeyState(VK_LALT) & 0x80) != 0) ;

                bool rAlt = ((GetKeyState(VK_RALT) & 0x80) != 0) ;

                // Is CapsLock and Shift on?
                bool capslock = (GetKeyState(VK_CAPITAL) != 0);

                // Is Winkey being held down?
                bool winkey = ((GetKeyState(VK_LWIN) & 0x80) != 0) ||
                    ((GetKeyState(VK_RWIN) & 0x80) != 0);

                // Is Menukey being held down?
                bool menukey = false; //((GetKeyState(VK_LMENU) & 0x80) != 0) ||
                    //((GetKeyState(VK_RME‍NU) & 0x80) != 0);
                
                if (!(lAlt |control |menukey |winkey|skipOnce)) 
                {
                    
                    switch (wParam)
                    {
                        case WM_KEYDOWN:
                        case WM_SYSKEYDOWN:
                            if (isAltGrUsed && keyboardHookStruct.vkCode==165)
                            {
                                rAltDown = true;
                                handled = true;
                                setRAltKeyOff();
                            }else if (capslock && shift)
                            {
                                if ((keyboardHookStruct.vkCode > 47 && keyboardHookStruct.vkCode < 91)||
                                    (keyboardHookStruct.vkCode > 185 && keyboardHookStruct.vkCode < 193)||
                                    (keyboardHookStruct.vkCode > 218 && keyboardHookStruct.vkCode < 224))
                                {
                                    if (defaultKeyArray[keyboardHookStruct.vkCode] != "")
                                    {
                                        inKey= capsAndShiftKeyArray[keyboardHookStruct.vkCode];
                                        state = stateArray[3, keyboardHookStruct.vkCode];
                                        handled = true;
                                    }
                                    else handled = false;
                                }
                                else handled = false;
                                rAltDown = false;
                            // Is Shift on?
                            }else if (shift)
                            {
                                if ((keyboardHookStruct.vkCode > 47 && keyboardHookStruct.vkCode < 91)||
                                    (keyboardHookStruct.vkCode > 185 && keyboardHookStruct.vkCode < 193)||
                                    (keyboardHookStruct.vkCode > 218 && keyboardHookStruct.vkCode < 224))
                                {
                                    if (shiftKeyArray[keyboardHookStruct.vkCode] != "")
                                    {
                                        inKey= shiftKeyArray[keyboardHookStruct.vkCode];
                                        state = stateArray[1, keyboardHookStruct.vkCode];
                                        handled = true;
                                    }
                                    else handled = false;
                                }
                                else handled = false;
                                rAltDown = false;
                            }
                            // Is CapsLock on?
                            else if (capslock)
                            {
                                if ((keyboardHookStruct.vkCode > 47 && keyboardHookStruct.vkCode < 91)||
                                    (keyboardHookStruct.vkCode > 185 && keyboardHookStruct.vkCode < 193)||
                                    (keyboardHookStruct.vkCode > 218 && keyboardHookStruct.vkCode < 224))
                                {
                                    if (defaultKeyArray[keyboardHookStruct.vkCode] != "")
                                    {
                                        inKey = capsKeyArray[keyboardHookStruct.vkCode];
                                        state = stateArray[2, keyboardHookStruct.vkCode];
                                        handled = true;
                                    }
                                    else handled = false;
                                }
                                else handled = false;
                                rAltDown = false;
                            }
                            // Is AltGr on?
                            else if (rAltDown)
                            {
                                if ((keyboardHookStruct.vkCode > 47 && keyboardHookStruct.vkCode < 91)||
                                    (keyboardHookStruct.vkCode > 185 && keyboardHookStruct.vkCode < 193)||
                                    (keyboardHookStruct.vkCode > 218 && keyboardHookStruct.vkCode < 224))
                                {
                                    if (defaultKeyArray[keyboardHookStruct.vkCode] != "")
                                    {
                                        inKey= altGrKeyArray[keyboardHookStruct.vkCode];
                                        state = stateArray[4, keyboardHookStruct.vkCode];
                                        handled = true;
                                    }
                                    else handled = true;
                                }
                                else handled = true;
                                rAltDown = false;
                            }
                            // Default
                            else 
                            {
                                if ((keyboardHookStruct.vkCode > 47 && keyboardHookStruct.vkCode < 91)||
                                    (keyboardHookStruct.vkCode > 185 && keyboardHookStruct.vkCode < 193)||
                                    (keyboardHookStruct.vkCode > 218 && keyboardHookStruct.vkCode < 224))
                                {
                                    if (defaultKeyArray[keyboardHookStruct.vkCode] != "")
                                    {
                                        inKey = defaultKeyArray[keyboardHookStruct.vkCode];
                                        state = stateArray[0, keyboardHookStruct.vkCode];
                                        handled = true;
                                    }
                                    else handled = false;
                                }
                                else if (keyboardHookStruct.vkCode == 32 || keyboardHookStruct.vkCode == 10 || keyboardHookStruct.vkCode == 13)
                                {
                                    oldState  = 0;
                                    handled = false;
                                }
                                else handled = false;
                                rAltDown = false;
                            }
                            //if (keyboardHookStruct.vkCode == 165 && isAltGrUsed) handled = true;
                            if (handled) 
                            { 
                                if (oldState > 0 )
                                {
                                    if (sequenceInput[oldState - 1].Count > 0)
                                    {
                                        tmp_i = sequenceInput[oldState - 1].IndexOf(inKey);
                                        if (0 <= tmp_i)
                                        {
                                            skipOnce = true;
                                            SendKeys.Send(sequenceOutput[oldState - 1][tmp_i]);
                                            state = sequenceState[oldState-1][tmp_i];
                                        }
                                        else
                                        {
                                            if (shift)
                                            {
                                                setShiftKeyOff();

                                            }
                                            skipOnce = true;
                                            if (inKey != "") SendKeys.Send(inKey);
                                        }
                                    }
                                    else
                                    {
                                        if (shift)
                                        {
                                            setShiftKeyOff();
                                        }
                                        skipOnce = true;
                                        if(inKey!="")SendKeys.Send(inKey);
                                    }
                                }
                                else
                                {
                                    if (shift)
                                    {
                                        setShiftKeyOff();
                                    }
                                    skipOnce = true;
                                    if (inKey != "") SendKeys.Send(inKey);
                                }
                                oldState = state;
                            }
                            skipOnce = false;
                            state = 0;
                            break;
                    }
                }
                //if (rAlt && isAltGrUsed)
                //{
                //    handled = true;
                //}
            }

            if (handled)
            {
                return 1;
            }
            else
            {
                
                //nCode = 80;
                //RtlMoveMemory(lParam, myarrpointer, (uint)(KeyboardHookStruct.sizeofkbs));
                return CallNextHookEx(_handleToHook, nCode, wParam,lParam);
            }

        }
        void setShiftKeyOff()
        {
            setKeyOff(16);
        }
        void setRAltKeyOff()
        {
            setKeyOff(VK_RALT);
        }
        void setKeyOff(int i)
        {
            GetKeyboardState(keyStates); //load the keyboard
            keyStates[i] = 0; // turn off the [i] key
            SetKeyboardState(keyStates); //set the new keyboard state

        }

        public bool fetchXML(string path) 
        {
            #region fetch xml
            defaultKeyArray = new string[256];
            capsKeyArray = new string[256];
            shiftKeyArray = new string[256];
            capsAndShiftKeyArray = new string[256];
            altGrKeyArray = new string[256];
            stateArray = new int[5, 256];
            XmlDocument xdoc = new XmlDocument();
            XmlDocument xInnerDoc = new XmlDocument();
            XmlNodeList innerList;
            XmlElement cl;
            XmlElement list;

            Int16 index;
            string tmpIndex;

            Int16 tmp_i = 0;
            Int16 tmp_j = 0;

            isAltGrUsed = false;

            try
            {
                FileStream rfile = new FileStream(path , FileMode.Open);
                xdoc.Load(rfile);
                rfile.Close();
            }
            catch (Exception e) 
            {

                MessageBox.Show("Cannot Load keyboard layout," + e.Data, "Error");
            }
            
            
            // clear state list
            stateList.Clear();

            //Ini Default Key Array
            parseXMLKeylayout(xdoc, defaultKeyArray, 0, "defaultKeyMap");

            //Ini Shift Key Array
            parseXMLKeylayout(xdoc, shiftKeyArray, 1, "shiftKeyMap");

            //Ini Caps Key Array
            parseXMLKeylayout(xdoc, capsKeyArray, 2, "capsKeyMap");

            //Ini Shift+Caps Key Array
            parseXMLKeylayout(xdoc, capsAndShiftKeyArray, 3, "capsAndShiftKeyMap");

            //Ini AltGr Key Array
            parseXMLKeylayout(xdoc, altGrKeyArray, 4, "altGrKeyMap");


            //Ini action
            list = (XmlElement)xdoc.GetElementsByTagName("action")[0];
            xInnerDoc.LoadXml("<root>" + list.InnerXml + "</root>");
            innerList = xInnerDoc.GetElementsByTagName("keySequence");

            for (int j = 0; j < innerList.Count; j++)
            {
                cl = (XmlElement)xdoc.GetElementsByTagName("keySequence")[j];
                tmpIndex = cl.GetAttribute("newState");
                if (tmpIndex != "")
                {
                    if (-1 == stateList.IndexOf(tmpIndex))
                        stateList.Add(tmpIndex);
                }
                //tmpIndex = cl.GetAttribute("state");
                //if (tmpIndex != "")
                //{
                //    if (-1 == stateList.IndexOf(tmpIndex))
                //        stateList.Add(tmpIndex);
                //}
            }

            innerList = xInnerDoc.GetElementsByTagName("keySequenceRng");

            for (int j = 0; j < innerList.Count; j++)
            {
                cl = (XmlElement)xdoc.GetElementsByTagName("keySequenceRng")[j];
                tmpIndex = cl.GetAttribute("newState");
                if (tmpIndex != "")
                {
                    if (-1 == stateList.IndexOf(tmpIndex))
                        stateList.Add(tmpIndex);
                }

            }

            sequenceInput = new List<string>[stateList.Count];
            for (int i = 0; i < stateList.Count; i++)
            {
                sequenceInput[i] = new List<string>();
            }
            sequenceOutput = new List<string>[stateList.Count];
            for (int i = 0; i < stateList.Count; i++)
            {
                sequenceOutput[i] = new List<string>();
            }
            sequenceState = new List<int>[stateList.Count];
            for (int i = 0; i < stateList.Count; i++)
            {
                sequenceState[i] = new List<int>();
            }

            innerList = xInnerDoc.GetElementsByTagName("keySequence");
            for (int j = 0; j < innerList.Count; j++)
            {
                cl = (XmlElement)xdoc.GetElementsByTagName("keySequence")[j];
                tmpIndex = cl.GetAttribute("state");
                index = (Int16)stateList.IndexOf(tmpIndex);
                if (index >= 0 && index < 256)
                {
                    tmpIndex = cl.GetAttribute("input");
                    if (tmpIndex != "")
                    {
                        tmp_i = (Int16)tmpIndex[0];
                        sequenceInput[index].Add(tmpIndex);
                        tmpIndex = cl.GetAttribute("output");
                        tmpIndex = tmpIndex.Replace("{inputx}", ((char)tmp_i).ToString());
                        sequenceOutput[index].Add(tmpIndex);
                        tmpIndex = cl.GetAttribute("newState");
                        if (tmpIndex != "")
                        {
                            sequenceState[index].Add(stateList.IndexOf(tmpIndex) + 1);
                        }
                        else
                        {
                            sequenceState[index].Add(-1);
                        }
                    }
                }

            }

            innerList = xInnerDoc.GetElementsByTagName("keySequenceRng");
            for (int j = 0; j < innerList.Count; j++)
            {
                cl = (XmlElement)xdoc.GetElementsByTagName("keySequenceRng")[j];
                tmpIndex = cl.GetAttribute("state");
                index = (Int16)stateList.IndexOf(tmpIndex);
                if (index >= 0 && index < 256)
                {
                    tmpIndex = cl.GetAttribute("start");
                    if (tmpIndex != "") tmp_i = (Int16)tmpIndex[0]; else continue;
                    tmpIndex = cl.GetAttribute("end");
                    if (tmpIndex != "") tmp_j = (Int16)tmpIndex[0]; else continue;
                    if (tmp_j < tmp_i)
                    {
                        short swap = tmp_j;
                        tmp_j = tmp_i;
                        tmp_i = swap;

                    }
                    for (int i = tmp_i; i <= tmp_j; i++)
                    {

                        sequenceInput[index].Add(((char)i).ToString());
                        tmpIndex = cl.GetAttribute("output");
                        tmpIndex = tmpIndex.Replace("(", "{(}");
                        tmpIndex = tmpIndex.Replace(")", "{)}");
                        tmpIndex = tmpIndex.Replace("+", "{+}");
                        tmpIndex = tmpIndex.Replace("^", "{^}");
                        tmpIndex = tmpIndex.Replace("%", "{%}");
                        tmpIndex = tmpIndex.Replace("~", "{~}");
                        tmpIndex = tmpIndex.Replace("[", "{[}");
                        tmpIndex = tmpIndex.Replace("]", "{]}");
                        tmpIndex = tmpIndex.Replace("{inputx}", ((char)i).ToString());
                        sequenceOutput[index].Add(tmpIndex);
                        tmpIndex = cl.GetAttribute("newState");
                        if (tmpIndex != "")
                        {
                            sequenceState[index].Add(stateList.IndexOf(tmpIndex) + 1);
                        }
                        else
                        {
                            sequenceState[index].Add(-1);
                        }

                    }
                }

            }
            #endregion

            return true;
        }

        private bool parseXMLKeylayout(XmlDocument xdoc,string[] keyArray,int stateArrayID,string mainEliment) 
        {
            XmlDocument xInnerDoc = new XmlDocument();
            XmlNodeList innerList;
            XmlElement cl;
            XmlElement list;

            Int16 index;
            string tmpIndex;

            list = (XmlElement)xdoc.GetElementsByTagName(mainEliment)[0];
            xInnerDoc.LoadXml("<root>" + list.InnerXml + "</root>");
            innerList = xInnerDoc.GetElementsByTagName("key");
            for (int j = 0; j < innerList.Count; j++)
            {
                cl = (XmlElement)xInnerDoc.GetElementsByTagName("key")[j];
                tmpIndex = cl.GetAttribute("code");
                index = (Int16)char.Parse(tmpIndex);
                if (index > 0 && index < 256)
                {
                    tmpIndex = cl.GetAttribute("output");
                    tmpIndex = tmpIndex.Replace("(", "{(}");
                    tmpIndex = tmpIndex.Replace(")", "{)}");
                    tmpIndex = tmpIndex.Replace("+", "{+}");
                    tmpIndex = tmpIndex.Replace("^", "{^}");
                    tmpIndex = tmpIndex.Replace("%", "{%}");
                    tmpIndex = tmpIndex.Replace("~", "{~}");
                    tmpIndex = tmpIndex.Replace("[", "{[}");
                    tmpIndex = tmpIndex.Replace("]", "{]}");
                    keyArray[index] = tmpIndex;
                    tmpIndex = cl.GetAttribute("state");
                    if (tmpIndex != "")
                    {
                        if (-1 == stateList.IndexOf(tmpIndex))
                            stateList.Add(tmpIndex);
                        stateArray[stateArrayID, index] = stateList.IndexOf(tmpIndex) + 1;
                    }
                    if (stateArrayID==4)isAltGrUsed = true;
                }
            }
            return true;
        }

        #endregion

    }

}
