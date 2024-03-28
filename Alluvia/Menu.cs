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
    public partial class Menu : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=HIEUDEPZAI;Initial Catalog=QuanLyBH;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void LoadSPList()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from SanPham";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            GridSP.DataSource = table;

        }

        public Menu()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txMaSP.ReadOnly = true;
            if (GridSP.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                GridSP.CurrentRow.Selected = true;
                txMaSP.Text = GridSP.Rows[e.RowIndex].Cells["SP_Ma"].Value.ToString();
                txTenSP.Text = GridSP.Rows[e.RowIndex].Cells["SP_Ten"].Value.ToString();
                txDonGia.Text = GridSP.Rows[e.RowIndex].Cells["SP_DonGia"].Value.ToString();
                txTonKho.Text = GridSP.Rows[e.RowIndex].Cells["SP_TonKho"].Value.ToString();
            }

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadSPList();
        }

        private void gnbtSearch_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from SanPham where SP_Ten  like N'%" + txSearch.Text.Trim() + "%'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            GridSP.DataSource = table;

        }

        private void gnbtDL_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from SanPham where SP_Ma = ('" + txMaSP.Text + "')";
            command.ExecuteNonQuery();
            LoadSPList();

        }

        private void gnbtRS_Click(object sender, EventArgs e)
        {
            LoadSPList();
            txMaSP.ReadOnly = false;
            txMaSP.Text = "";
            txTenSP.Text = "";
            txDonGia.Text = "";
            txTonKho.Text = "";

        }

        private void gnbtUD_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update SanPham set SP_Ten = '" + txTenSP.Text + "',SP_DonGia = '" + txDonGia.Text + "',SP_TonKho = '" + txTonKho.Text + "' where SP_Ma = '" + txMaSP.Text + "'";
            command.ExecuteNonQuery();
            LoadSPList();

        }

        private void gnbtADD_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into SanPham values('" + txMaSP.Text + "','" + txTenSP.Text + "','" + txDonGia.Text + "','" + txTonKho.Text + "')";
            command.ExecuteNonQuery();
            LoadSPList();

        }
    }
}
