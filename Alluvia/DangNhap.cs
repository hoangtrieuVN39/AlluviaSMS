using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alluvia
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection ql = new SqlConnection(@"Data Source=HIEUDEPZAI;Initial Catalog=QuanLyBH;Integrated Security=True");
                ql.Open();
                string sql = "SELECT * FROM TaiKhoan WHERE Ten_TK = @tk and CONVERT(char, CONVERT(varchar(100), DECRYPTBYPASSPHRASE('MatKhau', [Encrypted MatKhau]))) = @mk";
                SqlCommand cmd = new SqlCommand(sql, ql);
                cmd.Parameters.AddWithValue("@tk", txTK.Text);
                cmd.Parameters.AddWithValue("@mk", txMK.Text);

                string tk = txTK.Text;
                string mk = txMK.Text;
                string sql1 = "select * from TaiKhoan where Ten_TK ='" + tk + "' and  CONVERT(char, CONVERT(varchar(100), DECRYPTBYPASSPHRASE('MatKhau', [Encrypted MatKhau]))) = '" + mk + "' ";
                SqlCommand cmd1 = new SqlCommand(sql1, ql);
                SqlDataReader dta = cmd1.ExecuteReader();
                if (dta.Read() == true)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    QuanLy f = new QuanLy();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DangNhap_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn thoát không?", "Quản Lý Quán Alluvia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}