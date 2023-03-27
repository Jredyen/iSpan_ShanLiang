using Frm_ShanLiang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShanLiang
{
    public partial class Frm_Homepage : Form
    {
        List<Image> _adImages = new List<Image>();
        int _adIndex = 0;
        ShanLiangEntities SL = new ShanLiangEntities();
        public Frm_Homepage()
        {
            InitializeComponent();
            
            timer_ADchange.Enabled = true;
            timer_ADchange.Interval = 5000;

            _adImages.Add(Image.FromFile(@"ubAD1.png"));
            _adImages.Add(Image.FromFile(@"ubAD2.png"));
            _adImages.Add(Image.FromFile(@"ubAD3.png"));
            pictureBox1.Image = _adImages[_adIndex];


            // cmb區域
            var q = from c in SL.Cities

                    select c.CityName;

            foreach (var c in q)
            {
                cmb_City.Items.Add(c);
            }
            // cmb餐廳類別
            var q1 = from c in SL.Restaurant_Type

                    select c.TypeName;

            foreach (var c in q1)
            {
                cmb_restaurantType.Items.Add(c);
            }

        }

        private void Frm_Homepage_Load(object sender,EventArgs e)
        {
           

        }
        private void bnt_login_Click(object sender, EventArgs e)
        {
            new Frm_LoginPage().ShowDialog();
            
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            new Frm_SignInPage().ShowDialog();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                var q = from S in SL.Stores
                        select S;
                dataGridView1.DataSource = q.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void timer_ADchange_Tick(object sender, EventArgs e)
        {
            _adIndex++;
            if (_adIndex == _adImages.Count)
            {
                _adIndex = 0;
                pictureBox1.Image = _adImages[_adIndex];
            }
            else
            {
                pictureBox1.Image = _adImages[_adIndex];
            }
        }

        private void cmb_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 需要把市區跟類別 弄成 單獨選擇 市區 就會出現符合市區的資料 
            //                           選擇 市區跟類別 就會出現符合市區跟類別的資料
            // 可以設定成 cmb 點選就出現資料 也可以弄成 btn點選後才出現資料
            try
            {
                var q = from S in SL.Stores.AsEnumerable()
                        where S.RestaurantAddress.Contains($"{cmb_City.SelectedItem}")
                        select S;
                dataGridView1.DataSource = q.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
        }
        private void cmb_restaurantType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 需要把市區跟類別 弄成 單獨選擇 市區 就會出現符合市區的資料 
            //                           選擇 市區跟類別 就會出現符合市區跟類別的資料
            try
            {
                var q = from S in SL.Store_Type
                        where S.Restaurant_Type.TypeName == cmb_restaurantType.SelectedItem.ToString()
                        select  S.Store;
                dataGridView1.DataSource = q.ToList();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

           

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //預計做成 點選DataGridView 的店家資料 picturebox2就會出現店家的圖片
            //資料庫圖片還沒插入 還沒試驗能不能成
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    // 取得圖片的路徑
                    string imagePath = row.Cells["StoreImage"].Value.ToString();

                    // 將圖片載入 PictureBox
                    pictureBox2.Image = Image.FromFile(imagePath);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
