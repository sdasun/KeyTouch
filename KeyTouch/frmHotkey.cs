using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KeyTouch
{
    public partial class frmHotKey : Form
    {
        int modifier = 0;
        int key = 0;
        public void getHotKeys(ref int modifier, ref int key)
        {
            modifier = this.modifier;
            key = this.key;
        }

        public frmHotKey()
        {
            InitializeComponent();

        }
        public frmHotKey(int modifier, int key)
        {
            this.modifier = modifier;
            this.key = key;
            InitializeComponent();
        }

        private void frmHotKey_Load(object sender, EventArgs e)
        {
            cmbKeys.Items.Add("None");
            for (int i = 61; i < 87; i++)
            {
                cmbKeys.Items.Add(Enum.GetNames(typeof(Keys))[i]);
            }
            for (int i = 107; i < 119; i++)
            {
                cmbKeys.Items.Add(Enum.GetNames(typeof(Keys))[i]);
            }
            if (key == 0)
            {
                cmbKeys.SelectedIndex = 0;
            }
            else if (key >= 65 && key < 91) //A to Z
            {
                cmbKeys.SelectedIndex = key - 64;
            }
            else if (key >= 112 && key < 124)
            {
                cmbKeys.SelectedIndex = key - 85;
            }
            else cmbKeys.SelectedIndex = 0;

            if ((modifier & 1) != 0)
            {
                chkAlt.Checked = true;
            }
            if ((modifier & 2) != 0)
            {
                chkCtrl.Checked = true;
            }
            if ((modifier & 4) != 0)
            {
                chkShift.Checked = true;
            }

        }


        private void btnApply_Click(object sender, EventArgs e)
        {
            modifier = (chkAlt.Checked ? 1 : 0) | (chkCtrl.Checked ? 2 : 0) | (chkShift.Checked ? 4 : 0);
            key = (int)Enum.Parse(typeof(Keys), cmbKeys.Text);
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
