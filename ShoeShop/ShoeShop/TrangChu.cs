using System;
using System.IO;
using System.Windows.Forms;

namespace ShoeShop
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
            LoadImages();
            SetupButtonHoverEffects();
        }

        private void LoadImages()
        {
            try
            {
                string logoPath = "Resources/caabb9ab58e9b530b0bd26544a17f114-removebg-preview.png";
                if (File.Exists(logoPath))
                {
                    picLogo.Image = System.Drawing.Image.FromFile(logoPath);
                }
            }
            catch { }

            try
            {
                string heroPath = "Resources/hero-shoe-2.png";
                if (File.Exists(heroPath))
                {
                    picHeroShoe.Image = System.Drawing.Image.FromFile(heroPath);
                }
            }
            catch { }
        }

        private void SetupButtonHoverEffects()
        {
            var menuButtons = new[] { btnQuanLySanPham, btnQuanLyKhachHang, btnQuanLyDonHang, btnQuanLyNhanVien };
            foreach (var btn in menuButtons)
            {
                btn.MouseEnter += (s, e) => btn.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
                btn.MouseLeave += (s, e) => btn.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            }

            btnDangXuat.MouseEnter += (s, e) => btnDangXuat.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnDangXuat.MouseLeave += (s, e) => btnDangXuat.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
        }

        private void btnQuanLySanPham_Click(object sender, EventArgs e)
        {
            FormQuanLySanPham f = new FormQuanLySanPham();
            f.Show();
        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            FormQuanLyKhachHang f = new FormQuanLyKhachHang();
            f.Show();
        }

        private void btnQuanLyDonHang_Click(object sender, EventArgs e)
        {
            FormQuanLyDonHang f = new FormQuanLyDonHang();
            f.Show();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            FormQuanLyNhanVien f = new FormQuanLyNhanVien();
            f.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                FormDangNhap loginForm = new FormDangNhap();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {

        }
    }
}
