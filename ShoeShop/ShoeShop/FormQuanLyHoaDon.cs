using System;
using System.Windows.Forms;

namespace ShoeShop
{
    public partial class FormQuanLyHoaDon : Form
    {
        public FormQuanLyHoaDon()
        {
            InitializeComponent();

            // Đăng ký các sự kiện
            this.Load += FormQuanLyHoaDon_Load;
            this.btnSearch.Click += btnSearch_Click;
            this.btnRefresh.Click += btnRefresh_Click;
            this.btnAdd.Click += btnAdd_Click;
            this.btnEdit.Click += btnEdit_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.btnView.Click += btnView_Click;
            this.btnExport.Click += btnExport_Click;
            this.cboFilter.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
            this.dgvOrders.CellDoubleClick += dgvOrders_CellDoubleClick;
        }

        #region Form Load
        private void FormQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            // TODO: Khởi tạo form
            LoadData();
            LoadStatistics();
            cboFilter.SelectedIndex = 0; // Chọn "Tất cả"
        }
        #endregion

        #region Load dữ liệu
        private void LoadData()
        {
            try
            {
                dgvOrders.Rows.Clear();

                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(
                    "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True"))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            hd.MaHD,
                            hd.MaDH,
                            hd.NgayLap,
                            hd.TongTien,
                            hd.TrangThai,
                            ISNULL(tt.PhuongThuc, N'Chưa thanh toán') AS PhuongThucTT,
                            ISNULL(tt.TrangThai, N'') AS TrangThaiTT
                        FROM HoaDon hd
                        LEFT JOIN ThanhToan tt ON hd.MaHD = tt.MaHD
                        ORDER BY hd.NgayLap DESC
                    ";

                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn))
                    {
                        using (System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgvOrders.Rows.Add(
                                    reader["MaHD"],
                                    reader["MaDH"],
                                    Convert.ToDateTime(reader["NgayLap"]).ToString("dd/MM/yyyy"),
                                    string.Format("{0:N0} VNĐ", reader["TongTien"]),
                                    reader["TrangThai"],
                                    reader["PhuongThucTT"],
                                    reader["TrangThaiTT"]
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatistics()
        {
            try
            {
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(
                    "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True"))
                {
                    conn.Open();

                    // Tổng số hóa đơn
                    string queryTotal = "SELECT COUNT(*) FROM HoaDon";
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(queryTotal, conn))
                    {
                        lblTotalOrders.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Đơn hàng đã thanh toán
                    string queryCompleted = "SELECT COUNT(*) FROM HoaDon WHERE TrangThai = N'Đã thanh toán'";
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(queryCompleted, conn))
                    {
                        lblCompletedOrders.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Tổng doanh thu
                    string queryRevenue = "SELECT ISNULL(SUM(TongTien), 0) FROM HoaDon WHERE TrangThai = N'Đã thanh toán'";
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(queryRevenue, conn))
                    {
                        decimal total = Convert.ToDecimal(cmd.ExecuteScalar());
                        lblTotalAmount.Text = string.Format("{0:N0} VNĐ", total);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTotalOrders.Text = "0";
                lblCompletedOrders.Text = "0";
                lblTotalAmount.Text = "0 VNĐ";
            }
        }
        #endregion

        #region Tìm kiếm và lọc
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                dgvOrders.Rows.Clear();

                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(
                    "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True"))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            hd.MaHD,
                            hd.MaDH,
                            hd.NgayLap,
                            hd.TongTien,
                            hd.TrangThai,
                            ISNULL(tt.PhuongThuc, N'Chưa thanh toán') AS PhuongThucTT,
                            ISNULL(tt.TrangThai, N'') AS TrangThaiTT
                        FROM HoaDon hd
                        LEFT JOIN ThanhToan tt ON hd.MaHD = tt.MaHD
                        WHERE hd.MaHD LIKE @Keyword OR hd.MaDH LIKE @Keyword
                        ORDER BY hd.NgayLap DESC
                    ";

                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                        using (System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgvOrders.Rows.Add(
                                    reader["MaHD"],
                                    reader["MaDH"],
                                    Convert.ToDateTime(reader["NgayLap"]).ToString("dd/MM/yyyy"),
                                    string.Format("{0:N0} VNĐ", reader["TongTien"]),
                                    reader["TrangThai"],
                                    reader["PhuongThucTT"],
                                    reader["TrangThaiTT"]
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboFilter.SelectedIndex = 0;
            LoadData();
            LoadStatistics();
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = cboFilter.SelectedItem?.ToString();

            if (status == "Tất cả")
            {
                LoadData();
                return;
            }

            try
            {
                dgvOrders.Rows.Clear();

                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(
                    "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True"))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            hd.MaHD,
                            hd.MaDH,
                            hd.NgayLap,
                            hd.TongTien,
                            hd.TrangThai,
                            ISNULL(tt.PhuongThuc, N'Chưa thanh toán') AS PhuongThucTT,
                            ISNULL(tt.TrangThai, N'') AS TrangThaiTT
                        FROM HoaDon hd
                        LEFT JOIN ThanhToan tt ON hd.MaHD = tt.MaHD
                        WHERE hd.TrangThai = @TrangThai
                        ORDER BY hd.NgayLap DESC
                    ";

                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TrangThai", status);

                        using (System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgvOrders.Rows.Add(
                                    reader["MaHD"],
                                    reader["MaDH"],
                                    Convert.ToDateTime(reader["NgayLap"]).ToString("dd/MM/yyyy"),
                                    string.Format("{0:N0} VNĐ", reader["TongTien"]),
                                    reader["TrangThai"],
                                    reader["PhuongThucTT"],
                                    reader["TrangThaiTT"]
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Thao tác CRUD
        private void btnAdd_Click(object sender, EventArgs e)
        {
        
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
        
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần chỉnh sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

      
            int maHD = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["colMaHD"].Value);

           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // TODO: Xóa hóa đơn
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa hóa đơn này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int maHD = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["colMaHD"].Value);


                MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                LoadStatistics();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            // TODO: Xem chi tiết hóa đơn
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xem!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHD = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["colMaHD"].Value);

           
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Double click để xem chi tiết
            if (e.RowIndex >= 0)
            {
                btnView_Click(sender, e);
            }
        }
        #endregion

        #region Xuất Excel
        private void btnExport_Click(object sender, EventArgs e)
        {
            // TODO: Xuất dữ liệu ra Excel
            try
            {
                if (dgvOrders.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

              

                MessageBox.Show("Chức năng xuất XML đang được phát triển!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất XML: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void FormQuanLyHoaDon_Load_1(object sender, EventArgs e)
        {

        }
    }
}