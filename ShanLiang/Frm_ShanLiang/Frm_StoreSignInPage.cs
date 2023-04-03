using Frm_ShanLiang.ExtesionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frm_ShanLiang
{
    public partial class Frm_StoreSignInPage : Form
    {

        ShanLiangEntities SLE = new ShanLiangEntities();

        public Frm_StoreSignInPage()
        {
            InitializeComponent();

            txt_account.SetWatermark("店家帳號");
            txt_password.SetWatermark("店家密碼");
            txt_doubleCheckPassword.SetWatermark("再次輸入店家密碼");
            txt_taxID.SetWatermark("店家統編");
            txt_name.SetWatermark("店家名稱");
            txt_phone.SetWatermark("店家電話號碼");
            txt_address.SetWatermark("店家地址");
            txt_website.SetWatermark("店家網址");
            txt_email.SetWatermark("店家信箱");
            txt_seats.SetWatermark("店家座位容客量");
            txt_openTime.SetWatermark("店家開始營業時間");
            txt_closeTime.SetWatermark("店家結束營業時間");
        }

        private void txt_inputCheck(object sender, EventArgs e)
        {
            switch (((TextBox)sender).Name)
            {
                case "txt_account":
                    lab_account.Text = txt_account.Text == "" ? "請輸入帳號" : SLE.Accounts.Where(n => n.AccountName == txt_account.Text).Select(n => n.AccountName).Any() ? "該帳號已存在" : "Ok!";
                    // 判斷式1.驗證帳號欄位是不是空的、判斷式2.驗證帳號是否已經存在、3.Ok!
                    break;
                case "txt_password":
                    bool isHighPassword = Regex.IsMatch(txt_password.Text, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,50}$");
                    lab_password.Text = (isHighPassword ? "Ok!" : "密碼強度不足!");
                    //密碼中小於8碼、沒有大小寫及數字會顯示密碼強度不足
                    break;
                case "txt_doubleCheckPassword":
                    lab_doubleCheckPassword.Text = txt_password.Text == txt_doubleCheckPassword.Text ? "Ok!" : "請輸入相同的密碼";
                    break;
                case "txt_taxID":
                    lab_taxID.Text = txt_taxID.Text == "" ? "請輸入統編" : SLE.Stores.Where(t => t.TaxID == txt_taxID.Text).Select(t => t.TaxID).Any() ? "該統編已存在" : "OK!";
                    break;
                case "txt_name":
                    lab_name.Text = txt_name.Text == "" ? "請輸入姓名" : SLE.Stores.Where(n => n.RestaurantName == txt_name.Text).Select(n => n.RestaurantName).Any() ? "該店家名稱已存在" : "OK!";
                    break;
                case "txt_phone":
                    bool isPhone = Regex.IsMatch(txt_phone.Text, @"^02[0-9]{8}$");
                    lab_phone.Text = isPhone ? "Ok!" : "請輸入正確的店家號碼格式";
                    break;
                case "cmb_type":
                    lab_type.Text = cmb_type.Text == "" ? "請選擇類型" : "Ok!";
                    break;
                case "cmb_district":
                    lab_district.Text = cmb_district.Text == "" ? "請選擇地區類型" : "Ok!";
                    break;
                case "txt_address":
                    lab_address.Text = txt_address.Text == "" ? "請輸入地址" : "Ok!";
                    break;
                case "txt_website":
                    lab_website.Text = txt_website.Text == "" ? "請輸入店家網址" : SLE.Stores.Where(ws => ws.Website == txt_website.Text).Select(wn => wn.Website).Any() ? "該店家網址已存在" : "OK!";
                    break;
                case "txt_email":
                    lab_email.Text = txt_email.Text == "" ? "請輸入Email" : SLE.Stores.Where(m => m.StoreMail == txt_email.Text).Select(m => m.StoreMail).Any() ? "該信箱已存在" : "OK!";
                    break;
                case "txt_seats":
                    lab_seats.Text = txt_seats.Text == "" ? "請輸入最大容客量" : "Ok!";
                    break;
                case "txt_openTime":
                    lab_openTime.Text = txt_openTime.Text == "" ? "請輸入開始營業時間" : "Ok!";
                    break;
                case "txt_closeTime":
                    lab_closeTime.Text = txt_closeTime.Text == "" ? "請輸入結束營業時間" : "Ok!";
                    break;
            }
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            try
            {
                bool haveAccount = SLE.Accounts.Where(n => n.AccountName == txt_account.Text).Select(n => n.AccountName).Any();
                if (haveAccount)
                {
                    MessageBox.Show("店家帳號輸入有誤");
                    return;
                }

                bool haveTaxID = SLE.Stores.Where(t => t.TaxID == txt_taxID.Text).Select(t => t.TaxID).Any();
                if (haveTaxID) 
                {
                    MessageBox.Show("店家統編輸入有誤");
                }

                Store store = new Store {AccountName = txt_account .Text, TaxID = txt_taxID.Text, RestaurantName = txt_name.Text, RestaurantPhone = txt_phone.Text , DistrictID = 1, RestaurantAddress = txt_address.Text, Website = txt_website.Text, StoreMail = txt_email.Text, Seats = int.Parse(txt_seats.Text), OpeningTime =TimeSpan.Parse(txt_openTime.Text), ClosingTime = TimeSpan.Parse(txt_closeTime.Text) };
                Account account = new Account { AccountName = txt_account.Text, AccountPassword = txt_password.Text , Identification = 2 };

                this.SLE.Stores.Add(store);
                this.SLE.Accounts.Add(account);
                this.SLE.SaveChanges();

                MessageBox.Show("註冊會員成功");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lab_linkToMemberSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            new Frm_SignupPage().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
