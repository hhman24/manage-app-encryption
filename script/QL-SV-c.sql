/*----------------------------------------------------------
MASV: 20127102
HO TEN: HOÀNG HỮU MINH AN
LAB: 04
NGAY: 30/04/2023
----------------------------------------------------------*/

USE QLSinhVien
GO

-- Tạo Stored dùng để thêm mới dữ liệu (Insert) vào table SINHVIEN, trong đó thuộc tính
-- MATKHAU được mã hóa (HASH) sử dụng MD5 ở client

IF OBJECT_ID('SP_INS_ENCRYPT_SINHVIEN') IS NOT NULL
	DROP PROCEDURE SP_INS_ENCRYPT_SINHVIEN
GO

CREATE PROCEDURE SP_INS_ENCRYPT_SINHVIEN @MASV nvarchar(20),
										 @HOTEN nvarchar(100),
										 @NGAYSINH DATETIME,
										 @DIACHI nvarchar(200),
										 @MALOP varchar(200),
										 @TENDN nvarchar(100),
										 @MATKHAU varbinary(MAX)
AS
BEGIN
	INSERT INTO SINHVIEN
	VALUES(@MASV, @HOTEN, @NGAYSINH, @DIACHI, @MALOP, @TENDN, @MATKHAU)
END
GO

-- Stored dùng để thêm mới dữ liệu (Insert) vào table NHANVIEN, trong đó thuộc tính
-- MATKHAU được mã hóa (HASH) sử dụng SHA1 và thuộc tính LUONG sẽ được mã
-- hóa sử dụng thuật toán AES 256, với khóa mã hóa là mã số của sinh viên thực hiện bài
-- Lab này.

IF OBJECT_ID('SP_INS_ENCRYPT_NHANVIEN') IS NOT NULL
	DROP PROCEDURE SP_INS_ENCRYPT_NHANVIEN
GO

CREATE PROCEDURE SP_INS_ENCRYPT_NHANVIEN @MANV varchar(20),
										 @HOTEN nvarchar(100),
										 @EMAIL varchar(20),
										 @LUONG varbinary(MAX),
										 @TENDN nvarchar(100),
										 @MATKHAU varbinary(MAX)
AS
BEGIN
	INSERT INTO NHANVIEN
	VALUES(@MANV, @HOTEN, @EMAIL, @LUONG, @TENDN, @MATKHAU)
END
GO

-- Stored dùng để truy vấn dữ liệu nhân viên (NHANVIEN) 
IF OBJECT_ID('SP_SEL_ENCRYPT_NHANVIEN') IS NOT NULL
	DROP PROCEDURE SP_SEL_ENCRYPT_NHANVIEN
GO

CREATE PROCEDURE SP_SEL_ENCRYPT_NHANVIEN
AS
BEGIN
	SELECT MANV, HOTEN, EMAIL, LUONG
	FROM NHANVIEN
END
GO

EXEC SP_SEL_ENCRYPT_NHANVIEN