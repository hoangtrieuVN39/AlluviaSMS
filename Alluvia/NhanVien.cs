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
    public partial class NhanVien : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=HIEUDEPZAI;Initial Catalog=QuanLyBH;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void LoadNhanVienList()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from NhanVien";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            GridNhanVien.DataSource = table;

        }
        public NhanVien()
        {
            InitializeComponent();
        }

        private void gnbtDL_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from NhanVien where NV_Ma = ('" + txNV.Text + "')";
            command.ExecuteNonQuery();
            LoadNhanVienList();
        }

        private void gnbtRS_Click(object sender, EventArgs e)
        {
            LoadNhanVienList();
            txNV.ReadOnly = false;
            txNV.Text = "";
            txTen.Text = "";

        }

        private void gnbtUD_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update NhanVien set NV_Ten = '" + txTen.Text + "' where NV_Ma = '" + txNV.Text + "'";
            command.ExecuteNonQuery();
            LoadNhanVienList();
        }

        private void gnbtADD_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into NhanVien(NV_Ma,NV_Ten) values('" + txNV.Text + "','" + txTen.Text + "')";
            command.ExecuteNonQuery();
            LoadNhanVienList();
        }

        private void gnbtSearch_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from NhanVien where NV_Ten  like N'%" + txSearch.Text.Trim() + "%'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            GridNhanVien.DataSource = table;
        }

        private void GridNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txNV.ReadOnly = true;
            if (GridNhanVien.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                GridNhanVien.CurrentRow.Selected = true;
                txNV.Text = GridNhanVien.Rows[e.RowIndex].Cells["NV_Ma"].Value.ToString();
                txTen.Text = GridNhanVien.Rows[e.RowIndex].Cells["NV_Ten"].Value.ToString();
            }
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadNhanVienList();
        }
    }
}
