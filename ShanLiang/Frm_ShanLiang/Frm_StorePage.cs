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
            //取得當下_sid的_list
            Store store = cSP.getCurrent();
            //店名
            labResName.Text = store.RestaurantName;
            //地址
            labResAddress.Text = store.RestaurantAddress;
            //電話
            labResPhone.Text = store.RestaurantPhone;
            //座位
            labSeat.Text = $"1 / {store.Seats}";
            //營業時間
            labOpenTime.Text = $"{store.OpeningTime} - {store.ClosingTime}";
            //店家圖片
            if (store.StoreImage == null)
                pictureBox1.Image = null;
            else
            {
                MemoryStream ms = new MemoryStream(store.StoreImage);
                pictureBox1.Image = Image.FromStream(ms);
            }
            //評分            
            labRating.Text = $"{store.Rating:F1}";
            labStar.Text = null;
            for (int i = 0; i < store.Rating; i++)
                labStar.Text += "★";

            //店家類型(Store_Type)
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

            //評論區(Store_Evaluate)
            var qCName = SLE.Store_Evaluate.Where(id => id.StoreID == CStorePage._sid).Select(n => n.Member.MemberName);
            foreach (var item in qCName)
                labCmtName.Text = item;
            var qCRating = SLE.Store_Evaluate.Where(id => id.StoreID == CStorePage._sid).Select(n => n.Rating);
            labCmtStar.Text = null;
            foreach (var item in qCRating)
            {               
                for (int m = 0; m < item.Value; m++)
                    labCmtStar.Text += "★";
            }
            var qCDate = SLE.Store_Evaluate.Where(id => id.StoreID == CStorePage._sid).Select(n => n.EvaluateDate);
            foreach (var item in qCDate)
                labCmtDate.Text = $"{item}";
            var qCmt = SLE.Store_Evaluate.Where(id => id.StoreID == CStorePage._sid).Select(n => n.Comments);
            foreach (var item in qCmt)
                labCmt.Text = item;
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
        }//載入分店圖片
        private void btnBranch1_Click(object sender, EventArgs e)
        {
            CStorePage._sid = 1;
            cSP.OutsideShow();
        }
        private void btnBranch2_Click(object sender, EventArgs e)
        {
            CStorePage._sid = 8;
            cSP.OutsideShow();
        }

        private void btnBranch3_Click(object sender, EventArgs e)
        {
            CStorePage._sid = 6;
            cSP.OutsideShow();
        }

        private void btnBranch4_Click(object sender, EventArgs e)
        {
            CStorePage._sid = 12;
            cSP.OutsideShow();
        }

        private void bnt_login_Click(object sender, EventArgs e)
        {
            new Frm_LoginPage().ShowDialog();
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            new Frm_SignupPage().ShowDialog();
        }

        private void bnt_login_Click_1(object sender, EventArgs e)
        {

        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            Frm_StoreReserve fsr = new Frm_StoreReserve();
            fsr.Show();
        }//進入預約頁面

        bool b = false;
        private void btnLike_Click(object sender, EventArgs e)
        {            
            if(b)
            {
                b = false;
                btnLike.Image = Properties.Resources.like_icon;

            }
            else
            {
                b = true;
                btnLike.Image = Properties.Resources.like_love_icon;        
                
            }
            
        }//收藏
    }
}
