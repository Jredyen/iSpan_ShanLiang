using Frm_ShanLiang.ExtesionMethods;
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
    public partial class Frm_MemberPage : Form
    {
    public Frm_MemberPage()
    {
        InitializeComponent();
    }
    private void Frm_MemberPage_Load(object sender, EventArgs e)
    {
        txt_MemberSearchByWords.SetWatermark("請輸入餐廳名稱");
    }
        //private void btn_ReviseData_Click(object sender, EventArgs e)
        //{
           
        //}
    private void btn_MemberRevisingInfo_Click(object sender, EventArgs e)
    {
         this.tabControl_MemberManagementSystem.SelectedIndex = 1;
    }
    private void btn_MemberOrderRecord_Click(object sender, EventArgs e)
    {
         this.tabControl_MemberManagementSystem.SelectedIndex = 2;
    }

    private void btn_MemberCoupon_Click(object sender, EventArgs e)
    {
         this.tabControl_MemberManagementSystem.SelectedIndex = 3;
    }

        //private void btn_MemberEvaluation_Click(object sender, EventArgs e)
        //{
        //}

        

    private void btn_MemberAction1_Click(object sender, EventArgs e)
    {
        this.tabControl_MemberManagementSystem.SelectedIndex = 4;
    }

        private void txt_MemberRevisionConfirm_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl_MemberManagementSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_MemberManagementSystem.SelectedIndex == 1)
            {
                txt_MemberAccount.Text = CMemberData._loginAccountName;
                txt_MemberName.Text = CMemberData._memberName;
                txt_MemberAddress.Text = CMemberData._address;
                txt_MemberEMail.Text = CMemberData._email;
                txt_MemberTelephoneNumber.Text = CMemberData._memberphone;
            }
            

        }

        private void txt_MemberPasswords_TextChanged(object sender, EventArgs e)
        {
            //"密碼強度強中弱" 至少包含小寫大寫數字 正規表達式
        }

        private void txt_MemberEMail_TextChanged(object sender, EventArgs e)
        {
            //正規表達式 包含@  在db是不是唯一值
        }

        private void btn_BactToMemberMainPage_Click(object sender, EventArgs e)
        {
            BackToMainPage();
        }

        void BackToMainPage()
        {
            this.tabControl_MemberManagementSystem.SelectedIndex = 0;
        }

        private void btn_BactToMemberMainPage2_Click(object sender, EventArgs e)
        {
            BackToMainPage();
        }

        private void btn_BactToMemberMainPage3_Click(object sender, EventArgs e)
        {
            BackToMainPage();
        }

        private void btn_BactToMemberMainPage4_Click(object sender, EventArgs e)
        {
            BackToMainPage();
        }
    }
}
