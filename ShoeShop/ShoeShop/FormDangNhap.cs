using ShoeShop.DAO;
using ShoeShop.Service;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace ShoeShop
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();

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
            if (result != null && result.RoleID == 1)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                TrangChu formMain = new TrangChu();
                formMain.Show();
                this.Hide();
            }else if (result.RoleID != 1)
            {
				MessageBox.Show("Bạn không có quyền vào trang này!!!", "Thông báo",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtPassword.Clear();
				txtUsername.Focus();
			}
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi",
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
    }
}