//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace OpenKey
//{
//    public class DynamicMenuItem : MenuItem
//    {
//        private string _data;

//        // Dynamic menus information, i.e. menu text and menu data are
//        // normally retrieved from some source like a database or
//        // Registry. Putting them into an array of DynamicMenuItemTextData
//        // struct will make it convenient to prepare for creating a group
//        // of dynamic menu items through the dynamic menu manager.
//        public struct DynamicMenuItemTextData
//        {
//            string _menuText;
//            string _menuData;

//            public string MenuText
//            {
//                get { return _menuText; }
//                set { _menuText = value; }
//            }
//            public string MenuData
//            {
//                get { return _menuData; }
//                set { _menuData = value; }
//            }
//            public DynamicMenuItemTextData(string menuText,
//                                           string menuData)
//            {
//                _menuText = menuText;
//                _menuData = menuData;
//            }
//        }

//        public string Data
//        {
//            get { return _data; }
//            set { _data = value; }
//        }

//        public DynamicMenuItem(string text, string data,
//                               System.EventHandler eventHandler)
//            : base(text)
//        {
//            _data = data;
//            // Add menu item clicked event handler when it is created.
//            this.Click += new System.EventHandler(eventHandler);
//        }
//    }
//}
