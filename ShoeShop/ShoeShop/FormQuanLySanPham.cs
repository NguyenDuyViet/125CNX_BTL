using _125CNX_ECommerce.Models;
using ShoeShop.DAO;
using ShoeShop.Service;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ShoeShop
{
	public partial class FormQuanLySanPham : Form
	{
		private string selectedImagePath = "";
		private ProductService pds;
		private List<ProductModel> products = new List<ProductModel>();
		private List<CategoriesModel> categories = new List<CategoriesModel>();


		public FormQuanLySanPham()
		{
			InitializeComponent();
			// Đăng ký sự kiện form load/Shown để await async tasks
			this.Shown += async (s, e) =>
			{
				await LoadCategoriesAsync();   // load danh mục trước (để cbo có dữ liệu)
				await LoadData();             // load sản phẩm
				FormatDataGridView();        // chỉ format style, không format cột giá ở đây
			};

			// Đăng ký DataBindingComplete để áp format sau khi DataSource bind xong
			dgvSanPham.DataBindingComplete += DgvSanPham_DataBindingComplete;
		}

		private void DgvSanPham_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			FormatMoneyColumn();
		}

		#region Load Data
		private async Task LoadData()
		{
			try
			{
				pds = new ProductService();
				products = await pds.GetAllProduct();

				ShowToGrid(products);
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

		private async Task LoadCategoriesAsync()
		{
			try
			{
				pds = new ProductService();
				categories = await pds.GetAllCategories();
				DataTable dt = new DataTable();

				// Tạo cột
				dt.Columns.Add("C_ID", typeof(int));
				dt.Columns.Add("C_Name", typeof(string));

				//Lấy danh mục hiển thị lên datagridview
				foreach (var ct in categories)
				{
					dt.Rows.Add(ct.C_ID, ct.C_Name);
				}
				cboLoaiSP.DataSource = dt;

				cboLoaiSP.DisplayMember = "C_Name";
				cboLoaiSP.ValueMember = "C_ID";
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
			decimal gia = ParseGiaFromText(txtGia.Text);

			if (string.IsNullOrWhiteSpace(txtGia.Text) || gia <= 0)
			{
				MessageBox.Show("Vui lòng nhập giá hợp lệ!", "Cảnh báo",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
				var raw = row.Cells["Giá"].Value;

				if (raw != null && decimal.TryParse(raw.ToString(), out decimal value))
				{
					txtGia.Text = value.ToString("N0", new CultureInfo("vi-VN")) + " VNĐ";
				}
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

		//format money
		private void FormatMoneyColumn()
		{
			if (dgvSanPham.Columns.Contains("Giá"))
			{
				var col = dgvSanPham.Columns["Giá"];
				col.DefaultCellStyle.Format = "N0";
				col.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("vi-VN");
				col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			}
		}

		//Format Giá khi đưa vào model
		private decimal ParseGiaFromText(string text)
		{
			if (string.IsNullOrWhiteSpace(text))
				return 0m;

			// 1. Xóa đơn vị tiền
			string raw = text.Replace("VNĐ", "", StringComparison.OrdinalIgnoreCase)
							 .Replace("VND", "", StringComparison.OrdinalIgnoreCase)
							 .Replace("₫", "")
							 .Trim();

			// 2. Xóa dấu cách
			raw = raw.Replace(" ", "");

			// 3. Kiểm tra dạng số "1.234.567" hoặc "1,234,567"
			if (raw.Contains(".") && raw.Contains(","))
			{
				int lastDot = raw.LastIndexOf('.');
				int lastComma = raw.LastIndexOf(',');

				if (lastComma > lastDot)
				{
					// "," là thập phân → bỏ tất cả "." (ngàn)
					raw = raw.Replace(".", "");
				}
				else
				{
					// "." là thập phân → bỏ tất cả ","
					raw = raw.Replace(",", "");
					raw = raw.Replace(".", ",");
				}
			}
			else
			{
				if (raw.Contains(".") && !raw.Contains(","))
				{
					// Nếu sau dấu "." có 3 chữ số → là phân cách ngàn
					int lastDot = raw.LastIndexOf('.');
					if (raw.Length - lastDot - 1 == 3)
					{
						raw = raw.Replace(".", "");
					}
					else
					{
						raw = raw.Replace(".", ",");
					}
				}
			}
			// 4. Parse theo chuẩn Việt Nam
			if (decimal.TryParse(raw, System.Globalization.NumberStyles.Number,
				new System.Globalization.CultureInfo("vi-VN"), out decimal value))
			{
				return value;
			}

			return 0m;
		}


		private void ShowToGrid(List<ProductModel> list)
		{
			DataTable dt = new DataTable();

			dt.Columns.Add("Mã SP", typeof(int));
			dt.Columns.Add("Tên sản phẩm", typeof(string));
			dt.Columns.Add("Loại SP", typeof(string));
			dt.Columns.Add("Kích cỡ", typeof(string));
			dt.Columns.Add("Màu sắc", typeof(string));
			dt.Columns.Add("Giá", typeof(decimal));
			dt.Columns.Add("Số lượng", typeof(int));
			dt.Columns.Add("Images", typeof(string));

			foreach (var pd in list)
			{
				string cateName = categories.FirstOrDefault(c => c.C_ID == pd.C_ID)?.C_Name ?? pd.C_ID.ToString();

				dt.Rows.Add(
					pd.MaSP,
					pd.TenSP,
					cateName,   // nếu muốn hiển thị tên loại
					pd.KichCo,
					pd.MauSac,
					pd.Gia,
					pd.SoLuong,
					pd.Images
				);
			}

			dgvSanPham.DataSource = dt;

			if (dgvSanPham.Columns["Images"] != null)
				dgvSanPham.Columns["Images"].Visible = false;
		}
		#endregion

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

		#region CRUD
		private void btnThem_Click(object sender, EventArgs e)
		{
			if (!ValidateInput()) return;

			ProductModel product = new ProductModel();
			product.TenSP = txtTenSP.Text.Trim();
			product.C_ID = int.Parse(cboLoaiSP.SelectedValue.ToString());
			product.KichCo = txtKichCo.Text.Trim();
			product.MauSac = txtMauSac.Text.Trim();
			product.Gia = ParseGiaFromText(txtGia.Text);
			product.SoLuong = int.Parse(txtSoLuong.Text);
			product.Images = txtImages.Text;

			AddProduct(product);
		}

		private async Task AddProduct(ProductModel pdm)
		{
			try
			{
				Boolean success = await pds.AddProduct(pdm);

				if (success)
				{
					MessageBox.Show("Thêm sản phẩm thành công!", "Thành công",
						MessageBoxButtons.OK, MessageBoxIcon.Information);

					LoadData();
					ClearInputs();
				}
				else
					MessageBox.Show("Thêm sản phẩm thất bại!", "Thất bại",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				MessageBox.Show("Vui lòng nhập mã sản phẩm!", "Cảnh báo",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (!ValidateInput()) return;

			ProductModel product = new ProductModel();
			product.MaSP = int.Parse(txtMaSP.Text);
			product.TenSP = txtTenSP.Text.Trim();
			product.C_ID = int.Parse(cboLoaiSP.SelectedValue.ToString());
			product.KichCo = txtKichCo.Text.Trim();
			product.MauSac = txtMauSac.Text.Trim();
			product.Gia = ParseGiaFromText(txtGia.Text);
			product.SoLuong = int.Parse(txtSoLuong.Text);
			product.Images = txtImages.Text;

			UpdateProduct(product);
		}

		private async Task UpdateProduct(ProductModel pdm)
		{
			try
			{
				Boolean success = await pds.UpdateProduct(pdm);

				if (success)
				{
					MessageBox.Show("Cập nhật sản phẩm thành công!", "Thành công",
						MessageBoxButtons.OK, MessageBoxIcon.Information);

					LoadData();
					ClearInputs();
				}
				else
					MessageBox.Show("Cập nhật sản phẩm thất bại!", "Thất bại",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
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
					DeleteProduct(int.Parse(txtMaSP.Text.ToString()));
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		public async Task DeleteProduct(int MaSP)
		{
			Boolean success = await pds.DeleteProduct(MaSP);

			if (success)
			{
				MessageBox.Show("Xóa thành công!", "Thành công",
				MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadData();
				ClearInputs();
			}
			else MessageBox.Show("Có lỗi khi xoá sản phẩm!", "Thất bại",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		#endregion

		#region Search
		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			try
			{
				string key = txtTimKiem.Text.Trim().ToLower();

				Search(key);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async Task Search(String keyword)
		{
			if (products == null) return;

			decimal searchGia = -1;
			bool isNumber = decimal.TryParse(keyword.Replace("VNĐ", "").Trim(),
				System.Globalization.NumberStyles.Number,
				new System.Globalization.CultureInfo("vi-VN"), out searchGia);

			var filtered = products.Where(p =>
				(!string.IsNullOrEmpty(p.TenSP) && p.TenSP.ToLower().Contains(keyword)) ||
				(!string.IsNullOrEmpty(p.MauSac) && p.MauSac.ToLower().Contains(keyword)) ||
				p.C_ID.ToString().Contains(keyword) ||
				(isNumber && p.Gia == searchGia) ||
				(!isNumber && p.Gia.ToString("N0", new System.Globalization.CultureInfo("vi-VN")).Contains(keyword))
			).ToList();

			ShowToGrid(filtered);
		}
		#endregion

		#region Xuất XMl
		private void btnExportXML_Click(object sender, EventArgs e)
		{
			// TODO: Xuất dữ liệu ra XML
			try
			{
				if (dgvSanPham.Rows.Count == 0)
				{
					MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
						MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				ExportAsyncXML();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi khi xuất XML: {ex.Message}", "Lỗi",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		//Hàm export ra XML
		private async void ExportAsyncXML()
		{
			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.Filter = "XML files (*.xml)|*.xml";
				sfd.Title = "Lưu file XML";
				sfd.FileName = "SanPham.xml";

				if (sfd.ShowDialog() == DialogResult.OK)
				{
					try
					{
						// Lấy dữ liệu từ service
						pds = new ProductService();
						List<ProductModel> hds = await pds.GetAllProduct();

						// Chuẩn hóa dữ liệu: chỉ giữ các trường đơn giản
						var exportList = new List<ProductModel>();
						foreach (var pd in hds)
						{
							exportList.Add(new ProductModel
							{
								MaSP = pd.MaSP,
								TenSP = pd.TenSP,
								C_ID = pd.C_ID,
								KichCo = pd.KichCo,
								MauSac = pd.MauSac,
								Gia = pd.Gia,
								SoLuong = pd.SoLuong,
								Images = pd.Images
							});
						}

						// Serialize ra XML
						XmlSerializer serializer = new XmlSerializer(typeof(List<ProductModel>));
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
		#endregion

		#region Import XML to SQL
		private async void btnImportXML_Click(object sender, EventArgs e)
		{
			try
			{
				// Hiển thị dialog xác nhận
				DialogResult result = MessageBox.Show(
					"Bạn có chắc chắn muốn import dữ liệu từ XML vào SQL Server?\n\n" +
					"Lưu ý: Dữ liệu trùng lặp sẽ được cập nhật, dữ liệu mới sẽ được thêm vào.",
					"Xác nhận Import",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);

				if (result != DialogResult.Yes)
					return;

				// Hiển thị progress
				this.Cursor = Cursors.WaitCursor;
				
				// Disable button để tránh click nhiều lần
				var button = sender as Button;
				if (button != null)
				{
					button.Enabled = false;
					button.Text = "Đang import...";
				}

				// Thực hiện import
				pds = new ProductService();
				bool success = await pds.ImportXmlToSql();

				if (success)
				{
					MessageBox.Show(
						"Import XML vào SQL Server thành công!\n\n" +
						"Dữ liệu đã được đồng bộ từ file XML sang cơ sở dữ liệu SQL.",
						"Import thành công",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					// Reload data để hiển thị kết quả
					await LoadData();
				}
				else
				{
					MessageBox.Show(
						"Import thất bại!\n\n" +
						"Vui lòng kiểm tra:\n" +
						"- File XML có tồn tại không\n" +
						"- Kết nối SQL Server\n" +
						"- Cấu trúc dữ liệu",
						"Import thất bại",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Lỗi khi import XML vào SQL:\n\n{ex.Message}",
					"Lỗi",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				// Restore UI
				this.Cursor = Cursors.Default;
				
				var button = sender as Button;
				if (button != null)
				{
					button.Enabled = true;
					button.Text = "Import XML → SQL";
				}
			}
		}
		#endregion

	}
}
