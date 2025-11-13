namespace _125CNX_ECommerce.Models
{

    public class UserModel
    {
        public int U_ID { get; set; }

        public string? HoTen { get; set; }

        public string? DiaChi { get; set; }

        public string? SDT { get; set; }

        public string? Email { get; set; }

        public string? TenDangNhap { get; set; }

        public string? MatKhau { get; set; }

        // 🔹 Thêm dòng này để khớp với View
        public string? XacNhanMatKhau { get; set; }

        public int? RoleID { get; set; } = 3; // Mặc định là khách hàng
    }
}
