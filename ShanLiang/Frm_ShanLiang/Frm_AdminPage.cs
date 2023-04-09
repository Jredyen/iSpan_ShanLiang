using System;
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
            tabControl1.SelectedIndex = 3;
            pictureBoxStoreImage.AllowDrop = true;            
            pictureBoxStoreImage.DragEnter += pictureBoxStoreImage_DragEnter;
            pictureBoxStoreImage.DragDrop += pictureBoxStoreImage_DragDrop;
            pictureBoxStoreimages.AllowDrop = true;
            pictureBoxStoreimages.DragEnter += PictureBoxStoreimages_DragEnter;
            pictureBoxStoreimages.DragDrop += PictureBoxStoreimages_DragDrop;
        }
        private void pictureBoxStoreImage_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void pictureBoxStoreImage_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            pictureBoxStoreImage.Image = Image.FromFile(files[0]);
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
        private void PictureBoxStoreimages_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void PictureBoxStoreimages_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            pictureBoxStoreimages.Image = Image.FromFile(files[0]);
            try
            {
                byte[] bytesImage = { 1, 1 };      //先把照片轉成二進位資料
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                this.pictureBoxStoreimages.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                bytesImage = ms.GetBuffer();               
                dataGridViewStoreImage.SelectedCells[0].Value = bytesImage;  //只能選照片那格去更換照片
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        ShanLiangEntities _SLE = new ShanLiangEntities();

        void Read_DataGridView(DataGridView dataGridView,object list) //此方法用在讀取資料表到GridView
        { dataGridView.DataSource = list; }                           //list = 要放入的資料表

        //===============================帳號======================================

        private void btn_readaccount_Click(object sender, EventArgs e)
        {            
            Read_DataGridView(dataGridViewAccount, _SLE.Accounts.ToList());//讀取Account帳號表
            Read_DataGridView(dataGridViewIdentification, _SLE.Identifications.ToList());//讀取帳號類型表            
        }

        private void btn_orderbyaccount_Click(object sender, EventArgs e)
        {    //照帳號類別順序瀏覽
            try
            {
                var q = from p in _SLE.Accounts
                        orderby p.Identification
                        select p;               
                Read_DataGridView(dataGridViewAccount, q.ToList());
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
                Read_DataGridView(dataGridViewAccount, _SLE.Accounts.ToList());                
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
                Read_DataGridView(dataGridViewAccount, _SLE.Accounts.ToList());
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
                Read_DataGridView(dataGridViewAccount, _SLE.Accounts.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }
        //==================================會員==================================
        
        private void btn_readmember_Click(object sender, EventArgs e)
        {  //讀取Member會員表
            Read_DataGridView(dataGridViewMember, _SLE.Members.ToList());
        }
        
        private void btn_updatemember_Click(object sender, EventArgs e)
        {   //修改會員資料
            try
            {
                var member = (from p in _SLE.Members
                              select p).FirstOrDefault();
                if (member == null) return;
                _SLE.SaveChanges();
                Read_DataGridView(dataGridViewMember, _SLE.Members.ToList());
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
                Read_DataGridView(dataGridViewMember, _SLE.Members.ToList());
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
                Read_DataGridView(dataGridViewMember, _SLE.Members.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //========================店家=====================================
        private void btn_readstore_Click(object sender, EventArgs e)
        {
            Read_DataGridView(dataGridViewStore, _SLE.Stores.ToList());
        }

        private void btn_updatestore_Click(object sender, EventArgs e)
        {
            try
            {
                var store = (from p in _SLE.Stores
                              select p).FirstOrDefault();
                if (store == null) return;
                _SLE.SaveChanges();
                Read_DataGridView(dataGridViewStore, _SLE.Stores.ToList());
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
                Read_DataGridView(dataGridViewStore, _SLE.Stores.ToList());
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
                Read_DataGridView(dataGridViewStore, _SLE.Stores.ToList());
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
        //===========================店家照片集==========================================
        private void btn_readstoreimages_Click(object sender, EventArgs e)
        {   //讀取Store_Image資料表
            Read_DataGridView(dataGridViewStoreImage, _SLE.Store_Image.ToList());
            
            var q = from p in _SLE.Stores
                    select p.RestaurantName;
            foreach (var Name in q)
            {   //把店家名放到combobox
                comboBoxStoreName.Items.Add(Name);
            }
        }
        private void btn_addstoreimages_Click(object sender, EventArgs e)
        {  //增加一欄
            try
            {
                Store_Image store_Image = new Store_Image { StoreID = 1 };
                _SLE.Store_Image.Add(store_Image);
                _SLE.SaveChanges();
                Read_DataGridView(dataGridViewStoreImage, _SLE.Store_Image.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_updatestoreimages_Click(object sender, EventArgs e)
        {   //儲存變更
            try
            {
                var store = (from p in _SLE.Stores
                             select p).FirstOrDefault();
                if (store == null) return;
                _SLE.SaveChanges();
                Read_DataGridView(dataGridViewStoreImage, _SLE.Store_Image.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_deletestoreimages_Click(object sender, EventArgs e)
        {  //刪除選到的欄位
            try
            {
                foreach (DataGridViewRow row in dataGridViewStoreImage.SelectedRows)
                {
                    var storeImage = row.DataBoundItem;
                    _SLE.Store_Image.Remove((Store_Image)storeImage);
                    _SLE.SaveChanges();
                }
                Read_DataGridView(dataGridViewStoreImage, _SLE.Store_Image.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void comboBoxStoreName_SelectedIndexChanged(object sender, EventArgs e)
        {  //選擇店家名會跳出該店家的圖片集
            try
            {
                int SelectStoreID = (int)((from p in _SLE.Store_Image
                                      join s in _SLE.Stores
                                      on p.StoreID equals s.StoreID
                                      where s.RestaurantName == comboBoxStoreName.Text
                                      select p.StoreID).Distinct()).First();
                
                ShowImage(SelectStoreID);//顯示對應的店家圖片
            }
            catch (Exception)
            {
                MessageBox.Show("沒有對應的圖片");
            }                                                  
        }
        public void ShowImage(int storeID)
        {  //用combobox選到的店名去搜尋圖片並放到flowLayoutPanel
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
                    f.Width =1200 ;
                    f.Height = 720;
                    f.BackgroundImage = ((PictureBox)sender).Image;
                    f.BackgroundImageLayout = ImageLayout.Stretch;
                    f.Show();
                };
                MemoryStream ms = new MemoryStream(img);
                pictureBox.Image = Image.FromStream(ms);               //轉好的資料放到pictureBox
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; //設定pictureBox屬性                
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
