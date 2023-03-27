
namespace Frm_ShanLiang
{
    partial class Frm_MemberPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl_CustomerReviseData = new System.Windows.Forms.TabControl();
            this.tabPage_CustomerMain = new System.Windows.Forms.TabPage();
            this.tabPage_Customer = new System.Windows.Forms.TabPage();
            this.btn_ReviseData = new System.Windows.Forms.Button();
            this.btn_OrderRecord = new System.Windows.Forms.Button();
            this.btn_CustomerCoupon = new System.Windows.Forms.Button();
            this.tabPage_CustomerOrderRecord = new System.Windows.Forms.TabPage();
            this.tabPage_CustomerCoupon = new System.Windows.Forms.TabPage();
            this.label_CouponStatus = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_CouponInfomation = new System.Windows.Forms.Label();
            this.label_CustomerCoupons = new System.Windows.Forms.Label();
            this.label_CustomerCoupon = new System.Windows.Forms.Label();
            this.label_CustomerCouponQuantity = new System.Windows.Forms.Label();
            this.tabControl_CustomerReviseData.SuspendLayout();
            this.tabPage_CustomerMain.SuspendLayout();
            this.tabPage_CustomerCoupon.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_CustomerReviseData
            // 
            this.tabControl_CustomerReviseData.Controls.Add(this.tabPage_CustomerMain);
            this.tabControl_CustomerReviseData.Controls.Add(this.tabPage_Customer);
            this.tabControl_CustomerReviseData.Controls.Add(this.tabPage_CustomerOrderRecord);
            this.tabControl_CustomerReviseData.Controls.Add(this.tabPage_CustomerCoupon);
            this.tabControl_CustomerReviseData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_CustomerReviseData.Location = new System.Drawing.Point(0, 0);
            this.tabControl_CustomerReviseData.Name = "tabControl_CustomerReviseData";
            this.tabControl_CustomerReviseData.SelectedIndex = 0;
            this.tabControl_CustomerReviseData.Size = new System.Drawing.Size(800, 450);
            this.tabControl_CustomerReviseData.TabIndex = 0;
            // 
            // tabPage_CustomerMain
            // 
            this.tabPage_CustomerMain.Controls.Add(this.btn_CustomerCoupon);
            this.tabPage_CustomerMain.Controls.Add(this.btn_OrderRecord);
            this.tabPage_CustomerMain.Controls.Add(this.btn_ReviseData);
            this.tabPage_CustomerMain.Location = new System.Drawing.Point(4, 22);
            this.tabPage_CustomerMain.Name = "tabPage_CustomerMain";
            this.tabPage_CustomerMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_CustomerMain.Size = new System.Drawing.Size(792, 424);
            this.tabPage_CustomerMain.TabIndex = 0;
            this.tabPage_CustomerMain.Text = "會員主頁面";
            this.tabPage_CustomerMain.UseVisualStyleBackColor = true;
            // 
            // tabPage_Customer
            // 
            this.tabPage_Customer.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Customer.Name = "tabPage_Customer";
            this.tabPage_Customer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Customer.Size = new System.Drawing.Size(792, 424);
            this.tabPage_Customer.TabIndex = 1;
            this.tabPage_Customer.Text = "會員資料修改";
            this.tabPage_Customer.UseVisualStyleBackColor = true;
            // 
            // btn_ReviseData
            // 
            this.btn_ReviseData.Location = new System.Drawing.Point(25, 112);
            this.btn_ReviseData.Name = "btn_ReviseData";
            this.btn_ReviseData.Size = new System.Drawing.Size(75, 23);
            this.btn_ReviseData.TabIndex = 0;
            this.btn_ReviseData.Text = "資料修改";
            this.btn_ReviseData.UseVisualStyleBackColor = true;
            // 
            // btn_OrderRecord
            // 
            this.btn_OrderRecord.Location = new System.Drawing.Point(25, 150);
            this.btn_OrderRecord.Name = "btn_OrderRecord";
            this.btn_OrderRecord.Size = new System.Drawing.Size(75, 23);
            this.btn_OrderRecord.TabIndex = 1;
            this.btn_OrderRecord.Text = "訂單紀錄";
            this.btn_OrderRecord.UseVisualStyleBackColor = true;
            // 
            // btn_CustomerCoupon
            // 
            this.btn_CustomerCoupon.Location = new System.Drawing.Point(25, 191);
            this.btn_CustomerCoupon.Name = "btn_CustomerCoupon";
            this.btn_CustomerCoupon.Size = new System.Drawing.Size(75, 23);
            this.btn_CustomerCoupon.TabIndex = 2;
            this.btn_CustomerCoupon.Text = "優惠券";
            this.btn_CustomerCoupon.UseVisualStyleBackColor = true;
            // 
            // tabPage_CustomerOrderRecord
            // 
            this.tabPage_CustomerOrderRecord.Location = new System.Drawing.Point(4, 22);
            this.tabPage_CustomerOrderRecord.Name = "tabPage_CustomerOrderRecord";
            this.tabPage_CustomerOrderRecord.Size = new System.Drawing.Size(792, 424);
            this.tabPage_CustomerOrderRecord.TabIndex = 2;
            this.tabPage_CustomerOrderRecord.Text = "會員訂單紀錄";
            this.tabPage_CustomerOrderRecord.UseVisualStyleBackColor = true;
            // 
            // tabPage_CustomerCoupon
            // 
            this.tabPage_CustomerCoupon.Controls.Add(this.label_CustomerCouponQuantity);
            this.tabPage_CustomerCoupon.Controls.Add(this.label_CustomerCoupon);
            this.tabPage_CustomerCoupon.Controls.Add(this.label_CustomerCoupons);
            this.tabPage_CustomerCoupon.Controls.Add(this.label_CouponInfomation);
            this.tabPage_CustomerCoupon.Controls.Add(this.comboBox1);
            this.tabPage_CustomerCoupon.Controls.Add(this.label_CouponStatus);
            this.tabPage_CustomerCoupon.Location = new System.Drawing.Point(4, 22);
            this.tabPage_CustomerCoupon.Name = "tabPage_CustomerCoupon";
            this.tabPage_CustomerCoupon.Size = new System.Drawing.Size(792, 424);
            this.tabPage_CustomerCoupon.TabIndex = 3;
            this.tabPage_CustomerCoupon.Text = "會員優惠券";
            this.tabPage_CustomerCoupon.UseVisualStyleBackColor = true;
            // 
            // label_CouponStatus
            // 
            this.label_CouponStatus.AutoSize = true;
            this.label_CouponStatus.Location = new System.Drawing.Point(72, 101);
            this.label_CouponStatus.Name = "label_CouponStatus";
            this.label_CouponStatus.Size = new System.Drawing.Size(65, 12);
            this.label_CouponStatus.TabIndex = 0;
            this.label_CouponStatus.Text = "使用狀態：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "未使用",
            "已使用",
            "逾期"});
            this.comboBox1.Location = new System.Drawing.Point(137, 98);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // label_CouponInfomation
            // 
            this.label_CouponInfomation.Location = new System.Drawing.Point(517, 101);
            this.label_CouponInfomation.Name = "label_CouponInfomation";
            this.label_CouponInfomation.Size = new System.Drawing.Size(258, 94);
            this.label_CouponInfomation.TabIndex = 2;
            this.label_CouponInfomation.Text = "優惠券使用注意事項";
            // 
            // label_CustomerCoupons
            // 
            this.label_CustomerCoupons.Location = new System.Drawing.Point(73, 130);
            this.label_CustomerCoupons.Name = "label_CustomerCoupons";
            this.label_CustomerCoupons.Size = new System.Drawing.Size(422, 274);
            this.label_CustomerCoupons.TabIndex = 3;
            this.label_CustomerCoupons.Text = "依據上方combo box 顯示會員的優惠券應包含id、有效期限、內容等";
            // 
            // label_CustomerCoupon
            // 
            this.label_CustomerCoupon.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_CustomerCoupon.Location = new System.Drawing.Point(17, 21);
            this.label_CustomerCoupon.Name = "label_CustomerCoupon";
            this.label_CustomerCoupon.Size = new System.Drawing.Size(120, 40);
            this.label_CustomerCoupon.TabIndex = 4;
            this.label_CustomerCoupon.Text = "優惠券";
            // 
            // label_CustomerCouponQuantity
            // 
            this.label_CustomerCouponQuantity.Location = new System.Drawing.Point(299, 21);
            this.label_CustomerCouponQuantity.Name = "label_CustomerCouponQuantity";
            this.label_CustomerCouponQuantity.Size = new System.Drawing.Size(176, 23);
            this.label_CustomerCouponQuantity.TabIndex = 5;
            this.label_CustomerCouponQuantity.Text = "目前可用優惠券    張";
            // 
            // Frm_MemberPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl_CustomerReviseData);
            this.Name = "Frm_MemberPage";
            this.Text = "Frm_MemberPage";
            this.tabControl_CustomerReviseData.ResumeLayout(false);
            this.tabPage_CustomerMain.ResumeLayout(false);
            this.tabPage_CustomerCoupon.ResumeLayout(false);
            this.tabPage_CustomerCoupon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_CustomerReviseData;
        private System.Windows.Forms.TabPage tabPage_CustomerMain;
        private System.Windows.Forms.TabPage tabPage_Customer;
        private System.Windows.Forms.Button btn_ReviseData;
        private System.Windows.Forms.Button btn_CustomerCoupon;
        private System.Windows.Forms.Button btn_OrderRecord;
        private System.Windows.Forms.TabPage tabPage_CustomerOrderRecord;
        private System.Windows.Forms.TabPage tabPage_CustomerCoupon;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label_CouponStatus;
        private System.Windows.Forms.Label label_CouponInfomation;
        private System.Windows.Forms.Label label_CustomerCouponQuantity;
        private System.Windows.Forms.Label label_CustomerCoupon;
        private System.Windows.Forms.Label label_CustomerCoupons;
    }
}