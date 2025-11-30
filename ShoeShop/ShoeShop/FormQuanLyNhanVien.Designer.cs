namespace ShoeShop
{
    partial class FormQuanLyNhanVien
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

        private void InitializeComponent()
        {
            panelTop = new Panel();
            lblTitle = new Label();
            panelSearch = new Panel();
            btnLamMoi = new Button();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            panelInput = new Panel();
            txtMatKhau = new TextBox();
            label8 = new Label();
            txtTenDangNhap = new TextBox();
            label7 = new Label();
            cboChucVu = new ComboBox();
            label6 = new Label();
            txtEmail = new TextBox();
            label5 = new Label();
            txtSDT = new TextBox();
            label4 = new Label();
            txtDiaChi = new TextBox();
            label3 = new Label();
            txtHoTen = new TextBox();
            label2 = new Label();
            txtMaNV = new TextBox();
            label1 = new Label();
            panelButtons = new Panel();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            dgvNhanVien = new DataGridView();
            panelTop.SuspendLayout();
            panelSearch.SuspendLayout();
            panelInput.SuspendLayout();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(230, 126, 34);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 5, 4, 5);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1714, 100);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(29, 25);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(385, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.Controls.Add(btnLamMoi);
            panelSearch.Controls.Add(btnTimKiem);
            panelSearch.Controls.Add(txtTimKiem);
            panelSearch.Controls.Add(lblTimKiem);
            panelSearch.Location = new Point(29, 133);
            panelSearch.Margin = new Padding(4, 5, 4, 5);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1657, 100);
            panelSearch.TabIndex = 1;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(149, 165, 166);
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10F);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(914, 25);
            btnLamMoi.Margin = new Padding(4, 5, 4, 5);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(143, 50);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(230, 126, 34);
            btnTimKiem.Cursor = Cursors.Hand;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 10F);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(743, 25);
            btnTimKiem.Margin = new Padding(4, 5, 4, 5);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(143, 50);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "🔍 Tìm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.Location = new Point(143, 28);
            txtTimKiem.Margin = new Padding(4, 5, 4, 5);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên, SĐT, email hoặc chức vụ...";
            txtTimKiem.Size = new Size(570, 34);
            txtTimKiem.TabIndex = 1;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI", 10F);
            lblTimKiem.Location = new Point(29, 33);
            lblTimKiem.Margin = new Padding(4, 0, 4, 0);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(95, 28);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Tìm kiếm:";
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.White;
            panelInput.Controls.Add(txtMatKhau);
            panelInput.Controls.Add(label8);
            panelInput.Controls.Add(txtTenDangNhap);
            panelInput.Controls.Add(label7);
            panelInput.Controls.Add(cboChucVu);
            panelInput.Controls.Add(label6);
            panelInput.Controls.Add(txtEmail);
            panelInput.Controls.Add(label5);
            panelInput.Controls.Add(txtSDT);
            panelInput.Controls.Add(label4);
            panelInput.Controls.Add(txtDiaChi);
            panelInput.Controls.Add(label3);
            panelInput.Controls.Add(txtHoTen);
            panelInput.Controls.Add(label2);
            panelInput.Controls.Add(txtMaNV);
            panelInput.Controls.Add(label1);
            panelInput.Location = new Point(29, 267);
            panelInput.Margin = new Padding(4, 5, 4, 5);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(1657, 233);
            panelInput.TabIndex = 2;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 10F);
            txtMatKhau.Location = new Point(1329, 87);
            txtMatKhau.Margin = new Padding(4, 5, 4, 5);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '●';
            txtMatKhau.Size = new Size(284, 34);
            txtMatKhau.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(1171, 92);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(98, 28);
            label8.TabIndex = 14;
            label8.Text = "Mật khẩu:";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Font = new Font("Segoe UI", 10F);
            txtTenDangNhap.Location = new Point(1329, 28);
            txtTenDangNhap.Margin = new Padding(4, 5, 4, 5);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(284, 34);
            txtTenDangNhap.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(1171, 33);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(144, 28);
            label7.TabIndex = 12;
            label7.Text = "Tên đăng nhập:";
            // 
            // cboChucVu
            // 
            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucVu.Font = new Font("Segoe UI", 10F);
            cboChucVu.FormattingEnabled = true;
            cboChucVu.Items.AddRange(new object[] { "Bán hàng", "Kho", "Quản lý" });
            cboChucVu.Location = new Point(757, 145);
            cboChucVu.Margin = new Padding(4, 5, 4, 5);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(284, 36);
            cboChucVu.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(600, 150);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(86, 28);
            label6.TabIndex = 10;
            label6.Text = "Chức vụ:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(757, 87);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(355, 34);
            txtEmail.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(600, 92);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(63, 28);
            label5.TabIndex = 8;
            label5.Text = "Email:";
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Segoe UI", 10F);
            txtSDT.Location = new Point(757, 28);
            txtSDT.Margin = new Padding(4, 5, 4, 5);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(284, 34);
            txtSDT.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(600, 33);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(132, 28);
            label4.TabIndex = 6;
            label4.Text = "Số điện thoại:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 10F);
            txtDiaChi.Location = new Point(171, 145);
            txtDiaChi.Margin = new Padding(4, 5, 4, 5);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(355, 34);
            txtDiaChi.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(29, 150);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(75, 28);
            label3.TabIndex = 4;
            label3.Text = "Địa chỉ:";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 10F);
            txtHoTen.Location = new Point(171, 87);
            txtHoTen.Margin = new Padding(4, 5, 4, 5);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(355, 34);
            txtHoTen.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(29, 92);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(75, 28);
            label2.TabIndex = 2;
            label2.Text = "Họ tên:";
            // 
            // txtMaNV
            // 
            txtMaNV.BackColor = Color.FromArgb(236, 240, 241);
            txtMaNV.Font = new Font("Segoe UI", 10F);
            txtMaNV.Location = new Point(171, 28);
            txtMaNV.Margin = new Padding(4, 5, 4, 5);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(213, 34);
            txtMaNV.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(29, 33);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(76, 28);
            label1.TabIndex = 0;
            label1.Text = "Mã NV:";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnXoa);
            panelButtons.Controls.Add(btnSua);
            panelButtons.Controls.Add(btnThem);
            panelButtons.Location = new Point(29, 533);
            panelButtons.Margin = new Padding(4, 5, 4, 5);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1657, 100);
            panelButtons.TabIndex = 3;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(900, 17);
            btnXoa.Margin = new Padding(4, 5, 4, 5);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(171, 67);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(52, 152, 219);
            btnSua.Cursor = Cursors.Hand;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(700, 17);
            btnSua.Margin = new Padding(4, 5, 4, 5);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(171, 67);
            btnSua.TabIndex = 1;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(46, 204, 113);
            btnThem.Cursor = Cursors.Hand;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(500, 17);
            btnThem.Margin = new Padding(4, 5, 4, 5);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(171, 67);
            btnThem.TabIndex = 0;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Location = new Point(29, 667);
            dgvNhanVien.Margin = new Padding(4, 5, 4, 5);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 62;
            dgvNhanVien.RowTemplate.Height = 30;
            dgvNhanVien.Size = new Size(1657, 467);
            dgvNhanVien.TabIndex = 4;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            // 
            // FormQuanLyNhanVien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1714, 1167);
            Controls.Add(dgvNhanVien);
            Controls.Add(panelButtons);
            Controls.Add(panelInput);
            Controls.Add(panelSearch);
            Controls.Add(panelTop);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormQuanLyNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Nhân viên";
            Load += FormQuanLyNhanVien_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvNhanVien;
    }
}
