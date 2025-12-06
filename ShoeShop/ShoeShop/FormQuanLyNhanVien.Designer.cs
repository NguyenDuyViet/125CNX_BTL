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
            btnExportXML = new Button();
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
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1220, 70);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(340, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(btnExportXML);
            panelSearch.Controls.Add(btnLamMoi);
            panelSearch.Controls.Add(btnTimKiem);
            panelSearch.Controls.Add(txtTimKiem);
            panelSearch.Controls.Add(lblTimKiem);
            panelSearch.Location = new Point(15, 85);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1190, 65);
            panelSearch.TabIndex = 1;
            // 
            // btnExportXML
            // 
            btnExportXML.BackColor = Color.FromArgb(41, 128, 185);
            btnExportXML.Cursor = Cursors.Hand;
            btnExportXML.FlatStyle = FlatStyle.Flat;
            btnExportXML.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            btnExportXML.ForeColor = Color.White;
            btnExportXML.Location = new Point(880, 15);
            btnExportXML.Name = "btnExportXML";
            btnExportXML.Size = new Size(140, 35);
            btnExportXML.TabIndex = 4;
            btnExportXML.Text = "📄 Export XML";
            btnExportXML.UseVisualStyleBackColor = false;
            btnExportXML.Click += btnExportXML_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(149, 165, 166);
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(720, 15);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(140, 35);
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
            btnTimKiem.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(560, 15);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(140, 35);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Times New Roman", 11.25F);
            txtTimKiem.Location = new Point(120, 19);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên, SĐT, email hoặc chức vụ để tìm kiếm...";
            txtTimKiem.Size = new Size(420, 29);
            txtTimKiem.TabIndex = 1;
            // 
            // lblTimKiem
            // 
            lblTimKiem.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            lblTimKiem.Location = new Point(20, 19);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(90, 25);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Tìm kiếm:";
            lblTimKiem.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.White;
            panelInput.BorderStyle = BorderStyle.FixedSingle;
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
            panelInput.Location = new Point(15, 165);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(1190, 150);
            panelInput.TabIndex = 2;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Times New Roman", 11.25F);
            txtMatKhau.Location = new Point(940, 61);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '●';
            txtMatKhau.Size = new Size(200, 29);
            txtMatKhau.TabIndex = 15;
            // 
            // label8
            // 
            label8.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label8.Location = new Point(820, 61);
            label8.Name = "label8";
            label8.Size = new Size(110, 25);
            label8.TabIndex = 14;
            label8.Text = "Mật khẩu:";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Font = new Font("Times New Roman", 11.25F);
            txtTenDangNhap.Location = new Point(940, 19);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(200, 29);
            txtTenDangNhap.TabIndex = 13;
            // 
            // label7
            // 
            label7.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label7.Location = new Point(820, 19);
            label7.Name = "label7";
            label7.Size = new Size(110, 25);
            label7.TabIndex = 12;
            label7.Text = "Tên đăng nhập:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboChucVu
            // 
            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucVu.Font = new Font("Times New Roman", 11.25F);
            cboChucVu.FormattingEnabled = true;
            cboChucVu.Items.AddRange(new object[] { "Bán hàng", "Kho", "Quản lý" });
            cboChucVu.Location = new Point(550, 103);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(220, 29);
            cboChucVu.TabIndex = 11;
            // 
            // label6
            // 
            label6.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label6.Location = new Point(420, 103);
            label6.Name = "label6";
            label6.Size = new Size(120, 25);
            label6.TabIndex = 10;
            label6.Text = "Chức vụ:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Times New Roman", 11.25F);
            txtEmail.Location = new Point(550, 61);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 29);
            txtEmail.TabIndex = 9;
            // 
            // label5
            // 
            label5.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label5.Location = new Point(420, 61);
            label5.Name = "label5";
            label5.Size = new Size(120, 25);
            label5.TabIndex = 8;
            label5.Text = "Email:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Times New Roman", 11.25F);
            txtSDT.Location = new Point(550, 19);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(220, 29);
            txtSDT.TabIndex = 7;
            // 
            // label4
            // 
            label4.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label4.Location = new Point(420, 19);
            label4.Name = "label4";
            label4.Size = new Size(120, 25);
            label4.TabIndex = 6;
            label4.Text = "Số điện thoại:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Times New Roman", 11.25F);
            txtDiaChi.Location = new Point(120, 103);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(260, 29);
            txtDiaChi.TabIndex = 5;
            // 
            // label3
            // 
            label3.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label3.Location = new Point(20, 103);
            label3.Name = "label3";
            label3.Size = new Size(90, 25);
            label3.TabIndex = 4;
            label3.Text = "Địa chỉ:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Times New Roman", 11.25F);
            txtHoTen.Location = new Point(120, 61);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(260, 29);
            txtHoTen.TabIndex = 3;
            // 
            // label2
            // 
            label2.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label2.Location = new Point(20, 61);
            label2.Name = "label2";
            label2.Size = new Size(90, 25);
            label2.TabIndex = 2;
            label2.Text = "Họ tên:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMaNV
            // 
            txtMaNV.BackColor = Color.FromArgb(236, 240, 241);
            txtMaNV.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            txtMaNV.ForeColor = Color.FromArgb(52, 73, 94);
            txtMaNV.Location = new Point(120, 19);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(150, 29);
            txtMaNV.TabIndex = 1;
            // 
            // label1
            // 
            label1.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label1.Location = new Point(20, 19);
            label1.Name = "label1";
            label1.Size = new Size(90, 25);
            label1.TabIndex = 0;
            label1.Text = "Mã NV:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.BorderStyle = BorderStyle.FixedSingle;
            panelButtons.Controls.Add(btnXoa);
            panelButtons.Controls.Add(btnSua);
            panelButtons.Controls.Add(btnThem);
            panelButtons.Location = new Point(15, 330);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1190, 65);
            panelButtons.TabIndex = 3;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(660, 12);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(140, 40);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(230, 126, 34);
            btnSua.Cursor = Cursors.Hand;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(500, 12);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(140, 40);
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
            btnThem.Location = new Point(340, 12);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(140, 40);
            btnThem.TabIndex = 0;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToDeleteRows = false;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.BackgroundColor = Color.White;
            dgvNhanVien.BorderStyle = BorderStyle.FixedSingle;
            dgvNhanVien.ColumnHeadersHeight = 40;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvNhanVien.Location = new Point(15, 410);
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowHeadersWidth = 50;
            dgvNhanVien.RowTemplate.Height = 35;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new Size(1190, 320);
            dgvNhanVien.TabIndex = 4;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            // 
            // FormQuanLyNhanVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1220, 750);
            Controls.Add(dgvNhanVien);
            Controls.Add(panelButtons);
            Controls.Add(panelInput);
            Controls.Add(panelSearch);
            Controls.Add(panelTop);
            Name = "FormQuanLyNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Nhân viên";
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
        private System.Windows.Forms.Button btnExportXML;
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