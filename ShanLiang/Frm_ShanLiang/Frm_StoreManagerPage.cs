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

namespace Frm_ShanLiang
{
    public partial class Frm_StoreManagerPage : Form
    {
        public Frm_StoreManagerPage()
        {
            InitializeComponent();
            lab_accountName.Text = $"您好，{CStoreData._storyName}";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                txt_searchStyle.SetWatermark("搜尋類型");
                txt_accountName.Text = CStoreData._loginAccountName;
                txt_address.Text = CStoreData._restaurantAddress;
                txt_storeName.Text = CStoreData._restaurantName;
                txt_seats.Text = CStoreData._seats.ToString();
                txt_storePhone.Text = CStoreData._restaurantPhone;
            }
        }
    }
}
