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
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1199, 60);
            panelTop.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.White;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.FromArgb(52, 152, 219);
            btnRefresh.Location = new Point(1050, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(130, 35);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "🔄 Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(243, 47);
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
            panelStats.Location = new Point(20, 80);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(1160, 120);
            panelStats.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(52, 152, 219);
            panel1.Controls.Add(lblTotalRevenue);
            panel1.Controls.Add(label1);
            panel1.Font = new Font("Times New Roman", 9F);
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 100);
            panel1.TabIndex = 0;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold);
            lblTotalRevenue.ForeColor = Color.White;
            lblTotalRevenue.Location = new Point(15, 45);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(140, 47);
            lblTotalRevenue.TabIndex = 1;
            lblTotalRevenue.Text = "0 VNĐ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 15);
            label1.Name = "label1";
            label1.Size = new Size(163, 27);
            label1.TabIndex = 0;
            label1.Text = "Tổng doanh thu";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(46, 204, 113);
            panel2.Controls.Add(lblTotalOrders);
            panel2.Controls.Add(label3);
            panel2.Font = new Font("Times New Roman", 9F);
            panel2.Location = new Point(300, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(270, 100);
            panel2.TabIndex = 1;
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.AutoSize = true;
            lblTotalOrders.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold);
            lblTotalOrders.ForeColor = Color.White;
            lblTotalOrders.Location = new Point(15, 45);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(41, 47);
            lblTotalOrders.TabIndex = 1;
            lblTotalOrders.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(15, 15);
            label3.Name = "label3";
            label3.Size = new Size(156, 27);
            label3.TabIndex = 0;
            label3.Text = "Tổng đơn hàng";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(155, 89, 182);
            panel3.Controls.Add(lblTotalProducts);
            panel3.Controls.Add(label5);
            panel3.Font = new Font("Times New Roman", 9F);
            panel3.Location = new Point(590, 10);
            panel3.Name = "panel3";
            panel3.Size = new Size(270, 100);
            panel3.TabIndex = 2;
            // 
            // lblTotalProducts
            // 
            lblTotalProducts.AutoSize = true;
            lblTotalProducts.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold);
            lblTotalProducts.ForeColor = Color.White;
            lblTotalProducts.Location = new Point(15, 45);
            lblTotalProducts.Name = "lblTotalProducts";
            lblTotalProducts.Size = new Size(41, 47);
            lblTotalProducts.TabIndex = 1;
            lblTotalProducts.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(15, 15);
            label5.Name = "label5";
            label5.Size = new Size(158, 27);
            label5.TabIndex = 0;
            label5.Text = "Tổng sản phẩm";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(230, 126, 34);
            panel4.Controls.Add(lblTotalCustomers);
            panel4.Controls.Add(label7);
            panel4.Font = new Font("Times New Roman", 9F);
            panel4.Location = new Point(880, 10);
            panel4.Name = "panel4";
            panel4.Size = new Size(270, 100);
            panel4.TabIndex = 3;
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.AutoSize = true;
            lblTotalCustomers.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold);
            lblTotalCustomers.ForeColor = Color.White;
            lblTotalCustomers.Location = new Point(15, 45);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(41, 47);
            lblTotalCustomers.TabIndex = 1;
            lblTotalCustomers.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 12F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(15, 15);
            label7.Name = "label7";
            label7.Size = new Size(177, 27);
            label7.TabIndex = 0;
            label7.Text = "Tổng khách hàng";
            // 
            // panelRevenueChart
            // 
            panelRevenueChart.BackColor = Color.White;
            panelRevenueChart.Location = new Point(20, 220);
            panelRevenueChart.Name = "panelRevenueChart";
            panelRevenueChart.Size = new Size(672, 635);
            panelRevenueChart.TabIndex = 2;
            panelRevenueChart.Paint += PanelRevenueChart_Paint;
            // 
            // panelProductChart
            // 
            panelProductChart.BackColor = Color.White;
            panelProductChart.Location = new Point(713, 220);
            panelProductChart.Name = "panelProductChart";
            panelProductChart.Size = new Size(467, 635);
            panelProductChart.TabIndex = 3;
            panelProductChart.Paint += PanelProductChart_Paint;
            // 
            // FormThongKe
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1199, 888);
            Controls.Add(panelProductChart);
            Controls.Add(panelRevenueChart);
            Controls.Add(panelStats);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
