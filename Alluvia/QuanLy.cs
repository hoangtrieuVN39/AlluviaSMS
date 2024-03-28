using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alluvia
{
    public partial class QuanLy : Form
    {
        public QuanLy()
        {
            InitializeComponent();
        }

        private void moveImageBox(object sender)
        {

            Guna2Button b = (Guna2Button)sender;




        }

        private void guna2Button6_CheckedChanged(object sender, EventArgs e)
        {

            moveImageBox(sender);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {


        }
        private void OpenChildForm(Form childForm)
        {

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.Bigform.Controls.Add(childForm);
            this.Bigform.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Menu());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Dat());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DatChiTiet());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhanVien());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhachHangcs());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TaiKhoan());
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn đăng xuất không?", "Quản Lý Quán Alluvia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }

        }
    }
}
