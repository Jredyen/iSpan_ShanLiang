using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Frm_ShanLiang.ExtesionMethods;
using ShanLiang;

namespace Frm_ShanLiang
{
    public partial class Frm_LoginPage : Form
    {
        public Frm_LoginPage()
        {
            InitializeComponent();
            txt_accountName.SetWatermark("帳號");
            txt_password.SetWatermark("密碼");
        }

        private void linkLab_signin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            new Frm_SignupPage().ShowDialog();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
