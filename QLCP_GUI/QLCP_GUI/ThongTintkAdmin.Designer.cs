namespace QLCP_GUI
{
    partial class ThongTintkAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThongTintkAdmin));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblTenAdmin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUserAcount = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtMaAdmin = new System.Windows.Forms.TextBox();
            this.txtTenAdmin = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = true;
            this.btnExit.Location = new System.Drawing.Point(1284, 763);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(319, 123);
            this.btnExit.TabIndex = 28;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.ImageIndex = 1;
            this.btnUpdate.Location = new System.Drawing.Point(748, 763);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(319, 123);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "Đổi mật khẩu";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblTenAdmin
            // 
            this.lblTenAdmin.AutoSize = true;
            this.lblTenAdmin.Font = new System.Drawing.Font("MV Boli", 13.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenAdmin.Location = new System.Drawing.Point(725, 313);
            this.lblTenAdmin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenAdmin.Name = "lblTenAdmin";
            this.lblTenAdmin.Size = new System.Drawing.Size(282, 62);
            this.lblTenAdmin.TabIndex = 18;
            this.lblTenAdmin.Text = "Tên Admin:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MV Boli", 13.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(737, 213);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 62);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mã Admin:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(941, 87);
            this.label1.TabIndex = 16;
            this.label1.Text = "Thông Tin Tài Khoản Admin";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(121, 198);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(379, 389);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // lblUserAcount
            // 
            this.lblUserAcount.AutoSize = true;
            this.lblUserAcount.Font = new System.Drawing.Font("MV Boli", 13.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserAcount.Location = new System.Drawing.Point(649, 412);
            this.lblUserAcount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserAcount.Name = "lblUserAcount";
            this.lblUserAcount.Size = new System.Drawing.Size(358, 62);
            this.lblUserAcount.TabIndex = 29;
            this.lblUserAcount.Text = "Tên tài khoản:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("MV Boli", 13.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(725, 536);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(269, 62);
            this.lblPassword.TabIndex = 30;
            this.lblPassword.Text = "Mật khẩu:";
            // 
            // txtMaAdmin
            // 
            this.txtMaAdmin.Location = new System.Drawing.Point(1106, 219);
            this.txtMaAdmin.Multiline = true;
            this.txtMaAdmin.Name = "txtMaAdmin";
            this.txtMaAdmin.Size = new System.Drawing.Size(527, 56);
            this.txtMaAdmin.TabIndex = 31;
            // 
            // txtTenAdmin
            // 
            this.txtTenAdmin.Location = new System.Drawing.Point(1106, 319);
            this.txtTenAdmin.Multiline = true;
            this.txtTenAdmin.Name = "txtTenAdmin";
            this.txtTenAdmin.Size = new System.Drawing.Size(527, 56);
            this.txtTenAdmin.TabIndex = 32;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(1106, 418);
            this.txtUserName.Multiline = true;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(527, 56);
            this.txtUserName.TabIndex = 33;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(1106, 531);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(527, 56);
            this.txtPassword.TabIndex = 34;
            // 
            // ThongTintkAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(2270, 1207);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtTenAdmin);
            this.Controls.Add(this.txtMaAdmin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserAcount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblTenAdmin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ThongTintkAdmin";
            this.Text = "Thông tin tài khoản Admin";
            this.Load += new System.EventHandler(this.ThongTintkAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblTenAdmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUserAcount;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtMaAdmin;
        private System.Windows.Forms.TextBox txtTenAdmin;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
    }
}