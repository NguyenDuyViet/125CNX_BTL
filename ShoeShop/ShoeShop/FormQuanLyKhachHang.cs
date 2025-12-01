using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ShoeShop
{
    public partial class FormQuanLyKhachHang : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True";

        public FormQuanLyKhachHang()
        {
            InitializeComponent();
            LoadData();
            FormatDataGridView();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT U_ID as 'Mã KH', HoTen as 'Họ tên', DiaChi as 'Địa chỉ', 
                                    SDT as 'Số điện thoại', Email, TenDangNhap as 'Tên đăng nhập' 
                                    FROM Users WHERE RoleID = 3 ORDER BY U_ID DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvKhachHang.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối database: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.MultiSelect = false;
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.RowHeadersVisible = false;
            dgvKhachHang.BackgroundColor = System.Drawing.Color.White;
            dgvKhachHang.BorderStyle = BorderStyle.None;
            dgvKhachHang.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            dgvKhachHang.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dgvKhachHang.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            dgvKhachHang.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvKhachHang.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            dgvKhachHang.EnableHeadersVisualStyles = false;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Users (HoTen, DiaChi, SDT, Email, RoleID, TenDangNhap, MatKhau) 
                                   VALUES (@HoTen, @DiaChi, @SDT, @Email, 3, @TenDangNhap, @MatKhau)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@TenDangNhap", txtTenDangNhap.Text.Trim());
                        cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm khách hàng thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearInputs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE Users SET HoTen=@HoTen, DiaChi=@DiaChi, SDT=@SDT, 
                                   Email=@Email, TenDangNhap=@TenDangNhap WHERE U_ID=@U_ID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@U_ID", int.Parse(txtMaKH.Text));
                        cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@TenDangNhap", txtTenDangNhap.Text.Trim());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearInputs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa khách hàng '{txtHoTen.Text}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Users WHERE U_ID=@U_ID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@U_ID", int.Parse(txtMaKH.Text));
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Xóa thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearInputs();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT U_ID as 'Mã KH', HoTen as 'Họ tên', DiaChi as 'Địa chỉ', 
                                    SDT as 'Số điện thoại', Email, TenDangNhap as 'Tên đăng nhập' 
                                    FROM Users 
                                    WHERE RoleID = 3 AND (HoTen LIKE @Search OR SDT LIKE @Search OR Email LIKE @Search)";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" + txtTimKiem.Text + "%");
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvKhachHang.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearInputs();
            txtTimKiem.Clear();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["Mã KH"].Value.ToString();
                txtHoTen.Text = row.Cells["Họ tên"].Value.ToString();
                txtDiaChi.Text = row.Cells["Địa chỉ"].Value.ToString();
                txtSDT.Text = row.Cells["Số điện thoại"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtTenDangNhap.Text = row.Cells["Tên đăng nhập"].Value.ToString();
                txtMatKhau.Clear();
            }
        }

        private void ClearInputs()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
        }

        private void FormQuanLyKhachHang_Load(object sender, EventArgs e)
        {

        }
    }
}
