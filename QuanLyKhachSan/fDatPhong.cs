using QuanLyKhachSan.DAO;
using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class fDatPhong : Form
    {
        public fDatPhong()
        {
            InitializeComponent();
            LoadList();
        }
        void LoadList()
        {
            LoadRoomType();
            LoadDgvDatPhong();
            LoadCustomer();
            AddDatPhongBinding();
        }
        void LoadDgvDatPhong()
        {
            string query = "USP_LoadDatPhong";
            dgvDatPhong.DataSource = DataProvider.Instance.ExecuteQuery(query); //hiện thị dữ liệu lên dgv

        }
        void AddDatPhongBinding()
        {
            cbCustomer.DataBindings.Add(new Binding("Text", dgvDatPhong.DataSource, "Khách hàng", true, DataSourceUpdateMode.Never));
            cbRoomtype.DataBindings.Add(new Binding("Text", dgvDatPhong.DataSource, "Loại phòng", true, DataSourceUpdateMode.Never));
            cbRoom.DataBindings.Add(new Binding("Text", dgvDatPhong.DataSource, "Phòng", true, DataSourceUpdateMode.Never));
        }
        void LoadRoomType()
        {
            List<RoomType> listRoomType = RoomTypeDAO.Instance.GetListRoomType();
            cbRoomtype.DataSource = listRoomType;
            cbRoomtype.DisplayMember = "NameType";
        }
        void LoadCustomer()
        {
            List<Customer> CustomerList = CustomerDAO.Instance.LoadCustomer();
            cbCustomer.DataSource = CustomerList;
            cbCustomer.DisplayMember = "NameCustomer";
        }
        void LoadRoomListByRoomTypeID(int id)
        {
            List<Room> listFood = RoomDAO.Instance.GetRoomByRoomTypeID(id);
            cbRoom.DataSource = listFood;
            cbRoom.DisplayMember = "NameRoom";
        }

        private void cbRoomtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            RoomType selected = cb.SelectedItem as RoomType;
            id = selected.ID;

            LoadRoomListByRoomTypeID(id);
        }

        private void btnAddCustomerByRoom_Click(object sender, EventArgs e)
        {
            int idCustomer = (cbCustomer.SelectedItem as Customer).ID;
            int idRoom = (cbRoom.SelectedItem as Room).ID;

            if (BillDAO.Instance.InsertBill(idCustomer, idRoom))
            {
                MessageBox.Show("Đặt phòng thành công!");
                LoadDgvDatPhong();
            }
            else
            {
                MessageBox.Show("Đặt phòng thất bại!!!");
            }
        }
    }
}
