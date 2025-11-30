using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ShoeShop
{
    public partial class FormQuanLySanPham : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True";
        private string selectedImagePath = "";

        public FormQuanLySanPham()
        {
            InitializeComponent();
            LoadData();
            LoadCategories();
            FormatDataGridView();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT p.MaSP as 'Mã SP', p.TenSP as 'Tên sản phẩm', c.C_Name as 'Loại SP', 
                                    p.KichCo as 'Kích cỡ', p.MauSac as 'Màu sắc', 
                                    p.Gia as 'Giá', p.SoLuong as 'Số lượng', p.Images 
                                    FROM Products p 
                                    LEFT JOIN Categories c ON p.C_ID = c.C_ID
                                    ORDER BY p.MaSP DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvSanPham.DataSource = dt;

                    if (dgvSanPham.Columns["Images"] != null)
                    {
                        dgvSanPham.Columns["Images"].Visible = false;
                    }
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
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.MultiSelect = false;
            dgvSanPham.ReadOnly = true;
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            dgvSanPham.BorderStyle = BorderStyle.None;
            dgvSanPham.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            dgvSanPham.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dgvSanPham.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            dgvSanPham.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvSanPham.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            dgvSanPham.EnableHeadersVisualStyles = false;
        }

        private void LoadCategories()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT C_ID, C_Name FROM Categories";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cboLoaiSP.DataSource = dt;
                    cboLoaiSP.DisplayMember = "C_Name";
                    cboLoaiSP.ValueMember = "C_ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.Focus();
                return false;
            }
            if (cboLoaiSP.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtGia.Text) || !decimal.TryParse(txtGia.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập giá hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGia.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || !int.TryParse(txtSoLuong.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return false;
            }
            return true;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Chọn ảnh sản phẩm";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                    txtImages.Text = selectedImagePath;

                    try
                    {
                        picPreview.Image = System.Drawing.Image.FromFile(selectedImagePath);
                        picPreview.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi load ảnh: " + ex.Message);
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Products (TenSP, C_ID, KichCo, MauSac, Gia, SoLuong, Images) 
                                   VALUES (@TenSP, @C_ID, @KichCo, @MauSac, @Gia, @SoLuong, @Images)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text.Trim());
                        cmd.Parameters.AddWithValue("@C_ID", cboLoaiSP.SelectedValue);
                        cmd.Parameters.AddWithValue("@KichCo", txtKichCo.Text.Trim());
                        cmd.Parameters.AddWithValue("@MauSac", txtMauSac.Text.Trim());
                        cmd.Parameters.AddWithValue("@Gia", decimal.Parse(txtGia.Text));
                        cmd.Parameters.AddWithValue("@SoLuong", int.Parse(txtSoLuong.Text));
                        cmd.Parameters.AddWithValue("@Images", txtImages.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm sản phẩm thành công!", "Thành công",
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
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE Products SET TenSP=@TenSP, C_ID=@C_ID, KichCo=@KichCo, 
                                   MauSac=@MauSac, Gia=@Gia, SoLuong=@SoLuong, Images=@Images 
                                   WHERE MaSP=@MaSP";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSP", int.Parse(txtMaSP.Text));
                        cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text.Trim());
                        cmd.Parameters.AddWithValue("@C_ID", cboLoaiSP.SelectedValue);
                        cmd.Parameters.AddWithValue("@KichCo", txtKichCo.Text.Trim());
                        cmd.Parameters.AddWithValue("@MauSac", txtMauSac.Text.Trim());
                        cmd.Parameters.AddWithValue("@Gia", decimal.Parse(txtGia.Text));
                        cmd.Parameters.AddWithValue("@SoLuong", int.Parse(txtSoLuong.Text));
                        cmd.Parameters.AddWithValue("@Images", txtImages.Text);
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
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa sản phẩm '{txtTenSP.Text}'?",
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
                        string query = "DELETE FROM Products WHERE MaSP=@MaSP";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", int.Parse(txtMaSP.Text));
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
                    string query = @"SELECT p.MaSP as 'Mã SP', p.TenSP as 'Tên sản phẩm', c.C_Name as 'Loại SP', 
                                    p.KichCo as 'Kích cỡ', p.MauSac as 'Màu sắc', 
                                    p.Gia as 'Giá', p.SoLuong as 'Số lượng', p.Images 
                                    FROM Products p 
                                    LEFT JOIN Categories c ON p.C_ID = c.C_ID
                                    WHERE p.TenSP LIKE @Search OR p.MauSac LIKE @Search OR c.C_Name LIKE @Search";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" + txtTimKiem.Text + "%");
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvSanPham.DataSource = dt;

                    if (dgvSanPham.Columns["Images"] != null)
                    {
                        dgvSanPham.Columns["Images"].Visible = false;
                    }
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

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["Mã SP"].Value.ToString();
                txtTenSP.Text = row.Cells["Tên sản phẩm"].Value.ToString();

                string loaiSP = row.Cells["Loại SP"].Value.ToString();
                for (int i = 0; i < cboLoaiSP.Items.Count; i++)
                {
                    DataRowView item = (DataRowView)cboLoaiSP.Items[i];
                    if (item["C_Name"].ToString() == loaiSP)
                    {
                        cboLoaiSP.SelectedIndex = i;
                        break;
                    }
                }

                txtKichCo.Text = row.Cells["Kích cỡ"].Value.ToString();
                txtMauSac.Text = row.Cells["Màu sắc"].Value.ToString();
                txtGia.Text = row.Cells["Giá"].Value.ToString();
                txtSoLuong.Text = row.Cells["Số lượng"].Value.ToString();
                txtImages.Text = row.Cells["Images"].Value?.ToString();

                // Load preview image
                if (!string.IsNullOrEmpty(txtImages.Text))
                {
                    try
                    {
                        if (File.Exists(txtImages.Text))
                        {
                            picPreview.Image = System.Drawing.Image.FromFile(txtImages.Text);
                        }
                        else if (txtImages.Text.StartsWith("http"))
                        {
                            picPreview.Load(txtImages.Text);
                        }
                        picPreview.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch
                    {
                        picPreview.Image = null;
                    }
                }
            }
        }

        private void ClearInputs()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtKichCo.Clear();
            txtMauSac.Clear();
            txtGia.Clear();
            txtSoLuong.Clear();
            txtImages.Clear();
            cboLoaiSP.SelectedIndex = -1;
            picPreview.Image = null;
            selectedImagePath = "";
        }

        private void FormQuanLySanPham_Load(object sender, EventArgs e)
        {

        }
    }
}
