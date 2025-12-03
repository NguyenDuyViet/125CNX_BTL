using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ShoeShop
{
    public partial class FormThongKe : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True";

        public FormThongKe()
        {
            InitializeComponent();
            LoadStatistics();
            LoadRevenueChart();
            LoadProductChart();
        }

        private void LoadStatistics()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tổng doanh thu
                    string queryRevenue = "SELECT ISNULL(SUM(TongTien), 0) FROM DonHang WHERE TrangThai = N'Đã giao'";
                    using (SqlCommand cmd = new SqlCommand(queryRevenue, conn))
                    {
                        decimal revenue = Convert.ToDecimal(cmd.ExecuteScalar());
                        lblTotalRevenue.Text = string.Format("{0:N0} VNĐ", revenue);
                    }

                    // Tổng đơn hàng
                    string queryOrders = "SELECT COUNT(*) FROM DonHang";
                    using (SqlCommand cmd = new SqlCommand(queryOrders, conn))
                    {
                        lblTotalOrders.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Tổng sản phẩm
                    string queryProducts = "SELECT COUNT(*) FROM Products";
                    using (SqlCommand cmd = new SqlCommand(queryProducts, conn))
                    {
                        lblTotalProducts.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Tổng khách hàng
                    string queryCustomers = "SELECT COUNT(*) FROM Users WHERE RoleID = 3";
                    using (SqlCommand cmd = new SqlCommand(queryCustomers, conn))
                    {
                        lblTotalCustomers.Text = cmd.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRevenueChart()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            MONTH(NgayDat) as Thang,
                            SUM(TongTien) as DoanhThu
                        FROM DonHang
                        WHERE YEAR(NgayDat) = YEAR(GETDATE()) AND TrangThai = N'Đã giao'
                        GROUP BY MONTH(NgayDat)
                        ORDER BY MONTH(NgayDat)
                    ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int month = Convert.ToInt32(reader["Thang"]);
                                decimal revenue = Convert.ToDecimal(reader["DoanhThu"]);
                                // Dữ liệu sẽ được vẽ trong sự kiện Paint
                            }
                        }
                    }
                }
                panelRevenueChart.Invalidate(); // Vẽ lại biểu đồ
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải biểu đồ doanh thu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductChart()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT TOP 5
                            c.C_Name as LoaiSP,
                            COUNT(p.MaSP) as SoLuong
                        FROM Products p
                        JOIN Categories c ON p.C_ID = c.C_ID
                        GROUP BY c.C_Name
                        ORDER BY COUNT(p.MaSP) DESC
                    ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Dữ liệu sẽ được vẽ trong sự kiện Paint
                            }
                        }
                    }
                }
                panelProductChart.Invalidate(); // Vẽ lại biểu đồ
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải biểu đồ sản phẩm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PanelRevenueChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            MONTH(NgayDat) as Thang,
                            SUM(TongTien) as DoanhThu
                        FROM DonHang
                        WHERE YEAR(NgayDat) = YEAR(GETDATE()) AND TrangThai = N'Đã giao'
                        GROUP BY MONTH(NgayDat)
                        ORDER BY MONTH(NgayDat)
                    ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Tạo mảng 12 tháng với giá trị 0
                            var monthlyData = new decimal[12];
                            for (int i = 0; i < 12; i++)
                            {
                                monthlyData[i] = 0;
                            }

                            // Điền dữ liệu từ database
                            while (reader.Read())
                            {
                                int month = Convert.ToInt32(reader["Thang"]);
                                decimal revenue = Convert.ToDecimal(reader["DoanhThu"]);
                                monthlyData[month - 1] = revenue;
                            }

                            // Chuyển thành list
                            var data = new System.Collections.Generic.List<(int Month, decimal Revenue)>();
                            for (int i = 0; i < 12; i++)
                            {
                                data.Add((i + 1, monthlyData[i]));
                            }

                            DrawBarChart(g, panelRevenueChart, data);
                        }
                    }
                }
            }
            catch
            {
                DrawNoDataMessage(g, panelRevenueChart, "Lỗi khi tải dữ liệu");
            }
        }

        private void DrawBarChart(Graphics g, Panel panel, System.Collections.Generic.List<(int Month, decimal Revenue)> data)
        {
            int padding = 60;
            int topPadding = 55;
            int bottomPadding = 45;
            int chartWidth = panel.Width - padding * 2;
            int chartHeight = panel.Height - topPadding - bottomPadding;
            
            if (data.Count == 0) return;
            
            int barWidth = (chartWidth / data.Count) - 10;
            if (barWidth < 15) barWidth = 15;
            if (barWidth > 50) barWidth = 50;

            decimal maxRevenue = 0;
            foreach (var item in data)
            {
                if (item.Revenue > maxRevenue) maxRevenue = item.Revenue;
            }

            if (maxRevenue == 0) maxRevenue = 1000000; // Giá trị mặc định

            // Vẽ tiêu đề
            Font titleFont = new Font("Segoe UI", 13, FontStyle.Bold);
            string title = "Doanh thu theo tháng (năm " + DateTime.Now.Year + ")";
            SizeF titleSize = g.MeasureString(title, titleFont);
            g.DrawString(title, titleFont, new SolidBrush(Color.FromArgb(44, 62, 80)), 
                (panel.Width - titleSize.Width) / 2, 15);

            // Vẽ trục
            Pen axisPen = new Pen(Color.FromArgb(189, 195, 199), 2);
            g.DrawLine(axisPen, padding, topPadding + chartHeight, 
                padding + chartWidth, topPadding + chartHeight); // Trục X
            g.DrawLine(axisPen, padding, topPadding, 
                padding, topPadding + chartHeight); // Trục Y

            // Vẽ các cột
            Color[] colors = {
                Color.FromArgb(52, 152, 219),
                Color.FromArgb(46, 204, 113),
                Color.FromArgb(155, 89, 182),
                Color.FromArgb(230, 126, 34),
                Color.FromArgb(231, 76, 60),
                Color.FromArgb(26, 188, 156),
                Color.FromArgb(52, 73, 94),
                Color.FromArgb(241, 196, 15),
                Color.FromArgb(149, 165, 166),
                Color.FromArgb(192, 57, 43),
                Color.FromArgb(142, 68, 173),
                Color.FromArgb(39, 174, 96)
            };

            for (int i = 0; i < data.Count; i++)
            {
                int barHeight = (int)((double)data[i].Revenue / (double)maxRevenue * chartHeight);
                if (barHeight < 3 && data[i].Revenue > 0) barHeight = 3; // Chiều cao tối thiểu nếu có dữ liệu
                
                int x = padding + i * (chartWidth / data.Count) + 5;
                int y = topPadding + chartHeight - barHeight;

                using (SolidBrush brush = new SolidBrush(colors[i % colors.Length]))
                {
                    g.FillRectangle(brush, x, y, barWidth, barHeight);
                }

                // Viền cột
                g.DrawRectangle(new Pen(Color.White, 2), x, y, barWidth, barHeight);

                // Giá trị trên cột
                if (barHeight > 30) // Chỉ hiển thị nếu cột đủ cao
                {
                    Font valueFont = new Font("Segoe UI", 10, FontStyle.Bold);
                    string value;
                    if (data[i].Revenue >= 1000000)
                        value = string.Format("{0:0.#}M", data[i].Revenue / 1000000);
                    else if (data[i].Revenue >= 1000)
                        value = string.Format("{0:0}K", data[i].Revenue / 1000);
                    else
                        value = string.Format("{0:0}", data[i].Revenue);
                        
                    SizeF valueSize = g.MeasureString(value, valueFont);
                    g.DrawString(value, valueFont, Brushes.Black, 
                        x + (barWidth - valueSize.Width) / 2, y - 25);
                }

                // Tên tháng dưới cột
                Font labelFont = new Font("Segoe UI", 9, FontStyle.Bold);
                string month = "T" + data[i].Month;
                SizeF monthSize = g.MeasureString(month, labelFont);
                g.DrawString(month, labelFont, new SolidBrush(Color.FromArgb(52, 73, 94)), 
                    x + (barWidth - monthSize.Width) / 2, topPadding + chartHeight + 8);
            }

            // Vẽ các mốc trên trục Y
            Font axisFont = new Font("Segoe UI", 8);
            for (int i = 0; i <= 5; i++)
            {
                decimal value = (maxRevenue / 5) * i;
                int y = topPadding + chartHeight - (chartHeight / 5) * i;
                string label;
                if (value >= 1000000)
                    label = string.Format("{0:0.#}M", value / 1000000);
                else if (value >= 1000)
                    label = string.Format("{0:0}K", value / 1000);
                else
                    label = string.Format("{0:0}", value);
                    
                g.DrawString(label, axisFont, Brushes.Gray, 5, y - 8);
                
                // Đường lưới ngang
                if (i > 0)
                {
                    Pen gridPen = new Pen(Color.FromArgb(220, 220, 220), 1);
                    gridPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    g.DrawLine(gridPen, padding, y, padding + chartWidth, y);
                }
            }
        }

        private void PanelProductChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT TOP 5
                            c.C_Name as LoaiSP,
                            COUNT(p.MaSP) as SoLuong
                        FROM Products p
                        JOIN Categories c ON p.C_ID = c.C_ID
                        GROUP BY c.C_Name
                        ORDER BY COUNT(p.MaSP) DESC
                    ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            var data = new System.Collections.Generic.List<(string Category, int Count)>();
                            while (reader.Read())
                            {
                                data.Add((reader["LoaiSP"].ToString(), Convert.ToInt32(reader["SoLuong"])));
                            }

                            if (data.Count > 0)
                            {
                                DrawPieChart(g, panelProductChart, data);
                            }
                            else
                            {
                                DrawNoDataMessage(g, panelProductChart, "Chưa có dữ liệu sản phẩm");
                            }
                        }
                    }
                }
            }
            catch
            {
                DrawNoDataMessage(g, panelProductChart, "Lỗi khi tải dữ liệu");
            }
        }

        private void DrawPieChart(Graphics g, Panel panel, System.Collections.Generic.List<(string Category, int Count)> data)
        {
            // Vẽ tiêu đề
            Font titleFont = new Font("Segoe UI", 13, FontStyle.Bold);
            string title = "Phân loại sản phẩm";
            SizeF titleSize = g.MeasureString(title, titleFont);
            g.DrawString(title, titleFont, new SolidBrush(Color.FromArgb(44, 62, 80)), 
                (panel.Width - titleSize.Width) / 2, 15);

            int total = 0;
            foreach (var item in data)
            {
                total += item.Count;
            }

            if (total == 0) return;

            Color[] colors = {
                Color.FromArgb(52, 152, 219),
                Color.FromArgb(46, 204, 113),
                Color.FromArgb(155, 89, 182),
                Color.FromArgb(230, 126, 34),
                Color.FromArgb(231, 76, 60)
            };

            // Điều chỉnh vị trí biểu đồ tròn - đặt cao hơn để có chỗ cho legend dưới
            int centerX = panel.Width / 2;
            int centerY = (panel.Height - 80) / 2 + 35;
            int radius = Math.Min(panel.Width / 2 - 30, (panel.Height - 120) / 2);
            if (radius < 90) radius = 90;
            if (radius > 160) radius = 160;

            float startAngle = 0;
            Font labelFont = new Font("Segoe UI", 10);

            for (int i = 0; i < data.Count; i++)
            {
                float sweepAngle = (float)data[i].Count / total * 360;

                using (SolidBrush brush = new SolidBrush(colors[i % colors.Length]))
                {
                    g.FillPie(brush, centerX - radius, centerY - radius, radius * 2, radius * 2, startAngle, sweepAngle);
                }

                g.DrawPie(new Pen(Color.White, 3), centerX - radius, centerY - radius, radius * 2, radius * 2, startAngle, sweepAngle);

                // Vẽ phần trăm trên biểu đồ
                if (sweepAngle > 20) // Chỉ hiển thị % nếu phần đủ lớn
                {
                    float angle = startAngle + sweepAngle / 2;
                    float angleRad = angle * (float)Math.PI / 180;
                    int textX = centerX + (int)(radius * 0.7 * Math.Cos(angleRad));
                    int textY = centerY + (int)(radius * 0.7 * Math.Sin(angleRad));
                    
                    Font percentFont = new Font("Segoe UI", 11, FontStyle.Bold);
                    string percent = string.Format("{0:0}%", (float)data[i].Count / total * 100);
                    SizeF percentSize = g.MeasureString(percent, percentFont);
                    g.DrawString(percent, percentFont, Brushes.White, 
                        textX - percentSize.Width / 2, textY - percentSize.Height / 2);
                }

                startAngle += sweepAngle;
            }

            // Vẽ legend nằm ngang ở dưới
            int legendY = centerY + radius + 25;
            int totalLegendWidth = 0;
            
            // Tính tổng chiều rộng của tất cả legend
            Font legendFont = new Font("Segoe UI", 9, FontStyle.Bold);
            Font countFont = new Font("Segoe UI", 8);
            var legendWidths = new System.Collections.Generic.List<int>();
            
            foreach (var item in data)
            {
                string legendText = $"{item.Category} ({item.Count})";
                SizeF textSize = g.MeasureString(legendText, legendFont);
                int itemWidth = 22 + 8 + (int)textSize.Width + 12; // icon + spacing + text + margin nhỏ hơn
                legendWidths.Add(itemWidth);
                totalLegendWidth += itemWidth;
            }
            
            // Vẽ legend từ giữa
            int legendStartX = (panel.Width - totalLegendWidth) / 2;
            int currentX = legendStartX;
            
            for (int i = 0; i < data.Count; i++)
            {
                // Hình vuông màu
                g.FillRectangle(new SolidBrush(colors[i % colors.Length]), currentX, legendY, 22, 22);
                g.DrawRectangle(new Pen(Color.White, 2), currentX, legendY, 22, 22);
                
                // Text
                string legendText = $"{data[i].Category}";
                g.DrawString(legendText, legendFont, new SolidBrush(Color.FromArgb(52, 73, 94)), 
                    currentX + 28, legendY + 2);
                
                // Số lượng
                string countText = $"({data[i].Count})";
                SizeF countSize = g.MeasureString(countText, countFont);
                SizeF nameSize = g.MeasureString(legendText, legendFont);
                g.DrawString(countText, countFont, Brushes.Gray, 
                    currentX + 28 + nameSize.Width + 3, legendY + 3);
                
                currentX += legendWidths[i];
            }
        }

        private void DrawNoDataMessage(Graphics g, Panel panel, string message)
        {
            Font font = new Font("Segoe UI", 12);
            SizeF size = g.MeasureString(message, font);
            g.DrawString(message, font, Brushes.Gray,
                (panel.Width - size.Width) / 2, (panel.Height - size.Height) / 2);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
            LoadRevenueChart();
            LoadProductChart();
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {

        }
    }
}
