namespace Frm_ShanLiang
{
    partial class Frm_AccountPage
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
            this.DataGridViewAccount = new System.Windows.Forms.DataGridView();
            this.btn_loadaccount = new System.Windows.Forms.Button();
            this.DataGridViewIdentification = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_orderby = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewIdentification)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewAccount
            // 
            this.DataGridViewAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewAccount.Location = new System.Drawing.Point(274, 36);
            this.DataGridViewAccount.Name = "DataGridViewAccount";
            this.DataGridViewAccount.RowTemplate.Height = 24;
            this.DataGridViewAccount.Size = new System.Drawing.Size(475, 586);
            this.DataGridViewAccount.TabIndex = 0;
            // 
            // btn_loadaccount
            // 
            this.btn_loadaccount.Location = new System.Drawing.Point(10, 156);
            this.btn_loadaccount.Name = "btn_loadaccount";
            this.btn_loadaccount.Size = new System.Drawing.Size(247, 46);
            this.btn_loadaccount.TabIndex = 1;
            this.btn_loadaccount.Text = "LoadAccountTable";
            this.btn_loadaccount.UseVisualStyleBackColor = true;
            this.btn_loadaccount.Click += new System.EventHandler(this.btn_loadaccount_Click);
            // 
            // DataGridViewIdentification
            // 
            this.DataGridViewIdentification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewIdentification.Location = new System.Drawing.Point(10, 36);
            this.DataGridViewIdentification.Name = "DataGridViewIdentification";
            this.DataGridViewIdentification.RowTemplate.Height = 24;
            this.DataGridViewIdentification.Size = new System.Drawing.Size(247, 114);
            this.DataGridViewIdentification.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Identification帳號權限";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(274, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Account帳號列表";
            // 
            // btn_orderby
            // 
            this.btn_orderby.Location = new System.Drawing.Point(10, 208);
            this.btn_orderby.Name = "btn_orderby";
            this.btn_orderby.Size = new System.Drawing.Size(247, 46);
            this.btn_orderby.TabIndex = 1;
            this.btn_orderby.Text = "依照帳號類別排序";
            this.btn_orderby.UseVisualStyleBackColor = true;
            this.btn_orderby.Click += new System.EventHandler(this.btn_orderby_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 367);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(247, 46);
            this.button2.TabIndex = 1;
            this.button2.Text = "刪除";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(10, 260);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(247, 46);
            this.btn_update.TabIndex = 1;
            this.btn_update.Text = "修改";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(10, 312);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(247, 46);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = "新增";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // Frm_AccountPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 634);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataGridViewIdentification);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_orderby);
            this.Controls.Add(this.btn_loadaccount);
            this.Controls.Add(this.DataGridViewAccount);
            this.Name = "Frm_AccountPage";
            this.Text = "Frm_AccountPage帳號管理系統";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewIdentification)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewAccount;
        private System.Windows.Forms.Button btn_loadaccount;
        private System.Windows.Forms.DataGridView DataGridViewIdentification;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_orderby;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_add;
    }
}