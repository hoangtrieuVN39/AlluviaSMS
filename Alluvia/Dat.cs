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
    public partial class Dat : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=HIEUDEPZAI;Initial Catalog=QuanLyBH;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void LoadHoaDonList()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Dat";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            GridDat.DataSource = table;

        }

        public Dat()
        {
            InitializeComponent();
        }

        private void GridDat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txMaHD.ReadOnly = true;
            txTT.ReadOnly = true;
            txTC.ReadOnly = true;
            if (GridDat.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                GridDat.CurrentRow.Selected = true;
                txMaHD.Text = GridDat.Rows[e.RowIndex].Cells["HD_Ma"].Value.ToString();
                txMaKH.Text = GridDat.Rows[e.RowIndex].Cells["KH_Ma"].Value.ToString();
                txMaNV.Text = GridDat.Rows[e.RowIndex].Cells["NV_Ma"].Value.ToString();
                txNBL.Text = GridDat.Rows[e.RowIndex].Cells["NBL_Ma"].Value.ToString();
                txCK.Text = GridDat.Rows[e.RowIndex].Cells["HD_TongCK"].Value.ToString();
                txTg.Text = GridDat.Rows[e.RowIndex].Cells["HD_NgayXuat"].Value.ToString();
                txTT.Text = GridDat.Rows[e.RowIndex].Cells["HD_TongTien"].Value.ToString();
                txTC.Text = GridDat.Rows[e.RowIndex].Cells["HD_TongTT"].Value.ToString();
            }

        }

        private void gnbtADD_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into Dat(HD_Ma,KH_Ma,NV_Ma,HD_TongCK,HD_NgayXuat,NBL_Ma) values('" + txMaHD.Text + "','" + txMaKH.Text + "','" + txMaNV.Text + "','" + txCK.Text + "','" + txTg.Text + "','" + txNBL.Text + "')";
            command.ExecuteNonQuery();
            LoadHoaDonList();

        }

        private void gnbtDL_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from Dat where HD_Ma = ('" + txMaHD.Text + "')";
            command.ExecuteNonQuery();
            LoadHoaDonList();

        }

        private void gnbtUD_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update Dat set KH_Ma = '" + txMaKH.Text + "',NV_Ma = '" + txMaNV.Text + "',HD_NgayXuat = '" + txTg.Text + "',HD_TongCK = '" + txCK.Text + "',NBL_Ma = '" + txNBL.Text + "' where HD_Ma = '" + txMaHD.Text + "'";
            command.ExecuteNonQuery();
            LoadHoaDonList();

        }

        private void gnbtRS_Click(object sender, EventArgs e)
        {
            LoadHoaDonList();
            txMaHD.ReadOnly = false;
            txMaHD.Text = "";
            txMaKH.Text = "";
            txMaNV.Text = "";
            txNBL.Text = "";
            txTg.Text = "";
            txCK.Text = "";
            txTT.Text = "";
            txTC.Text = "";

        }

        private void gnbtSearch_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Dat where HD_Ma like N'%" + txSearch.Text.Trim() + "%'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            GridDat.DataSource = table;

        }

        private void Dat_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadHoaDonList();

        }
    }
}
