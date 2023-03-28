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
using static System.Windows.Forms.AxHost;

namespace Frm_ShanLiang
{
    public partial class Frm_StorePage : Form
    {
        ShanLiangEntities SLE = new ShanLiangEntities(); //資料模型        
        CStorePage cSP = new CStorePage(); //類別

        public Frm_StorePage()
        {
            InitializeComponent();
        }
        private void Frm_StorePage_Load(object sender, EventArgs e)
        {
            //載入分店按鍵背景
            LoadBtnImg();
            //委派LoadStoreData
            cSP.cSS += this.ShowStoreData;
            //載入店家資訊
            ShowStoreData();



            //隨機載入店家CStorePage._sid = SLE.Stores.OrderBy(id => Guid.NewGuid()).First().StoreID;
        }

        public void ShowStoreData()
        {
            //店家圖片
            var qImg = SLE.Stores.Where(id => id.StoreID == CStorePage._sid).Select(n => n.StoreImage);
            foreach (var item in qImg)
            {
                if(item==null)
                    pictureBox1.Image = null;
                else
                {
                    MemoryStream ms = new MemoryStream(item);
                    pictureBox1.Image = Image.FromStream(ms);
                }                                                  
            }
            //店家類型
            var qType = SLE.Store_Type.Where(id => id.StoreID == CStorePage._sid).Select(n => n.Restaurant_Type.TypeName);
            flowLayoutPanel1.Controls.Clear();
            foreach (var item in qType)
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
            var qName = SLE.Stores.Where(id => id.StoreID == CStorePage._sid).Select(n => n.RestaurantName);
            foreach (var item in qName)
                labResName.Text = item;
            //Store store = cSP.getCurrent();
            //labResName.Text = store.RestaurantName;

            //評分
            var qRating = SLE.Stores.Where(id => id.StoreID == CStorePage._sid).Select(n => n.Rating);
            labStar.Text = null;
            foreach (var item in qRating)
            {
                labRating.Text = $"{item.Value:F1}";
                for (int m = 0; m < item.Value; m++)
                    labStar.Text += "★";
            }
            //地址
            var qAd = SLE.Stores.Where(id => id.StoreID == CStorePage._sid).Select(n => n.RestaurantAddress);
            foreach (var item in qAd)
                labResAddress.Text = item;
            //營業時間
            var qTime = SLE.Stores.Where(id => id.StoreID == CStorePage._sid).Select(n => new { n.OpeningTime, n.ClosingTime });
            foreach (var item in qTime)
                labOpenTime.Text = $"{item.OpeningTime} - {item.ClosingTime}";
            //電話
            var qPhone = SLE.Stores.Where(id => id.StoreID == CStorePage._sid).Select(n => n.RestaurantPhone);
            foreach (var item in qPhone)
                labResPhone.Text = item;
            //空位
            var qSeat = SLE.Stores.Where(id => id.StoreID == CStorePage._sid).Select(n => n.Seats);
            foreach (var item in qSeat)
                labSeat.Text = $"1 / {item.ToString()}";  
        }                
        public void LoadBtnImg()
        {
            var q1 = SLE.Stores.Where(id => id.StoreID == 1).Select(n => n.StoreImage);
            foreach (var item in q1)
            {
                if (item == null)
                    btnBranch1.BackgroundImage = null;
                else
                {
                    MemoryStream ms = new MemoryStream(item);
                    btnBranch1.BackgroundImage = Image.FromStream(ms);
                }                
            }
            var q2 = SLE.Stores.Where(id => id.StoreID == 8).Select(n => n.StoreImage);
            foreach (var item in q2)
            {
                if (item == null)
                    btnBranch2.BackgroundImage = null;
                else
                {
                    MemoryStream ms = new MemoryStream(item);
                    btnBranch2.BackgroundImage = Image.FromStream(ms);
                }
                    
            }
            var q6 = SLE.Stores.Where(id => id.StoreID == 6).Select(n => n.StoreImage);
            foreach (var item in q6)
            {
                if (item == null)
                    btnBranch3.BackgroundImage = null;
                else
                {
                    MemoryStream ms = new MemoryStream(item);
                    btnBranch3.BackgroundImage = Image.FromStream(ms);
                }                
            }
            var q12 = SLE.Stores.Where(id => id.StoreID == 12).Select(n => n.StoreImage);
            foreach (var item in q12)
            {
                if (item == null)
                    btnBranch4.BackgroundImage = null;
                else
                {
                    MemoryStream ms = new MemoryStream(item);
                    btnBranch4.BackgroundImage = Image.FromStream(ms);
                }                
            }
        }
        private void btnBranch1_Click(object sender, EventArgs e)
        {
            CStorePage._sid = 1;
            ShowStoreData();            
        }
        private void btnBranch2_Click(object sender, EventArgs e)
        {
            CStorePage._sid = 8;
            ShowStoreData();
        }

        private void btnBranch3_Click(object sender, EventArgs e)
        {
            CStorePage._sid = 6;
            ShowStoreData();
        }

        private void btnBranch4_Click(object sender, EventArgs e)
        {
            CStorePage._sid = 12;
            ShowStoreData();
        }

        private void bnt_login_Click(object sender, EventArgs e)
        {
            new Frm_LoginPage().ShowDialog();
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            new Frm_SignupPage().ShowDialog();
        }
        
    }
}
