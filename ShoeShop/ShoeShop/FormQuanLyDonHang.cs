using _125CNX_ECommerce.Models;
using ShoeShop.DAO;
using ShoeShop.Service;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms.VisualStyles;
using System.Xml.Serialization;

namespace ShoeShop
{
	public partial class FormQuanLyDonHang : Form
	{
		private DonHangService donhangSV;
		public FormQuanLyDonHang()
		{
			InitializeComponent();
			LoadData();
		}

		private  void LoadData()
		{
			try
			{
				donhangSV = new DonHangService();
				List<DonHangModel> donhangs = donhangSV.GetAllDonHang();
				DataTable dt = new DataTable();

				// Tạo các cột giống như trong DonHangModel
				dt.Columns.Add("MaDH", typeof(int));
				dt.Columns.Add("TenKhachHang", typeof(string));
				dt.Columns.Add("NgayDat", typeof(DateTime));
				dt.Columns.Add("TongTien", typeof(decimal));
				dt.Columns.Add("TrangThai", typeof(string));

				foreach (var dh in donhangs)
				{
					dt.Rows.Add(dh.MaDH, dh.TenKhachHang, dh.NgayDat, dh.TongTien, dh.TrangThai);
				}

				dgvDonHang.DataSource = dt;
				// Auto Resize cho bảng đơn hàng
				dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
				
				// Cập nhật tiêu đề form với số lượng đơn hàng
				this.Text = $"Quản lý đơn hàng ({donhangs.Count} đơn)";
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi khi tải dữ liệu:\n{ex.Message}\n\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnCapNhatTrangThai_Click(object sender, EventArgs e)
		{
			CapNhat();
		}
		//Hàm xử lý logic khi cập nhật trạng thái
		private async void CapNhat()
		{
			if (string.IsNullOrEmpty(txtMaDH.Text))
			{
				MessageBox.Show("Vui lòng chọn đơn hàng!");
				return;
			}

			int MaDH;
			if (!int.TryParse(txtMaDH.Text, out MaDH))
			{
				MessageBox.Show("Mã đơn không hợp lệ!");
				return;
			}

			string status = cboTrangThai.Text;

			// Await vì UpdateStatus là async
			bool success = await donhangSV.UpdateStatus(MaDH, status);

			if (success)
			{
				MessageBox.Show("Cập nhật trạng thái thành công!");
				LoadData(); // reload DataGridView
			}
			else
			{
				MessageBox.Show("Cập nhật thất bại!");
			}
		}

		private void btnXemChiTiet_Click(object sender, EventArgs e)
		{
			DetailsOders();
		}
		//Hàm xử lý logic để xem chi tiết đơn hàng
		private void DetailsOders()
		{
			if (string.IsNullOrEmpty(txtMaDH.Text))
			{
				MessageBox.Show("Vui lòng chọn đơn hàng!");
				return;
			}
			//Nếu đã chọn đơn hàng
			int maDH = int.Parse(txtMaDH.Text);
			donhangSV = new DonHangService();
			ChiTietDonHangModel chitiet = donhangSV.GetChiTietByMaDH(maDH);
			DataTable dt = new DataTable();

			// Tạo các cột giống như trong DonHangModel
			dt.Columns.Add("MaCTDH", typeof(int));
			dt.Columns.Add("TenSP", typeof(string));
			dt.Columns.Add("SoLuong", typeof(int));
			dt.Columns.Add("DonGia", typeof(decimal));
			dt.Columns.Add("ThanhTien", typeof(decimal));

			dt.Rows.Add(chitiet.MaCTDH, chitiet.TenSP, chitiet.SoLuong, chitiet.DonGia, chitiet.ThanhTien);

			dgvChiTiet.DataSource = dt;
			// Auto Resize cho bảng chi tiết đơn hàng
			dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private void btnExportAsync()
		{
			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.Filter = "XML files (*.xml)|*.xml";
				sfd.Title = "Lưu file XML";
				sfd.FileName = "DonHang.xml";

				if (sfd.ShowDialog() == DialogResult.OK)
				{
					try
					{
						// Lấy dữ liệu từ service
						donhangSV = new DonHangService();
						List<DonHangModel> donhangs = donhangSV.GetAllDonHang();

						// Chuẩn hóa dữ liệu: chỉ giữ các trường đơn giản
						var exportList = new List<DonHangModel>();
						foreach (var dh in donhangs)
						{
							exportList.Add(new DonHangModel
							{
								MaDH = dh.MaDH,
								MaKH = dh.MaKH,
								NgayDat = dh.NgayDat,
								TongTien = dh.TongTien,
								TrangThai = dh.TrangThai
							});
						}

						// Serialize ra XML
						XmlSerializer serializer = new XmlSerializer(typeof(List<DonHangModel>));
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

		private void btnExport_Click(object sender, EventArgs e)
		{
			btnExportAsync();
		}

		private async void btnImportXML_Click(object sender, EventArgs e)
		{
			// Hiển thị dialog xác nhận
			DialogResult result = MessageBox.Show(
				"Bạn có chắc chắn muốn import dữ liệu từ XML vào SQL Server?\n\n" +
				"Lưu ý: Dữ liệu trùng lặp sẽ được cập nhật,\n" +
				"dữ liệu mới sẽ được thêm vào.",
				"⚠️ Xác nhận Import",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question
			);

			if (result == DialogResult.Yes)
			{
				await ImportXmlToSqlAsync();
			}
		}

		private async Task ImportXmlToSqlAsync()
		{
			try
			{
				// Thay đổi trạng thái button và cursor
				btnImportXML.Text = "📥 Đang import...";
				btnImportXML.Enabled = false;
				this.Cursor = Cursors.WaitCursor;

				// Thực hiện import
				donhangSV = new DonHangService();
				bool success = await donhangSV.ImportXmlToSql();

				if (success)
				{
					MessageBox.Show(
						"✅ Import XML vào SQL Server thành công!\n\n" +
						"Dữ liệu đã được đồng bộ từ file XML sang cơ sở dữ liệu SQL.",
						"Import thành công",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);

					// Reload dữ liệu để hiển thị thay đổi
					LoadData();
				}
				else
				{
					MessageBox.Show(
						"❌ Import thất bại!\n\n" +
						"Vui lòng kiểm tra:\n" +
						"- File XML có tồn tại không\n" +
						"- Kết nối SQL Server\n" +
						"- Cấu trúc dữ liệu",
						"Import thất bại",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error
					);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"❌ Lỗi trong quá trình import!\n\n{ex.Message}",
					"Lỗi",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
			finally
			{
				// Khôi phục trạng thái button và cursor
				btnImportXML.Text = "📥 XML → SQL";
				btnImportXML.Enabled = true;
				this.Cursor = Cursors.Default;
			}
		}
	}
}
