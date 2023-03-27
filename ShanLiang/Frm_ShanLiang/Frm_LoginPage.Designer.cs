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
            this.linkLab_losePassword = new System.Windows.Forms.LinkLabel();
            this.linkLab_signin = new System.Windows.Forms.LinkLabel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_accountName
            // 
            this.txt_accountName.Location = new System.Drawing.Point(358, 138);
            this.txt_accountName.Name = "txt_accountName";
            this.txt_accountName.Size = new System.Drawing.Size(250, 22);
            this.txt_accountName.TabIndex = 0;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(358, 266);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(250, 47);
            this.btn_login.TabIndex = 1;
            this.btn_login.Text = "登入";
            this.btn_login.UseVisualStyleBackColor = true;
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(358, 188);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(250, 22);
            this.txt_password.TabIndex = 0;
            // 
            // linkLab_losePassword
            // 
            this.linkLab_losePassword.AutoSize = true;
            this.linkLab_losePassword.Location = new System.Drawing.Point(356, 245);
            this.linkLab_losePassword.Name = "linkLab_losePassword";
            this.linkLab_losePassword.Size = new System.Drawing.Size(58, 12);
            this.linkLab_losePassword.TabIndex = 2;
            this.linkLab_losePassword.TabStop = true;
            this.linkLab_losePassword.Text = "忘記密碼?";
            // 
            // linkLab_signin
            // 
            this.linkLab_signin.AutoSize = true;
            this.linkLab_signin.Location = new System.Drawing.Point(552, 245);
            this.linkLab_signin.Name = "linkLab_signin";
            this.linkLab_signin.Size = new System.Drawing.Size(53, 12);
            this.linkLab_signin.TabIndex = 2;
            this.linkLab_signin.TabStop = true;
            this.linkLab_signin.Text = "註冊會員";
            this.linkLab_signin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLab_signin_LinkClicked);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(358, 223);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "保持登入狀態";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(322, 420);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(521, 319);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(87, 31);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Frm_LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.linkLab_signin);
            this.Controls.Add(this.linkLab_losePassword);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_accountName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_LoginPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm_LoginPage";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_accountName;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.LinkLabel linkLab_losePassword;
        private System.Windows.Forms.LinkLabel linkLab_signin;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_cancel;
    }
}