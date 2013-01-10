using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace KeyTouch
{
    static class XmlManager
    {
        //Use to creat basic layout of a XML file
        public static bool createXML(string filepath, string root)
        {
            try
            {
                XmlTextWriter xtw;
                xtw = new XmlTextWriter(filepath, Encoding.UTF8);
                xtw.WriteStartDocument();
                xtw.WriteStartElement(root);
                xtw.WriteEndElement();
                xtw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool validateXML(XmlDocument xDoc, string xDtd)
        {
            //XmlD
            return true;
        }
    }
}
