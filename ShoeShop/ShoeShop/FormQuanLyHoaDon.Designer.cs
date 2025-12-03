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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            btnExport = new Button();
            cboFilter = new ComboBox();
            label3 = new Label();
            btnRefresh = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            label2 = new Label();
            panelButtons = new Panel();
            btnView = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            dgvOrders = new DataGridView();
            colMaHD = new DataGridViewTextBoxColumn();
            colMaDH = new DataGridViewTextBoxColumn();
            colNgayLap = new DataGridViewTextBoxColumn();
            colTongTien = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            colPhuongThucTT = new DataGridViewTextBoxColumn();
            colTrangThaiTT = new DataGridViewTextBoxColumn();
            panelTop.SuspendLayout();
            panelStats.SuspendLayout();
            panelSearch.SuspendLayout();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(52, 152, 219);
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
            lblTitle.Size = new Size(356, 48);
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
            panelStats.Location = new Point(29, 133);
            panelStats.Margin = new Padding(4, 5, 4, 5);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(1657, 133);
            panelStats.TabIndex = 1;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(230, 126, 34);
            lblTotalAmount.Location = new Point(714, 67);
            lblTotalAmount.Margin = new Padding(4, 0, 4, 0);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(117, 45);
            lblTotalAmount.TabIndex = 5;
            lblTotalAmount.Text = "0 VNĐ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(714, 33);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(156, 28);
            label6.TabIndex = 4;
            label6.Text = "Tổng doanh thu:";
            // 
            // lblCompletedOrders
            // 
            lblCompletedOrders.AutoSize = true;
            lblCompletedOrders.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCompletedOrders.ForeColor = Color.FromArgb(46, 204, 113);
            lblCompletedOrders.Location = new Point(357, 67);
            lblCompletedOrders.Margin = new Padding(4, 0, 4, 0);
            lblCompletedOrders.Name = "lblCompletedOrders";
            lblCompletedOrders.Size = new Size(38, 45);
            lblCompletedOrders.TabIndex = 3;
            lblCompletedOrders.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(357, 33);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(144, 28);
            label4.TabIndex = 2;
            label4.Text = "Đã hoàn thành:";
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.AutoSize = true;
            lblTotalOrders.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalOrders.ForeColor = Color.FromArgb(52, 152, 219);
            lblTotalOrders.Location = new Point(43, 67);
            lblTotalOrders.Margin = new Padding(4, 0, 4, 0);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(38, 45);
            lblTotalOrders.TabIndex = 1;
            lblTotalOrders.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(43, 33);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(139, 28);
            label1.TabIndex = 0;
            label1.Text = "Tổng hóa đơn:";
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.Controls.Add(btnExport);
            panelSearch.Controls.Add(cboFilter);
            panelSearch.Controls.Add(label3);
            panelSearch.Controls.Add(btnRefresh);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(label2);
            panelSearch.Location = new Point(29, 300);
            panelSearch.Margin = new Padding(4, 5, 4, 5);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1657, 100);
            panelSearch.TabIndex = 2;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(46, 204, 113);
            btnExport.Cursor = Cursors.Hand;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 10F);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(1314, 25);
            btnExport.Margin = new Padding(4, 5, 4, 5);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(171, 50);
            btnExport.TabIndex = 6;
            btnExport.Text = "📊 Xuất XML";
            btnExport.UseVisualStyleBackColor = false;
            // 
            // cboFilter
            // 
            cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilter.Font = new Font("Segoe UI", 10F);
            cboFilter.FormattingEnabled = true;
            cboFilter.Items.AddRange(new object[] { "Tất cả", "Đã thanh toán", "Chưa thanh toán", "Đã hủy" });
            cboFilter.Location = new Point(1057, 28);
            cboFilter.Margin = new Padding(4, 5, 4, 5);
            cboFilter.Name = "cboFilter";
            cboFilter.Size = new Size(213, 36);
            cboFilter.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(943, 33);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(102, 28);
            label3.TabIndex = 4;
            label3.Text = "Trạng thái:";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(149, 165, 166);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(743, 25);
            btnRefresh.Margin = new Padding(4, 5, 4, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(143, 50);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "🔄 Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(52, 152, 219);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(600, 25);
            btnSearch.Margin = new Padding(4, 5, 4, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 50);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍 Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(143, 28);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập mã hóa đơn...";
            txtSearch.Size = new Size(427, 34);
            txtSearch.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(29, 33);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(95, 28);
            label2.TabIndex = 0;
            label2.Text = "Tìm kiếm:";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnView);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Location = new Point(29, 433);
            panelButtons.Margin = new Padding(4, 5, 4, 5);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1657, 100);
            panelButtons.TabIndex = 3;
            // 
            // btnView
            // 
            btnView.BackColor = Color.FromArgb(155, 89, 182);
            btnView.Cursor = Cursors.Hand;
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnView.ForeColor = Color.White;
            btnView.Location = new Point(1029, 17);
            btnView.Margin = new Padding(4, 5, 4, 5);
            btnView.Name = "btnView";
            btnView.Size = new Size(200, 67);
            btnView.TabIndex = 3;
            btnView.Text = "👁️ Xem chi tiết";
            btnView.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(829, 17);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(171, 67);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(52, 152, 219);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(629, 17);
            btnEdit.Margin = new Padding(4, 5, 4, 5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(171, 67);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "✏️ Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(429, 17);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(171, 67);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "➕ Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor = Color.White;
            dgvOrders.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvOrders.ColumnHeadersHeight = 40;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { colMaHD, colMaDH, colNgayLap, colTongTien, colTrangThai, colPhuongThucTT, colTrangThaiTT });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvOrders.DefaultCellStyle = dataGridViewCellStyle2;
            dgvOrders.EnableHeadersVisualStyles = false;
            dgvOrders.Location = new Point(29, 567);
            dgvOrders.Margin = new Padding(4, 5, 4, 5);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowHeadersWidth = 62;
            dgvOrders.RowTemplate.Height = 35;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(1657, 567);
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
            // FormQuanLyHoaDon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1714, 1167);
            Controls.Add(dgvOrders);
            Controls.Add(panelButtons);
            Controls.Add(panelSearch);
            Controls.Add(panelStats);
            Controls.Add(panelTop);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormQuanLyHoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Hóa đơn";
            Load += FormQuanLyHoaDon_Load_1;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelStats.ResumeLayout(false);
            panelStats.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);

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
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhuongThucTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThaiTT;
    }
}
