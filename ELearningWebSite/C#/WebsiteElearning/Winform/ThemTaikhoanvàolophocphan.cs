using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform
{
    public partial class ThemTaikhoanvàolophocphan : Form
    {
        public ThemTaikhoanvàolophocphan()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Quanlytaikhoan quanlytaikhoan = new Quanlytaikhoan();
            quanlytaikhoan.Show();
        }
    }
}
