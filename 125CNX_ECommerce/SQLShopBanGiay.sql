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
(N'Giày Sneaker Nike Air 42 trắng', 1, N'42', N'Trắng', 1500000, 20, N'https://www.bing.com/images/search?view=detailV2&ccid=CkzIY6SY&id=E94B4F466E43FFDFF70218AC6E68F67CC240D57F&thid=OIP.CkzIY6SYMRCr197ovu7w3gHaIA&mediaurl=https%3a%2f%2fproduct.hstatic.net%2f200000142885%2fproduct%2fz3428622876387_661478f9d3b684f83d1ed2294adc56b7-1_91015f216ad646829bbaaa1877399681_master.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.0a4cc863a4983110abd7dee8beeef0de%3frik%3df9VAwnz2aG6sGA%26pid%3dImgRaw%26r%3d0&exph=831&expw=768&q=Gi%c3%a0y+Sneaker+Nike+Air+43+%c4%91en&FORM=IRPRST&ck=8DF87AF0B7A2FD6DBA710CAAD9D8AF20&selectedIndex=5&itb=0'),
(N'Giày Sneaker Nike Air 43 đen', 1, N'43', N'Đen', 1550000, 25, N'https://www.bing.com/images/search?view=detailV2&ccid=U1DNl%2bAN&id=D01C39D979100C49A486695042562D4D07A553ED&thid=OIP.U1DNl-ANr_SDkDf_y8PPXgHaHa&mediaurl=https%3a%2f%2fcdn.vuahanghieu.com%2funsafe%2f0x900%2fleft%2ftop%2fsmart%2ffilters%3aquality(90)%2fhttps%3a%2f%2fadmin.vuahanghieu.com%2fupload%2fproduct%2f2023%2f12%2fgiay-the-thao-nike-air-dunk-low-jumbo-shoes-fb8894-001-mau-den-657cfce0668f1-16122023082656.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.5350cd97e00daff4839037ffcbc3cf5e%3frik%3d7VOlB00tVkJQaQ%26pid%3dImgRaw%26r%3d0&exph=900&expw=900&q=Gi%c3%a0y+Sneaker+Nike+Air+43+%c4%91en&FORM=IRPRST&ck=913E97A5718F4D1F3936D037B319175A&selectedIndex=1&itb=0'),
(N'Sandal Nữ quai ngang đen', 2, N'38', N'Đen', 460000, 40, N'https://www.bing.com/images/search?view=detailV2&ccid=xyMmyfEw&id=578ECBE5EA6458B4E82128B6459017D6181CCE41&thid=OIP.xyMmyfEw9G1N2h9U_-S1cgHaJ4&mediaurl=https%3a%2f%2fdown-vn.img.susercontent.com%2ffile%2fvn-11134208-7r98o-lswew24wo5954b&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.c72326c9f130f46d4dda1f54ffe4b572%3frik%3dQc4cGNYXkEW2KA%26pid%3dImgRaw%26r%3d0&exph=1000&expw=750&q=Sandal+N%e1%bb%af+quai+ngang+%c4%91en&FORM=IRPRST&ck=51699502B92369148689A6042AAD1B71&selectedIndex=2&itb=0'),
(N'Sandal Nữ quai ngang hồng', 2, N'37', N'Hồng', 450000, 30, N'https://www.bing.com/images/search?view=detailV2&ccid=f1s%2bUyO2&id=1C531AB9E406464395D4F4C6C6E5C6535F5AD52D&thid=OIP.f1s-UyO2NYHC8NxyanuQVQHaLH&mediaurl=https%3a%2f%2ffile.hstatic.net%2f1000284478%2ffile%2fthuong-hieu-giay-sneaker-viet-nam-9_8fc866f5cec44a33bb668c86054b72eb.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.7f5b3e5323b63581c2f0dc726a7b9055%3frik%3dLdVaX1PG5cbG9A%26pid%3dImgRaw%26r%3d0&exph=900&expw=600&q=gi%c3%a0y&FORM=IRPRST&ck=6015410B8E774400CC2B52C43DE7D99E&selectedIndex=8&itb=0'),
(N'Giày cao gót 9cm đỏ', 3, N'38', N'Đỏ', 700000, 15, N'https://www.bing.com/images/search?view=detailV2&ccid=NumZYHWa&id=BA1ADABDD8E6056BDE5639CCB147A57CB8B31513&thid=OIP.NumZYHWaIeyKHXVYNpUL7gHaHa&mediaurl=https%3a%2f%2flh7-us.googleusercontent.com%2fhAMXznKYgHgdDsCNx9NfvDKVR-GxUtpo9fD2n1NExp3QJ8D4MjXTYzjwGQ5_miBF-YLXRlbR9kbsV8fgaGyKXkWJij1dwpbusG9K0uSaUpBvzkiaeIcZPOTVXjybLIyXQjDf_yBtMWjCo8w9Jv5_Hg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.36e99960759a21ec8a1d755836950bee%3frik%3dExWzuHylR7HMOQ%26pid%3dImgRaw%26r%3d0&exph=1280&expw=1280&q=gi%c3%a0y&FORM=IRPRST&ck=0041040186BF880201D80C01B36356DB&selectedIndex=16&itb=0'),
(N'Dép lê nam Adidas xanh', 4, N'42', N'Xanh', 320000, 50, N'https://www.bing.com/images/search?view=detailV2&ccid=7AFDCARn&id=E874B955D1E40B28C031C77E34094CCEF0DDBC5A&thid=OIP.7AFDCARn4voHpyeOLbjcXAHaHa&mediaurl=https%3a%2f%2fcf.shopee.vn%2ffile%2fec0143080467e2fa07a7278e2db8dc5c&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.ec0143080467e2fa07a7278e2db8dc5c%3frik%3dWrzd8M5MCTR%252bxw%26pid%3dImgRaw%26r%3d0&exph=600&expw=600&q=D%c3%a9p+l%c3%aa+nam+Adidas+xanh&FORM=IRPRST&ck=B5332DCE3E30FDF55B1AC02B61D25D8C&selectedIndex=2&itb=0'),
(N'Boot nữ da lộn nâu', 5, N'36', N'Nâu', 1200000, 8, N'https://www.bing.com/images/search?view=detailV2&ccid=3L1%2f%2beG1&id=25240974038B25D30ADF3F139B911703B54CAF96&thid=OIP.3L1_-eG1bWThUJraapmQdwHaJH&mediaurl=https%3a%2f%2fgiaybootnu.com%2fupload%2fimages%2fboot-nu-co-thun-mau-nau-xam-da-lon-de-4cm-em-chan-gbn118b.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.dcbd7ff9e1b56d64e1509ada6a999077%3frik%3dlq9MtQMXkZsTPw%26pid%3dImgRaw%26r%3d0&exph=606&expw=492&q=Boot+n%e1%bb%af+da+l%e1%bb%99n+n%c3%a2u&FORM=IRPRST&ck=DC632DB264776C0151332B961788DAFC&selectedIndex=0&itb=0');

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

UPDATE Products SET Images = 'https://product.hstatic.net/200000142885/product/z3428622876387_661478f9d3b684f83d1ed2294adc56b7-1_91015f216ad646829bbaaa1877399681_master.jpg' WHERE TenSP = N'Giày Sneaker Nike Air 42 trắng';

UPDATE Products SET Images = 'https://cdn.vuahanghieu.com/unsafe/0x900/left/top/smart/filters:quality(90)/https://admin.vuahanghieu.com/upload/product/2023/12/giay-the-thao-nike-air-dunk-low-jumbo-shoes-fb8894-001-mau-den-657cfce0668f1-16122023082656.jpg' WHERE TenSP = N'Giày Sneaker Nike Air 43 đen';

UPDATE Products SET Images = 'https://down-vn.img.susercontent.com/file/vn-11134208-7r98o-lswew24wo5954b' WHERE TenSP = N'Sandal Nữ quai ngang đen';

UPDATE Products SET Images = 'https://file.hstatic.net/1000284478/file/thuong-hieu-giay-sneaker-viet-nam-9_8fc866f5cec44a33bb668c86054b72eb.jpg' WHERE TenSP = N'Sandal Nữ quai ngang hồng';

UPDATE Products SET Images = 'https://lh7-us.googleusercontent.com/hAMXznKYgHgdDsCNx9NfvDKVR-GxUtpo9fD2n1NExp3QJ8D4MjXTYzjwGQ5_miBF-YLXRlbR9kbsV8fgaGyKXkWJij1dwpbusG9K0uSaUpBvzkiaeIcZPOTVXjybLIyXQjDf_yBtMWjCo8w9Jv5_Hg' WHERE TenSP = N'Giày cao gót 9cm đỏ';

UPDATE Products SET Images = 'https://cf.shopee.vn/file/ec0143080467e2fa07a7278e2db8dc5c' WHERE TenSP = N'Dép lê nam Adidas xanh';

UPDATE Products SET Images = 'https://giaybootnu.com/upload/images/boot-nu-co-thun-mau-nau-xam-da-lon-de-4cm-em-chan-gbn118b.jpg' WHERE TenSP = N'Boot nữ da lộn nâu';
