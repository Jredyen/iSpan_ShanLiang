using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        ShanLiangEntities SLE = new ShanLiangEntities();
        List<string> _storeType;
        public Frm_StoreManagerPage()
        {
            InitializeComponent();
            lab_accountName.Text = $"您好，{CStoreData._storyName}";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 1:
                    storeDataManager();
                    break;
                case 2:

                    break;
            }
        }

        void storeDataManager()
        {
            txt_searchStyle.SetWatermark("搜尋類型");
            txt_accountName.Text = CStoreData._loginAccountName;
            txt_address.Text = CStoreData._restaurantAddress;
            txt_storeName.Text = CStoreData._restaurantName;
            txt_seats.Text = CStoreData._seats.ToString();
            txt_storePhone.Text = CStoreData._restaurantPhone;
            txt_web.Text = CStoreData._website;
            txt_email.Text = CStoreData._storeMail;
            if (CStoreData._openTime.HasValue && CStoreData._closeTime.HasValue)
            {
                TimeSpan openTime = CStoreData._openTime.Value;
                TimeSpan closeTime = CStoreData._closeTime.Value;
                open_hh.Value = openTime.Hours;
                open_mm.Value = openTime.Minutes;
                close_hh.Value = closeTime.Hours;
                close_mm.Value = closeTime.Minutes;
            }
            var restaurantTypeName = SLE.Restaurant_Type.Select(n => n.TypeName)
                .Except(from RT in SLE.Restaurant_Type
                        join ST in SLE.Store_Type
                        on RT.RestaurantTypeNum equals ST.RestaurantTypeNum
                        where ST.StoreID == CStoreData._storeID
                        select RT.TypeName);
            listBox_allType.Items.Clear();
            foreach (string item in restaurantTypeName)
            {
                listBox_allType.Items.Add(item);
            }

            _storeType = SLE.Store_Type.Where(n => n.StoreID == CStoreData._storeID).Select(n => n.Restaurant_Type.TypeName).ToList();
            listBox_storeType.Items.Clear();
            foreach (string item in _storeType)
            {
                listBox_storeType.Items.Add(item);
            }
        }

        private void btn_allSearch_Click(object sender, EventArgs e)
        {
            var v = /*from o in */SLE.Orders
                    //join pm in SLE.Payment_Method on o.PaymentMethodID equals pm.PaymentMethodID
                    //join em in SLE.EatType_Method on o.EatTypeMethodID equals em.EatTypeMethodID
                    //where o.StoreID == CStoreData._storeID
                    //select new { 訂單編號 = o.OrderID, 客戶編號 = o.MemberID, 訂單時間 = o.ReservationTime, 付款方式 = pm.PaymentName, 用餐方式 = em.EatTypeMethodName, 優惠券編號 = o.CouponID };
                    .Where(n => n.StoreID == CStoreData._storeID)
                    .Select(n => new { 訂單編號 = n.OrderID, 客戶編號 = n.MemberID, 訂單時間 = n.ReservationTime, 付款方式 = n.Payment_Method.PaymentName, 用餐方式 = n.EatType_Method.EatTypeMethodName, 優惠券編號 = n.CouponID });

            ddv_orderDetails.DataSource = v.ToList();
        }

        private void btn_updata_Click(object sender, EventArgs e)
        {
            bool isApproved = SLE.Accounts.Where(n => n.AccountPassword == txt_password.Text && n.AccountName == CNowLoginAccount._loginAccountName).Select(n => n).Any();
            if (isApproved)
            {
                var storeData = SLE.Stores.Where(n => n.StoreID == CStoreData._storeID).Select(n => n).First();
                storeData.RestaurantName = txt_storeName.Text;
                storeData.RestaurantPhone = txt_storePhone.Text;
                storeData.Seats = Convert.ToInt32(txt_seats.Text);
                storeData.Website = txt_web.Text;
                storeData.StoreMail = txt_email.Text;

                string openTime = $"{open_hh.Value}:{open_mm.Value}";
                string closeTime = $"{close_hh.Value}:{close_mm.Value}";
                storeData.OpeningTime = TimeSpan.Parse(openTime);
                storeData.ClosingTime = TimeSpan.Parse(closeTime);

                //TODO:更新店家類型


                if (txt_newPassword.Text != "" && txt_newPassword.Text == txt_newDoubleCheckPassword.Text)
                {
                    var accountData = SLE.Accounts.Where(n => n.AccountPassword == txt_password.Text && n.AccountName == CNowLoginAccount._loginAccountName).Select(n => n).First();
                    accountData.AccountPassword = txt_newPassword.Text;
                }
                SLE.SaveChanges();
                MessageBox.Show("資料修改成功");
            }
            else
            {
                MessageBox.Show("密碼錯誤");
                return;
            }
        }

        private void txt_searchStyle_TextChanged(object sender, EventArgs e)
        {
            var restaurantTypeName = SLE.Restaurant_Type.Where(n => n.TypeName.Contains(txt_searchStyle.Text)).Select(n => n.TypeName);
            listBox_allType.Items.Clear();
            foreach (string item in restaurantTypeName)
            {
                listBox_allType.Items.Add(item);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            listBox_storeType.Items.Add(listBox_allType.SelectedItem);
            listBox_allType.Items.Remove(listBox_allType.SelectedItem);
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            listBox_allType.Items.Add(listBox_storeType.SelectedItem);
            listBox_storeType.Items.Remove(listBox_storeType.SelectedItem);
        }
    }
}
