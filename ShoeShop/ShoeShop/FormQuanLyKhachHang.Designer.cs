namespace ShoeShop
{
    partial class FormQuanLyKhachHang
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
            btnExportXML = new Button();
            btnImportXML = new Button();
            btnLamMoi = new Button();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            panelInput = new Panel();
            txtMatKhau = new TextBox();
            label7 = new Label();
            txtTenDangNhap = new TextBox();
            label6 = new Label();
            txtEmail = new TextBox();
            label5 = new Label();
            txtSDT = new TextBox();
            label4 = new Label();
            txtDiaChi = new TextBox();
            label3 = new Label();
            txtHoTen = new TextBox();
            label2 = new Label();
            txtMaKH = new TextBox();
            label1 = new Label();
            panelButtons = new Panel();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            dgvKhachHang = new DataGridView();
            panelTop.SuspendLayout();
            panelSearch.SuspendLayout();
            panelInput.SuspendLayout();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(41, 128, 185);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 5, 4, 5);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1743, 117);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(29, 33);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(511, 47);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ KHÁCH HÀNG";
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(btnExportXML);
            panelSearch.Controls.Add(btnImportXML);
            panelSearch.Controls.Add(btnLamMoi);
            panelSearch.Controls.Add(btnTimKiem);
            panelSearch.Controls.Add(txtTimKiem);
            panelSearch.Controls.Add(lblTimKiem);
            panelSearch.Location = new Point(21, 142);
            panelSearch.Margin = new Padding(4, 5, 4, 5);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1699, 107);
            panelSearch.TabIndex = 1;
            // 
            // btnExportXML
            // 
            btnExportXML.BackColor = Color.FromArgb(230, 126, 34);
            btnExportXML.Cursor = Cursors.Hand;
            btnExportXML.FlatStyle = FlatStyle.Flat;
            btnExportXML.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            btnExportXML.ForeColor = Color.White;
            btnExportXML.Location = new Point(1485, 25);
            btnExportXML.Margin = new Padding(4, 5, 4, 5);
            btnExportXML.Name = "btnExportXML";
            btnExportXML.Size = new Size(200, 58);
            btnExportXML.TabIndex = 5;
            btnExportXML.Text = "📄 Export XML";
            btnExportXML.UseVisualStyleBackColor = false;
            btnExportXML.Click += btnExportXML_Click;
            // 
            // btnImportXML
            // 
            btnImportXML.BackColor = Color.FromArgb(155, 89, 182);
            btnImportXML.Cursor = Cursors.Hand;
            btnImportXML.FlatStyle = FlatStyle.Flat;
            btnImportXML.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            btnImportXML.ForeColor = Color.White;
            btnImportXML.Location = new Point(1257, 25);
            btnImportXML.Margin = new Padding(4, 5, 4, 5);
            btnImportXML.Name = "btnImportXML";
            btnImportXML.Size = new Size(200, 58);
            btnImportXML.TabIndex = 4;
            btnImportXML.Text = "📥 XML → SQL";
            btnImportXML.UseVisualStyleBackColor = false;
            btnImportXML.Click += btnImportXML_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(149, 165, 166);
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(1029, 25);
            btnLamMoi.Margin = new Padding(4, 5, 4, 5);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(200, 58);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(41, 128, 185);
            btnTimKiem.Cursor = Cursors.Hand;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(800, 25);
            btnTimKiem.Margin = new Padding(4, 5, 4, 5);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(200, 58);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Times New Roman", 11.25F);
            txtTimKiem.Location = new Point(171, 32);
            txtTimKiem.Margin = new Padding(4, 5, 4, 5);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên, SĐT hoặc email để tìm kiếm...";
            txtTimKiem.Size = new Size(598, 33);
            txtTimKiem.TabIndex = 1;
            // 
            // lblTimKiem
            // 
            lblTimKiem.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            lblTimKiem.Location = new Point(29, 32);
            lblTimKiem.Margin = new Padding(4, 0, 4, 0);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(129, 42);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Tìm kiếm:";
            lblTimKiem.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.White;
            panelInput.BorderStyle = BorderStyle.FixedSingle;
            panelInput.Controls.Add(txtMatKhau);
            panelInput.Controls.Add(label7);
            panelInput.Controls.Add(txtTenDangNhap);
            panelInput.Controls.Add(label6);
            panelInput.Controls.Add(txtEmail);
            panelInput.Controls.Add(label5);
            panelInput.Controls.Add(txtSDT);
            panelInput.Controls.Add(label4);
            panelInput.Controls.Add(txtDiaChi);
            panelInput.Controls.Add(label3);
            panelInput.Controls.Add(txtHoTen);
            panelInput.Controls.Add(label2);
            panelInput.Controls.Add(txtMaKH);
            panelInput.Controls.Add(label1);
            panelInput.Location = new Point(21, 275);
            panelInput.Margin = new Padding(4, 5, 4, 5);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(1699, 249);
            panelInput.TabIndex = 2;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Times New Roman", 11.25F);
            txtMatKhau.Location = new Point(1314, 172);
            txtMatKhau.Margin = new Padding(4, 5, 4, 5);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '●';
            txtMatKhau.Size = new Size(313, 33);
            txtMatKhau.TabIndex = 13;
            // 
            // label7
            // 
            label7.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label7.Location = new Point(1171, 172);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(129, 42);
            label7.TabIndex = 12;
            label7.Text = "Mật khẩu:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Font = new Font("Times New Roman", 11.25F);
            txtTenDangNhap.Location = new Point(786, 172);
            txtTenDangNhap.Margin = new Padding(4, 5, 4, 5);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(313, 33);
            txtTenDangNhap.TabIndex = 11;
            // 
            // label6
            // 
            label6.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label6.Location = new Point(600, 172);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(171, 42);
            label6.TabIndex = 10;
            label6.Text = "Tên đăng nhập:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Times New Roman", 11.25F);
            txtEmail.Location = new Point(786, 102);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(427, 33);
            txtEmail.TabIndex = 9;
            // 
            // label5
            // 
            label5.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label5.Location = new Point(600, 102);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(171, 42);
            label5.TabIndex = 8;
            label5.Text = "Email:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Times New Roman", 11.25F);
            txtSDT.Location = new Point(786, 32);
            txtSDT.Margin = new Padding(4, 5, 4, 5);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(313, 33);
            txtSDT.TabIndex = 7;
            // 
            // label4
            // 
            label4.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label4.Location = new Point(600, 32);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(171, 42);
            label4.TabIndex = 6;
            label4.Text = "Số điện thoại:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Times New Roman", 11.25F);
            txtDiaChi.Location = new Point(171, 172);
            txtDiaChi.Margin = new Padding(4, 5, 4, 5);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(370, 33);
            txtDiaChi.TabIndex = 5;
            // 
            // label3
            // 
            label3.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label3.Location = new Point(29, 172);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(129, 42);
            label3.TabIndex = 4;
            label3.Text = "Địa chỉ:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Times New Roman", 11.25F);
            txtHoTen.Location = new Point(171, 102);
            txtHoTen.Margin = new Padding(4, 5, 4, 5);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(370, 33);
            txtHoTen.TabIndex = 3;
            // 
            // label2
            // 
            label2.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label2.Location = new Point(29, 102);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(129, 42);
            label2.TabIndex = 2;
            label2.Text = "Họ tên:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMaKH
            // 
            txtMaKH.BackColor = Color.FromArgb(236, 240, 241);
            txtMaKH.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            txtMaKH.ForeColor = Color.FromArgb(52, 73, 94);
            txtMaKH.Location = new Point(171, 32);
            txtMaKH.Margin = new Padding(4, 5, 4, 5);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.ReadOnly = true;
            txtMaKH.Size = new Size(213, 33);
            txtMaKH.TabIndex = 1;
            // 
            // label1
            // 
            label1.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label1.Location = new Point(29, 32);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(129, 42);
            label1.TabIndex = 0;
            label1.Text = "Mã KH:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.BorderStyle = BorderStyle.FixedSingle;
            panelButtons.Controls.Add(btnXoa);
            panelButtons.Controls.Add(btnSua);
            panelButtons.Controls.Add(btnThem);
            panelButtons.Location = new Point(21, 550);
            panelButtons.Margin = new Padding(4, 5, 4, 5);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1699, 107);
            panelButtons.TabIndex = 3;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(943, 20);
            btnXoa.Margin = new Padding(4, 5, 4, 5);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(200, 67);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(41, 128, 185);
            btnSua.Cursor = Cursors.Hand;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(714, 20);
            btnSua.Margin = new Padding(4, 5, 4, 5);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(200, 67);
            btnSua.TabIndex = 1;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(39, 174, 96);
            btnThem.Cursor = Cursors.Hand;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(486, 20);
            btnThem.Margin = new Padding(4, 5, 4, 5);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(200, 67);
            btnThem.TabIndex = 0;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AllowUserToDeleteRows = false;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.BackgroundColor = Color.White;
            dgvKhachHang.ColumnHeadersHeight = 40;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvKhachHang.Location = new Point(21, 691);
            dgvKhachHang.Margin = new Padding(4, 5, 4, 5);
            dgvKhachHang.MultiSelect = false;
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersWidth = 50;
            dgvKhachHang.RowTemplate.Height = 35;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.Size = new Size(1700, 402);
            dgvKhachHang.TabIndex = 4;
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;
            // 
            // FormQuanLyKhachHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1743, 1170);
            Controls.Add(dgvKhachHang);
            Controls.Add(panelButtons);
            Controls.Add(panelInput);
            Controls.Add(panelSearch);
            Controls.Add(panelTop);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormQuanLyKhachHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Khách hàng";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button btnExportXML;
        private System.Windows.Forms.Button btnImportXML;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvKhachHang;
    }
}