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
        public Frm_SignInPage()
        {
            InitializeComponent();
            txt_account.SetWatermark("帳號");
            txt_name.SetWatermark("姓名");
            txt_password.SetWatermark("密碼");
            txt_doubleCheckPassword.SetWatermark("再次輸入密碼");
            txt_address.SetWatermark("地址");
            txt_email.SetWatermark("E-Mail");
            txt_phone.SetWatermark("電話號碼");
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
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
                    lab_password.Text = (isHighPassword ? "Ok!" : "密碼強度不足");
                    //密碼中小於8碼、沒有大小寫及數字會顯示密碼強度不足
                    break;
                case "txt_doubleCheckPassword":
                    lab_doubleCheckPassword.Text = txt_password.Text == txt_doubleCheckPassword.Text ? "Ok!" : "請輸入相同的密碼";
                    break;
                case "txt_name":
                    lab_name.Text = txt_name.Text == "" ? "請輸入姓名" : "Ok!";
                    break;
                case "txt_phone":
                    bool isPhone = Regex.IsMatch(txt_phone.Text, @"^09[0-9]{8}$");
                    lab_phone.Text = isPhone ? "Ok!" : "請輸入正確的手機號碼格式";
                    break;
                case "txt_email":
                    //bool isEmail = Regex.IsMatch(txt_email.Text, "^[\\w-]+@[\\w-]+.(com|net|org|edu|mil|tv|biz|info)$");
                    lab_email.Text = txt_email.Text == "" ? "請輸入Email" : SLE.Members.Where(n => n.Email == txt_email.Text).Select(n => n.Email).Any() ? "該E-mail已存在" : "Ok!";
                    // 判斷式1.驗證E-mail欄位是不是空的、判斷式2.驗證E-mail是否已經存在、3.Ok!
                    break;
                case "txt_address":
                    lab_address.Text = txt_address.Text == "" ? "請輸入地址" : "Ok!";
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
                    MessageBox.Show("會員資料輸入有誤");
                    return;
                }
                bool haveEmail = SLE.Members.Where(n => n.Email == txt_email.Text).Select(n => n.Email).Any();
                if (haveEmail)
                {
                    MessageBox.Show("會員資料輸入有誤");
                    return;
                }
                Member member = new Member
                {
                    AccountName = txt_account.Text,
                    MemberName = txt_name.Text,
                    Memberphone = txt_phone.Text,
                    Email = txt_email.Text,
                    Address = txt_address.Text,
                    BrithDate = dateTimePicker1.Value,
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkToStoreSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //分支測試
        }
    }
}
