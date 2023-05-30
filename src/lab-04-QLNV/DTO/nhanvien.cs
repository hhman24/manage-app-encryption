using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_04_QLNV.DTO
{
    public class nhanvien
    {
        private string _manv;
        private string _hoten;
        private string _email;
        private byte[] _luong; // Lương đã mã hóa AES_256 key = 20127102
        private string _tendn;
        private byte[] _mk; // đã được mã hóa HASH_SHA1


        // để dành cho insert
        public nhanvien(string manv, string hoten, string email, byte[] luong, string tendn, byte[] mk)
        {
            Manv = manv;
            Hoten = hoten;
            Email = email;
            Luong = luong;
            Tendn = tendn;
            Mk = mk;
        }


        // khởi tạo từ một dòng của bảng
        public nhanvien(DataRow row)
        {
            Manv = row[0].ToString();
            Hoten = row["HOTEN"].ToString();
            Email = row["EMAIL"].ToString();
            Luong = (byte[])row["LUONG"];
            Tendn = row["TENDN"].ToString();
            Mk = (byte[])row["MATKHAU"];
        }

        public string Manv { get => _manv; set => _manv = value; }
        public string Hoten { get => _hoten; set => _hoten = value; }
        public string Email { get => _email; set => _email = value; }
        public byte[] Luong { get => _luong; set => _luong = value; }
        public string Tendn { get => _tendn; set => _tendn = value; }
        public byte[] Mk { get => _mk; set => _mk = value; }
    }
}
