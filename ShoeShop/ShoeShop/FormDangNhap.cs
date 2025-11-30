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
       
        private string connectionString = "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True";

        public FormDangNhap()
        {
            InitializeComponent();
            connectionString = ConfigurationManager
           .ConnectionStrings["ShopBanGiay"]
           .ConnectionString;

            txtPassword.KeyPress += TxtPassword_KeyPress;
            txtUsername.KeyPress += TxtUsername_KeyPress;
        }
        public static class Session
        {
            public static int UserID;
            public static string HoTen;
            public static int RoleID;
            public static string ChucVu;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DangNhap();
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

        private void DangNhap()
        {
            
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

            if (KiemTraDangNhap(txtUsername.Text, txtPassword.Text))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                TrangChu formMain = new TrangChu();
                formMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private bool KiemTraDangNhap(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT U_ID, HoTen, RoleID, ChucVu 
                FROM Users 
                WHERE TenDangNhap = @username AND MatKhau = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32(0);
                                string hoTen = reader.GetString(1);
                                int role = reader.GetInt32(2);
                                string chucVu = reader.IsDBNull(3) ? "" : reader.GetString(3);

                                
                                Session.UserID = userId;
                                Session.HoTen = hoTen;
                                Session.RoleID = role;
                                Session.ChucVu = chucVu;

                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối SQL: " + ex.Message);
                return false;
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