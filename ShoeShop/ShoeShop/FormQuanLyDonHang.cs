using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ShoeShop
{
    public partial class FormQuanLyDonHang : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True";

        public FormQuanLyDonHang()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT dh.MaDH, u.HoTen as TenKhachHang, dh.NgayDat, 
                                    dh.TongTien, dh.TrangThai 
                                    FROM DonHang dh 
                                    LEFT JOIN Users u ON dh.MaKH = u.U_ID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvDonHang.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnCapNhatTrangThai_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDH.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn hàng!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE DonHang SET TrangThai=@TrangThai WHERE MaDH=@MaDH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDH", int.Parse(txtMaDH.Text));
                        cmd.Parameters.AddWithValue("@TrangThai", cboTrangThai.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật trạng thái thành công!");
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDH.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn hàng!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT ct.MaCTDH, p.TenSP, ct.SoLuong, ct.DonGia, 
                                    (ct.SoLuong * ct.DonGia) as ThanhTien 
                                    FROM ChiTietDonHang ct 
                                    LEFT JOIN Products p ON ct.MaSP = p.MaSP 
                                    WHERE ct.MaDH = @MaDH";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@MaDH", int.Parse(txtMaDH.Text));
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvChiTiet.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDonHang.Rows[e.RowIndex];
                txtMaDH.Text = row.Cells["MaDH"].Value.ToString();
                txtTenKH.Text = row.Cells["TenKhachHang"].Value.ToString();
                dtpNgayDat.Value = Convert.ToDateTime(row.Cells["NgayDat"].Value);
                txtTongTien.Text = row.Cells["TongTien"].Value.ToString();
                cboTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
            }
        }

        private void FormQuanLyDonHang_Load(object sender, EventArgs e)
        {

        }
    }
}
