using _125CNX_ECommerce.Models;
using ShoeShop.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ShoeShop
{
    public partial class FormQuanLyNhanVien : Form
    {
        private UserService usv;
        private List<UsersModel> users;

        public FormQuanLyNhanVien()
        {
            InitializeComponent();
            LoadData();
            FormatDataGridView();
        }

        private async Task LoadData()
        {
            try
            {
                usv = new UserService();
                users = await usv.GetAllUsers();

				DataTable dt = new DataTable();
				dt.Columns.Add("Mã NV", typeof(int));
				dt.Columns.Add("Họ tên", typeof(string));
				dt.Columns.Add("Địa chỉ", typeof(string));
				dt.Columns.Add("Số điện thoại", typeof(string));
				dt.Columns.Add("Email", typeof(string));
				dt.Columns.Add("Chức vụ", typeof(string));
				dt.Columns.Add("Tên đăng nhập", typeof(string));

				foreach (var u in users)
				{
					if(u.RoleID == 2 || u.RoleID == 4)
						dt.Rows.Add(
							u.U_ID,
							u.HoTen,
							u.DiaChi,
							u.SDT,
							u.Email,
							u.ChucVu,
							u.TenDangNhap
						);
				}

				dgvNhanVien.DataSource = dt;

				// Auto Resize cho bảng Nhân viên
				dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			}
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối database: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.BackgroundColor = System.Drawing.Color.White;
            dgvNhanVien.BorderStyle = BorderStyle.None;
            dgvNhanVien.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(230, 126, 34);
            dgvNhanVien.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            dgvNhanVien.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            dgvNhanVien.EnableHeadersVisualStyles = false;
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
            if (cboChucVu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chức vụ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChucVu.Focus();
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

            AddUser();
        }

        private async Task AddUser()
        {
			try
			{
				int roleID = cboChucVu.Text == "Quản lý" ? 4 : 2;

				UsersModel user = new UsersModel();
				usv = new UserService();

				user.HoTen = txtHoTen.Text.Trim();
				user.DiaChi = txtDiaChi.Text.Trim();
				user.SDT = txtSDT.Text.Trim();
				user.Email = txtEmail.Text.Trim();
				user.RoleID = roleID;
				user.TenDangNhap = txtTenDangNhap.Text.Trim();
				user.MatKhau = txtMatKhau.Text.Trim();
				user.ChucVu = cboChucVu.Text;

				bool success = await usv.AddUser(user);

				if (success)
				{
					MessageBox.Show("Thêm thành công!", "Thành công",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadData();
					ClearInputs();
				}
				else MessageBox.Show("Thêm thất bại!", "Thất bại",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
        //Sửa thông tin
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            UpdateUser();
        }

        private async Task UpdateUser()
        {
			try
			{
				int roleID = cboChucVu.Text == "Quản lý" ? 4 : 2;

				UsersModel user = new UsersModel();
                usv = new UserService();

				user.U_ID = int.Parse(txtMaNV.Text);
				user.HoTen = txtHoTen.Text.Trim();
				user.DiaChi = txtDiaChi.Text.Trim();
				user.SDT = txtSDT.Text.Trim();
				user.Email = txtEmail.Text.Trim();
				user.RoleID = roleID;
				user.TenDangNhap = txtTenDangNhap.Text.Trim();
                user.MatKhau = txtMatKhau.Text.Trim();
				user.ChucVu = cboChucVu.Text;

                bool success = await usv.UpdateUser(user);

                if (success)
                {
					MessageBox.Show("Cập nhật thành công!", "Thành công",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadData();
					ClearInputs();
				}
                else MessageBox.Show("Cập nhật thất bại!", "Thất bại",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa nhân viên '{txtHoTen.Text}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DeleteUser();
            }
        }

        private async Task DeleteUser()
        {
			try
			{
				int UID = int.Parse(txtMaNV.Text);
                usv = new UserService();

                bool success = await usv.DeleteUser(UID);

                if (success)
                {
					MessageBox.Show("Xóa thành công!", "Thành công",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadData();
					ClearInputs();
				}
				else MessageBox.Show("Có lỗi khi xoá nhân viên!", "Thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
			try
			{
				string keyword = txtTimKiem.Text.Trim().ToLower();

				// Nếu không nhập gì → trả lại toàn bộ danh sách
				if (string.IsNullOrEmpty(keyword))
				{
					dgvNhanVien.DataSource = users;
					return;
				}

				var result = users.Where(user =>
					   user.U_ID.ToString().Contains(keyword)
					|| user.HoTen.ToLower().Contains(keyword)
					|| user.DiaChi.ToLower().Contains(keyword)
					|| user.SDT.ToLower().Contains(keyword)
					|| user.Email.ToLower().Contains(keyword)
					|| user.ChucVu.ToLower().Contains(keyword)
					|| user.TenDangNhap.ToLower().Contains(keyword)
				).ToList();

				dgvNhanVien.DataSource = result;

				// Auto Resize cho bảng Nhân viên
				dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearInputs();
            txtTimKiem.Clear();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["Mã NV"].Value.ToString();
                txtHoTen.Text = row.Cells["Họ tên"].Value.ToString();
                txtDiaChi.Text = row.Cells["Địa chỉ"].Value.ToString();
                txtSDT.Text = row.Cells["Số điện thoại"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                cboChucVu.Text = row.Cells["Chức vụ"].Value?.ToString();
                txtTenDangNhap.Text = row.Cells["Tên đăng nhập"].Value.ToString();
                txtMatKhau.Clear();
            }
        }

        private void ClearInputs()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboChucVu.SelectedIndex = -1;
        }
        private void btnExportXML_Click(object sender, EventArgs e)
        {
            ExportAsyncXML();
        }

		private async void ExportAsyncXML()
		{
			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.Filter = "XML files (*.xml)|*.xml";
				sfd.Title = "Lưu file XML";
				sfd.FileName = "NhanVien.xml";

				if (sfd.ShowDialog() == DialogResult.OK)
				{
					try
					{
						// Lấy dữ liệu từ service
						usv = new UserService();
						List<UsersModel> users = await usv.GetAllUsers();

						// Chuẩn hóa dữ liệu: chỉ giữ các trường đơn giản
						var exportList = new List<UsersModel>();
						foreach (var u in users)
						{
                            if(u.RoleID == 2 || u.RoleID == 4) 
                                exportList.Add(new UsersModel
							    {
                                    U_ID = u.U_ID,
                                    HoTen = u.HoTen,
                                    DiaChi = u.DiaChi,
                                    SDT = u.SDT,
                                    Email = u.Email,
                                    RoleID = u.RoleID,
                                    TenDangNhap = u.TenDangNhap,
                                    MatKhau = "********",
                                    ChucVu = u.ChucVu
							    });
						}

						// Serialize ra XML
						XmlSerializer serializer = new XmlSerializer(typeof(List<UsersModel>));
						using (var writer = new StreamWriter(sfd.FileName))
						{
							serializer.Serialize(writer, exportList);
						}

						// Hiển thị DataGridView (tùy chọn)
						LoadData();

						MessageBox.Show("Xuất XML thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch (Exception ex)
					{
						MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
	}
}
