using Frm_ShanLiang.ExtesionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frm_ShanLiang
{
    public partial class Frm_StoreSignInPage : Form
    {
        public Frm_StoreSignInPage()
        {
            InitializeComponent();

            txt_account.SetWatermark("店家帳號");
            txt_name.SetWatermark("店家名稱");
            txt_password.SetWatermark("店家密碼");
            txt_doubleCheckPassword.SetWatermark("再次輸入店家密碼");
            txt_address.SetWatermark("店家地址");
            //txt_.SetWatermark("店家類型");
            txt_phone.SetWatermark("店家電話號碼");
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {

        }
    }
}
