/*---------------------------------------------------------- 
MASV: 20127102
HO TEN: HOÀNG HỮU MINH AN
LAB: 04
NGAY: 30/04/2023
----------------------------------------------------------*/

USE QLSinhVien

exec sp_executesql N'EXEC SP_CHECK_TAIKHOAN @user, @password',N'@user nvarchar(3),@password varbinary(20)',@user=N'NVA',@password=0x0D5399508427CE79556CDA71918020C1E8D15B53