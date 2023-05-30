/*---------------------------------------------------------- 
MASV: 20127102
HO TEN: HOÀNG HỮU MINH AN 
LAB: 04
NGAY: 30/04/2023
----------------------------------------------------------*/

USE QLSinhVien
GO

-- store procedure để kiểm tra đăng nhập bằng các so sánh username
-- và password đã được mã hóa từ client truyền về

IF OBJECT_ID('SP_CHECK_TAIKHOAN') IS NOT NULL
	DROP PROCEDURE SP_CHECK_TAIKHOAN
GO

CREATE PROCEDURE SP_CHECK_TAIKHOAN @username nvarchar(100), @password varbinary(MAX)
AS
BEGIN

	IF(EXISTS(SELECT MASV FROM SINHVIEN WHERE TENDN LIKE @username AND MATKHAU = @password))
	BEGIN
		SELECT * FROM SINHVIEN WHERE TENDN LIKE @username AND MATKHAU = @password
		RETURN
	END

	IF(EXISTS(SELECT MANV FROM NHANVIEN WHERE TENDN LIKE @username AND MATKHAU = @password))
	BEGIN
		SELECT * FROM NHANVIEN WHERE TENDN LIKE @username AND MATKHAU = @password
		RETURN
	END
END
GO

DECLARE @HASH_MK VARBINARY(MAX)
SET @HASH_MK = HASHBYTES('MD5', N'123456')
EXEC SP_CHECK_TAIKHOAN NVA, @HASH_MK
GO

SELECT * FROM NHANVIEN
GO

-- store procedure cập nhật dữ liệu nhân viên

IF OBJECT_ID('SP_UPDATE_NHANVIEN') IS NOT NULL
	DROP PROCEDURE SP_UPDATE_NHANVIEN
GO

CREATE PROCEDURE SP_UPDATE_NHANVIEN @MANV varchar(20),
									@HOTEN nvarchar(100),
									@EMAIL varchar(20),
									@LUONG varbinary(MAX),
									@TENDN nvarchar(100),
									@MATKHAU varbinary(MAX),
									@_MANV varchar(20)
AS
BEGIN
	UPDATE NHANVIEN SET MANV = @MANV,
						HOTEN = @HOTEN,
						EMAIL = @EMAIL,
						LUONG = @LUONG,
						TENDN = @TENDN
					WHERE MANV = @_MANV
END
GO

