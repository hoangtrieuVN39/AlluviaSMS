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

namespace Alluvia
{
    public partial class TaiKhoan : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=HIEUDEPZAI;Initial Catalog=QuanLyBH;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void LoadTaiKhoanList()
        {
            command = connection.CreateCommand();
            command.CommandText = "select NV_Ma,Ten_TK, CONVERT(char, CONVERT(varchar(100), DECRYPTBYPASSPHRASE ('MatKhau',[encrypted MatKhau]))) as MatKhau from TaiKhoan";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            GridTaiKhoan.DataSource = table;


        }
        public TaiKhoan()
        {
            InitializeComponent();
        }

        private void gnbtADD_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into TaiKhoan(NV_Ma,Ten_TK,[encrypted MatKhau]) values('" + txMaNV.Text + "','" + txTen.Text + "', ENCRYPTBYPASSPHRASE('MatKhau', '" + txMK.Text + "'))";
            command.ExecuteNonQuery();
            LoadTaiKhoanList();
        }

        private void gnbtDL_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from TaiKhoan where Ten_TK = ('" + txTen.Text + "')";
            command.ExecuteNonQuery();
            LoadTaiKhoanList();
        }

        private void gnbtUD_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update TaiKhoan set Ten_TK = '" + txTen.Text + "',[Encrypted MatKhau] = ENCRYPTBYPASSPHRASE('MatKhau', '" + txMK.Text + "')  where NV_Ma = '" + txMaNV.Text + "'";
            command.ExecuteNonQuery();
            LoadTaiKhoanList();
        }

        private void gnbtRS_Click(object sender, EventArgs e)
        {
            LoadTaiKhoanList();
            txMaNV.ReadOnly = false;
            txMaNV.Text = "";
            txTen.Text = "";
            txMK.Text = "";
        }

        private void gnbtSearch_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select NV_Ma, Ten_TK, convert (varchar ,convert (varchar(100), DECRYPTBYPASSPHRASE ('MatKhau',[encrypted MatKhau]))) as MatKhau from TaiKhoan where NV_Ma  like N'%" + txSearch.Text.Trim() + "%'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            GridTaiKhoan.DataSource = table;
        }

        private void GridTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txMaNV.ReadOnly = true;
            if (GridTaiKhoan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                GridTaiKhoan.CurrentRow.Selected = true;
                txMaNV.Text = GridTaiKhoan.Rows[e.RowIndex].Cells["NV_Ma"].Value.ToString();
                txTen.Text = GridTaiKhoan.Rows[e.RowIndex].Cells["Ten_TK"].Value.ToString();
                txMK.Text = GridTaiKhoan.Rows[e.RowIndex].Cells["MatKhau"].Value.ToString();
            }
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadTaiKhoanList();
        }
    }
}
