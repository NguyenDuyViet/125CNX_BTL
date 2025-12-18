# HƯỚNG DẪN SỬ DỤNG CHỨC NĂNG IMPORT XML → SQL - KHÁCH HÀNG

## 📋 **Mô tả chức năng:**

Chức năng **Import XML → SQL** cho phép đồng bộ dữ liệu khách hàng từ file XML vào cơ sở dữ liệu SQL Server.

## 🎯 **Vị trí:**

**Form Quản Lý Khách Hàng** (FormQuanLyKhachHang)
- Button: **📥 XML → SQL**
- Vị trí: Góc trên bên phải, cạnh button "Export XML"
- Màu: Tím (#9B59B6)

## 🚀 **Cách sử dụng:**

### **Bước 1: Mở Form Quản Lý Khách Hàng**
```
Trang Chủ → Quản Lý Khách Hàng
```

### **Bước 2: Click Button "📥 XML → SQL"**
- Hệ thống sẽ hiển thị dialog xác nhận
- Đọc kỹ thông báo trước khi xác nhận

### **Bước 3: Xác nhận Import**
- Click **"Yes"** để tiếp tục
- Click **"No"** để hủy

### **Bước 4: Chờ xử lý**
- Button sẽ hiển thị "Đang import..."
- Cursor sẽ chuyển thành loading
- **KHÔNG** đóng form trong lúc này

### **Bước 5: Xem kết quả**
- Thông báo thành công/thất bại
- Danh sách khách hàng tự động reload

## ⚙️ **Cách hoạt động:**

### **1. Đọc dữ liệu từ XML:**
```
File: ShoeShop/App_Data/Users.xml
```

### **2. Xử lý từng khách hàng:**
- **Nếu khách hàng chưa có U_ID (ID):**
  - INSERT vào SQL Server
  - Lấy U_ID mới từ database
  - Cập nhật U_ID vào XML

- **Nếu khách hàng đã có U_ID:**
  - UPDATE thông tin trong SQL Server
  - Giữ nguyên U_ID

### **3. Đồng bộ dữ liệu:**
- XML ← → SQL Server
- Dữ liệu được sync 2 chiều

## 📊 **Dữ liệu được import:**

| Trường | Mô tả |
|--------|-------|
| HoTen | Họ và tên khách hàng |
| DiaChi | Địa chỉ |
| SDT | Số điện thoại |
| Email | Email |
| RoleID | Quyền (3 = Khách hàng) |
| TenDangNhap | Tên đăng nhập |
| MatKhau | Mật khẩu |
| ChucVu | Chức vụ |

## ✅ **Khi nào nên dùng:**

1. **Sau khi thêm khách hàng mới vào XML**
   - Đã edit file XML thủ công
   - Cần đồng bộ vào SQL Server

2. **Khôi phục dữ liệu**
   - Restore từ backup XML
   - Sync lại vào database

3. **Migration dữ liệu**
   - Chuyển từ hệ thống cũ (XML)
   - Sang hệ thống mới (SQL Server)

4. **Đồng bộ định kỳ**
   - Đảm bảo XML và SQL nhất quán
   - Sau khi có thay đổi lớn

## ⚠️ **Lưu ý quan trọng:**

### **1. Backup trước khi import:**
```sql
-- Backup SQL Server
BACKUP DATABASE SQLShopBanGiay 
TO DISK = 'C:\Backup\SQLShopBanGiay.bak'
```

### **2. Kiểm tra file XML:**
- File phải tồn tại: `ShoeShop/App_Data/Users.xml`
- Cấu trúc XML phải đúng format
- Dữ liệu phải hợp lệ

### **3. Kết nối SQL Server:**
- SQL Server phải đang chạy
- Connection string phải đúng
- User phải có quyền INSERT/UPDATE

### **4. Dữ liệu trùng lặp:**
- Khách hàng có U_ID → UPDATE
- Khách hàng không có U_ID → INSERT
- Không tạo duplicate records

## 🔧 **Troubleshooting:**

### **Lỗi: "Import thất bại"**
**Nguyên nhân:**
- File XML không tồn tại
- SQL Server không kết nối được
- Lỗi cấu trúc dữ liệu

**Giải pháp:**
1. Kiểm tra file `App_Data/Users.xml`
2. Test kết nối SQL Server
3. Xem log chi tiết trong console

### **Lỗi: "Không có dữ liệu"**
**Nguyên nhân:**
- File XML rỗng
- Cấu trúc XML sai

**Giải pháp:**
1. Mở file XML kiểm tra
2. Đảm bảo có ít nhất 1 khách hàng
3. Validate XML format

### **Lỗi: "Connection timeout"**
**Nguyên nhân:**
- SQL Server không chạy
- Connection string sai
- Firewall block

**Giải pháp:**
1. Mở SQL Server Management Studio
2. Kiểm tra SQL Server đang chạy
3. Test connection string
4. Tắt firewall tạm thời

## 📝 **Code Reference:**

### **Files liên quan:**
```
ShoeShop/ShoeShop/
├── FormQuanLyKhachHang.cs          # UI và event handler
├── FormQuanLyKhachHang.Designer.cs # Button definition
├── Service/UserService.cs          # Business logic
└── DAO/UserDao.cs                  # Data access (SyncXmlToSql)
```

### **Method chính:**
```csharp
// UserDao.cs
public async Task<bool> SyncXmlToSql()

// UserService.cs
public async Task<bool> ImportXmlToSql()

// FormQuanLyKhachHang.cs
private async void btnImportXML_Click(object sender, EventArgs e)
```

## 🎯 **Kết quả mong đợi:**

### **Thành công:**
```
✅ Import XML vào SQL Server thành công!

Dữ liệu đã được đồng bộ từ file XML sang cơ sở dữ liệu SQL.
```

### **Thất bại:**
```
❌ Import thất bại!

Vui lòng kiểm tra:
- File XML có tồn tại không
- Kết nối SQL Server
- Cấu trúc dữ liệu
```

## 🔍 **Cách kiểm tra Import thành công:**

### **1. Thông báo từ hệ thống:**
- **Thành công**: Dialog "✅ Import XML vào SQL Server thành công!"
- **Thất bại**: Dialog "❌ Import thất bại!" với lý do cụ thể

### **2. Kiểm tra trực quan:**
- **DataGridView tự động reload** sau khi import
- **Dữ liệu mới xuất hiện** trong danh sách khách hàng
- **U_ID được cập nhật** cho khách hàng mới

### **3. Kiểm tra trong SQL Server:**
```sql
-- 1. Kiểm tra tổng số khách hàng (RoleID = 3)
SELECT COUNT(*) AS TongSoKhachHang 
FROM Users 
WHERE RoleID = 3;

-- 2. Xem danh sách khách hàng vừa import
SELECT TOP 10 * FROM Users 
WHERE RoleID = 3
ORDER BY U_ID DESC;

-- 3. Kiểm tra khách hàng có đầy đủ thông tin
SELECT U_ID, HoTen, Email, SDT, TenDangNhap
FROM Users
WHERE RoleID = 3 
  AND HoTen IS NOT NULL 
  AND Email IS NOT NULL;
```

### **4. Kiểm tra file XML:**
- Mở file `ShoeShop/App_Data/Users.xml`
- Kiểm tra khách hàng mới đã có **U_ID** được cập nhật từ SQL Server
- Khách hàng trước đó không có U_ID, sau import sẽ có U_ID

## 📞 **Hỗ trợ:**

Nếu gặp vấn đề, kiểm tra:
1. Console output (F5 debug mode)
2. SQL Server logs
3. XML file structure
4. Connection string trong App.config

---

**Phiên bản:** 1.0
**Ngày cập nhật:** 2024
**Tác giả:** Nguyễn Duy Việt & Cao Thị Hân