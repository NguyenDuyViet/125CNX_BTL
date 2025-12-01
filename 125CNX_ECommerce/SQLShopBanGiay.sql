USE master;
GO

ALTER DATABASE SQLShopBanGiay SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE IF EXISTS SQLShopBanGiay;
GO
CREATE DATABASE SQLShopBanGiay;
GO
USE SQLShopBanGiay;
GO

-- Bảng phân quyền
CREATE TABLE Roles (
    RoleID INT IDENTITY PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL
);

-- Bảng loại sản phẩm
CREATE TABLE Categories (
    C_ID INT IDENTITY PRIMARY KEY,
    C_Name NVARCHAR(50)
);

-- Người dùng (chung cho cả nhân viên & khách hàng)
CREATE TABLE Users (
    U_ID INT IDENTITY PRIMARY KEY,
    HoTen NVARCHAR(100),
    DiaChi NVARCHAR(200),
    SDT VARCHAR(15),
    Email NVARCHAR(100),
    RoleID INT REFERENCES Roles(RoleID),
    TenDangNhap NVARCHAR(50),
    MatKhau NVARCHAR(100),
    ChucVu NVARCHAR(50) NULL
);

-- Sản phẩm
CREATE TABLE Products(
    MaSP INT IDENTITY PRIMARY KEY,
    TenSP NVARCHAR(100),
    C_ID INT REFERENCES Categories(C_ID),
    KichCo NVARCHAR(10),
    MauSac NVARCHAR(30),
    Gia DECIMAL(10,2),
    SoLuong INT,
    Images NVARCHAR(MAX)
);

-- Yêu thích sản phẩm
CREATE TABLE Wishlist(
    YeuThichID INT IDENTITY PRIMARY KEY,
    U_ID INT REFERENCES Users(U_ID),
    MaSP INT REFERENCES Products(MaSP),
    NgayYeuThich DATE DEFAULT GETDATE()
);

-- Giỏ hàng (1 user có nhiều sản phẩm trong giỏ, nghĩ đơn giản không cần bảng Cart riêng)
CREATE TABLE GioHang (
    GioHangID INT IDENTITY PRIMARY KEY,
    U_ID INT REFERENCES Users(U_ID),
    MaSP INT REFERENCES Products(MaSP),
    SoLuong INT NOT NULL,
    NgayThem DATE DEFAULT GETDATE()
);

-- Đơn hàng
CREATE TABLE DonHang (
    MaDH INT IDENTITY PRIMARY KEY,
    MaKH INT REFERENCES Users(U_ID),
    NgayDat DATE,
    TongTien DECIMAL(10,2),
    TrangThai NVARCHAR(50)
);

-- Chi tiết đơn hàng
CREATE TABLE ChiTietDonHang (
    MaCTDH INT IDENTITY PRIMARY KEY,
    MaDH INT REFERENCES DonHang(MaDH) ON DELETE CASCADE,
    MaSP INT REFERENCES Products(MaSP),
    SoLuong INT,
    DonGia DECIMAL(10,2)
);

-- Hóa đơn
CREATE TABLE HoaDon (
    MaHD INT IDENTITY PRIMARY KEY,
    MaDH INT REFERENCES DonHang(MaDH),
    NgayLap DATE,
    TongTien DECIMAL(10,2),
    TrangThai NVARCHAR(50)
);

-- Chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon (
    MaCTHD INT IDENTITY PRIMARY KEY,
    MaHD INT REFERENCES HoaDon(MaHD),
    MaSP INT REFERENCES Products(MaSP),
    SoLuong INT,
    DonGia DECIMAL(10,2)
);

-- Thanh toán
CREATE TABLE ThanhToan (
    MaTT INT IDENTITY PRIMARY KEY,
    MaHD INT REFERENCES HoaDon(MaHD),
    PhuongThuc NVARCHAR(50),
    SoTien DECIMAL(10,2),
    NgayTT DATE,
    TrangThai NVARCHAR(50)
);

-- Vai trò
INSERT INTO Roles(RoleName) VALUES
(N'Admin'), (N'Nhân viên'), (N'Khách hàng'), (N'Quản lý');

-- Loại sản phẩm
INSERT INTO Categories(C_Name) VALUES
(N'Sneaker'), (N'Sandal'), (N'Cao gót'), (N'Dép'), (N'Boot');

-- Người dùng
INSERT INTO Users (HoTen, DiaChi, SDT, Email, RoleID, TenDangNhap, MatKhau, ChucVu) VALUES
(N'Nguyễn Văn An', N'12 Lê Lợi, Hà Nội', '0901234567', 'an@gmail.com', 3, 'an123', '123456', NULL),
(N'Lê Thị B', N'22 Nguyễn Huệ, Huế', '0911987687', 'btle@gmail.com', 3, 'letb', '654321', NULL),
(N'Nguyễn Hồng Quân', N'15 Pasteur, TP.HCM', '0978661234', 'quanhnv@gmail.com', 2, 'quanhnv', 'nv9876', N'Bán hàng'),
(N'Phạm Thị Hoa', N'Kho hàng', '0988008877', 'hoapt@gmail.com', 2, 'hoapt', 'nv2345', N'Kho'),
(N'Hoàng Minh', N'KT, Hà Nội', '0933445566', 'minhhm@gmail.com', 4, 'minhhm', '123123', N'Quản lý'),
(N'Trần Mai', N'24 Hai Bà Trưng, Hà Nội', '0966112211', 'maitr@gmail.com', 3, 'traimai', '123abc', NULL);

-- Sản phẩm
INSERT INTO Products (TenSP, C_ID, KichCo, MauSac, Gia, SoLuong, Images) VALUES
(N'Giày Sneaker Nike Air 42 trắng', 1, N'42', N'Trắng', 1500000, 20, N'https://sneakerdouble.net/wp-content/uploads/2023/07/image-4-compressed.jpg'),
(N'Giày Sneaker Nike Air 43 đen', 1, N'43', N'Đen', 1550000, 25, N'https://i.pinimg.com/474x/1f/80/b8/1f80b82585f81b4d75f14cab8ef42d32.jpg'),
(N'Sandal Nữ quai ngang đen', 2, N'38', N'Đen', 460000, 40, N'https://shop.r10s.jp/ferrisota/cabinet/3123/168690406-1.jpg'),
(N'Sandal Nữ quai ngang hồng', 2, N'37', N'Hồng', 450000, 30, N'https://image.rakuten.co.jp/windyshop/cabinet/sandals/sandals-20a005_1.jpg'),
(N'Giày cao gót 9cm đỏ', 3, N'38', N'Đỏ', 700000, 15, N'https://down-vn.img.susercontent.com/file/vn-11134207-7ras8-md0mnyyw5zfgd2'),
(N'Dép lê nam Adidas xanh', 4, N'42', N'Xanh', 320000, 50, N'https://www.sportzon.rs/files/thumbs/files/images/slike_proizvoda/thumbs_600/F35541_600_900px.jpg'),
(N'Boot nữ da lộn nâu', 5, N'36', N'Nâu', 1200000, 8, N'https://di2ponv0v5otw.cloudfront.net/posts/2023/01/04/63b5aff1f8c5da45a337b56e/m_63b5afff8d7a3c6cc9f9c92b.jpg'),
(N'Giày Sneaker Adidas Ultraboost', 1, N'40', N'Đen', 1800000, 18, N'https://cdn.vuahanghieu.com/unsafe/0x900/left/top/smart/filters:quality(90)/https://admin.vuahanghieu.com/upload/product/2022/10/giay-the-thao-adidas-pharrell-williams-ultraboost-dna-shoes-h01893-mau-den-size-40-63438da211836-10102022101234.jpg');
-- Đơn hàng
INSERT INTO DonHang (MaKH, NgayDat, TongTien, TrangThai) VALUES
(1, '2025-10-10', 1550000, N'Chờ xác nhận'),
(2, '2025-10-12', 450000, N'Đã giao'),
(6, '2025-10-15', 320000, N'Đã giao'),
(1, '2025-10-16', 700000, N'Đã hủy'),
(2, '2025-10-22', 1200000, N'Chờ xác nhận');

-- Chi tiết đơn hàng
INSERT INTO ChiTietDonHang (MaDH, MaSP, SoLuong, DonGia) VALUES
(1, 2, 1, 1550000),
(2, 4, 1, 450000),
(3, 6, 1, 320000),
(4, 5, 1, 700000),
(5, 7, 1, 1200000);

-- Hóa đơn
INSERT INTO HoaDon (MaDH, NgayLap, TongTien, TrangThai) VALUES
(1, '2025-10-10', 1550000, N'Chưa thanh toán'),
(2, '2025-10-12', 450000, N'Đã thanh toán'),
(3, '2025-10-15', 320000, N'Chưa thanh toán'),
(4, '2025-10-16', 700000, N'Đã hủy'),
(5, '2025-10-22', 1200000, N'Chưa thanh toán');

-- Thanh toán
INSERT INTO ThanhToan (MaHD, PhuongThuc, SoTien, NgayTT, TrangThai) VALUES
(2, N'Tiền mặt', 450000, '2025-10-12', N'Hoàn tất'),
(3, N'Chuyển khoản', 320000, '2025-10-15', N'Hoàn tất');

-- Yêu thích sản phẩm
INSERT INTO Wishlist (U_ID, MaSP) VALUES
(1, 1), (1, 2),           -- User 1 thích sp 1, 2
(2, 1),                   -- User 2 thích sp 1
(3, 7),                   -- Nhân viên cũng có thể thích sản phẩm (tuỳ business)
(6, 3), (6, 4);           -- User 6 thích sp 3, 4

-- Giỏ hàng (U_ID, MaSP, SoLuong)
INSERT INTO GioHang (U_ID, MaSP, SoLuong) VALUES
(1, 2, 2),
(1, 6, 1),
(2, 3, 1),
(2, 4, 1),
(6, 1, 1),
(6, 5, 2);

-- Chi tiết hóa đơn
INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia) VALUES
(1, 2, 1, 1550000),
(2, 4, 1, 450000),
(2, 3, 2, 460000),   -- cùng trong 1 hóa đơn có nhiều sản phẩm
(3, 6, 1, 320000),
(4, 5, 1, 700000),
(5, 7, 1, 1200000);

