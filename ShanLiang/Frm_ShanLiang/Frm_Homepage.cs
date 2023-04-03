using Frm_ShanLiang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ShanLiang
{
    public partial class Frm_Homepage : Form
    {
        List<Image> _adImages = new List<Image>();
        int _adIndex = 0;
        ShanLiangEntities _SL = new ShanLiangEntities();
        private List<byte[]> _images;
        private int _currentIndex;

        public Frm_Homepage()
        {
            InitializeComponent();

            //timer_ADchange.Enabled = true;
            //timer_ADchange.Interval = 5000;


            //_adImages.Add(Image.FromFile(@"ubAD1.png"));
            //_adImages.Add(Image.FromFile(@"ubAD2.png"));
            //_adImages.Add(Image.FromFile(@"ubAD3.png"));

            //pictureBox1.Image = _adImages[_adIndex];

            
            timer_ADchange.Interval = 3000; 
            timer_ADchange.Start();
            LoadImages();
            // cmb 城市
            var q_City = from c in _SL.Cities

                    select c.CityName;

            foreach (var c in q_City)
            {
                cmb_City.Items.Add(c);
            }
            // cmb 區域
            //var q_Area = (from c in _SL.Stores

            //         select c.RestaurantAddress.Substring(3, 3)).Distinct();

            //foreach (var c in q_Area)
            //{
            //    cmb_area.Items.Add(c);
            //}

            // cmb餐廳類別
            var q_RestaurantType = from c in _SL.Restaurant_Type

                    select c.TypeName;

            foreach (var c in q_RestaurantType)
            {
                cmb_restaurantType.Items.Add(c);
            }

        }
        private void LoadImages()
        {
            _images = (from i in _SL.Stores select i.StoreImage).ToList();
        }
        public void Frm_Homepage_Load(object sender, EventArgs e)
        {
           

        }
       


        private void bnt_login_Click(object sender, EventArgs e)
        {
            new Frm_LoginPage().ShowDialog();
            
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            new Frm_SignupPage().ShowDialog();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txt_keyword.Text;

                if (cmb_area.SelectedItem == null && cmb_restaurantType.SelectedItem == null)
                {
                    var q = from S in _SL.Stores.AsEnumerable()
                            where S.RestaurantAddress.Contains($"{cmb_City.SelectedItem}")
                            select new
                            {
                                S.StoreID,
                                S.AccountName,
                                S.TaxID,
                                S.RestaurantName,
                                S.RestaurantAddress,
                                S.RestaurantPhone,
                                S.DistrictID,
                                S.Seats,
                                S.Longitude,
                                S.Latitude,
                                S.OpeningTime,
                                S.ClosingTime,
                                S.Website,
                                S.StoreImage,
                                S.Rating,
                                S.StoreMail
                            };
                    dataGridView1.DataSource = q.ToList();
                }
                else if (cmb_restaurantType.SelectedItem == null && cmb_City.SelectedItem != null && cmb_area.SelectedItem != null)
                {
                    var q = from S in _SL.Stores.AsEnumerable()
                            where
                            S.RestaurantAddress.Contains($"{cmb_City.SelectedItem}") &&
                            S.RestaurantAddress.Contains($"{cmb_area.SelectedItem}")
                            select new
                            {
                                S.StoreID,
                                S.AccountName,
                                S.TaxID,
                                S.RestaurantName,
                                S.RestaurantAddress,
                                S.RestaurantPhone,
                                S.DistrictID,
                                S.Seats,
                                S.Longitude,
                                S.Latitude,
                                S.OpeningTime,
                                S.ClosingTime,
                                S.Website,
                                S.StoreImage,
                                S.Rating,
                                S.StoreMail
                            };
                    dataGridView1.DataSource = q.ToList();
                }else
                {
                    var q = from S in _SL.Stores.AsEnumerable()
                                //from C in _SL.Cities
                                //join CC in _SL.Districts on C.CityID equals CC.CityID
                            join St in _SL.Store_Type.AsEnumerable() on S.StoreID equals St.StoreID
                            where
                            //TODO:
                            //C.CityName == (cmb_City.SelectedItem).ToString() 


                            S.RestaurantAddress.Contains($"{cmb_City.SelectedItem}") &&

                            S.RestaurantAddress.Contains($"{cmb_area.SelectedItem}") &&


                            //S.RestaurantAddress.Contains($"{cmb_City.SelectedItem}{cmb_area.SelectedItem}") ||

                            St.Restaurant_Type.TypeName == cmb_restaurantType.SelectedItem.ToString()

                            //  && S.RestaurantName.Contains($"{txt_keyword.Text}")


                            select new
                            {
                                S.StoreID,
                                S.AccountName,
                                S.TaxID,
                                S.RestaurantName,
                                S.RestaurantAddress,
                                S.RestaurantPhone,
                                S.DistrictID,
                                S.Seats,
                                S.Longitude,
                                S.Latitude,
                                S.OpeningTime,
                                S.ClosingTime,
                                S.Website,
                                S.StoreImage,
                                S.Rating,
                                S.StoreMail
                            };
                    dataGridView1.DataSource = q.ToList();
                }
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        

       
        public void timer_ADchange_Tick(object sender, EventArgs e)
        {
            //_adIndex++;
            //if (_adIndex == _adImages.Count)
            //{
            //    _adIndex = 0;
            //    pictureBox1.Image = _adImages[_adIndex];
            //}
            //else
            //{
            //    pictureBox1.Image = _adImages[_adIndex];
            //}
            if (_images == null || _images.Count == 0)
                return;
            byte[] imageData = _images[_currentIndex];

            if (imageData == null)
            {
                
                _currentIndex = (_currentIndex + 1) % _images.Count;
                return;
            }

           
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                try
                {
                    Bitmap bitmap = new Bitmap(ms);
                    pictureBox1.Image = bitmap;
                }
                catch (ArgumentException ex)
                {
                    
                    Console.WriteLine($"Failed to display image: {ex.Message}");
                    _currentIndex = (_currentIndex + 1) % _images.Count;
                    return;
                }
            }

            
            _currentIndex = (_currentIndex + 1) % _images.Count;
        }
       
        private void cmb_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            cmb_area.Items.Clear();
            IQueryable<string> v = from d in _SL.Districts
                                   join c in _SL.Cities on d.CityID equals c.CityID
                                   where c.CityName == cmb_City.SelectedItem.ToString()
                                   select d.DistrictName;
            v.ToList();
            foreach (string districe in v)
            {
                cmb_area.Items.Add(districe);
            }

        }
        private void cmb_area_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }
        private void cmb_restaurantType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

            

        }

       



        private void txt_keyword_TextChanged(object sender, EventArgs e)
        {   //如果沒搜尋到東西 是否要多個if data沒秀任何資料 就跳出視窗 告知沒有搜尋到結果 是否前往熱門餐廳的按鈕?
            try
            {
                
                string keyword = txt_keyword.Text;
                var query = from S in _SL.Stores
                            where 
                            S.RestaurantAddress.Contains(keyword) ||
                            S.RestaurantName.Contains(keyword)
                            select new {
                                S.StoreID,
                                S.AccountName,
                                S.TaxID,
                                S.RestaurantName,
                                S.RestaurantAddress,
                                S.RestaurantPhone,
                                S.DistrictID,
                                S.Seats,
                                S.Longitude,
                                S.Latitude,
                                S.OpeningTime,
                                S.ClosingTime,
                                S.Website,
                                S.StoreImage,
                                S.Rating, 
                                S.StoreMail
                            };
                dataGridView1.DataSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           




        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    // 從資料行取得二進位圖片資料
                    byte[] imageData = (byte[])row.Cells["StoreImage"].Value;

                    // 將二進位圖片資料轉換成圖片物件
                    Image image;
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        image = Image.FromStream(ms);
                    }

                    // 將圖片顯示在 PictureBox 控制項中
                    pictureBox2.Image = image;
                }
            }
            catch (Exception ex)
            {
                pictureBox2.Image = pictureBox2.ErrorImage;
            }
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

                    // 從資料行取得二進位圖片資料
                    byte[] imageData = (byte[])row.Cells["StoreImage"].Value;

                    // 將二進位圖片資料轉換成圖片物件
                    Image image;
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        image = Image.FromStream(ms);
                    }

                    // 將圖片顯示在 PictureBox 控制項中
                    pictureBox3.Image = image;
                }
            }
            catch (Exception ex)
            {
                pictureBox3.Image = pictureBox3.ErrorImage;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var query = from S in _SL.Stores
                            where S.Rating > 4

                            select new
                            {
                                S.StoreID,
                                S.AccountName,
                                S.TaxID,
                                S.RestaurantName,
                                S.RestaurantAddress,
                                S.RestaurantPhone,
                                S.DistrictID,
                                S.Seats,
                                S.Longitude,
                                S.Latitude,
                                S.OpeningTime,
                                S.ClosingTime,
                                S.Website,
                                S.StoreImage,
                                S.Rating,
                                S.StoreMail
                            };
                dataGridView2.DataSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
