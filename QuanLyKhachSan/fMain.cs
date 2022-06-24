using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyKhachSan
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            fRoomManager open = new fRoomManager();
            this.Hide();
            open.ShowDialog();
            this.Show();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            fService open = new fService();
            this.Hide();
            open.ShowDialog();
            this.Show();
        }
    }
}
