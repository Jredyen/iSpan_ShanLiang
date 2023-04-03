using Frm_ShanLiang.ExtesionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Frm_ShanLiang
{
    public partial class Frm_StoreSignInPage : Form
    {

        ShanLiangEntities dbContext = new ShanLiangEntities();
        int _typeID = 0;
        int _districtID = 0;

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

            //抓店家類型
            var q = dbContext.Restaurant_Type.Select(rt => rt.TypeName).ToList();
            foreach (string type in q)
            {
                this.cmb_type.Items.Add(type);
            }
            //抓店家縣市
            var c = dbContext.Cities.Select(rc => rc.CityName).ToList();
            foreach (string city in c)
            {
                this.cmb_city.Items.Add(city);
            }
        }

        private void txt_inputCheck(object sender, EventArgs e)
        {
            switch (((TextBox)sender).Name)
            {
                case "txt_account":
                    lab_account.Text = txt_account.Text == "" ? "請輸入帳號" : dbContext.Accounts.Where(n => n.AccountName == txt_account.Text).Select(n => n.AccountName).Any() ? "該帳號已存在" : "Ok!";
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
                    lab_taxID.Text = txt_taxID.Text == "" ? "請輸入統編" : dbContext.Stores.Where(t => t.TaxID == txt_taxID.Text).Select(t => t.TaxID).Any() ? "該統編已存在" : "OK!";
                    break;
                case "txt_name":
                    lab_name.Text = txt_name.Text == "" ? "請輸入姓名" : dbContext.Stores.Where(n => n.RestaurantName == txt_name.Text).Select(n => n.RestaurantName).Any() ? "該店家名稱已存在" : "OK!";
                    break;
                case "txt_phone":
                    bool isPhone = Regex.IsMatch(txt_phone.Text, @"^02[0-9]{8}$");
                    lab_phone.Text = isPhone ? "Ok!" : "請輸入正確的店家號碼格式";
                    break;
                case "txt_address":
                    lab_address.Text = txt_address.Text == "" ? "請輸入地址" : "Ok!";
                    break;
                case "txt_website":
                    lab_website.Text = txt_website.Text == "" ? "請輸入店家網址" : dbContext.Stores.Where(ws => ws.Website == txt_website.Text).Select(ws => ws.Website).Any() ? "該店家網址已存在" : "OK!";
                    break;
                case "txt_email":
                    lab_email.Text = txt_email.Text == "" ? "請輸入Email" : dbContext.Stores.Where(m => m.StoreMail == txt_email.Text).Select(m => m.StoreMail).Any() ? "該信箱已存在" : "OK!";
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

        private void cmb_inputCheck(object sender, EventArgs e)
        {
            switch (((ComboBox)sender).Name)
            {
                case "cmb_type":
                    lab_type.Text = cmb_type.Text == "" ? "請選擇類型" : "Ok!";
                    break;
                case "cmb_city":
                    lab_city.Text = cmb_city.Text == "" ? "請選擇縣市" : "Ok!";
                    break;
                case "cmb_district":
                    lab_district.Text = cmb_district.Text == "" ? "請選擇地區" : "Ok!";
                    break;
            }
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            try
            {
                bool haveAccount = dbContext.Accounts.Where(n => n.AccountName == txt_account.Text).Select(n => n.AccountName).Any();
                if (haveAccount)
                {
                    MessageBox.Show("店家帳號輸入有誤");
                    return;
                }

                bool haveTaxID = dbContext.Stores.Where(t => t.TaxID == txt_taxID.Text).Select(t => t.TaxID).Any();
                if (haveTaxID)
                {
                    MessageBox.Show("店家統編輸入有誤");
                    return;
                }
                if (!haveAccount && !haveTaxID)
                {
                    Store store = new Store { AccountName = txt_account.Text, TaxID = txt_taxID.Text, RestaurantName = txt_name.Text, RestaurantPhone = txt_phone.Text, DistrictID = _districtID , RestaurantAddress = txt_address.Text, Website = txt_website.Text, StoreMail = txt_email.Text, Seats = int.Parse(txt_seats.Text), OpeningTime = TimeSpan.Parse(txt_openTime.Text), ClosingTime = TimeSpan.Parse(txt_closeTime.Text) };
                    Account account = new Account { AccountName = txt_account.Text, AccountPassword = txt_password.Text, Identification = 2 };

                    this.dbContext.Stores.Add(store);
                    this.dbContext.Accounts.Add(account);
                    this.dbContext.SaveChanges();

                    //抓註冊後StoreID
                    var q = this.dbContext.Stores.Where(tid => tid.TaxID == txt_taxID.Text).Select(sid => sid.StoreID).First();

                    Store_Type storeType = new Store_Type { StoreID = q, RestaurantTypeNum = _typeID };

                    this.dbContext.Store_Type.Add(storeType);
                    this.dbContext.SaveChanges();

                    MessageBox.Show("註冊會員成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //關閉視窗
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //跳到會員註冊
        private void lab_linkToMemberSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            new Frm_SignupPage().ShowDialog();
        }

        //抓TypeID
        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Message = LINQ to Entities 無法辨識方法 'Int32 Last[Int32](System.Linq.IQueryable`1[System.Int32])' 方法，而且這個方法無法轉譯成存放區運算式。
            //var q = this.dbContext.Restaurant_Type.Where(tn => tn.TypeName == this.cmb_type.Text).Select(rid => rid.RestaurantTypeNum).Last();
            //解法↓
            //Last()方法要搭配ToList()使用  ANS: var q = this.dbContext.Restaurant_Type.Where(tn => tn.TypeName == this.cmb_type.Text).Select(rid => rid.RestaurantTypeNum).ToList().Last();
            //First()方法不需要搭配ToList()即可使用 ANS:  var q = this.dbContext.Restaurant_Type.Where(tn => tn.TypeName == this.cmb_type.Text).Select(rid => rid.RestaurantTypeNum).First();


            var q = this.dbContext.Restaurant_Type.Where(tn => tn.TypeName == this.cmb_type.Text).Select(rid => rid.RestaurantTypeNum).First();
            _typeID = q;

        }

        //城市對應地區
        private void cmb_city_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = this.dbContext.Districts.Where(cn => cn.City.CityName == this.cmb_city.Text).Select(dn => dn.DistrictName).ToList();

            this.cmb_district.Items.Clear();
            foreach (string districts in q)
            {
                this.cmb_district.Items.Add(districts);
            }

            //寫法一樣
            //var q = from c in this.SLE.Districts
            //        where c.City.CityName == this.cmb_city.Text
            //        select c.DistrictName;

        }

        //抓districtID
        private void cmb_district_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = this.dbContext.Districts.Where(dn => dn.DistrictName == this.cmb_district.Text).Select(id => id.DistrictID).First();
            _districtID = q;

        }

        //Demo
        private void btn_demo_Click(object sender, EventArgs e)
        {
            txt_account.Text = "test";
            txt_password.Text = "Test12345";
            txt_doubleCheckPassword.Text = "Test12345";
            txt_taxID.Text = "11111111";
            txt_name.Text = "Test11";
            txt_phone.Text = "0233445566";
            cmb_type.Text = "日式料理";
            cmb_city.Text = "台北市";
            cmb_district.Text = "大安區";
            txt_address.Text = "台北市大安區復興南路一段390號2樓";
            txt_website.Text = "https://www.iii.org.tw/";
            txt_email.Text = "test@gmail.com";
            txt_seats.Text = "30";
            txt_openTime.Text = "13:00";
            txt_closeTime.Text = "18:00";

        }
    }
}
