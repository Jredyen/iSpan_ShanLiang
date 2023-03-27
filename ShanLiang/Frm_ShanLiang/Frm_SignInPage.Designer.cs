namespace Frm_ShanLiang
{
    partial class Frm_SignInPage
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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_signin = new System.Windows.Forms.Button();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_account = new System.Windows.Forms.TextBox();
            this.txt_doubleCheckPassword = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lab_account = new System.Windows.Forms.Label();
            this.lab_password = new System.Windows.Forms.Label();
            this.lab_doubleCheckPassword = new System.Windows.Forms.Label();
            this.lab_name = new System.Windows.Forms.Label();
            this.lab_phone = new System.Windows.Forms.Label();
            this.lab_email = new System.Windows.Forms.Label();
            this.lab_address = new System.Windows.Forms.Label();
            this.lab_date = new System.Windows.Forms.Label();
            this.linkToStoreSignIn = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(314, 428);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(87, 31);
            this.btn_cancel.TabIndex = 9;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_signin
            // 
            this.btn_signin.Location = new System.Drawing.Point(151, 375);
            this.btn_signin.Name = "btn_signin";
            this.btn_signin.Size = new System.Drawing.Size(250, 47);
            this.btn_signin.TabIndex = 8;
            this.btn_signin.Text = "註冊";
            this.btn_signin.UseVisualStyleBackColor = true;
            this.btn_signin.Click += new System.EventHandler(this.btn_signin_Click);
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(151, 109);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(250, 22);
            this.txt_password.TabIndex = 1;
            this.txt_password.TextChanged += new System.EventHandler(this.txt_inputCheck);
            // 
            // txt_account
            // 
            this.txt_account.Location = new System.Drawing.Point(151, 75);
            this.txt_account.Name = "txt_account";
            this.txt_account.Size = new System.Drawing.Size(250, 22);
            this.txt_account.TabIndex = 0;
            this.txt_account.TextChanged += new System.EventHandler(this.txt_inputCheck);
            // 
            // txt_doubleCheckPassword
            // 
            this.txt_doubleCheckPassword.Location = new System.Drawing.Point(151, 143);
            this.txt_doubleCheckPassword.Name = "txt_doubleCheckPassword";
            this.txt_doubleCheckPassword.Size = new System.Drawing.Size(250, 22);
            this.txt_doubleCheckPassword.TabIndex = 2;
            this.txt_doubleCheckPassword.TextChanged += new System.EventHandler(this.txt_inputCheck);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(151, 177);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(250, 22);
            this.txt_name.TabIndex = 3;
            this.txt_name.TextChanged += new System.EventHandler(this.txt_inputCheck);
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(151, 245);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(250, 22);
            this.txt_email.TabIndex = 5;
            this.txt_email.TextChanged += new System.EventHandler(this.txt_inputCheck);
            // 
            // txt_address
            // 
            this.txt_address.Location = new System.Drawing.Point(151, 279);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(250, 22);
            this.txt_address.TabIndex = 6;
            this.txt_address.TextChanged += new System.EventHandler(this.txt_inputCheck);
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(151, 211);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(250, 22);
            this.txt_phone.TabIndex = 4;
            this.txt_phone.TextChanged += new System.EventHandler(this.txt_inputCheck);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(151, 332);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(250, 22);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // lab_account
            // 
            this.lab_account.AutoSize = true;
            this.lab_account.Location = new System.Drawing.Point(406, 97);
            this.lab_account.Name = "lab_account";
            this.lab_account.Size = new System.Drawing.Size(0, 12);
            this.lab_account.TabIndex = 10;
            // 
            // lab_password
            // 
            this.lab_password.AutoSize = true;
            this.lab_password.Location = new System.Drawing.Point(406, 131);
            this.lab_password.Name = "lab_password";
            this.lab_password.Size = new System.Drawing.Size(0, 12);
            this.lab_password.TabIndex = 10;
            // 
            // lab_doubleCheckPassword
            // 
            this.lab_doubleCheckPassword.AutoSize = true;
            this.lab_doubleCheckPassword.Location = new System.Drawing.Point(406, 165);
            this.lab_doubleCheckPassword.Name = "lab_doubleCheckPassword";
            this.lab_doubleCheckPassword.Size = new System.Drawing.Size(0, 12);
            this.lab_doubleCheckPassword.TabIndex = 10;
            // 
            // lab_name
            // 
            this.lab_name.AutoSize = true;
            this.lab_name.Location = new System.Drawing.Point(406, 199);
            this.lab_name.Name = "lab_name";
            this.lab_name.Size = new System.Drawing.Size(0, 12);
            this.lab_name.TabIndex = 10;
            // 
            // lab_phone
            // 
            this.lab_phone.AutoSize = true;
            this.lab_phone.Location = new System.Drawing.Point(406, 233);
            this.lab_phone.Name = "lab_phone";
            this.lab_phone.Size = new System.Drawing.Size(0, 12);
            this.lab_phone.TabIndex = 10;
            // 
            // lab_email
            // 
            this.lab_email.AutoSize = true;
            this.lab_email.Location = new System.Drawing.Point(406, 267);
            this.lab_email.Name = "lab_email";
            this.lab_email.Size = new System.Drawing.Size(0, 12);
            this.lab_email.TabIndex = 10;
            // 
            // lab_address
            // 
            this.lab_address.AutoSize = true;
            this.lab_address.Location = new System.Drawing.Point(406, 301);
            this.lab_address.Name = "lab_address";
            this.lab_address.Size = new System.Drawing.Size(0, 12);
            this.lab_address.TabIndex = 10;
            // 
            // lab_date
            // 
            this.lab_date.AutoSize = true;
            this.lab_date.Location = new System.Drawing.Point(406, 345);
            this.lab_date.Name = "lab_date";
            this.lab_date.Size = new System.Drawing.Size(0, 12);
            this.lab_date.TabIndex = 10;
            // 
            // linkToStoreSignIn
            // 
            this.linkToStoreSignIn.AutoSize = true;
            this.linkToStoreSignIn.Location = new System.Drawing.Point(149, 437);
            this.linkToStoreSignIn.Name = "linkToStoreSignIn";
            this.linkToStoreSignIn.Size = new System.Drawing.Size(58, 12);
            this.linkToStoreSignIn.TabIndex = 11;
            this.linkToStoreSignIn.TabStop = true;
            this.linkToStoreSignIn.Text = "是商家嗎?";
            this.linkToStoreSignIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkToStoreSignIn_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "生日";
            // 
            // Frm_SignInPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 578);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkToStoreSignIn);
            this.Controls.Add(this.lab_date);
            this.Controls.Add(this.lab_address);
            this.Controls.Add(this.lab_email);
            this.Controls.Add(this.lab_phone);
            this.Controls.Add(this.lab_name);
            this.Controls.Add(this.lab_doubleCheckPassword);
            this.Controls.Add(this.lab_password);
            this.Controls.Add(this.lab_account);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_signin);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.txt_doubleCheckPassword);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_account);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_SignInPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm_SignInPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_signin;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_account;
        private System.Windows.Forms.TextBox txt_doubleCheckPassword;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lab_account;
        private System.Windows.Forms.Label lab_password;
        private System.Windows.Forms.Label lab_doubleCheckPassword;
        private System.Windows.Forms.Label lab_name;
        private System.Windows.Forms.Label lab_phone;
        private System.Windows.Forms.Label lab_email;
        private System.Windows.Forms.Label lab_address;
        private System.Windows.Forms.Label lab_date;
        private System.Windows.Forms.LinkLabel linkToStoreSignIn;
        private System.Windows.Forms.Label label1;
    }
}