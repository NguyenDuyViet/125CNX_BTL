# LUỒNG ĐỒNG BỘ XML ↔ SQL TRONG HỆ THỐNG

## 🎯 **Tổng quan kiến trúc:**

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                           HỆ THỐNG QUẢN LÝ SHOP GIÀY                       │
├─────────────────────────────────────────────────────────────────────────────┤
│                                                                             │
│  ┌─────────────┐    ┌─────────────┐    ┌─────────────┐    ┌─────────────┐  │
│  │   XML       │◄──►│    DAO      │◄──►│   Service   │◄──►│    Form     │  │
│  │  Storage    │    │   Layer     │    │   Layer     │    │     UI      │  │
│  └─────────────┘    └─────────────┘    └─────────────┘    └─────────────┘  │
│         ▲                   ▲                                               │
│         │                   ▼                                               │
│         │            ┌─────────────┐                                        │
│         └───────────►│ SQL Server  │                                        │
│                      │  Database   │                                        │
│                      └─────────────┘                                        │
└─────────────────────────────────────────────────────────────────────────────┘
```

## 📊 **1. SẢN PHẨM (Products)**

### **XML Structure:**
```xml
<!-- App_Data/Products.xml -->
<?xml version="1.0" standalone="yes"?>
<DocumentElement>
  <Products>
    <MaSP>1</MaSP>                    <!-- ID từ SQL -->
    <TenSP>Giày Nike Air Max</TenSP>
    <C_ID>2</C_ID>
    <KichCo>42</KichCo>
    <MauSac>Đen</MauSac>
    <Gia>2500000</Gia>
    <SoLuong>15</SoLuong>
    <Images>nike_air_max.jpg</Images>
  </Products>
  <Products>
    <!-- Sản phẩm mới chưa có MaSP -->
    <TenSP>Giày Adidas Ultraboost</TenSP>
    <C_ID>1</C_ID>
    <KichCo>41</KichCo>
    <MauSac>Trắng</MauSac>
    <Gia>3200000</Gia>
    <SoLuong>8</SoLuong>
    <Images>adidas_ultraboost.jpg</Images>
  </Products>
</DocumentElement>
```

### **SQL Table:**
```sql
CREATE TABLE Products(
    MaSP INT IDENTITY PRIMARY KEY,    -- Auto-increment ID
    TenSP NVARCHAR(100),
    C_ID INT REFERENCES Categories(C_ID),
    KichCo NVARCHAR(10),
    MauSac NVARCHAR(30),
    Gia DECIMAL(10,2),
    SoLuong INT,
    Images NVARCHAR(MAX)
);
```

### **Sync Process:**
```csharp
// ProductDao.SyncXmlToSql()
foreach (DataRow row in xmlTable.Rows)
{
    int maSP = row["MaSP"] != DBNull.Value ? Convert.ToInt32(row["MaSP"]) : 0;
    
    if (maSP <= 0)
    {
        // ===== INSERT MỚI =====
        string insertSql = @"
            INSERT INTO Products (TenSP, C_ID, KichCo, MauSac, Gia, SoLuong, Images)
            VALUES (@TenSP, @C_ID, @KichCo, @MauSac, @Gia, @SoLuong, @Images);
            SELECT SCOPE_IDENTITY();";
        
        int newId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
        
        // 🔥 CẬP NHẬT ID NGƯỢC VỀ XML
        row["MaSP"] = newId;
    }
    else
    {
        // ===== UPDATE HIỆN CÓ =====
        string updateSql = @"
            UPDATE Products SET
                TenSP=@TenSP, C_ID=@C_ID, KichCo=@KichCo,
                MauSac=@MauSac, Gia=@Gia, SoLuong=@SoLuong, Images=@Images
            WHERE MaSP=@MaSP";
    }
}

// Lưu XML sau khi sync
dataSet.WriteXml(xmlPath);
```

## 👥 **2. KHÁCH HÀNG (Users)**

### **XML Structure:**
```xml
<!-- App_Data/Users.xml -->
<?xml version="1.0" standalone="yes"?>
<DocumentElement>
  <Users>
    <U_ID>5</U_ID>                    <!-- ID từ SQL -->
    <HoTen>Nguyễn Văn A</HoTen>
    <DiaChi>123 Đường ABC, Q1, HCM</DiaChi>
    <SDT>0901234567</SDT>
    <Email>nguyenvana@email.com</Email>
    <RoleID>3</RoleID>                <!-- 3 = Khách hàng -->
    <TenDangNhap>nguyenvana</TenDangNhap>
    <MatKhau>123456</MatKhau>
    <ChucVu>Khách hàng</ChucVu>
  </Users>
  <Users>
    <!-- Khách hàng mới chưa có U_ID -->
    <HoTen>Trần Thị B</HoTen>
    <DiaChi>456 Đường XYZ, Q2, HCM</DiaChi>
    <SDT>0907654321</SDT>
    <Email>tranthib@email.com</Email>
    <RoleID>3</RoleID>
    <TenDangNhap>tranthib</TenDangNhap>
    <MatKhau>654321</MatKhau>
    <ChucVu>Khách hàng</ChucVu>
  </Users>
</DocumentElement>
```

### **SQL Table:**
```sql
CREATE TABLE Users (
    U_ID INT IDENTITY PRIMARY KEY,    -- Auto-increment ID
    HoTen NVARCHAR(100),
    DiaChi NVARCHAR(200),
    SDT VARCHAR(15),
    Email NVARCHAR(100),
    RoleID INT REFERENCES Roles(RoleID),
    TenDangNhap NVARCHAR(50),
    MatKhau NVARCHAR(100),
    ChucVu NVARCHAR(50) NULL
);
```

### **Sync Process:**
```csharp
// UserDao.SyncXmlToSql()
foreach (DataRow row in xmlTable.Rows)
{
    int uid = row["U_ID"] != DBNull.Value ? Convert.ToInt32(row["U_ID"]) : 0;
    
    if (uid <= 0)
    {
        // ===== INSERT MỚI =====
        string insertSql = @"
            INSERT INTO Users (HoTen, DiaChi, SDT, Email, RoleID, TenDangNhap, MatKhau, ChucVu)
            VALUES (@HoTen, @DiaChi, @SDT, @Email, @RoleID, @TenDangNhap, @MatKhau, @ChucVu);
            SELECT SCOPE_IDENTITY();";
        
        int newId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
        
        // 🔥 CẬP NHẬT ID NGƯỢC VỀ XML
        row["U_ID"] = newId;
    }
    else
    {
        // ===== UPDATE HIỆN CÓ =====
        string updateSql = @"
            UPDATE Users SET
                HoTen=@HoTen, DiaChi=@DiaChi, SDT=@SDT, Email=@Email,
                RoleID=@RoleID, TenDangNhap=@TenDangNhap, MatKhau=@MatKhau, ChucVu=@ChucVu
            WHERE U_ID=@U_ID";
    }
}

// Lưu XML sau khi sync
dataSet.WriteXml(xmlPath);
```

## 📦 **3. ĐƠN HÀNG (DonHang)**

### **XML Structure:**
```xml
<!-- App_Data/DonHang.xml -->
<?xml version="1.0" standalone="yes"?>
<DocumentElement>
  <DonHang>
    <MaDH>1</MaDH>                    <!-- ID từ SQL -->
    <MaKH>5</MaKH>                    <!-- Liên kết với Users -->
    <NgayDat>2024-12-18T10:30:00</NgayDat>
    <TongTien>2500000</TongTien>
    <TrangThai>Chờ xác nhận</TrangThai>
  </DonHang>
  <DonHang>
    <!-- Đơn hàng mới chưa có MaDH -->
    <MaKH>7</MaKH>
    <NgayDat>2024-12-18T14:20:00</NgayDat>
    <TongTien>3200000</TongTien>
    <TrangThai>Đã xác nhận</TrangThai>
  </DonHang>
</DocumentElement>
```

### **SQL Table:**
```sql
CREATE TABLE DonHang (
    MaDH INT IDENTITY PRIMARY KEY,    -- Auto-increment ID
    MaKH INT REFERENCES Users(U_ID),
    NgayDat DATETIME,
    TongTien DECIMAL(10,2),
    TrangThai NVARCHAR(50)
);
```

### **Sync Process:**
```csharp
// DonHangDao.SyncXmlToSql()
foreach (DataRow row in xmlTable.Rows)
{
    int maDH = row["MaDH"] != DBNull.Value ? Convert.ToInt32(row["MaDH"]) : 0;
    
    if (maDH <= 0)
    {
        // ===== INSERT MỚI =====
        string insertSql = @"
            INSERT INTO DonHang (MaKH, NgayDat, TongTien, TrangThai)
            VALUES (@MaKH, @NgayDat, @TongTien, @TrangThai);
            SELECT SCOPE_IDENTITY();";
        
        int newId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
        
        // 🔥 CẬP NHẬT ID NGƯỢC VỀ XML
        row["MaDH"] = newId;
    }
    else
    {
        // ===== UPDATE HIỆN CÓ =====
        string updateSql = @"
            UPDATE DonHang SET
                MaKH=@MaKH, NgayDat=@NgayDat, TongTien=@TongTien, TrangThai=@TrangThai
            WHERE MaDH=@MaDH";
    }
}

// Lưu XML sau khi sync
dataSet.WriteXml(xmlPath);
```

## 🔄 **4. QUY TRÌNH ĐỒNG BỘ TỔNG QUÁT**

### **A. XML → SQL (Import Process):**

```
1. User click "📥 XML → SQL"
         ↓
2. Hiển thị dialog xác nhận
         ↓
3. Đọc file XML từ App_Data/
   - Products.xml
   - Users.xml  
   - DonHang.xml
         ↓
4. Parse XML thành DataTable
         ↓
5. Duyệt từng record:
   ┌─────────────────────────────────┐
   │ Có ID trong XML?                │
   │                                 │
   │ KHÔNG ──► INSERT vào SQL        │
   │    │      ├─ Lấy ID mới         │
   │    │      └─ Cập nhật vào XML   │
   │                                 │
   │ CÓ ────► UPDATE trong SQL       │
   │          └─ Giữ nguyên ID       │
   └─────────────────────────────────┘
         ↓
6. Lưu file XML đã cập nhật
         ↓
7. Reload DataGridView
         ↓
8. Hiển thị thông báo kết quả
```

### **B. SQL → XML (Export Process):**

```
1. User click "📄 Export XML"
         ↓
2. Hiển thị SaveFileDialog
         ↓
3. Query dữ liệu từ SQL Server:
   - SELECT * FROM Products
   - SELECT * FROM Users WHERE RoleID = 3
   - SELECT * FROM DonHang
         ↓
4. Tạo DataSet/DataTable
         ↓
5. Serialize thành XML:
   - XmlSerializer.Serialize()
   - DataSet.WriteXml()
         ↓
6. Lưu file XML mới
         ↓
7. Hiển thị thông báo thành công
```

## 🔧 **5. XỬ LÝ LỖI VÀ VALIDATION**

### **File Validation:**
```csharp
private string GetXmlPath(string fileName)
{
    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\App_Data\", fileName);
    return Path.GetFullPath(path);
}

// Kiểm tra file tồn tại
if (!File.Exists(xmlPath))
{
    return false; // Hoặc tạo file mới
}
```

### **SQL Connection Handling:**
```csharp
try
{
    using (SqlConnection conn = new CSDBConnection().Connection())
    {
        await conn.OpenAsync();
        // Thực hiện operations
    }
}
catch (SqlException ex)
{
    // Xử lý lỗi SQL
    MessageBox.Show($"Lỗi SQL: {ex.Message}");
    return false;
}
catch (Exception ex)
{
    // Xử lý lỗi chung
    MessageBox.Show($"Lỗi: {ex.Message}");
    return false;
}
```

### **Data Validation:**
```csharp
// Kiểm tra dữ liệu hợp lệ
cmd.Parameters.AddWithValue("@TenSP", row["TenSP"] ?? "");
cmd.Parameters.AddWithValue("@Gia", row["Gia"] ?? 0);
cmd.Parameters.AddWithValue("@SoLuong", row["SoLuong"] ?? 0);
```

## 📈 **6. PERFORMANCE & OPTIMIZATION**

### **Batch Processing:**
```csharp
// Xử lý theo batch để tăng hiệu suất
using (SqlTransaction transaction = conn.BeginTransaction())
{
    try
    {
        foreach (DataRow row in xmlTable.Rows)
        {
            // Thực hiện INSERT/UPDATE
        }
        
        transaction.Commit();
        return true;
    }
    catch
    {
        transaction.Rollback();
        return false;
    }
}
```

### **Memory Management:**
```csharp
// Giải phóng tài nguyên
GC.Collect();
GC.WaitForPendingFinalizers();

// Đóng connection
conn.Close();
conn.Dispose();
```

## 🎯 **7. KẾT QUA MONG ĐỢI**

### **Sau khi Import thành công:**
1. ✅ Dữ liệu XML được sync vào SQL Server
2. ✅ ID mới được cập nhật ngược lại XML
3. ✅ DataGridView reload hiển thị dữ liệu mới
4. ✅ File XML được lưu với ID đã cập nhật

### **Sau khi Export thành công:**
1. ✅ Dữ liệu SQL được xuất ra file XML
2. ✅ File XML có cấu trúc chuẩn
3. ✅ Có thể import lại vào hệ thống khác

## 🔍 **8. DEBUGGING & MONITORING**

### **Console Logging:**
```csharp
Console.WriteLine($"Processing record: {row["TenSP"]}");
Console.WriteLine($"New ID generated: {newId}");
Console.WriteLine($"XML updated successfully");
```

### **Error Tracking:**
```csharp
try
{
    // Sync operations
}
catch (Exception ex)
{
    // Log chi tiết lỗi
    File.AppendAllText("error.log", $"{DateTime.Now}: {ex.Message}\n");
    throw;
}
```

---

**Kết luận:** Hệ thống đồng bộ XML ↔ SQL này đảm bảo tính nhất quán dữ liệu giữa hai nguồn lưu trữ, cho phép backup/restore linh hoạt và migration dữ liệu dễ dàng.