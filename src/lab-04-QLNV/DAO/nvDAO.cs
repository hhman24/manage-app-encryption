using lab_04_QLNV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_04_QLNV.DAO
{
    public class nvDAO
    {
        private nvDAO() { }

        // tạo instance 
        private static nvDAO _instance;

        public static nvDAO Instance
        {
            get { if (_instance == null) _instance = new nvDAO(); return _instance; }
            set => _instance = value;
        }


        // phương thức lấy tất cả nhân viên từ data
        public List<nhanvien> get_list_nv()
        {
            List<nhanvien> ls_nv = new List<nhanvien>();

            string query = "SELECT * FROM NHANVIEN";

            DataTable table = dataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow row in table.Rows)
            {
                nhanvien nv = new nhanvien(row);
                ls_nv.Add(nv);
            }    

            return ls_nv;
        }

    }
}
