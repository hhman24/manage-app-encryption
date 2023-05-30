using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_04_QLNV.DAO
{
    public class dataProvider
    {
        // Kiến trúc singleton
        // ý tưởng: static được tạo ra bởi một lần duy nhất và được gọi thông qua tên hàm
        // Khởi tạo 
        private dataProvider() { } // bên ngoài không thể tác động được

        private static dataProvider _instance; // Đóng gói: Ctrl + R + E

        public static dataProvider Instance
        {
            // Expression-bodied members
            // Mong muốn chỉ duy nhất một instance => bên ngoài không thể thay đổi
            get 
            { 
                if (_instance == null) _instance = new dataProvider(); 
                return dataProvider._instance; 
            }
            // private set chỉ được nội bộ trong class mới được thay đổi
            private set => _instance = value; 
        }

        private string str_conn = @"Data Source=PC-AN;Initial Catalog=QLSinhVien;Integrated Security=True";

        public DataTable ExecuteQuery(string query, object[] var_type_value_para_ls = null)
        {
            // DataTable ?
            DataTable data = new DataTable();
            
            // Kết thúc lệnh sẽ được giải phóng
            using (SqlConnection conn = new SqlConnection(str_conn))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                if(var_type_value_para_ls != null)
                {
                    //string[] list_para = query.Split(' ');
                    //int i = 0;
                    //foreach (string item in list_para)
                    //{
                    //    if(item.Contains("@"))
                    //    {
                    //        command.Parameters.AddWithValue(item, parameter[i]);
                    //        i++;
                    //    }
                    //}

                    for (int i = 0; i < var_type_value_para_ls.Length; i += 3)
                    {
                        string p_variable = (string)var_type_value_para_ls[i];
                        SqlDbType p_type = (SqlDbType)var_type_value_para_ls[i + 1];
                        object p_val = var_type_value_para_ls[i + 2];


                        command.Parameters.Add(p_variable, p_type).Value = p_val;
                    }    
                }

                // Hoạt động như một cầu nối giữa DataSet và nguồn dữ liệu
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);


                command.Dispose();
                conn.Close();
            }

            return data;
        }

        public int ExecuteNoneQuery(string query, object[] var_type_value_para_ls = null)
        {
            int data = 0;
            try
            {
                // Kết thúc lệnh sẽ được giải phóng
                using (SqlConnection conn = new SqlConnection(str_conn))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(query, conn);

                    if (var_type_value_para_ls != null)
                    {
                        //string[] list_para = query.Split(' ');
                        //int i = 0;
                        //foreach (string item in list_para)
                        //{
                        //    if(item.Contains("@"))
                        //    {
                        //        command.Parameters.AddWithValue(item, parameter[i]);
                        //        i++;
                        //    }
                        //}

                        for (int i = 0; i < var_type_value_para_ls.Length; i += 3)
                        {
                            string p_variable = (string)var_type_value_para_ls[i];
                            SqlDbType p_type = (SqlDbType)var_type_value_para_ls[i + 1];
                            object p_val = var_type_value_para_ls[i + 2];


                            command.Parameters.Add(p_variable, p_type).Value = p_val;
                        }
                    }

                    data = command.ExecuteNonQuery();

                    command.Dispose();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Error: " + ex.Message);
            }


            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            // Kết thúc lệnh sẽ được giải phóng
            using (SqlConnection conn = new SqlConnection(str_conn))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                if (parameter != null)
                {
                    string[] list_para = query.Split(' ');
                    int i = 0;
                    foreach (string item in list_para)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                command.Dispose();
                data = command.ExecuteScalar();
                conn.Close();
            }

            
            return data;
        }
    }
}
