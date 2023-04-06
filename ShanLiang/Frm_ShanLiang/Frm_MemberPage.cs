using Frm_ShanLiang.ExtesionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
        //txt_MemberSearchByWords.SetWatermark("請輸入餐廳名稱");
       
        }
        //private void btn_ReviseData_Click(object sender, EventArgs e)
        //{
           
        //}
        ShanLiangEntities _SL = new ShanLiangEntities();
        BindingSource BindingSourceMemberOrderDetails = new BindingSource();
           
    private void btn_MemberRevisingInfo_Click(object sender, EventArgs e)
        {
            
            this.tabControl_MemberManagementSystem.SelectedIndex = 1;
           //從db載入會員資料
            var qAccount = from p in _SL.Members
                       where p.AccountName == CNowLoginAccount._loginAccountName
                       select p.AccountName;
            foreach (var i in qAccount) {
                this.txt_MemberAccount.Text = i;
            }
            var qName = from p in _SL.Members
                        where p.AccountName == CNowLoginAccount._loginAccountName
                        select p.MemberName;
            foreach(var i in qName){
                this.txt_MemberName.Text = i;
            }
            var qPhone = from p in _SL.Members
                         where p.AccountName == CNowLoginAccount._loginAccountName
                         select p.Memberphone;
            foreach (var i in qPhone){
                this.txt_MemberTelephoneNumber.Text = i;
            }    
            var qEmail = from p in _SL.Members
                         where p.AccountName == CNowLoginAccount._loginAccountName
                         select p.Email;
            foreach (var i in qEmail){
                this.txt_MemberEMail.Text = i;
            }
            var qAddress = from p in _SL.Members
                       where p.AccountName == CNowLoginAccount._loginAccountName
                       select p.Address;
            foreach (var i in qAddress){
                this.txt_MemberAddress.Text = i;
            }
            this.txt_MemberPasswords.Enabled = false;
            this.txt_MemberPasswordsConfirmation.Enabled = false;
            this.rdo_encryption.Enabled = false;
            this.rdoDecryption.Enabled = false; this.label_NewPasswords.Enabled = false;
            this.label_MemberNewPasswordsConfirm.Enabled = false;
            this.txt_MemberPasswords.Visible = false;
            this.txt_MemberPasswordsConfirmation.Visible = false;
            this.rdo_encryption.Visible = false;
            this.rdoDecryption.Visible = false;
            this.label_NewPasswords.Visible = false;
            this.label_MemberNewPasswordsConfirm.Visible = false;
        }
    private void btn_MemberOrderRecord_Click(object sender, EventArgs e)
    {
         this.tabControl_MemberManagementSystem.SelectedIndex = 2;
    }

    private void btn_MemberCoupon_Click(object sender, EventArgs e)
    {
         this.tabControl_MemberManagementSystem.SelectedIndex = 3;
    }


    private void btn_MemberAction1_Click(object sender, EventArgs e)
    {
        this.tabControl_MemberManagementSystem.SelectedIndex = 4;
    }

        private void txt_MemberRevisionConfirm_TextChanged(object sender, EventArgs e)
        {
        }

        private void tabControl_MemberManagementSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        bool boolStg;
        private void txt_MemberPasswords_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.btn_MemberInfoRevisionComfirm.Enabled = true;
                this.txt_MemberPasswords.ForeColor = Color.Black;
                CheckConsistency();
                boolStg = IsStrongPassword(txt_MemberPasswords.Text);
            //"密碼強度強中弱" 至少包含小寫大寫數字 正規表達式
                this.label_MemberPasswordWarning.Text = boolStg ? "密碼符合格式" : "密碼不符合格式";
                if (boolStg == false)
                {
                    this.label_MemberPasswordWarning.ForeColor = Color.Red;
                }
                if (boolStg == true)
                {
                    this.label_MemberPasswordWarning.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("密碼輸入錯誤");
            }
        }

        private bool IsStrongPassword(string password)
        {
            //try
            {
                bool result = Regex.IsMatch(password, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,16}$");
                return result;
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show("密碼輸入錯誤");
            //    return false; 
            //}
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

        private void button1_Click(object sender, EventArgs e)
        {
           
            _SL.SaveChanges();
        }
        bool IsPasswordsEnabled = false;
        private void btn_MemberInfoRevisionComfirm_Click(object sender, EventArgs e)
        {
            try
            {
                //修改會員資料
                var q = (from m in this._SL.Members
                         where m.AccountName == CNowLoginAccount._loginAccountName
                         select m).FirstOrDefault();
                if (q == null) return;
                if (boolStg == false && IsPasswordsEnabled == true)
                {
                    
                    MessageBox.Show("密碼不符格式");
                    return;
                }
                if (IsConsistency == false && IsPasswordsEnabled == true)
                {
                    MessageBox.Show("密碼不一致");
                    return;
                }
                //修改會員姓名
                q.MemberName = this.txt_MemberName.Text;
                //修改會員電話
                q.Memberphone = this.txt_MemberTelephoneNumber.Text;
                //修改會員姓名
                q.Email = this.txt_MemberEMail.Text;
                //修改會員地址
                q.Address = this.txt_MemberAddress.Text;
                //存入db
                this._SL.SaveChanges();
                MessageBox.Show("修改成功");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生{ex}例外"); 
                
            }
            
        }

        private void btn_MemberInfoLoad_Click(object sender, EventArgs e)
        {
            try
            {
                //從db載入會員資料
                var qAccount = from p in _SL.Members
                               where p.AccountName == CNowLoginAccount._loginAccountName
                               select p.AccountName;
                foreach (var i in qAccount)
                {
                    this.txt_MemberAccount.Text = i;
                }
                var qName = from p in _SL.Members
                            where p.AccountName == CNowLoginAccount._loginAccountName
                            select p.MemberName;
                foreach (var i in qName)
                {
                    this.txt_MemberName.Text = i;
                }
                var qPhone = from p in _SL.Members
                             where p.AccountName == CNowLoginAccount._loginAccountName
                             select p.Memberphone;
                foreach (var i in qPhone)
                {
                    this.txt_MemberTelephoneNumber.Text = i;
                }
                var qEmail = from p in _SL.Members
                             where p.AccountName == CNowLoginAccount._loginAccountName
                             select p.Email;
                foreach (var i in qEmail)
                {
                    this.txt_MemberEMail.Text = i;
                }
                var qAddress = from p in _SL.Members
                               where p.AccountName == CNowLoginAccount._loginAccountName
                               select p.Address;
                foreach (var i in qAddress)
                {
                    this.txt_MemberAddress.Text = i;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生{ex}例外事件");
            }
        }

        private void btn_MemberInfoRevisionDemo_Click(object sender, EventArgs e)
        {
            try { 
            //demo 修改會員電話與地址
            this.txt_MemberTelephoneNumber.Text = "0983385150";
            this.txt_MemberAddress.Text = "新北市土城區";
                }
            catch (Exception ex)
            {
                MessageBox.Show($"發生{ex}例外事件");
            }

        }

        private void btn_ClearMemberInfo_Click(object sender, EventArgs e)
        {
            try { 
                this.txt_MemberAccount.Text = "";
                this.txt_MemberPasswords.Text = "";
                this.txt_MemberPasswordsConfirmation.Text = "";
                this.txt_MemberName.Text = "";
                this.txt_MemberTelephoneNumber.Text = "";
                this.txt_MemberEMail.Text = "";
                this.txt_MemberAddress.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生{ex}例外事件");
            }
        }

        private void rdo_encryption_CheckedChanged(object sender, EventArgs e)
        {
            this.txt_MemberPasswords.PasswordChar = '*';
            this.txt_MemberPasswordsConfirmation.PasswordChar = '*';
        }
        private void rdoDecryption_CheckedChanged(object sender, EventArgs e)
        {
            this.txt_MemberPasswords.PasswordChar = '\0';
            this.txt_MemberPasswordsConfirmation.PasswordChar = '\0';        }

        private void rdo_encryption_Click(object sender, EventArgs e)
        {            

        }

        private void txt_MemberPasswords_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.Show("密碼須包含大寫、小寫英文字母及數字，8-16字", txt_MemberPasswords);
        }

        private void btn_MemberSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var q = from m in this._SL.Members
                        join o in this._SL.Orders
                        on m.MemberID equals o.MemberID
                        join s in this._SL.Stores
                        on o.StoreID equals s.StoreID
                        where m.AccountName == CNowLoginAccount._loginAccountName
                        //&& s.AccountName.Contains(ss)
                        select new
                        {
                            /*訂單編號 =*/
                            o.OrderID,
                            /*會員姓名 =*/
                            m.MemberName,
                            /*餐廳名稱 = */
                            s.AccountName,
                            /*餐廳電話 =*/
                            s.RestaurantPhone,
                            /*餐廳地址 = */
                            s.RestaurantAddress,
                            /*訂位時間 = */
                            o.ReservationTime,
                            /*訂位人數 = */
                            o.ReservationNumber,
                            /*用餐金額 = */
                            o.Amount,
                        };
                //var q = from m in this._SL.Members
                //        join o in this._SL.Orders
                //        on m.MemberID equals o.MemberID
                //        join s in this._SL.Stores
                //        on o.StoreID equals s.StoreID
                //        select new
                //        {
                //            o.OrderID,
                //            m.MemberName,
                //            s.AccountName,
                //            s.RestaurantPhone,
                //            s.RestaurantAddress,
                //            o.ReservationTime,
                //            o.ReservationNumber,
                //        };
                //var q = from m in this._SL.Members
                //        from o1 in m.Orders
                //        from o2 in o1.Store.RestaurantName

                //        where o1.MemberID == 33
                //        select new
                //        {
                //            o1.OrderID,
                //            o1.StoreID,
                //            m.MemberName,
                //            o2
                //        };
                //var q = from m in this._SL.Members
                //        from o1 in m.Orders
                //        from s in this._SL.Stores
                //        from o2 in s.Orders



                //        where o1.MemberID == 33
                //        select new
                //        {
                //            o1.OrderID,o1.StoreID,m.MemberName,
                //            o2.Store.RestaurantName
                //        };
                //var q =
                //       from s in this._SL.Stores
                //       from o in s.Orders

                //       where o.MemberID == 33
                //       select new
                //       {
                //           o.Store.RestaurantName,
                //           o.Store.RestaurantAddress,
                //           o.Store.RestaurantPhone,
                //           s.AccountName
                //       };
                //var q2 = from m in this._SL.Orders
                //        where m.MemberID == 33
                //        select m;
                //foreach (var i in q2) {


                //}

                BindingSourceMemberOrderDetails.DataSource = q.ToList();
                this.dataGridView1.DataSource = BindingSourceMemberOrderDetails;

                //MessageBox.Show(BindingSourceMemberOrderDetails[1].ToString());
                //this.listBox1.Items.Add(BindingSourceMemberOrderDetails);

                this.label_MemberOrderId.DataBindings.Add("Text", BindingSourceMemberOrderDetails, "OrderID");
                this.label_RestaurantName.DataBindings.Add("Text", BindingSourceMemberOrderDetails, "AccountName");
                this.label_RestaurantPhonenumber.DataBindings.Add("Text", BindingSourceMemberOrderDetails, "RestaurantPhone");
                this.label_RestaurantAddress.DataBindings.Add("Text", BindingSourceMemberOrderDetails, "RestaurantAddress");
                this.label_MemberReservationTime.DataBindings.Add("Text", BindingSourceMemberOrderDetails, "ReservationTime");
                this.label_MemberReservationNumber.DataBindings.Add("Text", BindingSourceMemberOrderDetails, "ReservationNumber");
                this.label_MemberSpend.DataBindings.Add("Text", BindingSourceMemberOrderDetails, "Amount");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生{ex}例外");
            }




        }
        bool IsConsistency;
        private void txt_MemberPasswordsConfirmation_TextChanged(object sender, EventArgs e)
        {
            CheckConsistency();

        }

        private void CheckConsistency()
        {
            if (this.txt_MemberPasswords.Text != this.txt_MemberPasswordsConfirmation.Text)
            {
                this.label_MemberPassworsConsistency.Text = "密碼不一致";
                this.label_MemberPassworsConsistency.ForeColor = Color.Red;
                IsConsistency = false;
            }
            if (this.txt_MemberPasswords.Text == this.txt_MemberPasswordsConfirmation.Text)
            {
                this.label_MemberPassworsConsistency.Text = "";
                IsConsistency = true;
            }
        }

        private void btn_MemberEnalblePassword_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt_MemberPasswords.Enabled = true;
                this.txt_MemberPasswordsConfirmation.Enabled = true;
                this.rdo_encryption.Enabled = true;
                this.rdoDecryption.Enabled = true;
                this.label_MemberNewPasswordsConfirm.Enabled = true;
                this.txt_MemberPasswords.Visible = true;
                this.label_NewPasswords.Enabled = true;
                this.txt_MemberPasswords.Visible = true;
                this.txt_MemberPasswordsConfirmation.Visible = true;
                this.rdo_encryption.Visible = true;
                this.rdoDecryption.Visible = true;
                this.label_NewPasswords.Visible = true;
                this.label_MemberNewPasswordsConfirm.Visible = true;
                IsPasswordsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生{ex}例外事件");
            }
        }

        private void tabPage1_MemberAction_Click(object sender, EventArgs e)
        {
           }
        

        private void btn_MemberActionChaningedConfirm_Click(object sender, EventArgs e)
        {

        }

        private void cbo_MemberSelectedAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            
            var q = from a in _SL.Actions
                    join ma in _SL.Member_Action
                    on a.ActionID equals ma.ActionID
                    join s in _SL.Stores
                    on ma.StoreID equals s.StoreID
                    //where AccountAndAction((Int32)ma.MemberID, (Int32)ma.ActionID )

                    where ma.MemberID == 33
                    &&
                    ma.ActionID == cbo_MemberSelectedAction.SelectedIndex+1
                    select new {a.ActionName, s.AccountName };
            this.dataGridView2.DataSource = q.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生{ex}例外事件");
            }
            //foreach (var item in q)
            //{
            //    item.ActionName= "收藏";
            //}
        }
        bool AccountAndAction(int ii1, int ii2)
        {
            bool result1 = ii1 == CNowLoginAccount._nowLoginAccountID;
            bool result2 = ii2 == cbo_MemberSelectedAction.SelectedIndex;
            return result1 && result2;
        }

        private void btn_MemberInfoRevisionDemoWithPasswords_Click(object sender, EventArgs e)
        {
            try
            {
                //demo 修改會員電話與地址
                this.txt_MemberPasswords.Text = "ispanR304";
                this.txt_MemberTelephoneNumber.Text = "0983385150";
                this.txt_MemberAddress.Text = "新北市土城區";
                this.txt_MemberPasswordsConfirmation.Text = "ispanR304";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生{ex}例外事件");
            }

        }

        private void btn_MemberInfoRevisionComfirmWithPasswords_Click(object sender, EventArgs e)
        {
            try
            {
                //修改會員資料
                var q = (from m in this._SL.Members
                         join a in this._SL.Accounts
                         on m.AccountName equals a.AccountName
                         where m.AccountName == CNowLoginAccount._loginAccountName
                         select m ).FirstOrDefault();
                if (q == null) return;
                if (boolStg == false && IsPasswordsEnabled == true)
                {

                    MessageBox.Show("密碼不符格式");
                    return;
                }
                if (IsConsistency == false && IsPasswordsEnabled == true)
                {
                    MessageBox.Show("密碼不一致");
                    return;
                }
                //修改會員姓名
                q.MemberName = this.txt_MemberName.Text;
                //修改會員電話
                q.Memberphone = this.txt_MemberTelephoneNumber.Text;
                //修改會員姓名
                q.Email = this.txt_MemberEMail.Text;
                //修改會員地址
                q.Address = this.txt_MemberAddress.Text;
                //存入db
                this._SL.SaveChanges();
                MessageBox.Show("修改成功");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生{ex}例外");

            }

        }
    }
}
