/*
DATABASE QUẢN LÝ QUẦY THUỐC
*/

-------TẠO CƠ SỞ DỮ LIỆU-------
create database DrugStoreDB
ON PRIMARY
(
	NAME = 'quanLyQT',
	filename = 'D:\DrugStoreDB.mdf',
	size = 10MB,
	filegrowth = 20%,
	maxsize = 50MB
)
log on
(
	name = 'quanLyQT_log',
	filename = 'D:\DrugStoreDB_log.ldf',
	size = 10MB,
	filegrowth = 10%,
	maxsize = 20MB 
)

-------TẠO BẢNG-------
use DrugStoreDB

--1.LOẠI THUỐC
create table loaiThuoc
(
	maLoai nchar(3) not null,
	tenLoai nvarchar(30)
)

--2.ĐƠN VỊ TÍNH
create table donViTinh
(
	maDVT nchar(3) not null,
	tenDVT nvarchar(20)
)

--3.NƯỚC XUẤT XỨ
create table nuoc
(
	maNuoc nchar(3) not null,
	tenNuoc nvarchar(30)
)

--4.THUỐC
create table thuoc
(
	maThuoc nchar(8) not null, 
	tenThuoc nvarchar(40) not null, 
	maNCC int,
	moTa nvarchar(700),
	maLoai nchar(3),
	maDVT nchar(3),
	giaGoc money,
	giaBan money,
	slTon int,
	maNuoc nchar(3),
	hanSuDung datetime
)

--5.HÓA ĐƠN
create table hoaDon
(
	maHoaDon INT IDENTITY(1,1),
	ngayLapHD dateTime,
	maNV nchar(5),
	maKH nchar(5)
)

--6.CHI TIẾT HÓA ĐƠN
create table ct_hoaDon
(
	maHD int,
	maThuoc nchar(8) not null,
	soLuong int,
	donGia money,
	thue float
)

--7.NHÀ CUNG CẤP
create table nhaCungCap
(
	maNCC int not null,
	tenNCC nvarchar(200) not null,
	diaChi nvarchar(500),
	phone nvarchar(15)
)

--8.KHÁCH HÀNG
create table khachHang
(
	maKH nchar(5) not null,
	tenKH nvarchar(40) not null,
	diaChi nvarchar(500),
	phone nvarchar(24)
)

--9.NHÂN VIÊN
create table nhanVien
(
	maNV nchar(5) not null,
	tenNV nvarchar(40) not null,
	diaChi nvarchar(500),
	dienThoai nvarchar(24),
	maLoaiNV nchar(2) not null
)

--10.LOẠI NHÂN VIÊN
create table loaiNhanVien
(
	maLoaiNV nchar(2) not null,
	tenLoaiNV nvarchar(50)
)
--11.TÀI KHOẢN
create table taiKhoan
(
	matKhau nchar(20) not null,
	maNV nchar(5) not null
)

-------TẠO KHÓA-------

--KHÓA CHÍNH
alter table loaiThuoc
add constraint pk_maLoai primary key (maLoai)
alter table thuoc
add constraint pk_maThuoc primary key (maThuoc)
alter table hoaDon
add constraint pk_maHoaDon primary key (maHoaDon)
alter table nhaCungCap
add constraint pk_maNCC primary key (maNCC)
alter table khachHang
add constraint pk_maKH primary key (maKH)
alter table nhanVien
add constraint pk_maNV primary key (maNV)
alter table loaiNhanVien
add constraint pk_maLNV primary key (maLoaiNV)
alter table donViTinh
add constraint pk_maDVT primary key (maDVT)
alter table nuoc
add constraint pk_maNuoc primary key (maNuoc)

--KHÓA NGOẠI
alter table thuoc
add constraint fk_maLoai foreign key (maLoai) references loaiThuoc(maLoai),
    constraint fk_maNCC foreign key (maNCC) references nhaCungCap(maNCC),
	constraint fk_maDVT foreign key (maDVT) references donViTinh(maDVT),
	constraint fk_maNuoc foreign key (maNuoc) references nuoc(maNuoc)
alter table hoaDon
add constraint fk_maNV foreign key (maNV) references nhanVien(maNV),
	constraint fk_maKH foreign key (maKH) references khachHang(maKH)
alter table ct_hoaDon
add constraint fk_maHD foreign key (maHD) references hoaDon(maHoaDon),
	constraint fk_maThuoc foreign key (maThuoc) references thuoc(maThuoc)
alter table nhanVien
add constraint fk_maLNV foreign key (maLoaiNV) references loaiNhanVien(maLoaiNV)
alter table taiKhoan
add constraint fk_TaiKhoan foreign key (maNV) references nhanVien(maNV)

-------NHẬP DỮ LIỆU-------

--1.LOẠI THUỐC
insert into loaiThuoc values
( 'HST', N'Hạ sốt'),
( 'GID', N'Giảm đau'),
( 'HOH', N'Hô hấp'),
( 'KHS', N'Kháng sinh'),
( 'ANT', N'An thần'),
( 'GAN', N'Bệnh về gan'),
( 'UNT', N'Ung thư(chung)'),
( 'VIT', N'Vitamin, khoáng chất'),
( 'HUA', N'Huyết áp, tim mạch'),
( 'TRG', N'Thuốc trị giun'),
( 'DAD', N'Thuốc chữa dạ dày'),
( 'HUY', N'Thuốc điều trị xuất huyết')

select *from loaiThuoc

--2.ĐƠN VỊ TÍNH
insert into donViTinh values
( 'VI', N'Vỉ'),
( 'HOP', N'Hộp'),
( 'GOI', N'Gói'),
( 'VIE', N'Viên'),
( 'LO', N'Lọ'),
( 'CHA', N'Chai'),
( 'ONG', N'Ống')

--3.NƯỚC
insert into nuoc values
( 'AFG', N'Afghanistan'),
( 'ALB', N'Albania'),
( 'DZA', N'Algeria'),
( 'AND', N'Andorra'),
( 'ARG', N'Argentina'),
( 'AUS', N'Australia'),
( 'BEL', N'Bỉ'),
( 'BRA', N'Brazil'),
( 'BRN', N'Brunei'),
( 'KHM', N'Cam-pu-chia'),
( 'CAN', N'Canada'),
( 'CHN', N'Trung Quốc'),
( 'COL', N'Colombia'),
( 'CUB', N'Cuba'),
( 'EGY', N'Hi Lạp'),
( 'FIN', N'Phần Lan'),
( 'FRA', N'Pháp'),
( 'DEU', N'Đức'),
( 'HUN', N'Hungary'),
( 'ISL', N'Iceland'),
( 'IND', N'Ấn Độ'),
( 'IDN', N'Indonesia'),
( 'IRN', N'Iran'),
( 'IRQ', N'Iraq'),
( 'IRL', N'Ireland'),
( 'ISR', N'Israel'),
( 'ITA', N'Ý'),
( 'JPN', N'Nhật bản'),
( 'KGZ', N'Kyrgyzstan'),
( 'LAO', N'Lào'),
( 'LVA', N'Latvia'),
( 'LBN', N'Lebanon'),
( 'LBR', N'Liberia'),
( 'LBY', N'Libya'),
( 'LUX', N'Luxembourg'),
( 'MYS', N'Malaysia'),
( 'MEX', N'Mexico'),
( 'MDA', N'Moldova'),
( 'MCO', N'Monaco'),
( 'MNG', N'Mông Cổ'),
( 'MMR', N'Myanmar'),
( 'NLD', N'Hà Lan'),
( 'NZL', N'New Zealand'),
( 'NGA', N'Nigeria'),
( 'PRK', N'Triều Tiên'),
( 'OMN', N'Oman'),
( 'PHL', N'Philippines'),
( 'RUS', N'Nga'),
( 'USA', N'Mỹ'),
( 'VNM', N'Việt Nam'),
( 'THA', N'Thái Lan')

select *from loaiThuoc

--4.NHÀ CUNG CẤP
insert into nhaCungCap values
( 1001, N'CTCP Traphaco', N'75 Yên Ninh, Ba Đình, Hà Nội, Việt Nam', '0836610724'),
( 1002, N'CTCP Dược phẩm Me Di Sun', N'521 ấp An Lợi, xã Hà Lợi, huyện Bến Cát, Bình Dương, Việt Nam', '6503589036'),
( 1003, N'CTCP Dược phẩm Phương Đông', N'Lô số 7, đường số 2, KCN Tân Tạo, P.Tân Tạo A, Q. Bình Tân, TPHCM Việt Nam', '0837540725'),
( 1005, N'Viện Dược Liệu', N'3B Quang Trung, Hoàn Kiếm, Hà Nội, Việt Nam', '0839349072'),
( 1004, N'Naprod Life Sciences Pvt.Ltd.', N'G-17/1, MIDC, Tarapur, Industrial Area, Boisar, Dist.Thane-401506 Ấn Độ', '2525323686'),
( 1006, N'CT dược phẩm trung ương VIDIPHA', N'184/2 Lê Văn Sỹ, Phường 10, Quận Phú Nhuận, Hồ Chí Minh, Việt Nam', '0838440106'),
( 1007, N'CT dược phẩm trung ương 2', N'Lô 27 KCN Quang Minh, Mê Linh, Hà Nội, Việt Nam', '0420474129'),
( 1008, N'Olic Ltd.', N'166 Moo 16 Bangpa-In Industrial Estate, Udomsorayuth Road, Bangpa-In District Ayutthaya Province, Thái Lan', '6635221031'),
( 1009, N'CTCP Dược phẩm Sanofi-Synthelabo', N'15/6C Đặng Văn Bi, Thủ Dức, Hồ Chí Minh, Việt Nam', '0838298526 '),
( 1010, N'Teva Pharmaceutical Works Private Limited Company', N'Tancsics Mihaly ut 82, H-2100 Godollo Hungary', '3652515100'),
( 1011, N'FDC Limited', N'B-8, MIDC Industrial are Waluj, Aurangabad 431136 Maharashtra State Ấn Độ', '02402554407'),
( 1012, N'CTCP dược phẩm IMEXPHARM', N'04- đường 30/4, Phường 1, Tp.Cao Lãnh, Tỉnh Đồng Tháp Việt Nam', '0673851620'),
( 1013, N'CTCP dược-vật tư Thanh Hóa', N'Số 4 đường Quang Trung - TP.Thanh Hóa, Việt Nam', '0373852821'),
( 1014, N'Hermes Arzneimittel GmbH', N'Hans-Urmiller-Ring 52, 82515 Woffratshausen Đức', '4989791020'),
( 1015, N'CTCP dược học Bidiphar 1', N'498 Nguyễn Thái Học, TP.Qui Nhơn, Tỉnh Bình Định Việt Nam', '2563846500'),
( 1016, N'CTCP dược phẩm Euvipharm', N'Ấp Bình Tiền 2, xã Hòa Đức hạ , Đức Hòa, Long An, Việt Nam', '7309.4688'),
( 1017, N'Công ty TNHH Ha San - Dermapharm', N'Đường số 2, KCN Đồng An, Thuận An, Bình Dương Việt Nam', '2743768107'),
( 1018, N'Brawn Laboratories Ltd', N'13, New Industrial Township, Faridabad 121001, Haryana Ấn Độ', '911244666152'),
( 1019, N'CTCP dược Minh Hải', N'325 Lý Văn Lâm, Phường 1, TP.Cà Mau Việt Nam', '07803831133' ),
( 1020, N'Actavis HF', N'Reykjavikurvegur 78, 220 Hafnarfjordur Iceland', '3544228000'),
( 1021, N'Cadila Pharmaceuticals ltd', '1389, Trasad Road, Dholka-387 810, District: Ahmedabat, Gujarat state Ấn Độ', '9101923246981'),
( 1022, N'CTCP LD dược phẩm	Mediphacro-Tenamyd BR s.r.l', N'Số 8, Nguyễn Trường Tộ, P.Phước Vĩnh, TP.Huế, Thừa Thiên Huế Việt Nam', '054823099'),
( 1023, N'Delpharm Tours', N'Rue Paul Langevin 37170 Chambray-Les-Tours Pháp', '330247484300'),
( 1024, N'CTCP được phẩm Glomed', N'29A Đại Lộ Tự Do, Khu công nghiệp Việt Nam-Singapore, Thuận An, Bình Dương Việt Nam', '06503768824'),
( 1025, N'Công ty TNHH LD Stada - Việt Nam', N'K63/1 Nguyễn Thị Sóc, ấp Mỹ Hòa 2, xã Xuân Thới Đông, huyện Hóc Môn, TP.HCM Viện Nam','842837182141'),
( 1026, N'Bayer Pharma AG', N'D-51368 Leverkusen Đức', '49214301'),
( 1027, N'Bioindustria L.I.M (Laboratorio Italiano Medicinali) S.p.A', N'Via De Ambrosiis, 2/6-15067 Novi Ligure Ý', '3901433131'),
( 1028, N'Schering-Plough Labo N.V', N'Industriepark 30, 2220, Heist-op-den-Berg Bỉ', '3215258711')

select *from nhaCungCap	

--5.THUỐC
insert into thuoc values
('HUA00001', N'Casoran', 1001, N'Cao hoa chè(3:1)-160mg, Cao dừa cạn(6:1)-20mg, Cao tâm sen(4:1)-15mg, Cao cúc hoa(3:1)-10mg', 'HUA', 'VI', 40000, 40500, 12, 'VNM', '2021-6-1'),
('VIT00001', N'3B-Medi', 1002, N'Vitamin B1-125mg, Vitamin B6-125mg, Vitamin B12-250mcg', 'VIT', 'VIE', 1250, 1750, 50, 'VNM', '2021-7-15'),
('VIT00002', N'3Bplusz F', 1003, N'Vitamin B1-12.5mg, Vitamin B6-12.5mg, Vitamin B12-50mg, Sắt sulfat-16.2mg', 'VIT', 'VIE', 1400, 1900, 24, 'VNM', '2020-10-2'),
('UNT00001', N'4-Epeedo-50', 1004, N'Epirubicin hydrochloride-50mg', 'UNT', 'LO', 573000, 573500, 20, 'IND', '2022-1-1'),
('GAN00001', N'Abivina', 1005, N'Cao khô bồ bồ-170mg, Tinh dầu bồ bồ-0.002ml', 'GAN', 'LO', 185100, 185600, 21, 'VNM', '2020-10-2'),
('KHS00001', N'Amoxicilin 250mg', 1006, N'Amoxicilin-250mg', 'KHS', 'VI', 10000, 10500, 20, 'VNM', '2019-12-31'),
('KHS00002', N'Ampicillin 250mg', 1006, N'Ampicillin khan-250mg', 'KHS', 'VI', 12000, 12500, 14, 'VNM', '2021-7-1'),
('KHS00003', N'Augxicine 250mg', 1006, N'Amoxicilin (dưới dạng Amoxicilin hydrat)-250mg', 'KHS','GOI', 50000, 50500, 4, 'VNM', '2020-12-31'),
('ANT00001', N'Morphin 30mg', 1007, N'Morphin sulfat-30mg', 'ANT', 'VI', 45500, 46000, 3, 'VNM', '2022-12-1'),
('GID00001', N'Acetalvic Codein 30', 1006, N'Paracetamol-500mg, Codein phosphat-30mg', 'GID', 'HOP', 110000, 110500, 10, 'VNM', '2021-12-12'),
('TRG00001', N'Piperazin', 1006, N'Piperacilin(dưới dạng Piperacilin natri)-1g', 'TRG', 'CHA', 50000, 50500, 9, 'VNM', '2022-1-1'),
('TRG00002', N'Fugacar', 1008, N'Mebendazole-500mg', 'TRG', 'VIE', 17000, 17500, 34, 'THA', '2022-1-1'),
('HOH00001', N'Bixovom 4', 1006, N'Bromhexin hydrochlorid-4mg', 'HOH', 'HOP', 38000, 38500, 19, 'VNM', '2022-1-1'),
('HOH00002', N'Terpin Codein', 1006, N'Terpin hydrat-100mg, Codein monohydat-5mg', 'HOH', 'VI', 5000, 5500, 10, 'VNM', '2022-1-1'),
('HST00001', N'Panadol Extra', 1009, N'Paracetamol-500mg, Caffein-65mg', 'HST', 'VI', 12000, 12500, 23, 'VNM', '2022-1-1'),
('HST00002', N'Paracetamol', 1007, N'Paracetamol-500mg', 'HST', 'LO', 88000,88500,  8, 'VNM', '2022-1-1'),
('UNT00002', N'Docetaxel 20mg', 1010, N'Docetaxel -20mg/2ml', 'UNT', 'LO', 1260000, 1260500, 10, 'HUN', '2022-5-6'),
('HOH00003', N'1-AL', 1011, N'Levocetirizine Dihydrochloride -15mg/30ml', 'HOH', 'LO', 65000, 65500, 23, 'IND', '2019-9-12'),
('GID00002', N'ABAB 500mg', 1012, N'Acetaminophen - 500mg', 'GID', 'VIE', 286, 786, 53, 'VNM', '2022-9-24'),
('HOH00004', N'Abrocto', 1013, N'Ambroxol HCL - 30mg', 'HOH', 'GOI', 1200, 1500, 23, 'VNM', '2019-12-26'),
('HOH00005', N'Acc Pluzz 200', 1014, N'Acetylcystein - 200mmg','HOH', 'VIE', 6700, 7200, 30, 'DEU', '2020-8-15'),
('HST00003', N'Ace kid 150', 1015, N'Paracetamol - 150mg, Vitamin C - 75mg', 'HST', 'GOI', 1260, 1760, 12, 'VNM', '2020-4-25'),
('HST00004', N'Ace kid 325', 1015, N'Paracetamol - 325mg', 'HST', 'GOI', 2940, 3440, 45, 'VNM', '2020-7-25'),
('GID00003', N'Acefalgan 150', 1016, N'Acetaminophen - 150mg/1.5g', 'GID', 'GOI', 1425, 1925, 12, 'VNM', '2020-2-25'),
('GID00004', N'Acefalgan 250', 1016, N'Paracetamol - 250mg', 'GID', 'GOI', 1800, 2300, 20, 'VNM', '2020-2-28'),
('GID00005', N'Acefalgan 500', 1016, N'Paracetamol - 500mg', 'GID', 'VIE', 2100, 2600, 12, 'VNM', '2020-4-30'),
('HST00005', N'Acefalgan 500', 1016, N'Acetaminophen - 500mg', 'HST','VIE', 918, 1418, 50, 'VNM', '2020-8-30'),
('HOH00006', N'Acehasan 100', 1017, N'Acetylcystein - 100mg', 'HOH', 'GOI', 1020, 1520, 30, 'VNM', '2021-6-10'),
('HOH00007', N'Acehasan 200', 1017, N'Acetylcystein - 200mg', 'HOH', 'GOI', 1140, 1640, 20, 'VNM', '2021-6-10'),
('KHS00004', N'Aciclovir Tablets BD', 1018, N'Acyclovir - 200mg', 'KHS', 'VIE', 840, 1340, 15, 'IND', '2020-7-5'),
('HOH00008', N'Acigmentin 1000', 1019, N'Amoxicilin (dưới dạng Amoxicilin trihydrat) - 875mg, Acid Clavulanic (dưới dạng Clavulanat kali) - 125mg)', 'HOH', 'VIE', 9000, 9500, 25, 'VNM', '2021-5-23'),
('HOH00009', N'Acigmentin 281.25', 1019, N'Amoxicilin (dưới dạng Amoxicilin trihydrat) - 250, Acid Clavulanic (dưới dạng Clavulanat kali) - 31.25)', 'HOH', 'GOI', 4800, 5300, 12, 'VNM', '2019-11-30'),
('HOH00010', N'Acigmentin 375', 1019, N'Amoxicilin (dưới dạng Amoxicilin trihydrat) - 250, Acid Clavulanic (dưới dạng Clavulanat kali) - 125mg)', 'HOH', 'VIE', 5000, 5500, 25, 'VNM', '2022-1-10'),
('DAD00001', N'Acilesol 10mg', 1020, N'Rabeprazole natri - 10mg', 'DAD', 'VIE', 8000, 8500, 40, 'ISL', '2019-11-25'),
('DAD00002', N'Acilesol 20mg', 1020, N'Rabeprazole natri - 20mg', 'DAD', 'VIE', 12400, 12900, 20, 'ISL', '2019-11-25'),
('DAD00003', N'Aciloc 150', 1021, N'Ranitidin (dưới dạng Ranitidin hydrochlorid) - 150mg', 'DAD', 'VIE', 320, 820, 12, 'ISL', '2022-3-12'),
('DAD00004', N'Aciloc 300', 1021, N'Ranitidin (dưới dạng Ranitidin hydrochlorid) - 300mg', 'DAD', 'VIE', 700, 1200, 23, 'ISL', '2023-1-11'),
('HST00006', N'Actadol 250', 1022, N'Paracetamol - 250mg', 'HST', 'GOI', 2500, 3000, 30, 'VNM', '2024-8-15'),
('HST00007', N'Actadol 500', 1022, N'Paracetamol - 500mg', 'HST', 'VIE', 530, 1030, 25, 'VNM', '2023-9-19'),
('GID00006', N'Acupan', 1023, N'Nefopam hydroclorid - 20mg', 'GID', 'ONG', 34000, 34500, 15, 'FRA', '2022-10-30'),
('KHS00005', N'Actixim', 1024, N'Cefuroxim - 750mg', 'KHS', 'LO', 28500, 29000, 20, 'VNM', '2023-12-1'),
('KHS00006', N'Actixim 1.5g', 1024, N'Cefuroxim (dưới dạng Cefuroxim natri)- 1.5mg', 'KHS', 'LO', 35500, 36000, 20, 'VNM', '2023-9-12'),
('KHS00007', N'Actixim 1g', 1024, N'Cefuroxim (dưới dạng Cefuroxim natri)- 1mg', 'KHS', 'LO', 89000, 89500, 20, 'VNM', '2023-8-7'),
('KHS00008', N'Acyclovir Stada 200mg', 1025, N'Acyclovir - 200mg', 'KHS', 'VIE', 1600, 2100, 41, 'VNM', '2020-11-11'),
('KHS00009', N'Acyclovir Stada 400mg', 1025, N'Acyclovir - 400mg', 'KHS', 'VIE', 3100, 3600, 35, 'VNM', '2020-11-11'),
('HUA00002', N'Adalat retard', 1026, N'Nìedipin - 20mg', 'HUA', 'VIE', 4647, 5147, 20, 'DEU', '2022-8-12'),
('HUA00003', N'Adalat LA 30mg', 1026, N'Nìedipin - 30mg', 'HUA', 'VIE', 9454, 9954, 20, 'DEU', '2021-5-25'),
('HUA00004', N'Adalat LA 60mg', 1026, N'Nìedipin - 60mg', 'HUA', 'VIE', 12034, 12534, 20, 'DEU', '2021-5-25'),
('HUY00001', N'Acido Tranexamico Bioindustria L.I.M', 1027, N'Acid tranexamic - 500mg', 'HUY', 'ONG', 21546, 22046, 10, 'ITA', '2025-1-1'),
('KHS00010', N'Aerius', 1028, N'Desloratadine - 5mg', 'KHS','VIE', 9521, 10021, 30, 'BEL', '2019-12-28')

--6.LOẠI NHÂN VIÊN
insert into loaiNhanVien values
('BH', N'Nhân viên bán hàng'),
('QL', N'Nhân viên quản lý'),
('TK', N'Nhân viên thống kê')

--7.NHÂN VIÊN
insert into nhanVien values
('BH001', N'Kim Jong-Un', N'720A Điện Biên Phủ, Phường 22, Bình Thạnh, Hồ Chí Minh','0703211234','BH'),
('BH002', N'Donald Trump', N'Số 2 Lê Lợi, Phường 4, Gò Vấp, TPHCM', '0903222237','BH'),
('BH003',N'Trần Thị Ngọc Trâm',N'56/28 Tô Hiến Thành, P.14, Q.10, Tp.HCM','0986260499','BH'),
('BH004',N'Nguyễn Hoàng Anh',N'81 Phạm Đăng Giăng, P.Bình Hưng Hòa, Q.Bình Tân, Tp.HCM','0957681362','BH'),
('QL001', N'Nguyễn Thu Phú', N'242 Phạm Văn Đồng, Hiệp Bình Chánh, Thủ Đức, Hồ Chí Minh', '0703211234','QL'),
('QL002',N'Lê Tấn Lộc',N'171/4C Tôn Thất Thuyết, P.15, Q.04, Tp.HCM','09098580','QL'),
('QL003',N'Phạm Thị Huyền',N'150 Phạm Văn Hai, F.03, Q.tân Bình, TPHCM','0909591859','QL'),
('QL004',N'Cao Nhật Thiên',N'637/6 Phạm Thế Hiển, p.04, Q.08, Tp.HCM','0937090369','QL'),
('TK001', N'Lindsey Graham', N'366 Phan Văn Trị, Phường 5, Gò Vấp, Hồ Chí Minh', '0905566789', 'TK'),
('TK002', N'Phan Tấn Ba Tạ', N'Số 86 Lê Thánh Tôn, Bến Nghé, Quận 1, Hồ Chí Minh', '0908654321', 'TK'),
('TK003',N'Lê Thị Nhâm Huế',N'84/9 Dương Đức Hiền, P. Tây Thạnh, Tân Phú, Hồ Chí Minh','0862672379','TK'),
('TK004',N'Nguyễn Hùng Phương',N'118/83 G3, Bạch Đằng, P24, Q Bình Thạnh, TP.HCM','0822161080','TK')

select * from nhanVien

--TÀI KHOẢN
insert into taiKhoan values
('123','BH001'),
('123','BH002'),
('123','BH003'),
('123','BH004'),
('123','QL001'),
('123','QL002'),
('123','QL003'),
('123','QL004'),
('123','TK001'),
('123','TK002'),
('123','TK003'),
('123','TK004')

--8.KHÁCH HÀNG
insert into khachHang values
('KH001', N'Nguyễn Văn Minh', N'122/17 Bùi Đình Túy, Phường 12, Bình Thạnh, Hồ Chí Minh', '0703212235'),
('KH002', N'Trần Đô Thị', N'14/26 Huỳnh Tấn Phát, Phường Bình Thuận, Q.7 , Hồ Chí Minh', '0703212235'),
('KH003', N'Phan Thị Trấn', N'25/16 Đường số 4, Hiệp Bình Chánh, Thủ Đức, Hồ Chí Minh', '0904212445'),
('KH004', N'Phạm Chí Phèo', N'15/2 , Phường 4, Gò Vấp, Hồ Chí Minh', '0703212235'),
('KH005', N'Trần Thị Nở', N'32/15 Phan Văn Trị, Phường 24, Bình Thạnh, Hồ Chí Minh', '0904213236'),
('KH006', N'Hoàng Thái Sơn', N'43/7 Cộng Hòa, P4, Quận Tân Bình', '0938121979'),
('KH007', N'Trần Tứ Xuyên', N'92/29 Tập Đoàn 6B Phường Tân Tạo A, Quận Bình Tân', '0908487452'),
('KH008', N'Vũ Thị Quế', N'87/8B Lưu Trọng Lư, phường Tân Thuận Đông, quận 7', '0942984391'),
('KH009', N'Đào Quang Tuấn', N'405/9 Xô viết nghệ tĩnh, quận Bình thạnh', '0862944423'),
('KH010', N'Võ Minh Tấn', N'Số 481, Nguyễn Chí Thanh, Phường 15, Quận 5', '0839561721'),
('KH011', N'Trần Công Tuấn', N'60 Đường 17, phường 4, Quận 8', '038503185'),
('KH012', N'Vũ Chiến Thắng', N'Lô G-02 Nhóm 5 KCN An Hạ Xã Phạm Văn Hai ,Huyện Bình Chánh', '0989349606'),
('KH013', N'Nguyễn Ngọc Dũng', N'Phòng 11.12, Lô A, Cư xá Bàu Cát 2, P10, Q.Tân Bình', '0902605880'),
('KH014', N'Nguyễn Mạnh Thắng', N'334/4B Phan Văn Trị, phường 11, Quận Bình Thạnh', '0989283899'),
('KH015', N'Vũ Linh Thảo', N'273 Trần Bình trọng, P.04, Q.5, HCM', '0907844687'),
('KH016', N'Nguyễn Ngọc Phụng', N'Tổ 1, KP5, Củ chi', '0908085777'),
('KH017', N'Nguyễn Văn Ba', N'173/130 Khuông Việt, P.Phú Trung, Tân Phú, HCM', '090377337'),
('KH018', N'Trịnh Thị Hoài Giang', N'61/20 BìnhGiã P.13, Q.TB', '903608690'),
('KH019', N'Vũ Ngọc Trâm', N'553/1A Trần Hưng Đạo, Q1', '0939243674'),
('KH020', N'Mr. Đỗ Ngọc Thanh', N'92/21/8 Xô Viết Nghệ Tĩnh, F21, Bình Thạnh, HCM', '0933559995'),
('KH021', N'Phan Đình Nhân', N'30/11A Phùng Văn Cung P7 Q.Phú Nhuận Phùng Văn Cung Q.Phú Nhuận', '902669734'),
('KH022', N'Nguyễn Thị Thanh Hiền', N'88/113 B Nguyễn Văn Quỳ, P7, Phú Nhuận, Hồ Chí Minh', '0907266445'),
('KH023', N'Lục Văn Hiền', N'Khu 5, Tổ 5, Thị Trấn Gia Ray, Huyện Xuân Lộc, Tỉnh Đồng Nai', '00906 763731'),
('KH024', N'Nguyễn Thị Bích Thu', N'28 Lô B8 Cư xá 304 P25 Q.BT', '0987136650'),
('KH025', N'Nguyễn Chí Phúc', N'7 Đỗ Quang Đẩu P.Phạm Ngũ Lão Q.1', '0903704821'),
('KH026', N'Nguyễn Thị Quy', N'315/22A Lê Văn Sỹ P13 Q3', '0918159860'),
('KH027', N' Trần Anh Tuấn', N'37/12P Thống Nhất Dĩ An- Bình Dương', '0989735897'),
('KH028', N'Đào Thị Tuyết Nhung', N'43/1 Tổ 11 KP 4 P.Phước Long B Q.9', '0913145852'),
('KH029', N'Bùi Văn Nhổn', N'B18/12 KP1 P.Bình An Q.2', '0937879918'),
('KH030', N'Lê Hữu Duy', N'113 đường số 03 cư xá Lữ Gia, P15 Q.11', '0903937177'),
('KH031', N'Hà Thị Vân Diệp', N'489/23A/37 Huỳnh Văn Bánh P13 Q.PN', '0909451621'),
('KH032', N'Hoàng Thị Hiền', N'83A Trần Quang Khải P.Tân Định Q.1', '0932755980'),
('KH033', N'Trịnh Khắc Tĩnh', N'110A/5 Nội Hóa Dĩ An - Bình Dương', '0972603314'),
('KH034', N'Đỗ Bùi Hưng', N'10/37 Đặng Văn Ngữ P10 Q.PN', '0903780931'),
('KH035', N'Đỗ Bùi Hồng Duyên', N'120/4A Bùi Thị Xuân P2 Q.TB', '0913111144'),
('KH036', N'Đặng Thị Thuận Hải', N'37C/14 P.Tân Hưng Q.7', '0919236777'),
('KH037', N' Trần Kim Long ', N'19/17 Trần Đình Xu P.Cầu Kho Q.1', '0903397407'),
('KH038', N'Trần Thị Xuân Thảo', N'224/5 Lý Thường Kiệt, F14, Q10, HCM', '01699906827'),
('KH039', N'Nguyễn Thị Lan Anh', N'2C Phó Đức Chính Q.1', '0903008720'),
('KH040', N' Phạm Thị Ngọc Dung', N'12 NH, Khu PHố 5, P.Tân Thuận Tây, Q7,HCM', '0919393998'),
('KH041', N'Trần Tuấn Dũng', N'82/16 Đỗ Tấn Phong, P.9, Q.Phú Nhuận, HCM', '0908835789'),
('KH042', N'Đặng Thị Kim Liên', N'42 Phạm Ngọc Thạch Q.3, Hồ Chí Minh', '0903926683'),
('KH043', N'Nguyễn Văn Hên', N'345/48 Trần Hưng Đạo P.Cầu Kho Q.1 Tp.HCM', '090382554'),
('KH044', N'Võ Thị Thoa', N'171/60 Cô Bắc Quận 1 Tp.Hồ Chí Minh', '0908817626'),
('KH045', N'Phạm Thế Anh', N'30D/1 Khu phố 1 P.Quang Vinh Tp.Biên Hòa Tỉnh Đồng Nai', '0913712111'),
('KH046', N'Lê Nguyên Diệm', N'216A/25 Trần Huy Liệu P.9 Q.Phú Nhuận Tp.Hồ Chí Minh', '0913961234'),
('KH047', N'Lê Thị Cường', N'30D/9 Cách Mạng Tháng 8 P.Quang Vinh Biên Hòa Đồng Nai', '091380003'),
('KH048', N'Tiêu Văn Minh', N'401 Lô F Cư xá Thanh Đa P.27 Q.Bình Thạnh Tp. Hồ Chí Minh', '0913763143'),
('KH049', N'Phan Hòa Bình', N'36 Hùng Vương, P.2, TX.Tân An, tỉnh Long An', '0913876000'),
('KH050', N'Trần Thiện Thanh Bình', N'6/6 đường số 40, khu phố 8, P.Hiệp Bình Chánh, Thủ Đức, HCM', '0919074174'),
('KH051', N'Nguyễn Nhơn Tuấn', N'120A/10 Huỳnh Văn Bánh, P12, Q.Phú Nhuận, HCM', '0903921616')

--9.HÓA ĐƠN
insert into hoaDon values
('2018-10-5', 'BH003', 'KH001'),
('2019-1-25', 'BH003', 'KH002'),
('2019-11-1', 'BH004', 'KH051'),
('2018-7-7', 'BH004', 'KH035'),
('2019-5-10', 'BH004', 'KH020'),
( '2019-10-10', 'BH001', 'KH025'),
('2018-7-11', 'BH001', 'KH014'),
('2018-11-20', 'BH001', 'KH025'),
('2019-7-11', 'BH002', 'KH021'),
('2019-1-12', 'BH002', 'KH051'),
('2019-6-22', 'BH002', 'KH021'),
('2017-12-29', 'BH002', 'KH051'),
('2017-12-7', 'BH002', 'KH051')

--10.CHI TIẾT HÓA ĐƠN
insert into ct_hoaDon values
(5, 'HUA00001', 5, 200000, 0.05),
(5, 'VIT00001', 15, 12500, 0.05),
(6, 'KHS00001', 1, 10000, 0.05),
(6, 'GID00001', 1, 110000, 0.05),
(7, 'KHS00002', 2, 24000, 0.05),
(7, 'HST00002', 1, 88000, 0.05),
(8, 'TRG00002', 4, 17000, 0.05),
(8, 'GID00001', 2, 220000, 0.05),
(9, 'ANT00001', 4, 182000, 0.05),
(9, 'KHS00003', 2, 100000, 0.05),
(10, 'UNT00001', 1, 573000, 0.05),
(10, 'GAN00001', 3, 555300, 0.05),
(1, 'VIT00002', 21, 29400, 0.05),
(1, 'TRG00001', 1, 50000, 0.05),
(2, 'HST00001', 2, 24000, 0.05),
(2, 'GID00001', 1, 110000, 0.05)
