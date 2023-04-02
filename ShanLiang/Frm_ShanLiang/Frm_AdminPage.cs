using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frm_ShanLiang
{
    public partial class Frm_AdminPage : Form
    {
        public Frm_AdminPage()
        {
            InitializeComponent();
            tabControl1.SelectedIndex = 2;
        }
        ShanLiangEntities _SLE = new ShanLiangEntities();
        void Read_RefreshDataGridViewAccount()
        {   //更新帳號列表
            this.dataGridViewAccount.DataSource = null;
            this.dataGridViewAccount.DataSource = _SLE.Accounts.ToList();
        }
        void Read_RefreshDataGridViewMember()
        {   //更新會員列表
            this.dataGridViewMember.DataSource = null;
            this.dataGridViewMember.DataSource = _SLE.Members.ToList();
        }
        void Read_RefreshDataGridViewStore()
        {   //更新店家列表
            this.dataGridViewStore.DataSource = null;
            this.dataGridViewStore.DataSource = _SLE.Stores.ToList();
        }


        //===============================帳號======================================

        private void btn_readaccount_Click(object sender, EventArgs e)
        {
            Read_RefreshDataGridViewAccount();                                     //讀取Account帳號表
            dataGridViewIdentification.DataSource = _SLE.Identifications.ToList(); //讀取帳號類型表
        }

        private void btn_orderbyaccount_Click(object sender, EventArgs e)
        {    //照帳號類別順序瀏覽
            try
            {
                var q = from p in _SLE.Accounts
                        orderby p.Identification
                        select p;
                dataGridViewAccount.DataSource = q.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_updateaccount_Click(object sender, EventArgs e)
        {  //修改帳號資料表
            try
            {
                var account = (from p in _SLE.Accounts
                               select p).FirstOrDefault();

                if (account == null) return;               
                _SLE.SaveChanges();
                Read_RefreshDataGridViewAccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                 
        }
        

        private void btn_addaccount_Click(object sender, EventArgs e)
        {   //新增一筆帳號
            try
            {
                Account account = new Account { AccountName = "Test" };
                _SLE.Accounts.Add(account);
                _SLE.SaveChanges();
                this.Read_RefreshDataGridViewAccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_deleteaccount_Click(object sender, EventArgs e)
        {    //刪除選到的資料
            try
            {
                foreach (DataGridViewRow row in dataGridViewAccount.SelectedRows)
                {
                    var account = row.DataBoundItem;
                    _SLE.Accounts.Remove((Account)account);
                    _SLE.SaveChanges();
                }
                Read_RefreshDataGridViewAccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }
        //==================================會員==================================
        
        private void btn_readmember_Click(object sender, EventArgs e)
        {  //讀取Member會員表
            Read_RefreshDataGridViewMember();
        }
        
        private void btn_updatemember_Click(object sender, EventArgs e)
        {   //修改會員資料
            try
            {
                var member = (from p in _SLE.Members
                              select p).FirstOrDefault();
                if (member == null) return;
                _SLE.SaveChanges();
                Read_RefreshDataGridViewMember();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_addmember_Click(object sender, EventArgs e)
        {   //新增一筆會員資料
            try
            {
                Member member = new Member { AccountName = "Test" };
                _SLE.Members.Add(member);
                _SLE.SaveChanges();
                Read_RefreshDataGridViewMember();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }
        private void btn_deletemember_Click(object sender, EventArgs e)
        {   //刪除選到的資料
            try
            {
                foreach (DataGridViewRow row in dataGridViewMember.SelectedRows)
                {
                    var member = row.DataBoundItem;
                    _SLE.Members.Remove((Member)member);
                    _SLE.SaveChanges();
                }
                Read_RefreshDataGridViewMember();              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //========================店家=====================================
        private void btn_readstore_Click(object sender, EventArgs e)
        {
            Read_RefreshDataGridViewStore();
        }

        private void btn_updatestore_Click(object sender, EventArgs e)
        {
            try
            {
                var store = (from p in _SLE.Stores
                              select p).FirstOrDefault();
                if (store == null) return;
                _SLE.SaveChanges();
                Read_RefreshDataGridViewStore();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_addstore_Click(object sender, EventArgs e)
        {
            try
            {
                Store store = new Store { AccountName = "Test" };
                _SLE.Stores.Add(store);
                _SLE.SaveChanges();
                Read_RefreshDataGridViewStore();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_deletestore_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridViewStore.SelectedRows)
                {
                    var store = row.DataBoundItem;
                    _SLE.Stores.Remove((Store)store);
                    _SLE.SaveChanges();
                }
                Read_RefreshDataGridViewStore();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        
        private void dataGridViewStore_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridViewStore.Rows[e.RowIndex];

                    // 從資料行取得二進位圖片資料
                    byte[] imageData = (byte[])row.Cells["StoreImage"].Value;

                    // 將二進位圖片資料轉換成圖片物件
                    Image image;
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        image = Image.FromStream(ms);
                    }

                    // 將圖片顯示在 PictureBox 控制項中
                    pictureBox1.Image = image;
                }
            }
            catch (Exception)
            {
                pictureBox1.Image = pictureBox1.ErrorImage;
            }
        }
    }
}
