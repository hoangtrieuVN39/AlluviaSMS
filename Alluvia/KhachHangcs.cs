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
    public partial class KhachHangcs : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=HIEUDEPZAI;Initial Catalog=QuanLyBH;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void LoadKhachHangList()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from KhachHang";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            GridKhachHang.DataSource = table;

        }
        public KhachHangcs()
        {
            InitializeComponent();
        }

        private void gnbtSearch_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from KhachHang where KH_Ten  like N'%" + txSearch.Text.Trim() + "%'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            GridKhachHang.DataSource = table;
        }

        private void gnbtRS_Click(object sender, EventArgs e)
        {
            LoadKhachHangList();
            txKH.ReadOnly = false;
            txKH.Text = "";
            txTen.Text = "";
        }

        private void gnbtDL_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from KhachHang where KH_Ma = ('" + txKH.Text + "')";
            command.ExecuteNonQuery();
            LoadKhachHangList();
        }

        private void gnbtUD_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update KhachHang set KH_Ten = '" + txTen.Text + "' where KH_Ma = '" + txKH.Text + "'";
            command.ExecuteNonQuery();
            LoadKhachHangList();
        }

        private void gnbtADD_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into KhachHang(KH_Ma,KH_Ten) values('" + txKH.Text + "','" + txTen.Text + "')";
            command.ExecuteNonQuery();
            LoadKhachHangList();
        }

        private void GridKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txKH.ReadOnly = true;
            if (GridKhachHang.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                GridKhachHang.CurrentRow.Selected = true;
                txKH.Text = GridKhachHang.Rows[e.RowIndex].Cells["KH_Ma"].Value.ToString();
                txTen.Text = GridKhachHang.Rows[e.RowIndex].Cells["KH_Ten"].Value.ToString();
            }
        }

        private void KhachHangcs_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadKhachHangList();
        }
    }
}
