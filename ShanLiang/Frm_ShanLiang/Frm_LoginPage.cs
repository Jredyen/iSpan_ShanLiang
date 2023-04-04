using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Frm_ShanLiang.ExtesionMethods;
using System.Configuration;
using ShanLiang;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Entity;
using System.Runtime.InteropServices;

namespace Frm_ShanLiang
{
    public partial class Frm_LoginPage : Form
    {
        Frm_Homepage _homepage;
        CCustomers customers = new CCustomers();
        public Frm_LoginPage()
        {
            InitializeComponent();
        }
        public Frm_LoginPage(Frm_Homepage homepage)
        {
            InitializeComponent();
            _homepage = homepage;
        }

        private void linkLab_signin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {    //轉跳會員註冊
            (new Frm_SignupPage()).Show();
            Close();
        }
        private void linkLab_Storesignin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {   //轉跳店家註冊
            (new Frm_StoreSignInPage()).Show();
            Close();
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        ShanLiangEntities dbcontext = new ShanLiangEntities();
        int _tryCount = 0; //帳號密碼嘗試次數
        private void btn_login_Click(object sender, EventArgs e)
        {   //ADO方式連接
            //查帳號密碼是否正確
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    string connstring = ConfigurationManager.ConnectionStrings["ShanLiangLogin"].ConnectionString;
                    conn.ConnectionString = connstring;
                    string AccountName = txt_accountName.Text;
                    string AccountPassWord = txt_password.Text;
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "Select * from Account where AccountName = @AccountName and AccountPassWord = @AccountPassWord ";
                    
                    comm.Connection = conn;
                    comm.Parameters.Add("@AccountName", SqlDbType.NVarChar, 20).Value = AccountName;
                    comm.Parameters.Add("@AccountPassWord", SqlDbType.NVarChar, 50).Value = AccountPassWord;
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows && AccountName != "" && AccountPassWord != "")
                    {
                        reader.Read();
                        MessageBox.Show($"歡迎回來~{reader["AccountName"]}");
                        //判斷要轉跳到哪個頁面

                        CNowLoginAccount._nowLoginAccountID = (int)reader[0]; //Jredyen:將現在登入的帳號ID記錄到Class
                        CNowLoginAccount._loginAccountName = (string)reader[1];//Jredyen:將現在登入的帳號名稱記錄到Class
                        CNowLoginAccount._Identification = (int)reader[3];//Jredyen:將現在登入的帳號類型記錄到Class
                        _homepage.accountNameCheckout(CNowLoginAccount._loginAccountName);

                        int Identification = (int)reader["Identification"];
                        if (Identification == 1)//如果是1轉跳到會員頁面//不跳轉，改由首頁由使用者操作
                        {
                            //new Frm_MemberPage().Show();
                            customers.memberDataLoad((string)reader[1]);
                            Close();
                        }
                        else if (Identification == 2)//如果是2轉跳到店家頁面//不跳轉，改由首頁由使用者操作
                        {
                            //new Frm_StoreManagerPage().Show();
                            customers.storeDataLoad((string)reader[1]);
                            Close();
                        }
                    }
                    else
                    {   //輸入3次錯誤就關閉
                        MessageBox.Show($"請輸入正確帳號密碼! 登入失敗{_tryCount + 1}次");
                        _tryCount++;
                        if (_tryCount > 2)
                        {
                            this.Close();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_Demo_Click(object sender, EventArgs e)
        {  //會員帳號
            txt_accountName.Text = "chris";
            txt_password.Text = "1234";
        }

        private void btn_storeDemo_Click(object sender, EventArgs e)
        {   //店家帳號
            txt_accountName.Text = "OGGIPizza";
            txt_password.Text = "1122";
        }
        
    }
}
