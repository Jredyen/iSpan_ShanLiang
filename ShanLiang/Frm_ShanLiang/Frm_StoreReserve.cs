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
    public partial class Frm_StoreReserve : Form
    {
        public Frm_StoreReserve()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        
        private void label_MouseClick(object sender, MouseEventArgs e)
        {
            Label lab = (Label)sender;
            lab.BackColor = SystemColors.Control;
        }
        

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if(rb.Checked) 
            {
                rb.BackColor = SystemColors.ControlLightLight;
                rb.ForeColor = SystemColors.ControlDarkDark;
            }
            else
            {
                rb.BackColor = SystemColors.ControlDarkDark;
                rb.ForeColor = SystemColors.ControlLightLight;
            }
            
        }


    }
}
