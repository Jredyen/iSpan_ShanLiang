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
            bool isHighPassword = Regex.IsMatch(txt_password.Text, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,50}$");
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
            bool isPhone = Regex.IsMatch(txt_phone.Text, @"^09[0-9]{8}$");
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

        }

    }
}
