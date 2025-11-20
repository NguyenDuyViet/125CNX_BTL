namespace _125CNX_ECommerce.Models
{
    public class UserRegisterModel
    {
        public string TenDangNhap { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string XacNhanMatKhau { get; set; }
        public string HoTen { get; set; } // Có thể không bắt buộc
    }
}
