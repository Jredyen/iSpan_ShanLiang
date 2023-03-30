namespace ShanLiang
{
    partial class Frm_Homepage
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Homepage));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lab_user = new System.Windows.Forms.Label();
            this.cmb_area = new System.Windows.Forms.ComboBox();
            this.cmb_restaurantType = new System.Windows.Forms.ComboBox();
            this.cmb_City = new System.Windows.Forms.ComboBox();
            this.txt_keyword = new System.Windows.Forms.TextBox();
            this.btn_signin = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.timer_ADchange = new System.Windows.Forms.Timer(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btn_signOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lab_user);
            this.splitContainer1.Panel1.Controls.Add(this.cmb_area);
            this.splitContainer1.Panel1.Controls.Add(this.cmb_restaurantType);
            this.splitContainer1.Panel1.Controls.Add(this.cmb_City);
            this.splitContainer1.Panel1.Controls.Add(this.txt_keyword);
            this.splitContainer1.Panel1.Controls.Add(this.btn_signOut);
            this.splitContainer1.Panel1.Controls.Add(this.btn_signin);
            this.splitContainer1.Panel1.Controls.Add(this.btn_search);
            this.splitContainer1.Panel1.Controls.Add(this.btn_login);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(1210, 709);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.TabIndex = 0;
            // 
            // lab_user
            // 
            this.lab_user.AutoSize = true;
            this.lab_user.Location = new System.Drawing.Point(1036, 44);
            this.lab_user.Name = "lab_user";
            this.lab_user.Size = new System.Drawing.Size(60, 12);
            this.lab_user.TabIndex = 6;
            this.lab_user.Text = "訪客 您好!";
            // 
            // cmb_area
            // 
            this.cmb_area.FormattingEnabled = true;
            this.cmb_area.Location = new System.Drawing.Point(215, 9);
            this.cmb_area.Name = "cmb_area";
            this.cmb_area.Size = new System.Drawing.Size(121, 20);
            this.cmb_area.TabIndex = 5;
            this.cmb_area.SelectedIndexChanged += new System.EventHandler(this.cmb_area_SelectedIndexChanged);
            // 
            // cmb_restaurantType
            // 
            this.cmb_restaurantType.FormattingEnabled = true;
            this.cmb_restaurantType.Location = new System.Drawing.Point(340, 9);
            this.cmb_restaurantType.Name = "cmb_restaurantType";
            this.cmb_restaurantType.Size = new System.Drawing.Size(121, 20);
            this.cmb_restaurantType.TabIndex = 4;
            this.cmb_restaurantType.SelectedIndexChanged += new System.EventHandler(this.cmb_restaurantType_SelectedIndexChanged);
            // 
            // cmb_City
            // 
            this.cmb_City.FormattingEnabled = true;
            this.cmb_City.Location = new System.Drawing.Point(88, 9);
            this.cmb_City.Name = "cmb_City";
            this.cmb_City.Size = new System.Drawing.Size(121, 20);
            this.cmb_City.TabIndex = 3;
            this.cmb_City.SelectedIndexChanged += new System.EventHandler(this.cmb_City_SelectedIndexChanged);
            // 
            // txt_keyword
            // 
            this.txt_keyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_keyword.Location = new System.Drawing.Point(476, 9);
            this.txt_keyword.Name = "txt_keyword";
            this.txt_keyword.Size = new System.Drawing.Size(457, 22);
            this.txt_keyword.TabIndex = 1;
            this.txt_keyword.TextChanged += new System.EventHandler(this.txt_keyword_TextChanged);
            // 
            // btn_signin
            // 
            this.btn_signin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_signin.Location = new System.Drawing.Point(1114, 9);
            this.btn_signin.Name = "btn_signin";
            this.btn_signin.Size = new System.Drawing.Size(75, 23);
            this.btn_signin.TabIndex = 0;
            this.btn_signin.Text = "註冊";
            this.btn_signin.UseVisualStyleBackColor = true;
            this.btn_signin.Click += new System.EventHandler(this.btn_signin_Click);
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search.AutoSize = true;
            this.btn_search.BackColor = System.Drawing.SystemColors.Window;
            this.btn_search.Image = global::Frm_ShanLiang.Properties.Resources._352091_search_icon;
            this.btn_search.Location = new System.Drawing.Point(939, 5);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(30, 30);
            this.btn_search.TabIndex = 0;
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_login
            // 
            this.btn_login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_login.Location = new System.Drawing.Point(1033, 9);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 0;
            this.btn_login.Text = "登入";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1210, 605);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1202, 579);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "首頁";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.ErrorImage")));
            this.pictureBox2.Location = new System.Drawing.Point(612, 266);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(582, 295);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 266);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(603, 295);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1191, 260);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1202, 579);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "最熱門店家";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1202, 579);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "最近的店家";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "最新優惠";
            // 
            // timer_ADchange
            // 
            this.timer_ADchange.Tick += new System.EventHandler(this.timer_ADchange_Tick);
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // btn_signOut
            // 
            this.btn_signOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_signOut.Location = new System.Drawing.Point(1114, 38);
            this.btn_signOut.Name = "btn_signOut";
            this.btn_signOut.Size = new System.Drawing.Size(75, 23);
            this.btn_signOut.TabIndex = 0;
            this.btn_signOut.Text = "登出";
            this.btn_signOut.UseVisualStyleBackColor = true;
            this.btn_signOut.Visible = false;
            this.btn_signOut.Click += new System.EventHandler(this.btn_signin_Click);
            // 
            // Frm_Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 709);
            this.Controls.Add(this.splitContainer1);
            this.IsMdiContainer = true;
            this.Name = "Frm_Homepage";
            this.Text = "ShanLiang - Home";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txt_keyword;
        private System.Windows.Forms.Button btn_signin;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer_ADchange;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmb_City;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cmb_restaurantType;
        private System.Windows.Forms.ComboBox cmb_area;
        private System.Windows.Forms.Label lab_user;
        private System.Windows.Forms.Button btn_signOut;
    }
}

