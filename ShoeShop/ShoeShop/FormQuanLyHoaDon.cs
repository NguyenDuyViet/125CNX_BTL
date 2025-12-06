using _125CNX_ECommerce.Models;
using ShoeShop.Service;
using System;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ShoeShop
{
	public partial class FormQuanLyHoaDon : Form
	{
		private HoaDonService hoadonSV;
		private List<HoaDonModel> hoadons;
		public FormQuanLyHoaDon()
		{
			InitializeComponent();
			dgvOrders.DataBindingComplete += DgvOrders_DataBindingComplete;
			hoadonSV = new HoaDonService();
			// Đăng ký các sự kiện
			this.Load += FormQuanLyHoaDon_Load;
			this.btnSearch.Click += btnSearch_Click;
			this.btnRefresh.Click += btnRefresh_Click;
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
		private async Task LoadData()
		{
			try
			{
				dgvOrders.AutoGenerateColumns = true;
				dgvOrders.DataSource = null;
				dgvOrders.Columns.Clear();
				dgvOrders.Rows.Clear();


				hoadons = await hoadonSV.GetAllHoaDon();
				DataTable dt = new DataTable();

				//Truyền dữ liệu đúng từng cột
				dt.Columns.Add("MaHD", typeof(int));
				dt.Columns.Add("MaDH", typeof(int));
				dt.Columns.Add("NgayLap", typeof(DateTime));
				dt.Columns.Add("TongTien", typeof(decimal));
				dt.Columns.Add("TrangThai", typeof(string));
				dt.Columns.Add("PhuongThucTT", typeof(string));
				dt.Columns.Add("TrangThaiTT", typeof(string));

				foreach (var hd in hoadons)
				{
					dt.Rows.Add(hd.MaHD, hd.MaDH, hd.NgayLap, hd.TongTien, hd.TrangThai, hd.PhuongThucTT, hd.TrangThaiTT);
				}

				dgvOrders.DataSource = dt;

				// Auto Resize cho bảng hoá đơn
				dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			}catch(Exception ex)
			{
				MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async Task LoadStatistics()
		{
			try
			{
				int total = 0, payed = 0;
				decimal totalPrice = 0;

				hoadons = await hoadonSV.GetAllHoaDon();

				foreach (var hd in hoadons)
				{
					if (hd.TrangThai.Trim().ToLower() == "đã thanh toán") 
						payed ++;
					totalPrice += hd.TongTien;
				}
				// Tổng số hóa đơn
				lblTotalOrders.Text = hoadons.Count().ToString();

				// Đơn hàng đã thanh toán
				lblCompletedOrders.Text = payed.ToString();

				// Tổng doanh thu
				lblTotalAmount.Text = totalPrice.ToString("N0") + " VNĐ";
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

		private void DgvOrders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			if (dgvOrders.Columns.Contains("TongTien"))
			{
				var cul = new CultureInfo("vi-VN");
				dgvOrders.Columns["TongTien"].DefaultCellStyle.FormatProvider = cul;
				dgvOrders.Columns["TongTien"].DefaultCellStyle.Format = "#,##0 '₫'";
			}

			if (dgvChiTiet.Columns.Contains("DonGia"))
			{
				var cul = new CultureInfo("vi-VN");
				dgvChiTiet.Columns["TongTien"].DefaultCellStyle.FormatProvider = cul;
				dgvChiTiet.Columns["TongTien"].DefaultCellStyle.Format = "#,##0 '₫'";
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

			SearchHoaDon(keyword);
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

			FilterByPayment(status);
		}

		//Hàm tìm kiếm theo từ khoá
		private async Task SearchHoaDon(string keyword)
		{
			keyword = keyword.ToLower();

			hoadons = await hoadonSV.GetAllHoaDon();

			var filtered = hoadons.Where(hd =>
				hd.MaHD.ToString().Contains(keyword) ||
				hd.MaDH.ToString().Contains(keyword) ||
				hd.TrangThai.ToLower().Contains(keyword) ||
				hd.PhuongThucTT.ToLower().Contains(keyword) ||
				hd.TrangThaiTT.ToLower().Contains(keyword)
			).ToList();

			Load_SearchKeyword(filtered);
			await LoadStatistics();
		}

		//Hàm tìm kiếm theo trạng thái thanh toán
		private async Task FilterByPayment(string status)
		{
			List<HoaDonModel> filtered;
			hoadons = await hoadonSV.GetAllHoaDon();

			if (status == "Tất cả")
				filtered = hoadons;
			else
				filtered = hoadons.Where(hd => hd.TrangThai == status).ToList();

			Load_SearchKeyword(filtered);
			await LoadStatistics();
		}

		//Hàm load data khi tìm kiếm
		private void Load_SearchKeyword(List<HoaDonModel> filtered)
		{
			try
			{
				dgvOrders.AutoGenerateColumns = true;
				dgvOrders.DataSource = null;
				dgvOrders.Columns.Clear();
				dgvOrders.Rows.Clear();

				DataTable dt = new DataTable();

				//Truyền dữ liệu đúng từng cột
				dt.Columns.Add("MaHD", typeof(int));
				dt.Columns.Add("MaDH", typeof(int));
				dt.Columns.Add("NgayLap", typeof(DateTime));
				dt.Columns.Add("TongTien", typeof(decimal));
				dt.Columns.Add("TrangThai", typeof(string));
				dt.Columns.Add("PhuongThucTT", typeof(string));
				dt.Columns.Add("TrangThaiTT", typeof(string));

				foreach (var hd in filtered)
				{
					dt.Rows.Add(hd.MaHD, hd.MaDH, hd.NgayLap, hd.TongTien, hd.TrangThai, hd.PhuongThucTT, hd.TrangThaiTT);
				}

				dgvOrders.DataSource = dt;
				// Auto Resize cho bảng hoá đơn
				dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Thao tác CRUD

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
				int maHD = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["MaHD"].Value);


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

			int maHD = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["MaHD"].Value);

			DetailsInvoice(maHD);
		}

		//Hàm xử lý logic để xem chi tiết hoá đơn
		private async void DetailsInvoice(int MaHD)
		{
			hoadonSV = new HoaDonService();
			ChiTietHoaDonModel chitiet = await hoadonSV.GetChiTietByMaHD(MaHD);
			DataTable dt = new DataTable();

			// Tạo các cột giống như trong HoaDonModel
			dt.Columns.Add("MaCTHD", typeof(int));
			dt.Columns.Add("MaHD", typeof(int));
			dt.Columns.Add("MaSP", typeof(int));
			dt.Columns.Add("SoLuong", typeof(int));
			dt.Columns.Add("DonGia", typeof(decimal));

			dt.Rows.Add(chitiet.MaCTHD, chitiet.MaHD, chitiet.MaSP, chitiet.SoLuong, chitiet.DonGia);

			dgvChiTiet.DataSource = dt;

			// Format tiền
			var culture = new CultureInfo("vi-VN");
			dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "#,##0 ₫";
			dgvChiTiet.Columns["DonGia"].DefaultCellStyle.FormatProvider = culture;

			// Auto Resize cho bảng chi tiết hoá đơn
			dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

		#region Xuất XML
		private void btnExport_Click(object sender, EventArgs e)
		{
			// TODO: Xuất dữ liệu ra XML
			try
			{
				if (dgvOrders.Rows.Count == 0)
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
				sfd.FileName = "HoaDon.xml";

				if (sfd.ShowDialog() == DialogResult.OK)
				{
					try
					{
						// Lấy dữ liệu từ service
						hoadonSV = new HoaDonService();
						List<HoaDonModel> hds = await hoadonSV.GetAllHoaDon();

						// Chuẩn hóa dữ liệu: chỉ giữ các trường đơn giản
						var exportList = new List<HoaDonModel>();
						foreach (var hd in hds)
						{
							exportList.Add(new HoaDonModel
							{
								MaHD = hd.MaHD,
								MaDH = hd.MaDH,
								NgayLap = hd.NgayLap,
								TongTien = hd.TongTien,
								TrangThai = hd.TrangThai
							});
						}

						// Serialize ra XML
						XmlSerializer serializer = new XmlSerializer(typeof(List<HoaDonModel>));
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
	}
}