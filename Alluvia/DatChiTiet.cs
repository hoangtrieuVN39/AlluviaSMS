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
    public partial class DatChiTiet : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=HIEUDEPZAI;Initial Catalog=QuanLyBH;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void LoadDatCTList()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from DatChiTiet";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            GridDatChiTiet.DataSource = table;

        }
        public DatChiTiet()
        {
            InitializeComponent();
        }

        private void GridDatChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txHD.ReadOnly = true;
            txTT.ReadOnly = true;
            if (GridDatChiTiet.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                GridDatChiTiet.CurrentRow.Selected = true;
                txHD.Text = GridDatChiTiet.Rows[e.RowIndex].Cells["HD_Ma"].Value.ToString();
                txMaSP.Text = GridDatChiTiet.Rows[e.RowIndex].Cells["SP_Ma"].Value.ToString();
                txSL.Text = GridDatChiTiet.Rows[e.RowIndex].Cells["SL"].Value.ToString();
                txTT.Text = GridDatChiTiet.Rows[e.RowIndex].Cells["ThanhTien"].Value.ToString();
            }
        }

        private void gnbtSearch_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from DatChiTiet where HD_Ma  like N'%" + txSearch.Text.Trim() + "%'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            GridDatChiTiet.DataSource = table;
        }

        private void gnbtRS_Click(object sender, EventArgs e)
        {
            LoadDatCTList();
            txHD.ReadOnly = false;
            txHD.Text = "";
            txMaSP.Text = "";
            txSL.Text = "";
            txTT.Text = "";
        }

        private void gnbtDL_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from DatChiTiet where HD_Ma = ('" + txHD.Text + "')";
            command.ExecuteNonQuery();
            LoadDatCTList();
        }

        private void gnbtUD_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update DatChiTiet set SP_Ma = '" + txMaSP.Text + "',SL = '" + txSL.Text + "' where HD_Ma = '" + txHD.Text + "'";
            command.ExecuteNonQuery();
            LoadDatCTList();
        }

        private void gnbtADD_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into DatChiTiet(HD_Ma,SP_Ma,SL) values('" + txHD.Text + "','" + txMaSP.Text + "','" + txSL.Text + "')";
            command.ExecuteNonQuery();
            LoadDatCTList();
        }

        private void DatChiTiet_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadDatCTList();
        }
    }
}
