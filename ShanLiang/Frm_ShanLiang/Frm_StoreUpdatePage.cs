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
    public partial class Frm_StoreUpdatePage : Form
    {
        public Frm_StoreUpdatePage()
        {
            InitializeComponent();
        }

        private void storeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.storeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._ShanLiang2_1DataSet);

        }

        private void Frm_StoreUpdatePage_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 '_ShanLiang2_1DataSet.Store' 資料表。您可以視需要進行移動或移除。
            this.storeTableAdapter.Fill(this._ShanLiang2_1DataSet.Store);

        }

        private void btn_StoreImg_Click(object sender, EventArgs e)
        {
          
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.storeImagePictureBox.Image = Image.FromFile(this.openFileDialog1.FileName);
            }
        }
    }
}
