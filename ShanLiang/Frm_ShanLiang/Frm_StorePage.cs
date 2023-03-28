using Frm_ShanLiang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frm_ShanLiang
{
    public partial class Frm_StorePage : Form
    {
        ShanLiangEntities SLE = new ShanLiangEntities();
        List<Image> _storeAdImages = new List<Image>();
        public int _sid; //店家的ID

        public Frm_StorePage()
        {
            InitializeComponent();
        }
        private void Frm_StorePage_Load(object sender, EventArgs e)
        {
            //帶入店家的ID，載入資料
            _sid = SLE.Stores.First().StoreID;
            LoadStoreData(_sid);
        }

        public void LoadStoreData(int i)
        {
            //店家圖片
            var q7 = SLE.Stores.Where(id => id.StoreID == _sid).Select(n => n.StoreImage);
            foreach (var item in q7)
            {
                MemoryStream ms = new MemoryStream(item);
                pictureBox1.Image = Image.FromStream(ms);
            }
            //店家類型
            var q6 = SLE.Store_Type.Where(id => id.StoreID == _sid).Select(n => n.Restaurant_Type.TypeName);
            flowLayoutPanel1.Controls.Clear();
            foreach (var item in q6)
            {
                LinkLabel linkLab = new LinkLabel();
                linkLab.AutoSize = true;
                linkLab.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(136)));
                linkLab.ImageAlign = ContentAlignment.MiddleLeft;
                linkLab.Name = "linkLab"+item;
                linkLab.Size = new Size(31, 16);
                //linkLab.TabIndex = 1;
                linkLab.TabStop = true;
                linkLab.Text = item;
                flowLayoutPanel1.Controls.Add(linkLab);
            }
            //店名
            var q = SLE.Stores.Where(id => id.StoreID == _sid).Select(n => n.RestaurantName);
            foreach (var item in q)
                labResName.Text = item;
            //評分
            var q4 = SLE.Stores.Where(id => id.StoreID == _sid).Select(n => n.Rating);
            labStar.Text = null;
            foreach (var item in q4)
            {
                labRating.Text = $"{item.Value:F1}";
                for (int m = 0; m < item.Value; m++)
                    labStar.Text += "★";
            }
            //地址
            var q1 = SLE.Stores.Where(id => id.StoreID == _sid).Select(n => n.RestaurantAddress);
            foreach (var item in q1)
                labResAddress.Text = item;
            //營業時間
            var q2 = SLE.Stores.Where(id => id.StoreID == _sid).Select(n => new { n.OpeningTime, n.ClosingTime });
            foreach (var item in q2)
                labOpenTime.Text = $"{item.OpeningTime} - {item.ClosingTime}";
            //電話
            var q3 = SLE.Stores.Where(id => id.StoreID == _sid).Select(n => n.RestaurantPhone);
            foreach (var item in q3)
                labResPhone.Text = item;
            //空位
            var q5 = SLE.Stores.Where(id => id.StoreID == _sid).Select(n => n.Seats);
            foreach (var item in q5)
                labSeat.Text = $"1 / {item.ToString()}";  
        }                

        public int ShowImage(int i)
        {
            i++;
            if (i == _storeAdImages.Count)
            {
                i = 0;                
                return i;
            }
            else
            {                
                return i;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _sid = 1;
            LoadStoreData(_sid);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            _sid = 2;
            LoadStoreData(_sid);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _sid = 6;
            LoadStoreData(_sid);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _sid = 12;
            LoadStoreData(_sid);
        }

        private void bnt_login_Click(object sender, EventArgs e)
        {
            new Frm_LoginPage().ShowDialog();
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            new Frm_SignInPage().ShowDialog();
        }
        
    }
}
