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
			headerPanel.Size = new Size(984, 70);
			headerPanel.TabIndex = 0;
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblTitle.ForeColor = Color.White;
			lblTitle.Location = new Point(20, 15);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(295, 31);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "QUẢN LÝ ĐƠN HÀNG";
			// 
			// panelInfo
			// 
			panelInfo.BackColor = Color.White;
			panelInfo.BorderStyle = BorderStyle.FixedSingle;
			panelInfo.Controls.Add(btnExport);
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
			panelInfo.Location = new Point(12, 71);
			panelInfo.Name = "panelInfo";
			panelInfo.Size = new Size(960, 270);
			panelInfo.TabIndex = 1;
			// 
			// btnExport
			// 
			btnExport.BackColor = Color.FromArgb(192, 0, 0);
			btnExport.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnExport.ForeColor = Color.White;
			btnExport.Location = new Point(20, 223);
			btnExport.Name = "btnExport";
			btnExport.Size = new Size(173, 33);
			btnExport.TabIndex = 13;
			btnExport.Text = "Export to XML";
			btnExport.UseVisualStyleBackColor = false;
			btnExport.Click += btnExport_Click;
			// 
			// btnRefresh
			// 
			btnRefresh.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnRefresh.Image = Properties.Resources.refresh_28053551;
			btnRefresh.Location = new Point(761, 223);
			btnRefresh.Name = "btnRefresh";
			btnRefresh.Size = new Size(125, 33);
			btnRefresh.TabIndex = 12;
			btnRefresh.Text = "Refresh";
			btnRefresh.TextAlign = ContentAlignment.MiddleRight;
			btnRefresh.TextImageRelation = TextImageRelation.ImageBeforeText;
			btnRefresh.UseVisualStyleBackColor = true;
			btnRefresh.Click += btnRefresh_Click;
			// 
			// label1
			// 
			label1.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
			label1.Location = new Point(20, 17);
			label1.Name = "label1";
			label1.Size = new Size(125, 32);
			label1.TabIndex = 0;
			label1.Text = "Mã đơn hàng:";
			// 
			// txtMaDH
			// 
			txtMaDH.Location = new Point(210, 21);
			txtMaDH.Name = "txtMaDH";
			txtMaDH.ReadOnly = true;
			txtMaDH.Size = new Size(200, 21);
			txtMaDH.TabIndex = 1;
			// 
			// label2
			// 
			label2.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
			label2.Location = new Point(20, 98);
			label2.Name = "label2";
			label2.Size = new Size(125, 32);
			label2.TabIndex = 2;
			label2.Text = "Tên khách hàng:";
			// 
			// txtTenKH
			// 
			txtTenKH.Location = new Point(210, 102);
			txtTenKH.Name = "txtTenKH";
			txtTenKH.ReadOnly = true;
			txtTenKH.Size = new Size(250, 21);
			txtTenKH.TabIndex = 3;
			// 
			// label3
			// 
			label3.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
			label3.Location = new Point(20, 170);
			label3.Name = "label3";
			label3.Size = new Size(125, 32);
			label3.TabIndex = 4;
			label3.Text = "Ngày đặt:";
			// 
			// dtpNgayDat
			// 
			dtpNgayDat.Enabled = false;
			dtpNgayDat.Location = new Point(210, 168);
			dtpNgayDat.Name = "dtpNgayDat";
			dtpNgayDat.Size = new Size(250, 21);
			dtpNgayDat.TabIndex = 5;
			// 
			// label4
			// 
			label4.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
			label4.Location = new Point(545, 20);
			label4.Name = "label4";
			label4.Size = new Size(83, 32);
			label4.TabIndex = 6;
			label4.Text = "Tổng tiền:";
			// 
			// txtTongTien
			// 
			txtTongTien.Location = new Point(686, 18);
			txtTongTien.Name = "txtTongTien";
			txtTongTien.ReadOnly = true;
			txtTongTien.Size = new Size(200, 21);
			txtTongTien.TabIndex = 7;
			// 
			// label5
			// 
			label5.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
			label5.Location = new Point(545, 101);
			label5.Name = "label5";
			label5.Size = new Size(83, 32);
			label5.TabIndex = 8;
			label5.Text = "Trạng thái:";
			// 
			// cboTrangThai
			// 
			cboTrangThai.Items.AddRange(new object[] { "Chờ xác nhận", "Đã xác nhận", "Đang giao", "Đã giao", "Đã hủy" });
			cboTrangThai.Location = new Point(686, 99);
			cboTrangThai.Name = "cboTrangThai";
			cboTrangThai.Size = new Size(200, 23);
			cboTrangThai.TabIndex = 9;
			// 
			// btnCapNhatTrangThai
			// 
			btnCapNhatTrangThai.BackColor = Color.FromArgb(41, 128, 185);
			btnCapNhatTrangThai.FlatStyle = FlatStyle.Flat;
			btnCapNhatTrangThai.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnCapNhatTrangThai.ForeColor = Color.White;
			btnCapNhatTrangThai.Image = Properties.Resources.refresh_2546743;
			btnCapNhatTrangThai.Location = new Point(590, 162);
			btnCapNhatTrangThai.Name = "btnCapNhatTrangThai";
			btnCapNhatTrangThai.Size = new Size(170, 40);
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
			btnXemChiTiet.ImageAlign = ContentAlignment.MiddleRight;
			btnXemChiTiet.Location = new Point(770, 162);
			btnXemChiTiet.Name = "btnXemChiTiet";
			btnXemChiTiet.Size = new Size(150, 40);
			btnXemChiTiet.TabIndex = 11;
			btnXemChiTiet.Text = "Xem chi tiết";
			btnXemChiTiet.TextImageRelation = TextImageRelation.ImageBeforeText;
			btnXemChiTiet.UseVisualStyleBackColor = false;
			btnXemChiTiet.Click += btnXemChiTiet_Click;
			// 
			// dgvDonHang
			// 
			dgvDonHang.BackgroundColor = Color.White;
			dgvDonHang.ColumnHeadersHeight = 34;
			dgvDonHang.Location = new Point(12, 347);
			dgvDonHang.Name = "dgvDonHang";
			dgvDonHang.RowHeadersWidth = 62;
			dgvDonHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvDonHang.Size = new Size(960, 200);
			dgvDonHang.TabIndex = 2;
			dgvDonHang.CellClick += dgvDonHang_CellClick;
			// 
			// dgvChiTiet
			// 
			dgvChiTiet.BackgroundColor = Color.White;
			dgvChiTiet.ColumnHeadersHeight = 34;
			dgvChiTiet.Location = new Point(12, 587);
			dgvChiTiet.Name = "dgvChiTiet";
			dgvChiTiet.RowHeadersWidth = 62;
			dgvChiTiet.Size = new Size(960, 140);
			dgvChiTiet.TabIndex = 4;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			label6.Location = new Point(12, 557);
			label6.Name = "label6";
			label6.Size = new Size(146, 21);
			label6.TabIndex = 3;
			label6.Text = "Chi tiết đơn hàng:";
			// 
			// FormQuanLyDonHang
			// 
			ClientSize = new Size(984, 740);
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
	}
}
