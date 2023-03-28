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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Frm_ShanLiang
{
    public partial class Frm_SignInPage : Form
    {
        ShanLiangEntities SLE = new ShanLiangEntities();
        bool isHighPassword;
        bool isPhone;
        public Frm_SignInPage()
        {
            InitializeComponent();
            //註冊頁面圖片
            pictureBox_signIn.Image = Image.FromFile(@"C:\iSpanProject\ShanLiang\Frm_ShanLiang\Resources\signupImage.png");
            //TextBox的浮水印
            txt_account.SetWatermark("帳號");
            txt_name.SetWatermark("姓名");
            txt_password.SetWatermark("密碼");
            txt_doubleCheckPassword.SetWatermark("再次輸入密碼");
            txt_address.SetWatermark("地址");
            txt_email.SetWatermark("E-Mail");
            txt_phone.SetWatermark("電話號碼");
            //為誕生日添加12歲~100歲的年及月
            for (int year = DateTime.Now.Year - 12; year >= DateTime.Now.Year - 100; year--)
            {
                cb_Year.Items.Add(year);
            }
            for (int month = 1; month < 13; month++)
            {
                cb_Month.Items.Add(month);
            }
            //在ComboBox中填入城市
            var v = SLE.Cities.Select(c => c.CityName).ToList();
            foreach (string city in v)
            {
                cb_City.Items.Add(city);
            }
        }
        //帳號欄位驗證
        private void txt_account_TextChanged(object sender, EventArgs e)
        {
            if (txt_account.Text == "")
            {
                lab_account.Text = "請輸入帳號";
            }
            else if (SLE.Accounts.Where(n => n.AccountName == txt_account.Text).Select(n => n.AccountName).Any())
            {
                lab_account.Text = "該帳號已存在";
            }
            else
            {
                lab_account.Text = "Ok";
            }
        }
        //密碼欄位驗證
        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            isHighPassword = Regex.IsMatch(txt_password.Text, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,50}$");
            lab_password.Text = (isHighPassword ? "Ok!" : "密碼強度不足");
        }
        //密碼二次驗證
        private void txt_doubleCheckPassword_TextChanged(object sender, EventArgs e)
        {
            if (txt_password.Text == txt_doubleCheckPassword.Text)
            {
                lab_doubleCheckPassword.Text = "Ok!";
            }
            else
            {
                lab_doubleCheckPassword.Text = "請輸入相同的密碼";
            }
        }
        //姓名欄位驗證
        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            lab_name.Text = txt_name.Text == "" ? "請輸入姓名" : "Ok!";
        }

        private void txt_phone_TextChanged(object sender, EventArgs e)
        {
            isPhone = Regex.IsMatch(txt_phone.Text, @"^09[0-9]{8}$");
            lab_phone.Text = isPhone ? "Ok!" : "請輸入正確的手機號碼格式";
        }
        //Email欄位驗證
        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            if (txt_email.Text == "")
            {
                lab_email.Text = "請輸入Email";
            }
            else if (SLE.Members.Where(n => n.Email == txt_email.Text).Select(n => n.Email).Any())
            {
                lab_email.Text = "該E-mail已存在";
            }
            else
            {
                lab_email.Text = "Ok!";
            }
        }
        //地址欄位驗證
        private void txt_address_TextChanged(object sender, EventArgs e)
        {
            lab_address.Text = txt_address.Text == "" ? "請輸入地址" : "Ok";
        }
        //取消鍵
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //註冊鍵
        private void btn_signin_Click(object sender, EventArgs e)
        {
            try
            {
                //判斷所有欄位是否為空值
                if ( txt_account.Text == "" || txt_password.Text == "" || txt_doubleCheckPassword.Text == "" || txt_email.Text == "" || txt_name.Text == "" || txt_phone.Text == "")
                {
                    MessageBox.Show("會員資料輸入有缺少");
                    return;
                }
                //判斷是否已經有相同的帳號
                bool haveAccount = SLE.Accounts.Where(n => n.AccountName == txt_account.Text).Select(n => n.AccountName).Any();
                if (haveAccount)
                {
                    MessageBox.Show("已有相同帳號存在");
                    return;
                }
                //判斷是否已經有相同的E-mail
                bool haveEmail = SLE.Members.Where(n => n.Email == txt_email.Text).Select(n => n.Email).Any();
                if (haveEmail)
                {
                    MessageBox.Show("已有相同E-mail存在");
                    return;
                }
                //檢查是否有選取城市與行政區
                if (cb_City.SelectedIndex == -1 || cb_District.SelectedIndex == -1)
                {
                    MessageBox.Show("請選擇縣市與行政區");
                    return;
                }
                //若密碼強度不足跳出視窗詢問是否繼續
                if (!isHighPassword)
                {
                    if(MessageBox.Show("密碼強度不足，安全性較差，你確定嗎？", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
                }
                string date = $"{cb_Year.SelectedItem}-{cb_Month.SelectedItem}-{cb_Day.SelectedItem}";
                Member member = new Member
                {
                    AccountName = txt_account.Text,
                    MemberName = txt_name.Text,
                    Memberphone = txt_phone.Text,
                    Email = txt_email.Text,
                    Address = $"{cb_City.SelectedItem} {cb_District.SelectedItem} {txt_address.Text}",
                    BrithDate = DateTime.Parse(date),
                    CustomerLevel = 0
                };
                Account account = new Account
                {
                    AccountName = txt_account.Text,
                    AccountPassword = txt_password.Text,
                    Identification = 1
                };
                SLE.Members.Add(member);
                SLE.Accounts.Add(account);
                SLE.SaveChanges();

                MessageBox.Show("註冊會員成功");
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("請輸入正確的日期");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //連接到商家註冊頁面
        private void linkToStoreSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Frm_StoreSignInPage().Show();
        }
        //誕生日的ComboBoxItem產生
        private void YearMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year, month;
            cb_Day.Items.Clear();
            if (!int.TryParse(cb_Year.SelectedItem?.ToString(), out year)) return;
            if (!int.TryParse(cb_Month.SelectedItem?.ToString(), out month)) return;
            //如果年或月是空的就不執行添加日的動作
            int dayLenght = DateTime.DaysInMonth(year, month);
            for (int day = 1; day <= dayLenght; day++)
            {
                cb_Day.Items.Add(day);
            }
        }
        //添加該城市的行政區
        private void cb_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_District.Items.Clear();
            IQueryable<string> v = from d in SLE.Districts
                                   join c in SLE.Cities on d.CityID equals c.CityID
                                   where c.CityName == cb_City.SelectedItem.ToString()
                                   select d.DistrictName;
            v.ToList();
            //C#3.0 寫法，供參
            //var v = SLE.Districts
            //    .Join(SLE.Cities, d => d.CityID, c => c.CityID, (d, c) => new { d, c})
            //    .Where( x => x.c.CityName == cb_City.SelectedItem.ToString())
            //    .Select( x => x.d.DistrictName).ToList();
            foreach (string districe in v)
            {
                cb_District.Items.Add(districe);
            }
        }
    }
}
