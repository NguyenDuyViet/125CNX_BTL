using _125CNX_ECommerce.Models;
using ShoeShop.Service;
using System.Data;
using System.Xml.Serialization;

namespace ShoeShop
{
	public partial class FormQuanLyKhachHang : Form
	{
		private UserService usv;
		private List<UsersModel> users;

		public FormQuanLyKhachHang()
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
				dt.Columns.Add("Mã KH", typeof(int));
				dt.Columns.Add("Họ tên", typeof(string));
				dt.Columns.Add("Địa chỉ", typeof(string));
				dt.Columns.Add("Số điện thoại", typeof(string));
				dt.Columns.Add("Email", typeof(string));
				dt.Columns.Add("Tên đăng nhập", typeof(string));

				foreach (var u in users)
				{
					if (u.RoleID == 3)
						dt.Rows.Add(
							u.U_ID,
							u.HoTen,
							u.DiaChi,
							u.SDT,
							u.Email,
							u.TenDangNhap
						);
				}

				dgvKhachHang.DataSource = dt;
				dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
				MessageBox.Show("Vui lòng nhập họ tên!", "Cảnh báo");
				return false;
			}
			if (string.IsNullOrWhiteSpace(txtSDT.Text))
			{
				MessageBox.Show("Vui lòng nhập số điện thoại!", "Cảnh báo");
				return false;
			}
			if (string.IsNullOrWhiteSpace(txtEmail.Text))
			{
				MessageBox.Show("Vui lòng nhập email!", "Cảnh báo");
				return false;
			}
			if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
			{
				MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Cảnh báo");
				return false;
			}
			return true;
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			if (!ValidateInput()) return;

			if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
			{
				MessageBox.Show("Vui lòng nhập mật khẩu!", "Cảnh báo");
				return;
			}

			AddUser();
		}

		private async Task AddUser()
		{
			try
			{
				usv = new UserService();

				UsersModel user = new UsersModel
				{
					HoTen = txtHoTen.Text.Trim(),
					DiaChi = txtDiaChi.Text.Trim(),
					SDT = txtSDT.Text.Trim(),
					Email = txtEmail.Text.Trim(),
					RoleID = 3, // KHÁCH HÀNG = 3
					TenDangNhap = txtTenDangNhap.Text.Trim(),
					MatKhau = txtMatKhau.Text.Trim(),
					ChucVu = "Khách hàng"
				};

				bool success = await usv.AddUser(user);

				if (success)
				{
					MessageBox.Show("Thêm khách hàng thành công!", "Thành công");
					await LoadData();
					ClearInputs();
				}
				else
				{
					MessageBox.Show("Thêm thất bại!", "Lỗi");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
			}
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtMaKH.Text))
			{
				MessageBox.Show("Vui lòng chọn khách hàng cần sửa!");
				return;
			}

			if (!ValidateInput()) return;

			UpdateUser();
		}

		private async Task UpdateUser()
		{
			try
			{
				usv = new UserService();

				UsersModel user = new UsersModel
				{
					U_ID = int.Parse(txtMaKH.Text),
					HoTen = txtHoTen.Text.Trim(),
					DiaChi = txtDiaChi.Text.Trim(),
					SDT = txtSDT.Text.Trim(),
					Email = txtEmail.Text.Trim(),
					RoleID = 3,
					TenDangNhap = txtTenDangNhap.Text.Trim(),
					MatKhau = txtMatKhau.Text.Trim(),
					ChucVu = "Khách hàng"
				};

				bool success = await usv.UpdateUser(user);

				if (success)
				{
					MessageBox.Show("Cập nhật thành công!", "Thành công");
					LoadData();
					ClearInputs();
				}
				else
				{
					MessageBox.Show("Cập nhật thất bại!", "Lỗi");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
			}
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtMaKH.Text))
			{
				MessageBox.Show("Vui lòng chọn khách hàng cần xóa!");
				return;
			}

			if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận",
				MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				DeleteUser();
			}
		}

		private async Task DeleteUser()
		{
			try
			{
				usv = new UserService();

				bool success = await usv.DeleteUser(int.Parse(txtMaKH.Text));

				if (success)
				{
					MessageBox.Show("Xóa thành công!", "Thành công");
					LoadData();
					ClearInputs();
				}
				else
				{
					MessageBox.Show("Xóa thất bại!", "Lỗi");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message);
			}
		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			try
			{
				string keyword = txtTimKiem.Text.Trim().ToLower();

				if (string.IsNullOrEmpty(keyword))
				{
					LoadData();
					return;
				}

				var result = users.Where(u =>
					   u.RoleID == 3 &&
					  (u.U_ID.ToString().Contains(keyword)
					|| u.HoTen.ToLower().Contains(keyword)
					|| u.DiaChi.ToLower().Contains(keyword)
					|| u.SDT.ToLower().Contains(keyword)
					|| u.Email.ToLower().Contains(keyword)
					|| u.TenDangNhap.ToLower().Contains(keyword))
				).ToList();

				dgvKhachHang.DataSource = result;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message);
			}
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

		private void btnLamMoi_Click(object sender, EventArgs e)
		{
			LoadData();
			ClearInputs();
			txtTimKiem.Clear();
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
				sfd.FileName = "KhachHang.xml";

				if (sfd.ShowDialog() == DialogResult.OK)
				{
					try
					{
						usv = new UserService();
						List<UsersModel> allUsers = await usv.GetAllUsers();

						var listExport = allUsers
							.Where(u => u.RoleID == 3)
							.Select(u => new UsersModel
							{
								U_ID = u.U_ID,
								HoTen = u.HoTen,
								DiaChi = u.DiaChi,
								SDT = u.SDT,
								Email = u.Email,
								TenDangNhap = u.TenDangNhap,
								MatKhau = "********",
								ChucVu = "Khách hàng"
							}).ToList();

						XmlSerializer serializer = new XmlSerializer(typeof(List<UsersModel>));
						using (var writer = new StreamWriter(sfd.FileName))
						{
							serializer.Serialize(writer, listExport);
						}

						MessageBox.Show("Xuất XML thành công!", "Thông báo");
					}
					catch (Exception ex)
					{
						MessageBox.Show("Lỗi: " + ex.Message);
					}
				}
			}
		}
	}
}