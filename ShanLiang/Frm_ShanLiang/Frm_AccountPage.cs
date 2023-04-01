using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frm_ShanLiang
{
    public partial class Frm_AccountPage : Form
    {
        public Frm_AccountPage()
        {
            InitializeComponent();
            
        }
        ShanLiangEntities _SLE = new ShanLiangEntities();

        private void btn_loadaccount_Click(object sender, EventArgs e)
        {
            DataGridViewAccount.DataSource = _SLE.Accounts.ToList();               //瀏覽Account帳號表
            DataGridViewIdentification.DataSource = _SLE.Identifications.ToList(); //瀏覽帳號類型表
        }

        private void btn_orderby_Click(object sender, EventArgs e)
        {    //照帳號類別順序瀏覽
            try
            {
                var q = from p in _SLE.Accounts
                        orderby p.Identification
                        select p;
                DataGridViewAccount.DataSource = q.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_update_Click(object sender, EventArgs e)
        {  //修改帳號資料表
            try
            {
                var account = (from p in _SLE.Accounts
                               select p).FirstOrDefault();

                if (account == null) return;
                account.AccountName = account.AccountName;
                _SLE.SaveChanges();
                Read_RefreshDataGridView();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
                  
        }
        void Read_RefreshDataGridView()
        {
            this.DataGridViewAccount.DataSource = null;
            this.DataGridViewAccount.DataSource = _SLE.Accounts.ToList();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {   //新增一筆帳號
            try
            {
                Account account = new Account { AccountName = "Test" };
                _SLE.Accounts.Add(account);
                _SLE.SaveChanges();
                this.Read_RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {    //刪除DataGridView選到的資料
            try
            {
                foreach (DataGridViewRow row in DataGridViewAccount.SelectedRows)
                {
                    var account = row.DataBoundItem;
                    _SLE.Accounts.Remove((Account)account);
                    _SLE.SaveChanges();
                }
                Read_RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }
    }
}
