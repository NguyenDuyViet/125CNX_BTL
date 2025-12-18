# HƯỚNG DẪN SỬ DỤNG CHỨC NĂNG IMPORT XML → SQL - ĐƠN HÀNG

## 📋 **Mô tả chức năng:**

Chức năng **Import XML → SQL** cho phép đồng bộ dữ liệu đơn hàng từ file XML vào cơ sở dữ liệu SQL Server.

## 🎯 **Vị trí:**

**Form Quản Lý Đơn Hàng** (FormQuanLyDonHang)
- Button: **📥 XML → SQL**
- Vị trí: Góc dưới bên trái, cạnh button "Export XML"
- Màu: Tím (#9B59B6)

## 🚀 **Cách sử dụng:**

### **Bước 1: Mở Form Quản Lý Đơn Hàng**
```
Trang Chủ → Quản Lý Đơn Hàng
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
- Danh sách đơn hàng tự động reload

## ⚙️ **Cách hoạt động:**

### **1. Đọc dữ liệu từ XML:**
```
File: ShoeShop/App_Data/DonHang.xml
```

### **2. Xử lý từng đơn hàng:**
- **Nếu đơn hàng chưa có MaDH (ID):**
  - INSERT vào SQL Server
  - Lấy MaDH mới từ database
  - Cập nhật MaDH vào XML

- **Nếu đơn hàng đã có MaDH:**
  - UPDATE thông tin trong SQL Server
  - Giữ nguyên MaDH

### **3. Đồng bộ dữ liệu:**
- XML ← → SQL Server
- Dữ liệu được sync 2 chiều

## 📊 **Dữ liệu được import:**

| Trường | Mô tả |
|--------|-------|
| MaKH | Mã khách hàng |
| NgayDat | Ngày đặt hàng |
| TongTien | Tổng tiền đơn hàng |
| TrangThai | Trạng thái đơn hàng |

## ✅ **Khi nào nên dùng:**

1. **Sau khi thêm đơn hàng mới vào XML**
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
- File phải tồn tại: `ShoeShop/App_Data/DonHang.xml`
- Cấu trúc XML phải đúng format
- Dữ liệu phải hợp lệ

### **3. Kết nối SQL Server:**
- SQL Server phải đang chạy
- Connection string phải đúng
- User phải có quyền INSERT/UPDATE

### **4. Dữ liệu trùng lặp:**
- Đơn hàng có MaDH → UPDATE
- Đơn hàng không có MaDH → INSERT
- Không tạo duplicate records

## 🔧 **Troubleshooting:**

### **Lỗi: "Import thất bại"**
**Nguyên nhân:**
- File XML không tồn tại
- SQL Server không kết nối được
- Lỗi cấu trúc dữ liệu

**Giải pháp:**
1. Kiểm tra file `App_Data/DonHang.xml`
2. Test kết nối SQL Server
3. Xem log chi tiết trong console

### **Lỗi: "Không có dữ liệu"**
**Nguyên nhân:**
- File XML rỗng
- Cấu trúc XML sai

**Giải pháp:**
1. Mở file XML kiểm tra
2. Đảm bảo có ít nhất 1 đơn hàng
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
├── FormQuanLyDonHang.cs          # UI và event handler
├── FormQuanLyDonHang.Designer.cs # Button definition
├── Service/DonHangService.cs     # Business logic
└── DAO/DonHangDao.cs             # Data access (SyncXmlToSql)
```

### **Method chính:**
```csharp
// DonHangDao.cs
public async Task<bool> SyncXmlToSql()

// DonHangService.cs
public async Task<bool> ImportXmlToSql()

// FormQuanLyDonHang.cs
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
- **Dữ liệu mới xuất hiện** trong danh sách đơn hàng
- **MaDH được cập nhật** cho đơn hàng mới

### **3. Kiểm tra trong SQL Server:**
```sql
-- 1. Kiểm tra tổng số đơn hàng
SELECT COUNT(*) AS TongSoDonHang FROM DonHang;

-- 2. Xem danh sách đơn hàng vừa import
SELECT TOP 10 * FROM DonHang 
ORDER BY MaDH DESC;

-- 3. Kiểm tra đơn hàng theo trạng thái
SELECT TrangThai, COUNT(*) AS SoLuong
FROM DonHang
GROUP BY TrangThai;

-- 4. Kiểm tra đơn hàng có đầy đủ thông tin
SELECT MaDH, MaKH, NgayDat, TongTien, TrangThai
FROM DonHang
WHERE TongTien > 0 
  AND TrangThai IS NOT NULL;
```

### **4. Kiểm tra file XML:**
- Mở file `ShoeShop/App_Data/DonHang.xml`
- Kiểm tra đơn hàng mới đã có **MaDH** được cập nhật từ SQL Server
- Đơn hàng trước đó không có MaDH, sau import sẽ có MaDH

### **5. Kiểm tra trong Console/Debug:**
- Chạy ứng dụng ở chế độ Debug (F5)
- Xem output trong Console window
- Kiểm tra log chi tiết về quá trình import

### **6. So sánh trước và sau:**
- **Trước import**: Đếm số record trong SQL
- **Sau import**: Đếm lại số record
- **Kết quả**: Số lượng phải tăng lên (nếu có đơn hàng mới) hoặc giữ nguyên (nếu chỉ update)

## 📋 **Sample XML Structure:**

```xml
<?xml version="1.0" standalone="yes"?>
<DocumentElement>
  <DonHang>
    <MaDH>1</MaDH>
    <MaKH>5</MaKH>
    <NgayDat>2024-12-18T10:30:00</NgayDat>
    <TongTien>1500000</TongTien>
    <TrangThai>Chờ xác nhận</TrangThai>
  </DonHang>
  <DonHang>
    <!-- Đơn hàng mới chưa có MaDH -->
    <MaKH>7</MaKH>
    <NgayDat>2024-12-18T14:20:00</NgayDat>
    <TongTien>2300000</TongTien>
    <TrangThai>Đã xác nhận</TrangThai>
  </DonHang>
</DocumentElement>
```

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