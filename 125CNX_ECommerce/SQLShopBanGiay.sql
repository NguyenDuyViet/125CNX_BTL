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
(N'Trần Mai', N'24 Hai Bà Trưng, Hà Nội', '0966112211', 'maitr@gmail.com', 3, 'traimai', '123abc', NULL),
(N'Quản trị viên', N'Hệ thống', '', '', 1, 'admin', 'admin123', N'Admin');

-- Sản phẩm
INSERT INTO Products (TenSP, C_ID, KichCo, MauSac, Gia, SoLuong, Images) VALUES
-- Sneaker
(N'Giày Sneaker Nike Air 42 ', 1, N'42', N'Trắng', 1500000, 20, N'https://sneakerdouble.net/wp-content/uploads/2023/07/image-4-compressed.jpg'),
(N'Giày Sneaker Nike Air 43 đen', 1, N'43', N'Đen', 1550000, 25, N'https://i.pinimg.com/474x/1f/80/b8/1f80b82585f81b4d75f14cab8ef42d32.jpg'),
(N'Giày Sneaker Adidas ', 1, N'40', N'Đen', 1800000, 18, N'https://cdn.vuahanghieu.com/unsafe/0x900/left/top/smart/filters:quality(90)/https://admin.vuahanghieu.com/upload/product/2022/10/giay-the-thao-adidas-pharrell-williams-ultraboost-dna-shoes-h01893-mau-den-size-40-63438da211836-10102022101234.jpg'),
(N'Giày Sneaker Nike Jordan  ', 1, N'42', N'Trắng/Đỏ', 2100000, 15, N'https://cdn.vuahanghieu.com/unsafe/0x900/left/top/smart/filters:quality(90)/https://admin.vuahanghieu.com/upload/product/2022/11/giay-the-thao-nike-air-jordan-1-low-reverse-black-toe-dc0774-160-mau-do-trang-size-43-638430ce90e8f-28112022105350.jpg'),
(N'Giày Sneaker Nike Air Force 1 ', 1, N'41', N'Trắng', 1900000, 22, N'https://item-shopping.c.yimg.jp/i/n/joyfoot_dv0788-100'),
(N'Giày Sneaker Adidas Stan ', 1, N'40', N'Trắng/Xanh', 1650000, 20, N'https://giaysneakerhcm.com/wp-content/uploads/2018/06/giay-stan-smith-got-xanh-la-4.jpeg'),
(N'Giày Sneaker Puma RS-X ', 1, N'43', N'Trắng/Xanh', 1750000, 18, N'https://cdn.vuahanghieu.com/unsafe/0x900/left/top/smart/filters:quality(90)/https://admin.vuahanghieu.com/upload/product/2023/06/giay-the-thao-puma-rebound-game-row-sneakers-386373-mau-trang-xanh-green-size-40-5-64993f5b5d072-26062023143347.jpg'),
(N'Giày Sneaker Converse  ', 1, N'42', N'Đen', 1500000, 25, N'https://cf.shopee.vn/file/857a2dc8ba76c87b763b71f786067cee'),
(N'Giày Sneaker Vans Old Skool', 1, N'41', N'Đen/Trắng', 1450000, 30, N'https://down-br.img.susercontent.com/file/br-11134201-23010-e5oypgsrzjmv2f'),

-- Sandal
(N'Sandal Nữ quai ngang đen', 2, N'38', N'Đen', 460000, 40, N'https://shop.r10s.jp/ferrisota/cabinet/3123/168690406-1.jpg'),
(N'Sandal Nữ quai ngang hồng', 2, N'37', N'Hồng', 450000, 30, N'https://image.rakuten.co.jp/windyshop/cabinet/sandals/sandals-20a005_1.jpg'),
(N'Sandal nam quai ngang ', 2, N'42', N'Đen', 350000, 40, N'https://product.hstatic.net/200000104423/product/hunter_sd_11009__3__copy_8f838f68d11c4b709c940b8f944bd21e_master.jpg'),
(N'Sandal nữ đế bệt trắng ', 2, N'37', N'Trắng', 380000, 35, N'https://cf.shopee.vn/file/bbc75114e9109dd49f777df7cb0244bb'),
(N'Sandal nữ cao 5cm kem', 2, N'38', N'Kem', 420000, 25, N'https://cdn.shop-list.com/res/up/shoplist/shp/__thum370__/styleblock/94/sb-sandal194_5.jpg'),
(N'Sandal nam kiểu Hàn Quốc ', 2, N'43', N'Nâu', 390000, 28, N'https://img.kwcdn.com/product/Fancyalgo/VirtualModelMatting/68cbbf7e9d81da6c4c2c282b8489e686.jpg'),
(N'Sandal nữ quai mảnh ', 2, N'36', N'Hồng', 450000, 32, N'https://static.dafiti.com.br/p/Klin-Sand%C3%A1lia-Infantil-Klin-Suami-Rosa-2502-05172831-1-zoom.jpg'),

-- Cao gót
(N'Giày cao gót 9cm đỏ', 3, N'38', N'Đỏ', 700000, 15, N'https://down-vn.img.susercontent.com/file/vn-11134207-7ras8-md0mnyyw5zfgd2'),
(N'Giày cao gót 7cm mũi nhọn ', 3, N'37', N'Đen', 650000, 18, N'https://agiay.vn/wp-content/uploads/2022/08/1.dior-min-1024x1024.jpg'),
(N'Giày cao gót 5cm quai trong', 3, N'38', N'Trắng Trong', 620000, 22, N'https://elise.vn/media/catalog/product/cache/bb52e54e5ec1828d48ae8bf7c98f9f69/f/s/fs2105003fslebk.jpg'),
(N'Giày cao gót 9cm ánh kim ', 3, N'39', N'Bạc', 780000, 12, N'https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lqdnbtd4c30705'),
(N'Giày cao gót mũi vuông nude', 3, N'37', N'Nude', 690000, 20, N'https://cdn.chiaki.vn/unsafe/0x900/left/top/smart/filters:quality(90)/https://chiaki.vn/upload/product/2022/11/dep-sandals-charles-keith-ankle-strap-stacked-heel-ck1-60190301-chalk-636c5a4821894-10112022085624.jpg'),
(N'Giày cao gót slingback 6cm ', 3, N'38', N'Đỏ đô', 720000, 14, N'https://tse1.mm.bing.net/th/id/OIP.CDgvIjqz8m1FDOE6jJtPAgHaHa?rs=1&pid=ImgDetMain&o=7&rm=3'),

-- Dép
(N'Dép lê nam Adidas xanh', 4, N'42', N'Xanh', 320000, 50, N'https://www.sportzon.rs/files/thumbs/files/images/slike_proizvoda/thumbs_600/F35541_600_900px.jpg'),
(N'Dép lê nam Nike đen trắng', 4, N'43', N'Đen/Trắng', 350000, 50, N'https://tse3.mm.bing.net/th/id/OIP.NvKwYmyGBci6c_rNtLvLWwHaHa?w=1024&h=1024&rs=1&pid=ImgDetMain&o=7&rm=3'),
(N'Dép thời trang nữ màu ', 4, N'37', N'Hồng', 220000, 45, N'https://tse2.mm.bing.net/th/id/OIP.9LSQhce0kCDdipO-3x6-AQHaFn?rs=1&pid=ImgDetMain&o=7&rm=3'),
(N'Dép kẹp nam Adidas đen', 4, N'42', N'Đen', 300000, 60, N'https://down-id.img.susercontent.com/file/id-11134207-7rase-m3mccqm0livo7f'),
(N'Dép lông nữ màu kem ', 4, N'36', N'Kem', 180000, 55, N'https://down-vn.img.susercontent.com/file/sg-11134201-7rcev-ltdejpqqx9qs75'),
(N'Dép tổ ong truyền thống vàng', 4, N'41', N'Vàng', 120000, 80, N'https://sieuthisieure.vn/SalesUploads/141/19082018/128833aa-b04f-42e8-a5fc-9f1eec8a9ad6.jpg'),

-- Boot
(N'Boot nữ da lộn nâu', 5, N'36', N'Nâu', 1200000, 8, N'https://di2ponv0v5otw.cloudfront.net/posts/2023/01/04/63b5aff1f8c5da45a337b56e/m_63b5afff8d7a3c6cc9f9c92b.jpg'),
(N'Boot nữ cổ ngắn đen', 5, N'37', N'Đen', 1350000, 10, N'https://giaybootnu.com/kcfinder/upload/images/GBN-32/boot-de-tret-cot-day-mau-den-xinh-xan-08.jpg'),
(N'Boot nữ da bóng cổ cao', 5, N'38', N'Đen', 1450000, 8, N'https://tse4.mm.bing.net/th/id/OIP.q5sXSifoo24QoLjwJ1rwZgHaHa?rs=1&pid=ImgDetMain&o=7&rm=3'),
(N'Boot nam da bò nâu', 5, N'42', N'Nâu', 1600000, 12, N'https://forshoes.vn/wp-content/uploads/2024/03/Goc-1-6.webp'),
(N'Boot nữ da lộn cao cổ xám', 5, N'36', N'Xám', 1300000, 9, N'https://cf.shopee.vn/file/c2ef3ab21abfb0a62f27a416e15554ef'),
(N'Boot nam Chelsea đen', 5, N'41', N'Đen', 1750000, 14, N'https://www.sohada.vn/wp-content/uploads/2022/11/z3904227141861a0cd1549f6fb6aac9fdbefca74489fbd.jpg'),
(N'Boot nữ đế cao 7cm màu kem', 5, N'37', N'Kem', 1400000, 11, N'https://tse4.mm.bing.net/th/id/OIP.niAYJRi0EAS0KxOKedG9iwHaHa?rs=1&pid=ImgDetMain&o=7&rm=3');
--đơn hàng
INSERT INTO DonHang (MaKH, NgayDat, TongTien, TrangThai) VALUES
(1, '2025-01-10', 1550000, N'Chờ xác nhận'),
(2, '2025-02-12', 450000,  N'Đã giao'),
(6, '2025-03-15', 320000,  N'Đã giao'),
(1, '2025-04-16', 700000,  N'Đã hủy'),
(2, '2025-05-22', 1200000, N'Chờ xác nhận'),
(3, '2025-06-10', 980000,  N'Đã giao'),
(4, '2025-07-11', 410000,  N'Chờ xác nhận'),
(5, '2025-08-12', 860000,  N'Đã giao'),
(1, '2025-09-13', 530000,  N'Chờ xác nhận'),
(2, '2025-10-14', 1500000, N'Đã giao'),
(3, '2025-11-15', 620000,  N'Đã hủy'),
(4, '2025-12-16', 1100000, N'Chờ xác nhận');



-- Chi tiết đơn hàng
INSERT INTO ChiTietDonHang (MaDH, MaSP, SoLuong, DonGia) VALUES
(1, 2, 1, 1550000),
(2, 4, 1, 450000),
(3, 6, 1, 320000),
(4, 5, 1, 700000),
(5, 7, 1, 1200000);

-- Hóa đơn
INSERT INTO HoaDon (MaDH, NgayLap, TongTien, TrangThai) VALUES
(1, '2025-01-10', 1550000, N'Chưa thanh toán'),
(2, '2025-02-12', 450000,  N'Đã thanh toán'),
(3, '2025-03-15', 320000,  N'Chưa thanh toán'),
(4, '2025-04-16', 700000,  N'Đã hủy'),
(5, '2025-05-22', 1200000, N'Chưa thanh toán'),
(6,  '2025-06-10', 980000,  N'Đã thanh toán'),
(7,  '2025-07-11', 410000,  N'Chưa thanh toán'),
(8,  '2025-08-12', 860000,  N'Đã thanh toán'),
(9,  '2025-09-13', 530000,  N'Chưa thanh toán'),
(10, '2025-10-14', 1500000, N'Đã thanh toán'),
(11, '2025-11-15', 620000,  N'Đã hủy'),
(12, '2025-12-16', 1100000, N'Chưa thanh toán');

-- Thanh toán
INSERT INTO ThanhToan (MaHD, PhuongThuc, SoTien, NgayTT, TrangThai) VALUES
(2, N'Tiền mặt', 450000, '2025-10-12', N'Hoàn tất'),
(3, N'Chuyển khoản', 320000, '2025-10-15', N'Hoàn tất');

-- Chi tiết hóa đơn
INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia) VALUES
(1, 2, 1, 1550000),
(2, 4, 1, 450000),
(2, 3, 2, 460000),   -- cùng trong 1 hóa đơn có nhiều sản phẩm
(3, 6, 1, 320000),
(4, 5, 1, 700000),
(5, 7, 1, 1200000);

SELECT * FROM dbo.Products;
