/*----------------------------------------------------------
MASV: 20127102
HO TEN: HOÀNG HỮU MINH AN
LAB: 04
NGAY: 30/04/2023
----------------------------------------------------------*/

USE QLSinhVien
GO

-- TẠO TABLE SINH VIEN --
CREATE TABLE SINHVIEN
(
	MASV nvarchar(20),
	HOTEN nvarchar(100) NOT NULL,
	NGAYSINH DATETIME,
	DIACHI nvarchar(200),
	MALOP varchar(200),
	TENDN nvarchar(100) NOT NULL,
	MATKHAU varbinary(MAX) NOT NULL

	CONSTRAINT PK_SINHVIEN
	PRIMARY KEY(MASV)
)
GO

-- TẠO TABLE NHANVIEN --
CREATE TABLE NHANVIEN
(
	MANV varchar(20),
	HOTEN nvarchar(100) NOT NULL,
	EMAIL varchar(20),
	LUONG varbinary(MAX),
	TENDN nvarchar(100) NOT NULL,
	MATKHAU varbinary(MAX) NOT NULL

	CONSTRAINT PK_NHANVIEN
	PRIMARY KEY(MANV)
)
GO

-- TẠO TABLE LOP --
CREATE TABLE LOP
(
	MALOP varchar(20),
	TENLOP nvarchar(100) NOT NULL,
	MANV varchar(20)

	CONSTRAINT PK_LOP
	PRIMARY KEY(MALOP)
)
GO