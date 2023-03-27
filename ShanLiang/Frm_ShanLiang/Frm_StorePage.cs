using Frm_ShanLiang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frm_ShanLiang
{
    public partial class Frm_StorePage : Form
    {
        List<Image> _storeAdImages = new List<Image>();
        int _storeAdIndex1 = 0, _storeAdIndex2 = 1, _storeAdIndex3 = 2;
        public Frm_StorePage()
        {
            InitializeComponent();
            timerStoreAd.Enabled = true;
            timerStoreAd.Interval = 5000;

            _storeAdImages.Add(Image.FromFile(@"ubAD1.png"));
            _storeAdImages.Add(Image.FromFile(@"ubAD2.png"));
            _storeAdImages.Add(Image.FromFile(@"ubAD3.png"));
            pictureBox1.Image = _storeAdImages[_storeAdIndex1];
            pictureBox2.Image = _storeAdImages[_storeAdIndex2];
            pictureBox3.Image = _storeAdImages[_storeAdIndex3];
        }
        private void timerStoreAd_Tick(object sender, EventArgs e)
        {
            _storeAdIndex1 = ShowImage(_storeAdIndex1);
            pictureBox1.Image = _storeAdImages[_storeAdIndex1];
            _storeAdIndex2 = ShowImage(_storeAdIndex2);
            pictureBox2.Image = _storeAdImages[_storeAdIndex2];
            _storeAdIndex3 = ShowImage(_storeAdIndex3);
            pictureBox3.Image = _storeAdImages[_storeAdIndex3];
        }
        private int ShowImage(int i)
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

        private void bnt_login_Click(object sender, EventArgs e)
        {

        }

        private void btn_signin_Click(object sender, EventArgs e)
        {

        }
        
    }
}
