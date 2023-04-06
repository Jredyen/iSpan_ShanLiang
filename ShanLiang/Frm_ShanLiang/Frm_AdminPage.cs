﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
            tabControl1.SelectedIndex = 0;
            this.pictureBoxStoreImage.AllowDrop = true;
            this.pictureBoxStoreImage.DragEnter += pictureBoxStoreImage_DragEnter;
            this.pictureBoxStoreImage.DragDrop += pictureBoxStoreImage_DragDrop;
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
        void Read_RefreshDataGridViewStoreImage()
        {   //更新店家列表
            this.dataGridViewStoreImage.DataSource = null;
            this.dataGridViewStoreImage.DataSource = _SLE.Store_Image.ToList();
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
                    pictureBoxStoreImage.Image = image;
                }
            }
            catch (Exception)
            {
                pictureBoxStoreImage.Image = pictureBoxStoreImage.ErrorImage;
            }
        }

        private void pictureBoxStoreImage_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pictureBoxStoreImage_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            pictureBoxStoreImage.Image = Image.FromFile(files[0]);
            
        }

        private void btn_updateStoreImage_Click(object sender, EventArgs e)
        {    //把picturebox裡的照片放到StoreImage裡  (放進去後須按修改才會真的存進DB)
            try
            {
                byte[] bytesImage = { 1, 1 };      //先把照片轉成二進位資料
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                this.pictureBoxStoreImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                bytesImage = ms.GetBuffer();

                //dataGridViewStore.SelectedCells[13].Value = bytesImage; //可以選整欄去找序號13的位置更換圖片
                dataGridViewStore.SelectedCells[0].Value = bytesImage;  //只能選照片那格去更換照片
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);               
            }           
        }
        //===========================店家照片集==========================================
        private void btn_readstoreimage_Click(object sender, EventArgs e)
        {   //讀取Store_Image資料表 把StoreID放到combobox

            Read_RefreshDataGridViewStoreImage();

            var q = (from p in _SLE.Store_Image
                     select p.StoreID).Distinct();
            foreach (var ID in q)
            {
                comboBoxStoreID.Items.Add(ID);                
            }
           
            //var q = (from p in _SLE.Store_Image   //combobox同時顯示ID與Name 但沒辦法搜尋對應的圖片
            //         join s in _SLE.Stores
            //         on p.StoreID equals s.StoreID
            //         select new { p.StoreID , s.RestaurantName }).Distinct();
            //foreach (var ID in q)
            //{
            //    comboBoxStoreID.Items.Add(ID);
            //}
        }

        private void dataGridViewStoreImage_CellClick(object sender, DataGridViewCellEventArgs e)
        {    //把選到的欄位圖片放到picturebox瀏覽
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridViewStoreImage.Rows[e.RowIndex];                  
                    byte[] imageData = (byte[])row.Cells["StoreImage"].Value;
                    Image image;
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        image = Image.FromStream(ms);
                    }                   
                    pictureBoxStoreimages.Image = image;
                }
            }
            catch (Exception)
            {
                pictureBoxStoreimages.Image = pictureBoxStoreimages.ErrorImage;
            }
        }

        private void comboBoxStoreID_SelectedIndexChanged(object sender, EventArgs e)
        {  //選擇StoreID會跳出該店家的圖片集
            int comboboxID = Convert.ToInt16(comboBoxStoreID.Text);  //先將選到的comboBoxStoreID轉型int

            var s = from p in _SLE.Stores     //查詢storeID對應到的店家名
                    where p.StoreID == comboboxID
                    select p.RestaurantName;
            foreach (var storename in s)
            {
                LabelRestaurantname.Text = storename;
            }
            ShowImage(comboboxID);                     //顯示對應的店家圖片  
        }
        public void ShowImage(int storeID)
        {  //用combobox選到的StoreID去搜尋圖片並放到picturebox
            flowLayoutPanel1.Controls.Clear();
            var q = from p in _SLE.Store_Image
                    where p.StoreID == storeID
                    select p.StoreImage;
            foreach (byte[] img in q)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Click += (sender, e) =>
                {
                    Form f = new Form();
                    f.BackgroundImage = ((PictureBox)sender).Image;
                    f.BackgroundImageLayout = ImageLayout.Stretch;
                    f.Show();
                };
                MemoryStream ms = new MemoryStream(img);

                Image image = Image.FromStream(ms);
                pictureBox.Image = image;                              //轉好的資料放到pictureBox
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; //設定pictureBox屬性
                pictureBox.BorderStyle = BorderStyle.Fixed3D;
                pictureBox.Margin = new Padding(5, 5, 5, 5);
                pictureBox.Padding = new Padding(5, 5, 5, 5);
                pictureBox.BackColor = Color.Yellow;
                pictureBox.Width = pictureBox.Height = 300;

                pictureBox.MouseEnter += PictureBox_MouseEnter; ;
                pictureBox.MouseLeave += PictureBox_MouseLeave; ;

                flowLayoutPanel1.Controls.Add(pictureBox);
            }
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {  //滑鼠放到圖片上的變化
            ((PictureBox)sender).BackColor = Color.Red;
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {   //滑鼠離開圖片上的變化
            ((PictureBox)sender).BackColor = Color.Yellow;
        }
    }
}