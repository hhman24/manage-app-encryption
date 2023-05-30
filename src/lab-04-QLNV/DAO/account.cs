using lab_04_QLNV.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_04_QLNV.DAO
{
    public class account
    {
        // singleton pattern
        private account() { }

        // tạo instance 
        private static account _instance;

        public static account Instance 
        {
            get { if(_instance == null) _instance = new account(); return _instance; }
            set => _instance = value; 
        }


        private string _ma;
        private string _hoten;
        private string _tendn;


        private void save_account(DataRow row)
        {
            Ma = row[0].ToString();
            Hoten = row["HOTEN"].ToString();
            Tendn = row["TENDN"].ToString();
        }

        public string Ma { get => _ma; set => _ma = value; }
        public string Hoten { get => _hoten; set => _hoten = value; }
        public string Tendn { get => _tendn; set => _tendn = value; }

        public bool login(string username, string password)
        {
            byte[] mk_md5 = encryptAlgorithm.hash_md5(password);
            byte[] mk_sha1 = encryptAlgorithm.hash_SHA1(password);

            string query = "EXEC SP_CHECK_TAIKHOAN @user, @password";

            // variable, type, value
            object[] parameter_md5 = { "@user", SqlDbType.NVarChar, username, "@password", SqlDbType.VarBinary, mk_md5 };
            object[] parameter_sha1 = { "@user", SqlDbType.NVarChar, username, "@password", SqlDbType.VarBinary, mk_sha1 };


            // kiem tra ben sinh vien
            DataTable table = dataProvider.Instance.ExecuteQuery(query, parameter_md5);
            if (table.Rows.Count > 0)
            {
                // lưu đối tượng admin
                save_account(table.Rows[0]);

                return true;
            }

            // kiểm tra nhan vien
            table = dataProvider.Instance.ExecuteQuery(query, parameter_sha1);
            if (table.Rows.Count > 0)
            {
                // lưu đối tượng admin
                save_account(table.Rows[0]);

                return true;
            }

            return false;
        }

    }
}
