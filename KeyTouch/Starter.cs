using System;
using System.Collections.Generic;
using System.Text;

namespace KeyTouch
{
    class Starter
    {
        [STAThread]
        public static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            frmConfig fC=new frmConfig();
            System.Windows.Forms.Application.Run();
            //fC.ShowDialog();

        }
    }
}
