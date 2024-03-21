GO
IF DB_ID (N'QuanLyBH') IS NOT NULL
begin
	use master
	DROP DATABASE QuanLyBH
end
GO
CREATE DATABASE QuanLyBH
go
use QuanLyBH
go
--Tao bang SanPham
create table SanPham
(
	SP_Ma	char(6),
	SP_Ten	nvarchar(100) not null,
	SP_DonGia	int not null,
	SP_TonKho int not null,
	primary key(SP_Ma)
)
go
--Tao bang KhachHang
create table KhachHang
(
	KH_Ma	char(6),
	KH_Ten	nvarchar(100) not null,
	primary key(KH_Ma)
)
go

create table NhanVien
(
	NV_Ma	char(6),
	NV_Ten	nvarchar(100) not null,
	primary key(NV_Ma)
)
go

create table NhaBanLe
(
	NBL_Ma char(6),
	NBL_Ten nvarchar(100) not null,
	NBL_DChi nvarchar(150) not null,
	NBL_SDT varchar(10) not null,
	Primary Key (NBL_Ma)
)
go

create table Dat 
(
	HD_Ma char(10),
	HD_NgayXuat date not null,
	NV_Ma char (6),
	NBL_Ma char (6),
	KH_Ma char (6),
	HD_TongTien int ,
	HD_TongCK int not null,
	HD_TongTT int  
	primary key (HD_Ma),
	foreign key (NV_Ma) references NhanVien,
	foreign key (NBL_Ma) references NhaBanLe,
	foreign key (KH_Ma) references KhachHang
)

create table DatChiTiet
(
	HD_Ma char(10),
	SP_Ma char(6),
	SL int not null,
	ThanhTien int,
	foreign key (HD_Ma) references Dat,
	foreign key (SP_Ma) references SanPham
)
go

create table TaiKhoan
(
	NV_Ma char (6),
	Ten_TK nvarchar(15),
	MatKhau nvarchar(100),
	primary key (Ten_TK),
	foreign key (NV_Ma) references NhanVien
)
go
-- Dữ liệu cho bảng SanPham
INSERT INTO SanPham (SP_Ma, SP_Ten, SP_DonGia, SP_TonKho)
VALUES 
    ('SP01', N'Alluvia Chocolate Dark 100% FreeSugar', 120000, 94),
    ('SP02', N'Alluvia Chocolate Dark 85% ', 95000, 29),
    ('SP03', N'Alluvia Chocolate Dark 70% ',95000, 132),
	('SP04', N'Alluvia Chocolate Milk 40% ',95000, 20),
	('SP05', N'Alluvia Chocolate Dark 70% Coconut',95000, 36),
	('SP06', N'Alluvia Chocolate Dark 70% Coffee',95000, 58),
	('SP07', N'Alluvia Chocolate Dark 70% Cinnamon',95000, 43),
	('SP08', N'Alluvia Chocolate Dark 70% Blueberry',95000, 47),
	('SP09', N'Alluvia Chocolate Dark 70% Mango',95000, 73),
	('SP10', N'Alluvia Chocolate Dark 70% Orange Peel',95000, 65);

-- Dữ liệu cho bảng KhachHang
INSERT INTO KhachHang (KH_Ma, KH_Ten)
VALUES 
	('KH01',N'Nguyễn Hồng Hà'),
	('KH02',N'Nguyễn Bích Thủy'),
	('KH03',N'Lê Thị Thu'),
	('KH04',N'Lê Đức Huy'),
	('KH05',N'Lê Tường Vy'),
	('KH06',N'Trần Nhật Nam'),
	('KH07',N'Trần Nhật Đăng'),
	('KH08',N'Hồ Văn Thông'),
	('KH09',N'Hồ Thị Như Quỳnh'),
	('KH10',N'Hồ Công Mãi');

-- Dữ liệu cho bảng NhanVien
INSERT INTO NhanVien (NV_Ma, NV_Ten)
VALUES 
	('NV01',N'Nguyễn Thảo My'),
	('NV02',N'Phạm Bảo Thy'),
	('NV03',N'Trần Thị Minh Thi'),
	('NV04',N'Trần Thị Minh Hiếu'),
	('NV05',N'Nguyễn Văn Công'),
	('NV06',N'Lê Ngọc Lâm'),
	('NV07',N'Phạm Hoàng Triều'),
	('NV08',N'Nguyễn Đức Nhân'),
	('NV09',N'Võ Lê Anh Nhật'),
	('QL01',N'ADN'),
	('QL02',N'AHN');

-- Dữ liệu cho bảng NhaBanLe
INSERT INTO NhaBanLe (NBL_Ma, NBL_Ten, NBL_DChi, NBL_SDT)
VALUES 
	('BR01',N'Alluvia Đà Nẵng',N'196 Trần Phú,quận Hải Châu,thành phố Đà Nẵng','0905942003'),
	('BR02',N'Alluvia Hà Nội',N'45 Đinh Tiên Hoàng, Hoàn Kiếm,Hà Nội','0787132857');

-- Dữ liệu cho bảng Dat
INSERT INTO Dat (HD_Ma, HD_NgayXuat, NV_Ma, NBL_Ma, KH_Ma,HD_TongCK)
VALUES 
	('HD01','2023-11-01','NV01','BR01','KH01',10000),
	('HD02','2023-11-02','NV02','BR01','KH02',10000),
	('HD03','2023-11-03','NV03','BR01','KH03',0),
	('HD04','2023-11-04','NV04','BR01','KH04',20000),
	('HD05','2023-11-05','NV05','BR01','KH05',5000),
	('HD06','2023-11-06','NV01','BR01','KH06',10000),
	('HD07','2023-11-07','NV02','BR01','KH07',20000),
	('HD08','2023-11-08','NV02','BR01','KH08',5000),
	('HD09','2023-11-09','NV03','BR01','KH09',10000),
	('HD10','2023-11-10','NV04','BR01','KH10',20000),
	('HD11','2023-11-10','NV02','BR01','KH10',10000),
	('HD12','2023-11-13','NV03','BR01','KH03',0),
	('HD13','2023-11-14','NV04','BR01','KH04',20000),
	('HD14','2023-11-14','NV05','BR01','KH05',5000),
	('HD15','2023-11-15','NV01','BR01','KH06',10000),
	('HD16','2023-11-16','NV02','BR01','KH07',5000),
	('HD17','2023-11-17','NV02','BR01','KH08',0),
	('HD18','2023-11-18','NV03','BR01','KH09',10000),
	('HD19','2023-11-19','NV04','BR01','KH03',20000),
	('HD20','2023-11-20','NV04','BR01','KH10',20000)


select * from Dat
-- Dữ liệu cho bảng DatChiTiet
INSERT INTO DatChiTiet (HD_Ma, SP_Ma, SL)
VALUES 
	('HD01','SP01',5)
INSERT INTO DatChiTiet (HD_Ma, SP_Ma, SL)
VALUES 

	('HD02','SP02',10)
INSERT INTO DatChiTiet (HD_Ma, SP_Ma, SL)
VALUES 

	('HD03','SP03',2)
INSERT INTO DatChiTiet (HD_Ma, SP_Ma, SL)
VALUES 

	('HD04','SP04',4)
INSERT INTO DatChiTiet (HD_Ma, SP_Ma, SL)
VALUES 

	('HD05','SP05',3)
INSERT INTO DatChiTiet (HD_Ma, SP_Ma, SL)
VALUES 

	('HD06','SP02',5)
INSERT INTO DatChiTiet (HD_Ma, SP_Ma, SL)
VALUES 

	('HD07','SP01',10)
INSERT INTO DatChiTiet (HD_Ma, SP_Ma, SL)
VALUES 

	('HD08','SP07',2)
INSERT INTO DatChiTiet (HD_Ma, SP_Ma, SL)
VALUES 

	('HD09','SP08',7)
INSERT INTO DatChiTiet (HD_Ma, SP_Ma, SL)
VALUES 

	('HD10','SP06',8)
---
go
create trigger tgDatChiTiet 
on DatChiTiet
after insert, delete, update 
as 
begin
	update DatChiTiet
	set ThanhTien = (select SP_DonGia from SanPham where SP_Ma = (select SP_Ma from inserted )) * ( select SL from inserted)
	where SP_Ma = (select SP_Ma from inserted )
	update Dat
	set HD_TongTien = (select sum(ThanhTien) from DatChiTiet where HD_Ma = (select HD_Ma from inserted)) 
	where HD_Ma = (select HD_Ma from inserted)
	update Dat
	set HD_TongTT = HD_TongTien - ( select HD_TongCK from Dat where HD_Ma =( select HD_Ma from inserted)) 
	where HD_Ma = (select HD_Ma from inserted)
	update Dat
	set HD_TongTien = (select sum(ThanhTien) from DatChiTiet where HD_Ma = (select HD_Ma from deleted)) 
	where HD_Ma = (select HD_Ma from deleted)
	update Dat
	set HD_TongTT = HD_TongTien - ( select HD_TongCK from Dat where HD_Ma =( select HD_Ma from deleted)) 
	where HD_Ma = (select HD_Ma from deleted)
	
end
-- Dữ liệu cho bảng TaiKhoan
insert into TaiKhoan (NV_Ma, Ten_TK, MatKhau)
values
	('NV01', 'nguyenthaomy', 'Mynt@12345'),
	('NV02', 'phambaothy', 'Thypb@12345'),
	('NV03', 'tranthiminhthi', 'Thittm@12345'),
	('NV04', 'tranthiminhhieu', 'Hieuttm@12345'),
	('NV05', 'nguyenvancong', 'Congnv@12345'),
	('NV06', 'lengoclam', 'Lamln@12345'),
	('NV07', 'phamhoangtrieu', 'Trieuph@12345'),
	('NV08', 'nguyenducnhan', 'Nhannd@12345'),
	('NV09', 'voleanhnhat', 'Nhatvla@12345'),
	('QL01','ADN','Danang@12345'),
	('QL02','AHN','Hanoi@12345');

--select * from NhaBanLe
--select * from NhanVien
--select * from KhachHang
--select * from SanPham
select * from Dat
select * from DatChiTiet
--select * from TaiKhoan
--go

--alter table SanPham add [encrypted SP_DonGia] varbinary (max)
--go
--alter table DatChiTiet add [encrypted SL] varbinary (max)
--go
alter table TaiKhoan add [encrypted MatKhau] varbinary (max);
--go

--update SanPham 
--set [encrypted SP_DonGia] = ENCRYPTBYPASSPHRASE ('SP_DonGia', CONVERT (varchar(100), SP_DonGia))
--go
--update DatChiTiet
--set [encrypted SL] = ENCRYPTBYPASSPHRASE ('SL', CONVERT (varchar(100), SL))
--go
update TaiKhoan 
set [encrypted MatKhau] = ENCRYPTBYPASSPHRASE ('MatKhau', CONVERT (varchar(100), MatKhau))
--go

--select * from SanPham
--select * from DatChiTiet
--select * from TaiKhoan
--go

--alter table SanPham drop column SP_DonGia
--go
--alter table DatChiTiet drop column SL
--go
alter table TaiKhoan drop column MatKhau
--go

--select * from SanPham
--select * from DatChiTiet
--select * from TaiKhoan
--go

--select SP_Ma, SP_Ten, SP_TonKho, convert (bigint, convert (varchar(100), DECRYPTBYPASSPHRASE ('SP_DonGia',[encrypted SP_DonGia]))) as SP_DonGia from SanPham
--go
--select HD_Ma, SP_Ma, ThanhTien, convert (bigint, convert (varchar(100), DECRYPTBYPASSPHRASE ('SL',[encrypted SL]))) as SL from DatChiTiet
--go
select NV_Ma, Ten_TK, convert (varchar ,convert (varchar(100), DECRYPTBYPASSPHRASE ('MatKhau',[encrypted MatKhau]))) as MatKhau from TaiKhoan
--go

	--select * from Dat where HD_NgayXuat >=  'dtpFromDate' and HD_NgayXuat <= 'dateTimePicker2' 
