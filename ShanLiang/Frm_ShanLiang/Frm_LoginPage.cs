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

namespace Frm_ShanLiang
{
    public partial class Frm_LoginPage : Form
    {
        public Frm_LoginPage()
        {
            InitializeComponent();                   
        }

        private void linkLab_signin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new Frm_SignupPage()).Show();
            //Close();         
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        ShanLiangEntities dbcontext = new ShanLiangEntities();
        private void btn_login_Click(object sender, EventArgs e)
        {   //ADO方式連接
            //查帳號密碼是否存在資料庫
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
                        MessageBox.Show("登入成功");
                        //判斷要轉跳到哪個頁面
                        
                        reader.Read();
                        CNowLoginAccount.nowLoginAccountID = (int)reader[0]; //Jredyen:將現在登入的帳號ID記錄到Class
                        CNowLoginAccount.loginAccountName = (string)reader[1];//Jredyen:將現在登入的帳號名稱記錄到Class
                        int Identification =(int) reader["Identification"];
                        if (Identification == 1)
                        {
                            (new Frm_Homepage()).Show();
                            Close();
                        }
                        else if (Identification == 2)
                        {
                            (new Frm_StoreManagerPage()).Show();
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("請輸入正確帳號密碼! 登入失敗");
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
