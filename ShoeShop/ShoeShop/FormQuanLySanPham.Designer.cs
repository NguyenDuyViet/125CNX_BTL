namespace ShoeShop
{
    partial class FormQuanLySanPham
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
            panelImage = new Panel();
            picPreview = new PictureBox();
            btnChonAnh = new Button();
            txtImages = new TextBox();
            label8 = new Label();
            txtSoLuong = new TextBox();
            label7 = new Label();
            txtGia = new TextBox();
            label6 = new Label();
            txtMauSac = new TextBox();
            label5 = new Label();
            txtKichCo = new TextBox();
            label4 = new Label();
            cboLoaiSP = new ComboBox();
            label3 = new Label();
            txtTenSP = new TextBox();
            label2 = new Label();
            txtMaSP = new TextBox();
            label1 = new Label();
            panelButtons = new Panel();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            dgvSanPham = new DataGridView();
            panelTop.SuspendLayout();
            panelSearch.SuspendLayout();
            panelInput.SuspendLayout();
            panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(46, 204, 113);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 5, 4, 5);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1857, 100);
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
            lblTitle.Size = new Size(376, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ SẢN PHẨM";
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
            panelSearch.Size = new Size(1800, 100);
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
            btnTimKiem.BackColor = Color.FromArgb(46, 204, 113);
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
            txtTimKiem.PlaceholderText = "Nhập tên, màu sắc hoặc loại sản phẩm...";
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
            panelInput.Controls.Add(panelImage);
            panelInput.Controls.Add(txtSoLuong);
            panelInput.Controls.Add(label7);
            panelInput.Controls.Add(txtGia);
            panelInput.Controls.Add(label6);
            panelInput.Controls.Add(txtMauSac);
            panelInput.Controls.Add(label5);
            panelInput.Controls.Add(txtKichCo);
            panelInput.Controls.Add(label4);
            panelInput.Controls.Add(cboLoaiSP);
            panelInput.Controls.Add(label3);
            panelInput.Controls.Add(txtTenSP);
            panelInput.Controls.Add(label2);
            panelInput.Controls.Add(txtMaSP);
            panelInput.Controls.Add(label1);
            panelInput.Location = new Point(29, 267);
            panelInput.Margin = new Padding(4, 5, 4, 5);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(1800, 300);
            panelInput.TabIndex = 2;
            // 
            // panelImage
            // 
            panelImage.BackColor = Color.FromArgb(236, 240, 241);
            panelImage.BorderStyle = BorderStyle.FixedSingle;
            panelImage.Controls.Add(picPreview);
            panelImage.Controls.Add(btnChonAnh);
            panelImage.Controls.Add(txtImages);
            panelImage.Controls.Add(label8);
            panelImage.Location = new Point(1043, 17);
            panelImage.Margin = new Padding(4, 5, 4, 5);
            panelImage.Name = "panelImage";
            panelImage.Size = new Size(728, 265);
            panelImage.TabIndex = 14;
            // 
            // picPreview
            // 
            picPreview.BackColor = Color.White;
            picPreview.BorderStyle = BorderStyle.FixedSingle;
            picPreview.Location = new Point(14, 117);
            picPreview.Margin = new Padding(4, 5, 4, 5);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(685, 124);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 3;
            picPreview.TabStop = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.BackColor = Color.FromArgb(52, 152, 219);
            btnChonAnh.Cursor = Cursors.Hand;
            btnChonAnh.FlatStyle = FlatStyle.Flat;
            btnChonAnh.Font = new Font("Segoe UI", 9F);
            btnChonAnh.ForeColor = Color.White;
            btnChonAnh.Location = new Point(529, 55);
            btnChonAnh.Margin = new Padding(4, 5, 4, 5);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(171, 45);
            btnChonAnh.TabIndex = 2;
            btnChonAnh.Text = "📁 Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = false;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // txtImages
            // 
            txtImages.BackColor = Color.White;
            txtImages.Font = new Font("Segoe UI", 9F);
            txtImages.Location = new Point(14, 58);
            txtImages.Margin = new Padding(4, 5, 4, 5);
            txtImages.Name = "txtImages";
            txtImages.ReadOnly = true;
            txtImages.Size = new Size(498, 31);
            txtImages.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.Location = new Point(14, 17);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(152, 28);
            label8.TabIndex = 0;
            label8.Text = "Ảnh sản phẩm:";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Font = new Font("Segoe UI", 10F);
            txtSoLuong.Location = new Point(771, 145);
            txtSoLuong.Margin = new Padding(4, 5, 4, 5);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(141, 34);
            txtSoLuong.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(657, 150);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(96, 28);
            label7.TabIndex = 12;
            label7.Text = "Số lượng:";
            // 
            // txtGia
            // 
            txtGia.Font = new Font("Segoe UI", 10F);
            txtGia.Location = new Point(771, 87);
            txtGia.Margin = new Padding(4, 5, 4, 5);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(213, 34);
            txtGia.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(657, 92);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(45, 28);
            label6.TabIndex = 10;
            label6.Text = "Giá:";
            // 
            // txtMauSac
            // 
            txtMauSac.Font = new Font("Segoe UI", 10F);
            txtMauSac.Location = new Point(771, 28);
            txtMauSac.Margin = new Padding(4, 5, 4, 5);
            txtMauSac.Name = "txtMauSac";
            txtMauSac.Size = new Size(213, 34);
            txtMauSac.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(657, 33);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(87, 28);
            label5.TabIndex = 8;
            label5.Text = "Màu sắc:";
            // 
            // txtKichCo
            // 
            txtKichCo.Font = new Font("Segoe UI", 10F);
            txtKichCo.Location = new Point(171, 203);
            txtKichCo.Margin = new Padding(4, 5, 4, 5);
            txtKichCo.Name = "txtKichCo";
            txtKichCo.Size = new Size(141, 34);
            txtKichCo.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(29, 208);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(79, 28);
            label4.TabIndex = 6;
            label4.Text = "Kích cỡ:";
            // 
            // cboLoaiSP
            // 
            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSP.Font = new Font("Segoe UI", 10F);
            cboLoaiSP.FormattingEnabled = true;
            cboLoaiSP.Location = new Point(171, 145);
            cboLoaiSP.Margin = new Padding(4, 5, 4, 5);
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Size = new Size(284, 36);
            cboLoaiSP.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(29, 150);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(79, 28);
            label3.TabIndex = 4;
            label3.Text = "Loại SP:";
            // 
            // txtTenSP
            // 
            txtTenSP.Font = new Font("Segoe UI", 10F);
            txtTenSP.Location = new Point(171, 87);
            txtTenSP.Margin = new Padding(4, 5, 4, 5);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(427, 34);
            txtTenSP.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(29, 92);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(134, 28);
            label2.TabIndex = 2;
            label2.Text = "Tên sản phẩm:";
            // 
            // txtMaSP
            // 
            txtMaSP.BackColor = Color.FromArgb(236, 240, 241);
            txtMaSP.Font = new Font("Segoe UI", 10F);
            txtMaSP.Location = new Point(171, 28);
            txtMaSP.Margin = new Padding(4, 5, 4, 5);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.ReadOnly = true;
            txtMaSP.Size = new Size(141, 34);
            txtMaSP.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(29, 33);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(71, 28);
            label1.TabIndex = 0;
            label1.Text = "Mã SP:";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnXoa);
            panelButtons.Controls.Add(btnSua);
            panelButtons.Controls.Add(btnThem);
            panelButtons.Location = new Point(29, 600);
            panelButtons.Margin = new Padding(4, 5, 4, 5);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1800, 100);
            panelButtons.TabIndex = 3;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(1000, 17);
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
            btnSua.Location = new Point(800, 17);
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
            btnThem.Location = new Point(600, 17);
            btnThem.Margin = new Padding(4, 5, 4, 5);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(171, 67);
            btnThem.TabIndex = 0;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // dgvSanPham
            // 
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Location = new Point(29, 733);
            dgvSanPham.Margin = new Padding(4, 5, 4, 5);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersWidth = 62;
            dgvSanPham.RowTemplate.Height = 30;
            dgvSanPham.Size = new Size(1800, 400);
            dgvSanPham.TabIndex = 4;
            dgvSanPham.CellClick += dgvSanPham_CellClick;
            // 
            // FormQuanLySanPham
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1857, 1167);
            Controls.Add(dgvSanPham);
            Controls.Add(panelButtons);
            Controls.Add(panelInput);
            Controls.Add(panelSearch);
            Controls.Add(panelTop);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormQuanLySanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Sản phẩm";
            Load += FormQuanLySanPham_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            panelImage.ResumeLayout(false);
            panelImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
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
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.TextBox txtImages;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMauSac;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKichCo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboLoaiSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvSanPham;
    }
}
