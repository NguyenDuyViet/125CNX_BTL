namespace ShoeShop
{
    partial class FormThongKe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelTop = new Panel();
            btnRefresh = new Button();
            lblTitle = new Label();
            panelStats = new Panel();
            panel1 = new Panel();
            lblTotalRevenue = new Label();
            label1 = new Label();
            panel2 = new Panel();
            lblTotalOrders = new Label();
            label3 = new Label();
            panel3 = new Panel();
            lblTotalProducts = new Label();
            label5 = new Label();
            panel4 = new Panel();
            lblTotalCustomers = new Label();
            label7 = new Label();
            panelRevenueChart = new Panel();
            panelProductChart = new Panel();
            panelTop.SuspendLayout();
            panelStats.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(52, 152, 219);
            panelTop.Controls.Add(btnRefresh);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 5, 4, 5);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1714, 100);
            panelTop.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.White;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.FromArgb(52, 152, 219);
            btnRefresh.Location = new Point(1500, 25);
            btnRefresh.Margin = new Padding(4, 5, 4, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(186, 58);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "🔄 Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(29, 25);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(202, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THỐNG KÊ";
            // 
            // panelStats
            // 
            panelStats.BackColor = Color.FromArgb(236, 240, 241);
            panelStats.Controls.Add(panel1);
            panelStats.Controls.Add(panel2);
            panelStats.Controls.Add(panel3);
            panelStats.Controls.Add(panel4);
            panelStats.Location = new Point(29, 133);
            panelStats.Margin = new Padding(4, 5, 4, 5);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(1657, 200);
            panelStats.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(52, 152, 219);
            panel1.Controls.Add(lblTotalRevenue);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(14, 17);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(386, 167);
            panel1.TabIndex = 0;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTotalRevenue.ForeColor = Color.White;
            lblTotalRevenue.Location = new Point(21, 75);
            lblTotalRevenue.Margin = new Padding(4, 0, 4, 0);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(146, 54);
            lblTotalRevenue.TabIndex = 1;
            lblTotalRevenue.Text = "0 VNĐ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(21, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(167, 30);
            label1.TabIndex = 0;
            label1.Text = "Tổng doanh thu";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(46, 204, 113);
            panel2.Controls.Add(lblTotalOrders);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(429, 17);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(386, 167);
            panel2.TabIndex = 1;
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.AutoSize = true;
            lblTotalOrders.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTotalOrders.ForeColor = Color.White;
            lblTotalOrders.Location = new Point(21, 75);
            lblTotalOrders.Margin = new Padding(4, 0, 4, 0);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(46, 54);
            lblTotalOrders.TabIndex = 1;
            lblTotalOrders.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(21, 25);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(161, 30);
            label3.TabIndex = 0;
            label3.Text = "Tổng đơn hàng";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(155, 89, 182);
            panel3.Controls.Add(lblTotalProducts);
            panel3.Controls.Add(label5);
            panel3.Location = new Point(843, 17);
            panel3.Margin = new Padding(4, 5, 4, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(386, 167);
            panel3.TabIndex = 2;
            // 
            // lblTotalProducts
            // 
            lblTotalProducts.AutoSize = true;
            lblTotalProducts.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTotalProducts.ForeColor = Color.White;
            lblTotalProducts.Location = new Point(21, 75);
            lblTotalProducts.Margin = new Padding(4, 0, 4, 0);
            lblTotalProducts.Name = "lblTotalProducts";
            lblTotalProducts.Size = new Size(46, 54);
            lblTotalProducts.TabIndex = 1;
            lblTotalProducts.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(21, 25);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(162, 30);
            label5.TabIndex = 0;
            label5.Text = "Tổng sản phẩm";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(230, 126, 34);
            panel4.Controls.Add(lblTotalCustomers);
            panel4.Controls.Add(label7);
            panel4.Location = new Point(1257, 17);
            panel4.Margin = new Padding(4, 5, 4, 5);
            panel4.Name = "panel4";
            panel4.Size = new Size(386, 167);
            panel4.TabIndex = 3;
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.AutoSize = true;
            lblTotalCustomers.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTotalCustomers.ForeColor = Color.White;
            lblTotalCustomers.Location = new Point(21, 75);
            lblTotalCustomers.Margin = new Padding(4, 0, 4, 0);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(46, 54);
            lblTotalCustomers.TabIndex = 1;
            lblTotalCustomers.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(21, 25);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(179, 30);
            label7.TabIndex = 0;
            label7.Text = "Tổng khách hàng";
            // 
            // panelRevenueChart
            // 
            panelRevenueChart.BackColor = Color.White;
            panelRevenueChart.Location = new Point(29, 367);
            panelRevenueChart.Margin = new Padding(4, 5, 4, 5);
            panelRevenueChart.Name = "panelRevenueChart";
            panelRevenueChart.Size = new Size(960, 657);
            panelRevenueChart.TabIndex = 2;
            panelRevenueChart.Paint += PanelRevenueChart_Paint;
            // 
            // panelProductChart
            // 
            panelProductChart.BackColor = Color.White;
            panelProductChart.Location = new Point(1019, 367);
            panelProductChart.Margin = new Padding(4, 5, 4, 5);
            panelProductChart.Name = "panelProductChart";
            panelProductChart.Size = new Size(667, 657);
            panelProductChart.TabIndex = 3;
            panelProductChart.Paint += PanelProductChart_Paint;
            // 
            // FormThongKe
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1714, 1167);
            Controls.Add(panelProductChart);
            Controls.Add(panelRevenueChart);
            Controls.Add(panelStats);
            Controls.Add(panelTop);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormThongKe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống kê";
            Load += FormThongKe_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelStats.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTotalProducts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTotalCustomers;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelRevenueChart;
        private System.Windows.Forms.Panel panelProductChart;
    }
}
