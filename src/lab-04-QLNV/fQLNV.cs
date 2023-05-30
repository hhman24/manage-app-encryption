using lab_04_QLNV.DAO;
using lab_04_QLNV.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace lab_04_QLNV
{
    public partial class fQLNV : Form
    {
        // binding source
        List<nhanvien> nv_ls = nvDAO.Instance.get_list_nv();
        BindingSource binding_nv = new BindingSource();

        public fQLNV()
        {
            InitializeComponent();
            loadNV();
            display_info();
            binding_data();
        }

        #region Method
        // thực hiện binding source
        void loadNV()
        {
            DataTable table = dataProvider.Instance.ExecuteQuery("EXEC SP_SEL_ENCRYPT_NHANVIEN");

            DataTable table_nv = new DataTable();

            table_nv.Columns.Add("MANV", typeof(string));
            table_nv.Columns.Add("HOTEN", typeof(string));
            table_nv.Columns.Add("EMAIL", typeof(string));
            table_nv.Columns.Add("LUONG", typeof(string));
            table_nv.Columns.Add("TENDN", typeof(string));
            table_nv.Columns.Add("MK", typeof(string));

            // Giải mã

            string symetric_key = "20127102";
            byte[] key_bytes = new byte[32];
            byte[] iv_bytes = new byte[16];

            System.Text.Encoding.UTF8.GetBytes(symetric_key, 0, 1, key_bytes, 0);
            System.Text.Encoding.UTF8.GetBytes(symetric_key, 0, 1, iv_bytes, 0);


            foreach (nhanvien nv in nv_ls)
            {
                DataRow row = table_nv.NewRow();
                row["MANV"] = nv.Manv;
                row["HOTEN"] = nv.Hoten;
                row["EMAIL"] = nv.Email;
                row["TENDN"] = nv.Tendn;

                // giải mã lương
                // byte[] salary = encryptAlgorithm.EncryptStringToBytes_Aes("3000000", myAes.Key, myAes.IV);
                row["LUONG"] = encryptAlgorithm.DecryptStringFromBytes_Aes(nv.Luong, key_bytes, iv_bytes);

                // Chuyển chuỗi cho MK
                foreach (byte b in nv.Mk)
                {
                    row["MK"] += b.ToString("X2");
                }

                table_nv.Rows.Add(row);

            }

            binding_nv.DataSource = table_nv;

            dataNV.DataSource = binding_nv;

            dataNV.Columns["TENDN"].Visible = false;
            dataNV.Columns["MK"].Visible = false;
        }

        void display_info()
        {
            labelUser.Text = "NV: " + account.Instance.Ma;
            labelHoTen.Text = "Họ Tên: " + account.Instance.Hoten;
        }

        void binding_data()
        {
            tbMaNV.DataBindings.Add(new Binding("Text", dataNV.DataSource, "Manv", true, DataSourceUpdateMode.Never));
            tbName.DataBindings.Add(new Binding("Text", dataNV.DataSource, "Hoten", true, DataSourceUpdateMode.Never));
            tbEmail.DataBindings.Add(new Binding("Text", dataNV.DataSource, "Email", true, DataSourceUpdateMode.Never));
            tbUserName.DataBindings.Add(new Binding("Text", dataNV.DataSource, "Tendn", true, DataSourceUpdateMode.Never));
            tbLuong.DataBindings.Add(new Binding("Text", dataNV.DataSource, "LUONG", true, DataSourceUpdateMode.Never));
            
        }

        #endregion


        #region Event
        // Event nhấn log out
        private void bLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            fLogin login = new fLogin();
            login.ShowDialog();
            this.Dispose();
        }

        private void bQuite_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void bInsert_Click(object sender, EventArgs e)
        {
            // Nhận giá trị từ text box
            string manv = tbMaNV.Text;
            string hoten = tbName.Text;
            string email = tbEmail.Text;
            string salary = tbLuong.Text;
            string tendn = tbUserName.Text;
            string mk = tbPassWord.Text;

            // Kiểm tra điều kiện trk khi insert


            // Thực hiện mã hóa;      
            // Thực hiện mã hóa lương
            string symetric_key = "20127102";
            byte[] key_bytes = new byte[32];
            byte[] iv_bytes = new byte[16];

            System.Text.Encoding.UTF8.GetBytes(symetric_key, 0, 1, key_bytes, 0);
            System.Text.Encoding.UTF8.GetBytes(symetric_key, 0, 1, iv_bytes, 0);

            byte[] en_salary = encryptAlgorithm.EncryptStringToBytes_Aes(salary, key_bytes, iv_bytes);


            // Mk đã được mã hóa
            byte[] hash_mk = hash_mk = encryptAlgorithm.hash_SHA1(mk);


            // Khởi tạo đối tượng nhân viên
            nhanvien nv = new nhanvien(manv, hoten, email, en_salary, tendn, hash_mk);
            nv_ls.Add(nv);

            // Cập nhật grid view

            // Query
            string query = "SP_INS_ENCRYPT_NHANVIEN @manv, @hoten, @email, @luong, @tendn, @mk";
            object[] p = {"@manv", SqlDbType.VarChar, manv,
                        "@hoten", SqlDbType.NVarChar, hoten,
                        "@email", SqlDbType.VarChar, email,
                        "@luong", SqlDbType.VarBinary, en_salary,
                        "@tendn", SqlDbType.NVarChar, tendn,
                        "@mk", SqlDbType.VarBinary, hash_mk};

            // Thực hiện insert vào dữ liệu
            if (dataProvider.Instance.ExecuteNoneQuery(query, p) > 0)
            {
                MessageBox.Show("Success to Insert!", "Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbPassWord.Clear();
                loadNV();
            }
            else
            {
                MessageBox.Show("Failed to Insert!", "Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            // lấy giá trị binding
            string _manv = tbMaNV.DataBindings["Text"].Control.Text;

            // Nhận giá trị từ text box current
            string manv = tbMaNV.Text;
            string hoten = tbName.Text;
            string email = tbEmail.Text;
            string salary = tbLuong.Text;
            string tendn = tbUserName.Text;
            string mk = tbPassWord.Text;

            // Kiểm tra điều kiện trk khi insert
            if(tbMaNV.Text == "")
            {
                MessageBox.Show("MaNV Delete!", "Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Thực hiện mã hóa;      
            // Thực hiện mã hóa lương
            string symetric_key = "20127102";
            byte[] key_bytes = new byte[32];
            byte[] iv_bytes = new byte[16];

            System.Text.Encoding.UTF8.GetBytes(symetric_key, 0, 1, key_bytes, 0);
            System.Text.Encoding.UTF8.GetBytes(symetric_key, 0, 1, iv_bytes, 0);

            byte[] en_salary = encryptAlgorithm.EncryptStringToBytes_Aes(salary, key_bytes, iv_bytes);

            // Mk đã được mã hóa
            byte[] hash_mk = null;

            if (tbPassWord.Text != "")
            { 
                 hash_mk = encryptAlgorithm.hash_SHA1(mk);
            }

            // thay đổi đối tượng
            foreach (nhanvien nv in nv_ls)
            {
                if (tbPassWord.Text != "")
                {
                    if (_manv == nv.Manv)
                    {
                        nv.Manv = manv;
                        nv.Hoten = hoten;
                        nv.Email = email;
                        nv.Luong = en_salary;
                        nv.Tendn = tendn;
                        nv.Mk = hash_mk;
                        break;
                    }
                }
                else
                {
                    if (_manv == nv.Manv)
                    {
                        nv.Manv = manv;
                        nv.Hoten = hoten;
                        nv.Email = email;
                        nv.Luong = en_salary;
                        nv.Tendn = nv.Tendn;
                        hash_mk = nv.Mk;
                        break;
                    }
                }

            }

            // Cập nhật grid view
            //dataNV.DataSource = nv_ls;

            // Query
            string query = "SP_UPDATE_NHANVIEN @manv, @hoten, @email, @luong, @tendn, @mk, @_manv";
            object[] p = {"@manv", SqlDbType.VarChar, manv,
                          "@hoten", SqlDbType.NVarChar, hoten,
                          "@email", SqlDbType.VarChar, email,
                          "@luong", SqlDbType.VarBinary, en_salary,
                          "@tendn", SqlDbType.NVarChar, tendn,
                          "@mk", SqlDbType.VarBinary, hash_mk,
                          "@_manv", SqlDbType.VarChar, _manv};


            // Thực hiện insert vào dữ liệu
            if (dataProvider.Instance.ExecuteNoneQuery(query, p) > 0)
            {
                MessageBox.Show("Success to update!", "Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbPassWord.Clear();
                loadNV();
            }
            else
            {
                MessageBox.Show("Failed to update!", "Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bclear_Click(object sender, EventArgs e)
        {
            tbMaNV.Clear();
            tbName.Clear();
            tbEmail.Clear();
            tbLuong.Clear();
            tbUserName.Clear();
            tbPassWord.Clear();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            // lấy giá trị binding
            string _manv = tbMaNV.DataBindings["Text"].Control.Text;

            // xóa nhân viên
            nhanvien nv = nv_ls.FirstOrDefault(x => x.Manv == _manv);
            if (nv != null)
            {
                nv_ls.Remove(nv);
            }

            string query = "DELETE NHANVIEN WHERE MANV = @_manv";
            object[] p = {"@_manv", SqlDbType.VarChar, _manv};


            // Thực hiện insert vào dữ liệu
            if (dataProvider.Instance.ExecuteNoneQuery(query, p) > 0)
            {
                MessageBox.Show("Success to delete!", "Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbPassWord.Clear();
                loadNV();
            }
            else
            {
                MessageBox.Show("Failed to delete!", "Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion


    }
}
