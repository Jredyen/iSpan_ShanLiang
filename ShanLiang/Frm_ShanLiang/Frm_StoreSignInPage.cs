using Frm_ShanLiang.ExtesionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Frm_ShanLiang
{
    public partial class Frm_StoreSignInPage : Form
    {

        ShanLiangEntities dbContext = new ShanLiangEntities();
        int _typeID = 0;
        int _districtID = 0;
         public byte[] _storeImageSave;
        
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

            //open & close hours add
            for (int hours = 0; hours <= 23; hours++)
            {
                if (hours <10) 
                {
                    this.cmb_openTime_hour.Items.Add($"0{hours}");
                    this.cmb_closeTime_hour.Items.Add($"0{hours}");
                }
                if (hours >= 10) 
                {
                    this.cmb_openTime_hour.Items.Add(hours);
                    this.cmb_closeTime_hour.Items.Add(hours);
                }

            }

            ////open & close minutes add
            for (int minutes = 0; minutes <= 59; minutes++) 
            {
                if (minutes < 10) 
                {
                    this.cmb_openTime_minute.Items.Add($"0{minutes}");
                    this.cmb_closeTime_minute.Items.Add($"0{minutes}");
                }

                if (minutes >=10) 
                {
                     this.cmb_openTime_minute.Items.Add(minutes);
                     this.cmb_closeTime_minute.Items.Add(minutes);
                }
                
            }
        }

        private void txt_inputCheck(object sender, EventArgs e)
        {
            switch (((TextBox)sender).Name)
            {
                case "txt_account":
                    lab_account.Text = txt_account.Text == "" ? "請輸入帳號" : dbContext.Accounts.Where(n => n.AccountName == txt_account.Text).Select(n => n.AccountName).Any() ? "該帳號已存在" : "Ok!";
                    // 判斷式1.驗證帳號欄位是不是空的、判斷式2.驗證帳號是否已經存在、3.Ok!
                    Color foreColorAccount = lab_account.Text == "該帳號已存在" ? lab_account.ForeColor = Color.Yellow : lab_account.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                    Color backColorAccount = lab_account.ForeColor == Color.Yellow ? lab_account.BackColor = Color.Red : lab_account.BackColor = Color.FromKnownColor(KnownColor.Control);
                    break;
                case "txt_password":
                    bool isHighPassword = Regex.IsMatch(txt_password.Text, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,12}$");
                    lab_password.Text = (isHighPassword ? "Ok!" : "密碼強度不足!");
                    //密碼中小於8碼、沒有大小寫及數字會顯示密碼強度不足
                    Color foreColorHighPassword = lab_password.Text == "密碼強度不足!" ? lab_password.ForeColor = Color.Yellow : lab_password.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                    Color backColorHighPassword = lab_password.ForeColor == Color.Yellow ? lab_password.BackColor = Color.Red : lab_password.BackColor = Color.FromKnownColor(KnownColor.Control);
                    break;
                case "txt_doubleCheckPassword":
                    bool isdoubleCheckPassword = txt_doubleCheckPassword.Text == txt_password.Text;
                    lab_doubleCheckPassword.Text = (isdoubleCheckPassword ? "Ok!" : "請輸入相同的密碼!");
                    Color foreColorDoubleCheckPassword = lab_doubleCheckPassword.Text == "請輸入相同的密碼!" ? lab_doubleCheckPassword.ForeColor = Color.Yellow : lab_doubleCheckPassword.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                    Color backColorDoubleCheckPassword = lab_doubleCheckPassword.ForeColor == Color.Yellow ? lab_doubleCheckPassword.BackColor = Color.Red : lab_doubleCheckPassword.BackColor = Color.FromKnownColor(KnownColor.Control);
                    break;
                case "txt_taxID":
                    lab_taxID.Text = txt_taxID.Text == "" ? "請輸入統編" : dbContext.Stores.Where(t => t.TaxID == txt_taxID.Text).Select(t => t.TaxID).Any() ? "該統編已存在" : "Ok!";
                    Color foreColorTaxID = lab_taxID.Text == "該統編已存在" ? lab_taxID.ForeColor = Color.Yellow : lab_taxID.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                    Color backColorTaxID = lab_taxID.ForeColor == Color.Yellow ? lab_taxID.BackColor = Color.Red : lab_taxID.BackColor = Color.FromKnownColor(KnownColor.Control);
                    break;
                case "txt_name":
                    lab_name.Text = txt_name.Text == "" ? "請輸入姓名" : dbContext.Stores.Where(n => n.RestaurantName == txt_name.Text).Select(n => n.RestaurantName).Any() ? "該店家名稱已存在" : "Ok!";
                    Color foreColorName = lab_name.Text == "該店家名稱已存在" ? lab_name.ForeColor = Color.Yellow : lab_name.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                    Color backColorName = lab_name.ForeColor == Color.Yellow ? lab_name.BackColor = Color.Red : lab_name.BackColor = Color.FromKnownColor(KnownColor.Control);
                    break;
                case "txt_phone":
                    bool isPhone = Regex.IsMatch(txt_phone.Text, @"^(\d{2,3}-?|\(\d{2,3}\))\d{3,4}-?\d{4}$");
                    //phone正規表達式參考: https://medium.com/@koten0224/regex-%E5%A6%82%E4%BD%95%E6%AA%A2%E6%9F%A5%E9%9B%BB%E8%A9%B1%E8%99%9F%E7%A2%BC-5bacf88eae8d
                    lab_phone.Text = isPhone ? "Ok!" : "請輸入正確的店家號碼格式";
                    Color foreColorPhone = lab_phone.Text == "請輸入正確的店家號碼格式" ? lab_phone.ForeColor = Color.Yellow : lab_phone.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                    Color backColorPhone = lab_phone.ForeColor == Color.Yellow ? lab_phone.BackColor = Color.Red : lab_phone.BackColor = Color.FromKnownColor(KnownColor.Control);
                    break;
                case "txt_address":
                    lab_address.Text = txt_address.Text == "" ? "請輸入地址" : "Ok!";
                    Color foreColorAddress = lab_address.Text == "請輸入地址" ? lab_address.ForeColor = Color.Yellow : lab_address.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                    Color backColorAddress= lab_address.ForeColor == Color.Yellow ? lab_address.BackColor = Color.Red : lab_address.BackColor = Color.FromKnownColor(KnownColor.Control);
                    break;
                case "txt_website":
                    bool isWebsite = Regex.IsMatch(txt_website.Text, @"^(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})$");
                    //url正規表達式參考: https://stackoverflow.com/questions/3809401/what-is-a-good-regular-expression-to-match-a-url
                    lab_website.Text = isWebsite ? "Ok!" : "請輸入正確的完整格式";
                    Color foreColorWebsite = lab_website.Text == "請輸入正確的完整格式" ? lab_website.ForeColor = Color.Yellow : lab_website.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                    Color backColorWebsite = lab_website.ForeColor == Color.Yellow ? lab_website.BackColor = Color.Red : lab_website.BackColor = Color.FromKnownColor(KnownColor.Control);
                    break;
                case "txt_email":
                    bool isEmail = Regex.IsMatch(txt_email.Text, @"^(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])$");
                    //email正規表達式參考: https://stackoverflow.com/questions/201323/how-can-i-validate-an-email-address-using-a-regular-expression?page=1&tab=scoredesc#tab-top
                    lab_email.Text = isEmail ? "Ok!" : "請輸入正確的信箱格式";
                    Color foreColorEmail = lab_email.Text == "請輸入正確的信箱格式" ? lab_email.ForeColor = Color.Yellow : lab_email.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                    Color backColorEmail = lab_email.ForeColor == Color.Yellow ? lab_email.BackColor = Color.Red : lab_email.BackColor = Color.FromKnownColor(KnownColor.Control);
                    break;
                case "txt_seats":
                    lab_seats.Text = txt_seats.Text == "" ? "請輸入最大容客量" : "Ok!";
                    Color foreColorSeats = lab_seats.Text == "請輸入最大容客量" ? lab_seats.ForeColor = Color.Yellow : lab_seats.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                    Color backColorSeats = lab_seats.ForeColor == Color.Yellow ? lab_seats.BackColor = Color.Red : lab_seats.BackColor = Color.FromKnownColor(KnownColor.Control);
                    break;
            }
        }

        private void cmb_inputCheck(object sender, EventArgs e)
        {
            switch (((ComboBox)sender).Name)
            {
                case "cmb_type":
                    lab_type.Text = cmb_type.Text == "" ? "請選擇類型" : "Ok!";
                    Color foreColorType = lab_type.Text == "請選擇類型" ? lab_type.ForeColor = Color.Yellow : lab_type.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                    Color backColorType = lab_type.ForeColor == Color.Yellow ? lab_type.BackColor = Color.Red : lab_type.BackColor = Color.FromKnownColor(KnownColor.Control);
                    break;
                case "cmb_district":
                    lab_district.Text = cmb_district.Text == "" ? "請選擇地區" : "Ok!";
                    Color foreColorDistrict = lab_district.Text == "請選擇地區" ? lab_district.ForeColor = Color.Yellow : lab_district.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                    Color backColorDistrict = lab_district.ForeColor == Color.Yellow ? lab_district.BackColor = Color.Red : lab_district.BackColor = Color.FromKnownColor(KnownColor.Control);
                    break;

            }
        }

        //註冊
        private void btn_signin_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (txt_account.Text == "" || txt_password.Text == "" || txt_doubleCheckPassword.Text == "" || txt_taxID.Text == "" || txt_name.Text == "" || txt_phone.Text == "" || cmb_type.Text == "" || cmb_city.Text == "" || cmb_district.Text == "" || txt_address.Text == "" || txt_website.Text == "" || txt_email.Text == "" || txt_seats.Text == "" || cmb_openTime_hour.Text == "" || cmb_openTime_minute.Text == "" || cmb_closeTime_hour.Text == "" || cmb_closeTime_minute.Text == "")
                {
                    MessageBox.Show("有欄位為空,請填寫完整的資料");
                    return;
                }

                if (lab_password.Text == "密碼強度不足!")
                {
                    MessageBox.Show("密碼強度不足,請重新輸入!");
                    txt_password.Text = "";
                    txt_password.Focus();
                    return;
                }

                if (lab_doubleCheckPassword.Text == "請輸入相同的密碼!")
                {
                    MessageBox.Show("再次密碼輸入錯誤,請重新輸入!");
                    txt_doubleCheckPassword.Text = "";
                    txt_doubleCheckPassword.Focus();
                    return;
                }

                if (lab_phone.Text == "請輸入正確的店家號碼格式") 
                {
                    MessageBox.Show("店家號碼輸入錯誤,請重新輸入!");
                    txt_phone.Text = "";
                    txt_phone.Focus();
                    return;
                }

                if (lab_website.Text == "請輸入正確的完整格式") 
                {
                    MessageBox.Show("店家網址輸入錯誤,請重新輸入!");
                    txt_website.Text = "";
                    txt_website.Focus();
                    return;
                }

                if (lab_email.Text == "請輸入正確的信箱格式") 
                {
                    MessageBox.Show("店家信箱輸入錯誤,請重新輸入!");
                    txt_email.Text = "";
                    txt_email.Focus();
                    return;
                }

                bool haveAccount = dbContext.Accounts.Where(a => a.AccountName == this.txt_account.Text).Select(a => a.AccountName).Any();
                if (haveAccount)
                {
                    MessageBox.Show("店家帳號輸入已重複");
                    txt_account.Text = "";
                    txt_account.Focus();
                    return;
                }

                bool haveTaxID = dbContext.Stores.Where(t => t.TaxID == this.txt_taxID.Text).Select(t => t.TaxID).Any();
                if (haveTaxID)
                {
                    MessageBox.Show("店家統編輸入已重複");
                    txt_taxID.Text = "";
                    txt_taxID.Focus();
                    return;
                }

                bool haveName = dbContext.Stores.Where(n => n.RestaurantName == this.txt_name.Text).Select(n => n.RestaurantName).Any();
                if (haveName) 
                {
                    MessageBox.Show("店家名稱輸入已重複");
                    txt_name.Text = "";
                    txt_name.Focus();
                    return;
                }

                bool havePhone =dbContext.Stores.Where(p => p.RestaurantPhone == this.txt_phone.Text).Select(p => p.RestaurantPhone).Any();
                if (havePhone)
                {
                    MessageBox.Show("店家電話號碼已重複");
                    txt_phone.Text = "";
                    txt_phone.Focus();
                    return;
                }

                bool haveAddress = dbContext.Stores.Where(adr => adr.RestaurantAddress == this.txt_address.Text).Select(adr => adr.RestaurantAddress).Any();
                if (haveAddress) 
                {
                    MessageBox.Show("店家地址輸入已重複");
                    txt_address.Text = "";
                    txt_address.Focus();
                    return;
                }

                bool haveMail = dbContext.Stores.Where(m => m.StoreMail == txt_email.Text).Select(m => m.StoreMail).Any();
                if (haveMail) 
                {
                    MessageBox.Show("店家信箱輸入已重複");
                    txt_email.Text = "";
                    txt_email.Focus();
                    return;
                }

                if (!haveAccount && !haveTaxID && !haveName && !havePhone && !haveAddress && !haveMail)
                {
                    Store store = new Store { AccountName = txt_account.Text, TaxID = txt_taxID.Text, RestaurantName = txt_name.Text, RestaurantPhone = txt_phone.Text, DistrictID = _districtID , RestaurantAddress = $"{this.cmb_city.SelectedItem}{this.cmb_district.SelectedItem}{this.txt_address.Text}", Website = txt_website.Text, StoreMail = txt_email.Text, Seats = int.Parse(txt_seats.Text), OpeningTime = TimeSpan.Parse($"{this.cmb_openTime_hour.SelectedItem}:{this.cmb_openTime_minute.SelectedItem}"), ClosingTime = TimeSpan.Parse($"{this.cmb_closeTime_hour.SelectedItem}:{this.cmb_closeTime_minute.SelectedItem}"), StoreImage = _storeImageSave };
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
            txt_address.Text = "復興南路一段390號3樓";
            txt_website.Text = "https://www.iii.org.tw/";
            txt_email.Text = "test@gmail.com";
            txt_seats.Text = "30";
            cmb_openTime_hour.Text = "13";
            cmb_openTime_minute.Text = "00";
            cmb_closeTime_hour.Text = "18";
            cmb_closeTime_minute.Text = "00";

        }

        //show & save Image
        private void btn_browseStoreImage_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pic_showStoreImage.Image = Image.FromFile(this.openFileDialog1.FileName);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                this.pic_showStoreImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                _storeImageSave = ms.GetBuffer();

            }
        }
    }
}
