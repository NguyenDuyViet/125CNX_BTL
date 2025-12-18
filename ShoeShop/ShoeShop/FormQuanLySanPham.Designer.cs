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
            btnImportXML = new Button();
            btnExportXML = new Button();
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
            dgvSanPham = new DataGridView();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            panelButtons = new Panel();
            panelTop.SuspendLayout();
            panelSearch.SuspendLayout();
            panelInput.SuspendLayout();
            panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(39, 174, 96);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 5, 4, 5);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1886, 117);
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
            lblTitle.Size = new Size(440, 47);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ SẢN PHẨM";
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(btnImportXML);
            panelSearch.Controls.Add(btnExportXML);
            panelSearch.Controls.Add(btnLamMoi);
            panelSearch.Controls.Add(btnTimKiem);
            panelSearch.Controls.Add(txtTimKiem);
            panelSearch.Controls.Add(lblTimKiem);
            panelSearch.Location = new Point(21, 142);
            panelSearch.Margin = new Padding(4, 5, 4, 5);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1842, 107);
            panelSearch.TabIndex = 1;
            // 
            // btnImportXML
            // 
            btnImportXML.BackColor = Color.FromArgb(155, 89, 182);
            btnImportXML.Cursor = Cursors.Hand;
            btnImportXML.FlatStyle = FlatStyle.Flat;
            btnImportXML.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            btnImportXML.ForeColor = Color.White;
            btnImportXML.Location = new Point(1357, 25);
            btnImportXML.Margin = new Padding(4, 5, 4, 5);
            btnImportXML.Name = "btnImportXML";
            btnImportXML.Size = new Size(200, 58);
            btnImportXML.TabIndex = 4;
            btnImportXML.Text = "📥 XML → SQL";
            btnImportXML.UseVisualStyleBackColor = false;
            btnImportXML.Click += btnImportXML_Click;
            // 
            // btnExportXML
            // 
            btnExportXML.BackColor = Color.FromArgb(41, 128, 185);
            btnExportXML.Cursor = Cursors.Hand;
            btnExportXML.FlatStyle = FlatStyle.Flat;
            btnExportXML.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            btnExportXML.ForeColor = Color.White;
            btnExportXML.Location = new Point(1585, 25);
            btnExportXML.Margin = new Padding(4, 5, 4, 5);
            btnExportXML.Name = "btnExportXML";
            btnExportXML.Size = new Size(200, 58);
            btnExportXML.TabIndex = 5;
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
            btnLamMoi.Location = new Point(1129, 25);
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
            btnTimKiem.BackColor = Color.FromArgb(39, 174, 96);
            btnTimKiem.Cursor = Cursors.Hand;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(900, 25);
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
            txtTimKiem.PlaceholderText = "Nhập tên, màu sắc hoặc loại sản phẩm để tìm kiếm...";
            txtTimKiem.Size = new Size(698, 33);
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
            panelInput.Location = new Point(21, 275);
            panelInput.Margin = new Padding(4, 5, 4, 5);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(1842, 315);
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
            panelImage.Location = new Point(1086, 25);
            panelImage.Margin = new Padding(4, 5, 4, 5);
            panelImage.Name = "panelImage";
            panelImage.Size = new Size(728, 265);
            panelImage.TabIndex = 14;
            // 
            // picPreview
            // 
            picPreview.BackColor = Color.White;
            picPreview.BorderStyle = BorderStyle.FixedSingle;
            picPreview.Location = new Point(21, 125);
            picPreview.Margin = new Padding(4, 5, 4, 5);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(685, 124);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 3;
            picPreview.TabStop = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.BackColor = Color.FromArgb(39, 174, 96);
            btnChonAnh.Cursor = Cursors.Hand;
            btnChonAnh.FlatStyle = FlatStyle.Flat;
            btnChonAnh.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnChonAnh.ForeColor = Color.White;
            btnChonAnh.Location = new Point(536, 58);
            btnChonAnh.Margin = new Padding(4, 5, 4, 5);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(171, 50);
            btnChonAnh.TabIndex = 2;
            btnChonAnh.Text = "📁 Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = false;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // txtImages
            // 
            txtImages.BackColor = Color.White;
            txtImages.Font = new Font("Times New Roman", 10F);
            txtImages.Location = new Point(21, 63);
            txtImages.Margin = new Padding(4, 5, 4, 5);
            txtImages.Name = "txtImages";
            txtImages.ReadOnly = true;
            txtImages.Size = new Size(498, 30);
            txtImages.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label8.Location = new Point(21, 20);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(165, 25);
            label8.TabIndex = 0;
            label8.Text = "Ảnh sản phẩm:";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Font = new Font("Times New Roman", 11.25F);
            txtSoLuong.Location = new Point(771, 172);
            txtSoLuong.Margin = new Padding(4, 5, 4, 5);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(170, 33);
            txtSoLuong.TabIndex = 13;
            txtSoLuong.TextAlign = HorizontalAlignment.Right;
            // 
            // label7
            // 
            label7.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label7.Location = new Point(600, 172);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(157, 42);
            label7.TabIndex = 12;
            label7.Text = "Số lượng:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtGia
            // 
            txtGia.Font = new Font("Times New Roman", 11.25F);
            txtGia.Location = new Point(771, 102);
            txtGia.Margin = new Padding(4, 5, 4, 5);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(255, 33);
            txtGia.TabIndex = 11;
            txtGia.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label6.Location = new Point(600, 102);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(157, 42);
            label6.TabIndex = 10;
            label6.Text = "Giá (VNĐ):";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMauSac
            // 
            txtMauSac.Font = new Font("Times New Roman", 11.25F);
            txtMauSac.Location = new Point(771, 32);
            txtMauSac.Margin = new Padding(4, 5, 4, 5);
            txtMauSac.Name = "txtMauSac";
            txtMauSac.Size = new Size(255, 33);
            txtMauSac.TabIndex = 9;
            // 
            // label5
            // 
            label5.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label5.Location = new Point(600, 32);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(157, 42);
            label5.TabIndex = 8;
            label5.Text = "Màu sắc:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtKichCo
            // 
            txtKichCo.Font = new Font("Times New Roman", 11.25F);
            txtKichCo.Location = new Point(229, 242);
            txtKichCo.Margin = new Padding(4, 5, 4, 5);
            txtKichCo.Name = "txtKichCo";
            txtKichCo.Size = new Size(170, 33);
            txtKichCo.TabIndex = 7;
            // 
            // label4
            // 
            label4.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label4.Location = new Point(29, 242);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(186, 42);
            label4.TabIndex = 6;
            label4.Text = "Kích cỡ:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboLoaiSP
            // 
            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSP.Font = new Font("Times New Roman", 11.25F);
            cboLoaiSP.FormattingEnabled = true;
            cboLoaiSP.Location = new Point(229, 172);
            cboLoaiSP.Margin = new Padding(4, 5, 4, 5);
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Size = new Size(313, 34);
            cboLoaiSP.TabIndex = 5;
            // 
            // label3
            // 
            label3.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label3.Location = new Point(29, 172);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(186, 42);
            label3.TabIndex = 4;
            label3.Text = "Loại sản phẩm:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTenSP
            // 
            txtTenSP.Font = new Font("Times New Roman", 11.25F);
            txtTenSP.Location = new Point(229, 102);
            txtTenSP.Margin = new Padding(4, 5, 4, 5);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(313, 33);
            txtTenSP.TabIndex = 3;
            // 
            // label2
            // 
            label2.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label2.Location = new Point(29, 102);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(186, 42);
            label2.TabIndex = 2;
            label2.Text = "Tên sản phẩm:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMaSP
            // 
            txtMaSP.BackColor = Color.FromArgb(236, 240, 241);
            txtMaSP.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            txtMaSP.ForeColor = Color.FromArgb(52, 73, 94);
            txtMaSP.Location = new Point(229, 32);
            txtMaSP.Margin = new Padding(4, 5, 4, 5);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.ReadOnly = true;
            txtMaSP.Size = new Size(170, 33);
            txtMaSP.TabIndex = 1;
            // 
            // label1
            // 
            label1.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label1.Location = new Point(29, 32);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(186, 42);
            label1.TabIndex = 0;
            label1.Text = "Mã sản phẩm:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvSanPham
            // 
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AllowUserToDeleteRows = false;
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.BackgroundColor = Color.White;
            dgvSanPham.ColumnHeadersHeight = 40;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSanPham.Location = new Point(21, 758);
            dgvSanPham.Margin = new Padding(4, 5, 4, 5);
            dgvSanPham.MultiSelect = false;
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.ReadOnly = true;
            dgvSanPham.RowHeadersWidth = 50;
            dgvSanPham.RowTemplate.Height = 35;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.Size = new Size(1843, 261);
            dgvSanPham.TabIndex = 4;
            dgvSanPham.CellClick += dgvSanPham_CellClick;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(39, 174, 96);
            btnThem.Cursor = Cursors.Hand;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(586, 20);
            btnThem.Margin = new Padding(4, 5, 4, 5);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(200, 67);
            btnThem.TabIndex = 0;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(41, 128, 185);
            btnSua.Cursor = Cursors.Hand;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(814, 20);
            btnSua.Margin = new Padding(4, 5, 4, 5);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(200, 67);
            btnSua.TabIndex = 1;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(1043, 20);
            btnXoa.Margin = new Padding(4, 5, 4, 5);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(200, 67);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.BorderStyle = BorderStyle.FixedSingle;
            panelButtons.Controls.Add(btnXoa);
            panelButtons.Controls.Add(btnSua);
            panelButtons.Controls.Add(btnThem);
            panelButtons.Location = new Point(21, 617);
            panelButtons.Margin = new Padding(4, 5, 4, 5);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1842, 107);
            panelButtons.TabIndex = 3;
            // 
            // FormQuanLySanPham
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1886, 1033);
            Controls.Add(dgvSanPham);
            Controls.Add(panelButtons);
            Controls.Add(panelInput);
            Controls.Add(panelSearch);
            Controls.Add(panelTop);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormQuanLySanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Sản phẩm";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            panelImage.ResumeLayout(false);
            panelImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button btnImportXML;
        private System.Windows.Forms.Button btnExportXML;
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
        private System.Windows.Forms.DataGridView dgvSanPham;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Panel panelButtons;
    }
}