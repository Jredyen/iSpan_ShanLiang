namespace Frm_ShanLiang
{
    partial class Frm_LoginPage
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
            this.txt_accountName = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.linkLab_signin = new System.Windows.Forms.LinkLabel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Demo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_storeDemo = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.linkLab_Storesignin = new System.Windows.Forms.LinkLabel();
            this.btn_AdminDemo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_accountName
            // 
            this.txt_accountName.Location = new System.Drawing.Point(29, 43);
            this.txt_accountName.Name = "txt_accountName";
            this.txt_accountName.Size = new System.Drawing.Size(250, 22);
            this.txt_accountName.TabIndex = 0;
            // 
            // btn_login
            // 
            this.btn_login.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_login.Location = new System.Drawing.Point(29, 250);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(250, 47);
            this.btn_login.TabIndex = 1;
            this.btn_login.Text = "登入";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(29, 109);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(250, 22);
            this.txt_password.TabIndex = 0;
            // 
            // linkLab_signin
            // 
            this.linkLab_signin.AutoSize = true;
            this.linkLab_signin.DisabledLinkColor = System.Drawing.Color.Yellow;
            this.linkLab_signin.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.linkLab_signin.LinkColor = System.Drawing.Color.Yellow;
            this.linkLab_signin.Location = new System.Drawing.Point(197, 382);
            this.linkLab_signin.Name = "linkLab_signin";
            this.linkLab_signin.Size = new System.Drawing.Size(73, 20);
            this.linkLab_signin.TabIndex = 2;
            this.linkLab_signin.TabStop = true;
            this.linkLab_signin.Text = "會員註冊";
            this.linkLab_signin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLab_signin_LinkClicked);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_cancel.Location = new System.Drawing.Point(189, 303);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(87, 31);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(29, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "帳號";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(29, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "密碼";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Frm_ShanLiang.Properties.Resources.登入畫面;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(319, 446);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Demo
            // 
            this.btn_Demo.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Demo.Location = new System.Drawing.Point(29, 303);
            this.btn_Demo.Name = "btn_Demo";
            this.btn_Demo.Size = new System.Drawing.Size(86, 22);
            this.btn_Demo.TabIndex = 6;
            this.btn_Demo.Text = "會員Demo";
            this.btn_Demo.UseVisualStyleBackColor = true;
            this.btn_Demo.Click += new System.EventHandler(this.btn_Demo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(29, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "還沒有帳號嗎?";
            // 
            // btn_storeDemo
            // 
            this.btn_storeDemo.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_storeDemo.Location = new System.Drawing.Point(29, 331);
            this.btn_storeDemo.Name = "btn_storeDemo";
            this.btn_storeDemo.Size = new System.Drawing.Size(86, 22);
            this.btn_storeDemo.TabIndex = 6;
            this.btn_storeDemo.Text = "店家Demo";
            this.btn_storeDemo.UseVisualStyleBackColor = true;
            this.btn_storeDemo.Click += new System.EventHandler(this.btn_storeDemo_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.txt_accountName);
            this.splitContainer1.Panel2.Controls.Add(this.btn_AdminDemo);
            this.splitContainer1.Panel2.Controls.Add(this.btn_storeDemo);
            this.splitContainer1.Panel2.Controls.Add(this.txt_password);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Demo);
            this.splitContainer1.Panel2.Controls.Add(this.btn_login);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.btn_cancel);
            this.splitContainer1.Panel2.Controls.Add(this.linkLab_Storesignin);
            this.splitContainer1.Panel2.Controls.Add(this.linkLab_signin);
            this.splitContainer1.Size = new System.Drawing.Size(632, 450);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.TabIndex = 8;
            // 
            // linkLab_Storesignin
            // 
            this.linkLab_Storesignin.AutoSize = true;
            this.linkLab_Storesignin.DisabledLinkColor = System.Drawing.Color.Yellow;
            this.linkLab_Storesignin.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.linkLab_Storesignin.LinkColor = System.Drawing.Color.Yellow;
            this.linkLab_Storesignin.Location = new System.Drawing.Point(197, 412);
            this.linkLab_Storesignin.Name = "linkLab_Storesignin";
            this.linkLab_Storesignin.Size = new System.Drawing.Size(73, 20);
            this.linkLab_Storesignin.TabIndex = 2;
            this.linkLab_Storesignin.TabStop = true;
            this.linkLab_Storesignin.Text = "店家註冊";
            this.linkLab_Storesignin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLab_Storesignin_LinkClicked);
            // 
            // btn_AdminDemo
            // 
            this.btn_AdminDemo.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_AdminDemo.Location = new System.Drawing.Point(29, 357);
            this.btn_AdminDemo.Name = "btn_AdminDemo";
            this.btn_AdminDemo.Size = new System.Drawing.Size(86, 22);
            this.btn_AdminDemo.TabIndex = 6;
            this.btn_AdminDemo.Text = "後台Demo";
            this.btn_AdminDemo.UseVisualStyleBackColor = true;
            this.btn_AdminDemo.Click += new System.EventHandler(this.btn_AdminDemo_Click);
            // 
            // Frm_LoginPage
            // 
            this.AcceptButton = this.btn_login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(632, 450);
            this.Controls.Add(this.splitContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "Frm_LoginPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_LoginPage";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_accountName;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.LinkLabel linkLab_signin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Demo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_storeDemo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.LinkLabel linkLab_Storesignin;
        private System.Windows.Forms.Button btn_AdminDemo;
    }
}