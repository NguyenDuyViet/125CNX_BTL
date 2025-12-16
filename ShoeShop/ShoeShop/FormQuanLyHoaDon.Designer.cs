namespace ShoeShop
{
    partial class FormQuanLyHoaDon
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelTop = new Panel();
            lblTitle = new Label();
            panelStats = new Panel();
            lblTotalAmount = new Label();
            label6 = new Label();
            lblCompletedOrders = new Label();
            label4 = new Label();
            lblTotalOrders = new Label();
            label1 = new Label();
            panelSearch = new Panel();
            cboFilter = new ComboBox();
            label3 = new Label();
            btnRefresh = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            label2 = new Label();
            btnExport = new Button();
            panelButtons = new Panel();
            btnView = new Button();
            btnDelete = new Button();
            dgvOrders = new DataGridView();
            colMaHD = new DataGridViewTextBoxColumn();
            colMaDH = new DataGridViewTextBoxColumn();
            colNgayLap = new DataGridViewTextBoxColumn();
            colTongTien = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            colPhuongThucTT = new DataGridViewTextBoxColumn();
            colTrangThaiTT = new DataGridViewTextBoxColumn();
            dgvChiTiet = new DataGridView();
            label7 = new Label();
            panelTop.SuspendLayout();
            panelStats.SuspendLayout();
            panelSearch.SuspendLayout();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(52, 152, 219);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1135, 60);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(414, 47);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ HÓA ĐƠN";
            // 
            // panelStats
            // 
            panelStats.BackColor = Color.White;
            panelStats.Controls.Add(lblTotalAmount);
            panelStats.Controls.Add(label6);
            panelStats.Controls.Add(lblCompletedOrders);
            panelStats.Controls.Add(label4);
            panelStats.Controls.Add(lblTotalOrders);
            panelStats.Controls.Add(label1);
            panelStats.Location = new Point(49, 80);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(1033, 80);
            panelStats.TabIndex = 1;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(230, 126, 34);
            lblTotalAmount.Location = new Point(660, 38);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(107, 36);
            lblTotalAmount.TabIndex = 5;
            lblTotalAmount.Text = "0 VNĐ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 11.25F);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(660, 18);
            label6.Name = "label6";
            label6.Size = new Size(167, 26);
            label6.TabIndex = 4;
            label6.Text = "Tổng doanh thu:";
            // 
            // lblCompletedOrders
            // 
            lblCompletedOrders.AutoSize = true;
            lblCompletedOrders.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold);
            lblCompletedOrders.ForeColor = Color.FromArgb(46, 204, 113);
            lblCompletedOrders.Location = new Point(410, 38);
            lblCompletedOrders.Name = "lblCompletedOrders";
            lblCompletedOrders.Size = new Size(31, 36);
            lblCompletedOrders.TabIndex = 3;
            lblCompletedOrders.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 11.25F);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(410, 18);
            label4.Name = "label4";
            label4.Size = new Size(155, 26);
            label4.TabIndex = 2;
            label4.Text = "Đã hoàn thành:";
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.AutoSize = true;
            lblTotalOrders.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold);
            lblTotalOrders.ForeColor = Color.FromArgb(52, 152, 219);
            lblTotalOrders.Location = new Point(190, 38);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(31, 36);
            lblTotalOrders.TabIndex = 1;
            lblTotalOrders.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 11.25F);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(190, 18);
            label1.Name = "label1";
            label1.Size = new Size(149, 26);
            label1.TabIndex = 0;
            label1.Text = "Tổng hóa đơn:";
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.Controls.Add(cboFilter);
            panelSearch.Controls.Add(label3);
            panelSearch.Controls.Add(btnRefresh);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(label2);
            panelSearch.Location = new Point(49, 180);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1033, 60);
            panelSearch.TabIndex = 2;
            // 
            // cboFilter
            // 
            cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilter.Font = new Font("Times New Roman", 11.25F);
            cboFilter.FormattingEnabled = true;
            cboFilter.Items.AddRange(new object[] { "Tất cả", "Đã thanh toán", "Chưa thanh toán", "Đã hủy" });
            cboFilter.Location = new Point(848, 17);
            cboFilter.Name = "cboFilter";
            cboFilter.Size = new Size(161, 34);
            cboFilter.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 11.25F);
            label3.Location = new Point(715, 20);
            label3.Name = "label3";
            label3.Size = new Size(112, 26);
            label3.TabIndex = 4;
            label3.Text = "Trạng thái:";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(149, 165, 166);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Times New Roman", 11.25F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(520, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(161, 36);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "🔄 Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(52, 152, 219);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Times New Roman", 11.25F);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(345, 16);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(96, 35);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍 Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Times New Roman", 11.25F);
            txtSearch.Location = new Point(145, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập mã hóa đơn...";
            txtSearch.Size = new Size(194, 33);
            txtSearch.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 11.25F);
            label2.Location = new Point(20, 20);
            label2.Name = "label2";
            label2.Size = new Size(108, 26);
            label2.TabIndex = 0;
            label2.Text = "Tìm kiếm:";
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(46, 204, 113);
            btnExport.Cursor = Cursors.Hand;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Times New Roman", 11.25F);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(260, 11);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(239, 40);
            btnExport.TabIndex = 6;
            btnExport.Text = "📊 Xuất XML";
            btnExport.UseVisualStyleBackColor = false;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnExport);
            panelButtons.Controls.Add(btnView);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Location = new Point(49, 260);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1033, 60);
            panelButtons.TabIndex = 3;
            // 
            // btnView
            // 
            btnView.BackColor = Color.FromArgb(155, 89, 182);
            btnView.Cursor = Cursors.Hand;
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnView.ForeColor = Color.White;
            btnView.Location = new Point(750, 12);
            btnView.Name = "btnView";
            btnView.Size = new Size(246, 40);
            btnView.TabIndex = 3;
            btnView.Text = "👁️ Xem chi tiết";
            btnView.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(550, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(141, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor = Color.White;
            dgvOrders.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle3.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvOrders.ColumnHeadersHeight = 40;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { colMaHD, colMaDH, colNgayLap, colTongTien, colTrangThai, colPhuongThucTT, colTrangThaiTT });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvOrders.DefaultCellStyle = dataGridViewCellStyle4;
            dgvOrders.EnableHeadersVisualStyles = false;
            dgvOrders.Location = new Point(49, 340);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowHeadersWidth = 62;
            dgvOrders.RowTemplate.Height = 35;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(1033, 210);
            dgvOrders.TabIndex = 4;
            // 
            // colMaHD
            // 
            colMaHD.FillWeight = 60F;
            colMaHD.HeaderText = "Mã HĐ";
            colMaHD.MinimumWidth = 8;
            colMaHD.Name = "colMaHD";
            colMaHD.ReadOnly = true;
            // 
            // colMaDH
            // 
            colMaDH.FillWeight = 60F;
            colMaDH.HeaderText = "Mã ĐH";
            colMaDH.MinimumWidth = 8;
            colMaDH.Name = "colMaDH";
            colMaDH.ReadOnly = true;
            // 
            // colNgayLap
            // 
            colNgayLap.HeaderText = "Ngày lập";
            colNgayLap.MinimumWidth = 8;
            colNgayLap.Name = "colNgayLap";
            colNgayLap.ReadOnly = true;
            // 
            // colTongTien
            // 
            colTongTien.HeaderText = "Tổng tiền";
            colTongTien.MinimumWidth = 8;
            colTongTien.Name = "colTongTien";
            colTongTien.ReadOnly = true;
            // 
            // colTrangThai
            // 
            colTrangThai.HeaderText = "Trạng thái HĐ";
            colTrangThai.MinimumWidth = 8;
            colTrangThai.Name = "colTrangThai";
            colTrangThai.ReadOnly = true;
            // 
            // colPhuongThucTT
            // 
            colPhuongThucTT.FillWeight = 120F;
            colPhuongThucTT.HeaderText = "Phương thức TT";
            colPhuongThucTT.MinimumWidth = 8;
            colPhuongThucTT.Name = "colPhuongThucTT";
            colPhuongThucTT.ReadOnly = true;
            // 
            // colTrangThaiTT
            // 
            colTrangThaiTT.HeaderText = "Trạng thái TT";
            colTrangThaiTT.MinimumWidth = 8;
            colTrangThaiTT.Name = "colTrangThaiTT";
            colTrangThaiTT.ReadOnly = true;
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.BackgroundColor = SystemColors.ButtonHighlight;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Location = new Point(49, 613);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.RowHeadersWidth = 62;
            dgvChiTiet.Size = new Size(1033, 118);
            dgvChiTiet.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 13F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(52, 73, 94);
            label7.Location = new Point(49, 579);
            label7.Name = "label7";
            label7.Size = new Size(207, 30);
            label7.TabIndex = 7;
            label7.Text = "Chi tiết hoá đơn:";
            // 
            // FormQuanLyHoaDon
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1135, 763);
            Controls.Add(label7);
            Controls.Add(dgvChiTiet);
            Controls.Add(dgvOrders);
            Controls.Add(panelButtons);
            Controls.Add(panelSearch);
            Controls.Add(panelStats);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "FormQuanLyHoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Hóa đơn";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelStats.ResumeLayout(false);
            panelStats.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCompletedOrders;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvOrders;
		private DataGridViewTextBoxColumn colMaHD;
		private DataGridViewTextBoxColumn colMaDH;
		private DataGridViewTextBoxColumn colNgayLap;
		private DataGridViewTextBoxColumn colTongTien;
		private DataGridViewTextBoxColumn colTrangThai;
		private DataGridViewTextBoxColumn colPhuongThucTT;
		private DataGridViewTextBoxColumn colTrangThaiTT;
		private DataGridView dgvChiTiet;
		private Label label7;
	}
}
