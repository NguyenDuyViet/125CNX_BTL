using _125CNX_ECommerce.Models;
using ShoeShop.Service;

namespace ShoeShop
{
	public partial class FormThongKe : Form
	{
		private readonly DonHangService _donHangService;

		private List<DonHangModel> dsDonHang;
		private List<(int Month, decimal Revenue)> doanhThuTheoThang;
		private List<(string Category, int Count)> thongKeSanPham;

		public FormThongKe()
		{
			InitializeComponent();
			_donHangService = new DonHangService();
		}

		// ====================================
		// LOAD FORM (ASYNC)
		// ====================================
		private async void FormThongKe_Load(object sender, EventArgs e)
		{
			await LoadData();
		}

		// ====================================
		// LOAD TẤT CẢ DỮ LIỆU
		// ====================================
		private async Task LoadData()
		{
			// 1. LẤY ĐƠN HÀNG (async)
			dsDonHang = await _donHangService.GetAllDonHang();

			if (dsDonHang == null)
			{
				MessageBox.Show("Không thể load dữ liệu đơn hàng");
				return;
			}

			// 2. LOAD THỐNG KÊ
			await LoadStatistics();

			// 3. BUILD DATA CHO BIỂU ĐỒ
			BuildRevenueChartData();
			await BuildProductChartData();

			// 4. VẼ
			panelRevenueChart.Invalidate();
			panelProductChart.Invalidate();
		}

		// ====================================
		// 1. THỐNG KÊ
		// ====================================
		private async Task LoadStatistics()
		{
			try
			{
				decimal totalRevenue = dsDonHang
					.Where(d => d.TrangThai == "Đã giao")
					.Sum(d => d.TongTien);

				lblTotalRevenue.Text = $"{totalRevenue:N0} VNĐ";
				lblTotalOrders.Text = dsDonHang.Count.ToString();
				lblTotalCustomers.Text = dsDonHang.Select(x => x.MaKH).Distinct().Count().ToString();

				int tongSP = 0;

				foreach (var dh in dsDonHang)
				{
					var ct = await _donHangService.GetChiTietByMaDH(dh.MaDH);
					tongSP += ct?.SoLuong ?? 0;
				}

				lblTotalProducts.Text = tongSP.ToString();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi thống kê: " + ex.Message);
			}
		}

		// ====================================
		// 2. BIỂU ĐỒ DOANH THU THEO THÁNG
		// ====================================
		private void BuildRevenueChartData()
		{
			doanhThuTheoThang = Enumerable.Range(1, 12)
				.Select(month =>
				(
					Month: month,
					Revenue: dsDonHang
						.Where(d =>
							d.NgayDat.Month == month &&
							d.NgayDat.Year == DateTime.Now.Year &&
							d.TrangThai == "Đã giao")
						.Sum(d => d.TongTien)
				))
				.ToList();
		}

		// ====================================
		// 3. BIỂU ĐỒ SẢN PHẨM BÁN CHẠY
		// ====================================
		private async Task BuildProductChartData()
		{
			var categoryCount = new Dictionary<string, int>();

			foreach (var dh in dsDonHang)
			{
				var ct = await _donHangService.GetChiTietByMaDH(dh.MaDH);

				if (ct == null) continue;

				string loai = ct.TenSP ?? "Khác";

				if (!categoryCount.ContainsKey(loai))
					categoryCount[loai] = 0;

				categoryCount[loai] += ct.SoLuong;
			}

			thongKeSanPham = categoryCount
				.OrderByDescending(x => x.Value)
				.Take(5)
				.Select(x => (x.Key, x.Value))
				.ToList();
		}

		// ====================================
		// VẼ BIỂU ĐỒ
		// ====================================
		private void PanelRevenueChart_Paint(object sender, PaintEventArgs e)
		{
			if (doanhThuTheoThang == null)
			{
				DrawNoData(e.Graphics, panelRevenueChart);
				return;
			}

			DrawBarChart(e.Graphics, panelRevenueChart, doanhThuTheoThang);
		}

		private void PanelProductChart_Paint(object sender, PaintEventArgs e)
		{
			if (thongKeSanPham == null)
			{
				DrawNoData(e.Graphics, panelProductChart);
				return;
			}

			DrawPieChart(e.Graphics, panelProductChart, thongKeSanPham);
		}

		// ====================================
		// CÁC HÀM VẼ (GIỮ NGUYÊN LOGIC)
		// ====================================
		private void DrawBarChart(Graphics g, Panel pnl, List<(int Month, decimal Revenue)> data)
		{
			if (data.Count == 0) return;

			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			int leftPadding = 40;
			int bottomPadding = 30;
			int topPadding = 20;

			float maxValue = (float)data.Max(v => v.Revenue);
			if (maxValue == 0) maxValue = 1;

			int barWidth = (pnl.Width - leftPadding - 20) / 12 - 5;
			int chartHeight = pnl.Height - bottomPadding - topPadding;

			Brush barBrush = new SolidBrush(Color.FromArgb(52, 152, 219));
			Pen axisPen = new Pen(Color.Black, 1.4f);

			// trục
			g.DrawLine(axisPen, leftPadding, topPadding, leftPadding, pnl.Height - bottomPadding);
			g.DrawLine(axisPen, leftPadding, pnl.Height - bottomPadding, pnl.Width - 10, pnl.Height - bottomPadding);

			for (int i = 0; i < data.Count; i++)
			{
				float value = (float)data[i].Revenue;
				float ratio = value / maxValue;

				int barHeight = (int)(ratio * chartHeight);

				int x = leftPadding + (i * (barWidth + 5));
				int y = (pnl.Height - bottomPadding) - barHeight;

				g.FillRectangle(barBrush, x, y, barWidth, barHeight);

				// tháng
				g.DrawString(data[i].Month.ToString(), new Font("Times New Roman", 9), Brushes.Black, x + barWidth / 2 - 6, pnl.Height - bottomPadding + 5);

				// giá trị
				if (barHeight > 15)
				{
					g.DrawString($"{data[i].Revenue:N0}", new Font("Times New Roman", 9),
						Brushes.Black, x, y - 15);
				}
			}
		}

		private void DrawPieChart(Graphics g, Panel pnl, List<(string Category, int Count)> data)
		{
			if (data.Count == 0) return;

			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			int total = data.Sum(x => x.Count);

			// 1) Biểu đồ tròn
			int diameter = Math.Min(pnl.Width - 40, pnl.Height - 160);
			if (diameter < 40) diameter = 40;

			int centerX = (pnl.Width - diameter) / 2;
			int centerY = (pnl.Height - diameter) / 2 - 60;

			Rectangle rect = new Rectangle(centerX, centerY, diameter, diameter);

			Color[] colors =
			{
				Color.FromArgb(231, 76, 60),
				Color.FromArgb(46, 204, 113),
				Color.FromArgb(52, 152, 219),
				Color.FromArgb(155, 89, 182),
				Color.FromArgb(241, 196, 15),
				Color.FromArgb(230, 126, 34)
			};

			float startAngle = 0;

			// Vẽ pie
			for (int i = 0; i < data.Count; i++)
			{
				float sweep = ((float)data[i].Count / total) * 360f;
				using (Brush b = new SolidBrush(colors[i % colors.Length]))
				{
					g.FillPie(b, rect, startAngle, sweep);
				}
				startAngle += sweep;
			}

			// 2) Vẽ legend không giới hạn hàng, không chạm nhau
			// ======== LEGEND AUTO-WRAP =========
			int legendY = rect.Bottom + 20;
			int boxSize = 14;
			Font font = new Font("Times New Roman", 10);

			int x = 20;                      // điểm bắt đầu mỗi dòng
			int y = legendY;
			int maxWidth = pnl.Width - 40;   // lề trái + phải = 20px mỗi bên

			for (int i = 0; i < data.Count; i++)
			{
				string text = $"{data[i].Category} ({data[i].Count})";

				// đo chiều rộng item
				int itemWidth = (int)g.MeasureString(text, font).Width + boxSize + 8;

				// nếu vượt panel → xuống hàng
				if (x + itemWidth > maxWidth)
				{
					x = 20;         // reset về đầu dòng
					y += 28;        // xuống hàng 28px
				}

				// vẽ ô màu
				using (Brush b = new SolidBrush(colors[i % colors.Length]))
					g.FillRectangle(b, x, y, boxSize, boxSize);

				// vẽ chữ
				g.DrawString(text, font, Brushes.Black, x + boxSize + 6, y - 1);

				// tăng x cho item tiếp theo
				x += itemWidth + 15;
			}
		}

		private void DrawNoData(Graphics g, Panel pnl)
		{
			g.DrawString("Không có dữ liệu", new Font("Times New Roman", 10),
				Brushes.Gray, pnl.Width / 2 - 70, pnl.Height / 2);
		}

		private async void btnRefresh_Click(object sender, EventArgs e)
		{
			await LoadData();
		}
	}
}
