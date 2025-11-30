namespace ShoeShop
{
    partial class FormDangNhap
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelLeft = new Panel();
            pictureBox1 = new PictureBox();
            lblSubtitle = new Label();
            lblWelcome = new Label();
            panelRight = new Panel();
            panelLogin = new Panel();
            lblForgot = new Label();
            btnLogin = new Button();
            chkRemember = new CheckBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            lblTitle = new Label();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelRight.SuspendLayout();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.DodgerBlue;
            panelLeft.Controls.Add(pictureBox1);
            panelLeft.Controls.Add(lblSubtitle);
            panelLeft.Controls.Add(lblWelcome);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Margin = new Padding(4, 5, 4, 5);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(571, 1000);
            panelLeft.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.caabb9ab58e9b530b0bd26544a17f114_removebg_preview;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(93, 451);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(365, 358);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 12F);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(93, 400);
            lblSubtitle.Margin = new Padding(4, 0, 4, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(365, 32);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Hệ Thống Quản Lý Bán Giày Dép";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(86, 300);
            lblWelcome.Margin = new Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(343, 74);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "SHOE SHOP";
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.White;
            panelRight.Controls.Add(panelLogin);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(571, 0);
            panelRight.Margin = new Padding(4, 5, 4, 5);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(715, 1000);
            panelRight.TabIndex = 1;
            // 
            // panelLogin
            // 
            panelLogin.Controls.Add(lblForgot);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(chkRemember);
            panelLogin.Controls.Add(txtPassword);
            panelLogin.Controls.Add(lblPassword);
            panelLogin.Controls.Add(txtUsername);
            panelLogin.Controls.Add(lblUsername);
            panelLogin.Controls.Add(lblTitle);
            panelLogin.Location = new Point(71, 167);
            panelLogin.Margin = new Padding(4, 5, 4, 5);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(571, 667);
            panelLogin.TabIndex = 0;
            // 
            // lblForgot
            // 
            lblForgot.AutoSize = true;
            lblForgot.Cursor = Cursors.Hand;
            lblForgot.Font = new Font("Segoe UI", 9F);
            lblForgot.ForeColor = Color.FromArgb(59, 130, 246);
            lblForgot.Location = new Point(200, 617);
            lblForgot.Margin = new Padding(4, 0, 4, 0);
            lblForgot.Name = "lblForgot";
            lblForgot.Size = new Size(142, 25);
            lblForgot.TabIndex = 7;
            lblForgot.Text = "Quên mật khẩu?";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(59, 130, 246);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(43, 517);
            btnLogin.Margin = new Padding(4, 5, 4, 5);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(486, 75);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // chkRemember
            // 
            chkRemember.AutoSize = true;
            chkRemember.Font = new Font("Segoe UI", 9F);
            chkRemember.ForeColor = Color.FromArgb(107, 114, 128);
            chkRemember.Location = new Point(43, 450);
            chkRemember.Margin = new Padding(4, 5, 4, 5);
            chkRemember.Name = "chkRemember";
            chkRemember.Size = new Size(191, 29);
            chkRemember.TabIndex = 5;
            chkRemember.Text = "Ghi nhớ đăng nhập";
            chkRemember.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(43, 367);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(484, 39);
            txtPassword.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(55, 65, 81);
            lblPassword.Location = new Point(43, 317);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(104, 28);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Mật Khẩu";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(43, 233);
            txtUsername.Margin = new Padding(4, 5, 4, 5);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(484, 39);
            txtUsername.TabIndex = 2;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(55, 65, 81);
            lblUsername.Location = new Point(43, 183);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(158, 28);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Tên Đăng Nhập";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(31, 41, 55);
            lblTitle.Location = new Point(114, 50);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(320, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG NHẬP";
            // 
            // FormDangNhap
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1286, 1000);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "FormDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập - Shoe Shop";
            Load += FormDangNhap_Load;
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelRight.ResumeLayout(false);
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Label lblForgot;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblTitle;
    }
}