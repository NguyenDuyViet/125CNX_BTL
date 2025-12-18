namespace ShoeShop
{
    partial class FormQuanLyDonHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            lblTitle = new Label();
            panelInfo = new Panel();
            btnExport = new Button();
            btnImportXML = new Button();
            btnRefresh = new Button();
            label1 = new Label();
            txtMaDH = new TextBox();
            label2 = new Label();
            txtTenKH = new TextBox();
            label3 = new Label();
            dtpNgayDat = new DateTimePicker();
            label4 = new Label();
            txtTongTien = new TextBox();
            label5 = new Label();
            cboTrangThai = new ComboBox();
            btnCapNhatTrangThai = new Button();
            btnXemChiTiet = new Button();
            dgvDonHang = new DataGridView();
            dgvChiTiet = new DataGridView();
            label6 = new Label();
            headerPanel.SuspendLayout();
            panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDonHang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(41, 128, 185);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1000, 70);
            headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(446, 47);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ ĐƠN HÀNG";
            // 
            // panelInfo
            // 
            panelInfo.BackColor = Color.White;
            panelInfo.BorderStyle = BorderStyle.FixedSingle;
            panelInfo.Controls.Add(btnExport);
            panelInfo.Controls.Add(btnImportXML);
            panelInfo.Controls.Add(btnRefresh);
            panelInfo.Controls.Add(label1);
            panelInfo.Controls.Add(txtMaDH);
            panelInfo.Controls.Add(label2);
            panelInfo.Controls.Add(txtTenKH);
            panelInfo.Controls.Add(label3);
            panelInfo.Controls.Add(dtpNgayDat);
            panelInfo.Controls.Add(label4);
            panelInfo.Controls.Add(txtTongTien);
            panelInfo.Controls.Add(label5);
            panelInfo.Controls.Add(cboTrangThai);
            panelInfo.Controls.Add(btnCapNhatTrangThai);
            panelInfo.Controls.Add(btnXemChiTiet);
            panelInfo.Location = new Point(15, 85);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(970, 250);
            panelInfo.TabIndex = 1;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(230, 126, 34);
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(250, 198);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(201, 40);
            btnExport.TabIndex = 14;
            btnExport.Text = "📄 Export XML";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnImportXML
            // 
            btnImportXML.BackColor = Color.FromArgb(155, 89, 182);
            btnImportXML.FlatStyle = FlatStyle.Flat;
            btnImportXML.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImportXML.ForeColor = Color.White;
            btnImportXML.Location = new Point(20, 198);
            btnImportXML.Name = "btnImportXML";
            btnImportXML.Size = new Size(201, 40);
            btnImportXML.TabIndex = 13;
            btnImportXML.Text = "📥 XML → SQL";
            btnImportXML.UseVisualStyleBackColor = false;
            btnImportXML.Click += btnImportXML_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(149, 165, 166);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Image = Properties.Resources.refresh_28053551;
            btnRefresh.Location = new Point(788, 198);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(160, 40);
            btnRefresh.TabIndex = 12;
            btnRefresh.Text = "Làm mới";
            btnRefresh.TextAlign = ContentAlignment.MiddleRight;
            btnRefresh.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(160, 25);
            label1.TabIndex = 0;
            label1.Text = "Mã đơn hàng:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMaDH
            // 
            txtMaDH.Font = new Font("Times New Roman", 11.25F);
            txtMaDH.Location = new Point(213, 20);
            txtMaDH.Name = "txtMaDH";
            txtMaDH.ReadOnly = true;
            txtMaDH.Size = new Size(250, 33);
            txtMaDH.TabIndex = 1;
            // 
            // label2
            // 
            label2.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label2.Location = new Point(20, 70);
            label2.Name = "label2";
            label2.Size = new Size(187, 25);
            label2.TabIndex = 2;
            label2.Text = "Tên khách hàng:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTenKH
            // 
            txtTenKH.Font = new Font("Times New Roman", 11.25F);
            txtTenKH.Location = new Point(213, 67);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.ReadOnly = true;
            txtTenKH.Size = new Size(250, 33);
            txtTenKH.TabIndex = 3;
            // 
            // label3
            // 
            label3.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label3.Location = new Point(20, 120);
            label3.Name = "label3";
            label3.Size = new Size(140, 25);
            label3.TabIndex = 4;
            label3.Text = "Ngày đặt:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpNgayDat
            // 
            dtpNgayDat.Enabled = false;
            dtpNgayDat.Font = new Font("Times New Roman", 11.25F);
            dtpNgayDat.Format = DateTimePickerFormat.Short;
            dtpNgayDat.Location = new Point(160, 118);
            dtpNgayDat.Name = "dtpNgayDat";
            dtpNgayDat.Size = new Size(250, 33);
            dtpNgayDat.TabIndex = 5;
            // 
            // label4
            // 
            label4.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label4.Location = new Point(550, 20);
            label4.Name = "label4";
            label4.Size = new Size(125, 25);
            label4.TabIndex = 6;
            label4.Text = "Tổng tiền:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTongTien
            // 
            txtTongTien.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            txtTongTien.ForeColor = Color.FromArgb(192, 57, 43);
            txtTongTien.Location = new Point(698, 18);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.ReadOnly = true;
            txtTongTien.Size = new Size(250, 33);
            txtTongTien.TabIndex = 7;
            txtTongTien.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label5.Location = new Point(550, 70);
            label5.Name = "label5";
            label5.Size = new Size(125, 25);
            label5.TabIndex = 8;
            label5.Text = "Trạng thái:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Font = new Font("Times New Roman", 11.25F);
            cboTrangThai.Items.AddRange(new object[] { "Chờ xác nhận", "Đã xác nhận", "Đang giao", "Đã giao", "Đã hủy" });
            cboTrangThai.Location = new Point(698, 68);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(250, 34);
            cboTrangThai.TabIndex = 9;
            // 
            // btnCapNhatTrangThai
            // 
            btnCapNhatTrangThai.BackColor = Color.FromArgb(41, 128, 185);
            btnCapNhatTrangThai.FlatStyle = FlatStyle.Flat;
            btnCapNhatTrangThai.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCapNhatTrangThai.ForeColor = Color.White;
            btnCapNhatTrangThai.Image = Properties.Resources.refresh_2546743;
            btnCapNhatTrangThai.Location = new Point(580, 120);
            btnCapNhatTrangThai.Name = "btnCapNhatTrangThai";
            btnCapNhatTrangThai.Size = new Size(160, 40);
            btnCapNhatTrangThai.TabIndex = 10;
            btnCapNhatTrangThai.Text = "Cập nhật";
            btnCapNhatTrangThai.TextAlign = ContentAlignment.MiddleRight;
            btnCapNhatTrangThai.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCapNhatTrangThai.UseVisualStyleBackColor = false;
            btnCapNhatTrangThai.Click += btnCapNhatTrangThai_Click;
            // 
            // btnXemChiTiet
            // 
            btnXemChiTiet.BackColor = Color.FromArgb(39, 174, 96);
            btnXemChiTiet.FlatStyle = FlatStyle.Flat;
            btnXemChiTiet.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXemChiTiet.ForeColor = Color.White;
            btnXemChiTiet.Image = Properties.Resources.view_13066076;
            btnXemChiTiet.Location = new Point(750, 120);
            btnXemChiTiet.Name = "btnXemChiTiet";
            btnXemChiTiet.Size = new Size(198, 40);
            btnXemChiTiet.TabIndex = 11;
            btnXemChiTiet.Text = "Xem chi tiết";
            btnXemChiTiet.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnXemChiTiet.UseVisualStyleBackColor = false;
            btnXemChiTiet.Click += btnXemChiTiet_Click;
            // 
            // dgvDonHang
            // 
            dgvDonHang.AllowUserToAddRows = false;
            dgvDonHang.AllowUserToDeleteRows = false;
            dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDonHang.BackgroundColor = Color.White;
            dgvDonHang.ColumnHeadersHeight = 40;
            dgvDonHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDonHang.Location = new Point(15, 355);
            dgvDonHang.MultiSelect = false;
            dgvDonHang.Name = "dgvDonHang";
            dgvDonHang.ReadOnly = true;
            dgvDonHang.RowHeadersWidth = 50;
            dgvDonHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonHang.Size = new Size(970, 201);
            dgvDonHang.TabIndex = 2;
            dgvDonHang.CellClick += dgvDonHang_CellClick;
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.BackgroundColor = Color.White;
            dgvChiTiet.ColumnHeadersHeight = 40;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvChiTiet.Location = new Point(15, 609);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersWidth = 50;
            dgvChiTiet.Size = new Size(970, 76);
            dgvChiTiet.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(52, 73, 94);
            label6.Location = new Point(15, 574);
            label6.Name = "label6";
            label6.Size = new Size(222, 30);
            label6.TabIndex = 3;
            label6.Text = "Chi tiết đơn hàng:";
            // 
            // FormQuanLyDonHang
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1000, 732);
            Controls.Add(headerPanel);
            Controls.Add(panelInfo);
            Controls.Add(dgvDonHang);
            Controls.Add(label6);
            Controls.Add(dgvChiTiet);
            Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "FormQuanLyDonHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý đơn hàng";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDonHang).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // ===== Khai báo biến =====
        private Panel headerPanel;
        private Label lblTitle;
        private Panel panelInfo;

        private DataGridView dgvDonHang;
        private DataGridView dgvChiTiet;

        private TextBox txtMaDH;
        private TextBox txtTenKH;
        private TextBox txtTongTien;

        private DateTimePicker dtpNgayDat;
        private ComboBox cboTrangThai;

        private Button btnCapNhatTrangThai;
        private Button btnXemChiTiet;

        private Label label1, label2, label3, label4, label5, label6;
        private Button btnRefresh;
        private Button btnExport;
        private Button btnImportXML;
    }
}