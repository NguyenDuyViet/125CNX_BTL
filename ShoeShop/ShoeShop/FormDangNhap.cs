using _125CNX_ECommerce.Models;
using ShoeShop.DAO;
using ShoeShop.Service;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace ShoeShop
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
            LoadXML();

            txtPassword.KeyPress += TxtPassword_KeyPress;
            txtUsername.KeyPress += TxtUsername_KeyPress;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            DangNhapAsync();
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DangNhapAsync();
                e.Handled = true;
            }
        }

        private void TxtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
            }
        }

        //Load XML from sql
        private async Task LoadXML()
        {
            UserService user = new UserService();

            // Danh sách các bảng bạn cần xuất ra XML
            string[] tables = {
                "Products",
                "Roles",
                "ThanhToan",
                "Users",
                "HoaDon",
                "DonHang",
                "Categories",
                "ChiTietHoaDon",
                "ChiTietDonHang"
            };

            foreach (string table in tables)
            {
                await user.XmlExporter(table);
            }
        }

        private async void DangNhapAsync()
        {
            //Kiểm tra thông tin các trường có trống không
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            //Kiểm tra đăng nhập
            UserService userService = new UserService();

            var result = await userService.CheckLogin(txtUsername.Text, txtPassword.Text);

            if (result == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }

            if (result != null && result.RoleID == 1)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                TrangChu formMain = new TrangChu();
                formMain.Show();
                this.Hide();
            }
            else if (result != null && result.RoleID != 1)
            {
                MessageBox.Show("Bạn không có quyền vào trang này!!!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
        }
        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}