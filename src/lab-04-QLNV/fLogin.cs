using lab_04_QLNV.DAO;
using lab_04_QLNV.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace lab_04_QLNV
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void loginFrame_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string user = tboxUserName.Text.Trim();
            // truong hop ly neu chuoi la varchar, nvarchar
            // choi la ki tu co dau
            // string co luu duoc unicode ???
            string password = tboxPassWord.Text.Trim();

            // encrypt và kiểm tra đăng nhập
            bool is_admin = account.Instance.login(user, password);

            try
            {
                if(is_admin)
                {
                    MessageBox.Show("Success to Login!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fQLNV qlnv = new fQLNV();
                    this.Hide();
                    tboxUserName.Text = "";
                    tboxPassWord.Text = "";
                    tboxUserName.Focus();
                    qlnv.ShowDialog();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Failed to Login!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tboxUserName.Text = "";
                    tboxPassWord.Text = "";
                    tboxUserName.Focus();
                }    

            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                MessageBox.Show("Cannot connect to DB!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tboxUserName.Text = "";
                tboxPassWord.Text = "";
                tboxUserName.Focus();
            }


        }
        
        // Exit Button
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // CheckBox
        private void checkBoxPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPas.Checked)
            {
                tboxPassWord.PasswordChar = '\0';
            }
            else tboxPassWord.PasswordChar = '*';
        }

        // Text Box
        private void tboxUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tboxPassWord_TextChanged(object sender, EventArgs e)
        {

        }

        // Panel Image
        private void pImage_Paint(object sender, PaintEventArgs e)
        {

        }

        // Event Closing
        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Do you want quite ?", "Notify", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            //{
            //    e.Cancel = true;
            //}
        }
    }
}
