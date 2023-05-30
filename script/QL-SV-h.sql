/*---------------------------------------------------------- 
MASV: 20127102
HO TEN: HOÀNG HỮU MINH AN
LAB: 04
NGAY: 30/04/2023
----------------------------------------------------------*/ 

USE QLSinhVien

exec sp_executesql N'SP_INS_ENCRYPT_NHANVIEN @manv, @hoten, @email, @luong, @tendn, @mk',N'@manv varchar(4),@hoten nvarchar(12),@email varchar(4),@luong varbinary(16),@tendn nvarchar(3),@mk varbinary(20)',@manv='NV05',@hoten=N'NGUYEN VAN E',@email='NVE@',@luong=0xB6BE7CA2FE5BBCB6EE4F220E46750AC5,@tendn=N'NVE',@mk=0x0D5399508427CE79556CDA71918020C1E8D15B53