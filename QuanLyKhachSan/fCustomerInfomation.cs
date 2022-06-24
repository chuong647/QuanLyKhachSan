using QuanLyKhachSan.DAO;
using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class fCustomerInfomation : Form
    {
        BindingSource CustomerList = new BindingSource();
        public fCustomerInfomation()
        {
            InitializeComponent();
            LoadList();
        }

        void LoadList()
        {
            dgvCustomer.DataSource = CustomerList;

            LoadTableCustomer();
            AddCustomerBinding();
        }

        void AddCustomerBinding()
        {
            txbNameCustomer.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "Tên KH", true, DataSourceUpdateMode.Never));
            dtpDateCustumer.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "Ngày sinh", true, DataSourceUpdateMode.Never));
            cbGenderCustomer.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "Giới tính", true, DataSourceUpdateMode.Never));
            txbAddressCustomer.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "Địa chỉ", true, DataSourceUpdateMode.Never));
            txbCMND.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "Số CM", true, DataSourceUpdateMode.Never));
            txbPhoneNumber.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "Điện thoại", true, DataSourceUpdateMode.Never));
            txbidCustomer.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "id", true, DataSourceUpdateMode.Never));
        }
        void LoadTableCustomer()
        {
            string query = "USP_LoadCustomer";
            CustomerList.DataSource = DataProvider.Instance.ExecuteQuery(query); //hiện thị dữ liệu lên dgv

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string nameCustomer = txbNameCustomer.Text;
            string datetimeCustomer = dtpDateCustumer.Text;
            //DateTime datetimeCustomer = DateTime.ParseExact(dtpDateCustumer.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            string genderCustomer = cbGenderCustomer.Text;
            string addressCustomer = txbAddressCustomer.Text;
            string idCardCustomer = txbCMND.Text;
            string phoneNumber = txbPhoneNumber.Text;
            //int idRoom = int.Parse(txbidRoom.Text);


            if (CustomerDAO.Instance.InsertCustomer( nameCustomer, datetimeCustomer, genderCustomer, addressCustomer, idCardCustomer, phoneNumber))
            {
                MessageBox.Show("Thêm Khách hàng thành công!");
                LoadTableCustomer();
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại!!!");
            }
        }

        private void dtpDateCustumer_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTime = dtpDateCustumer.Value;
            label2.Text = dateTime.ToString();
        }

        private void btnRepairCustomer_Click(object sender, EventArgs e)
        {
            string nameCustomer = txbNameCustomer.Text;
            string datetimeCustomer = dtpDateCustumer.Text;
            string genderCustomer = cbGenderCustomer.Text;
            string addressCustomer = txbAddressCustomer.Text;
            string idCardCustomer = txbCMND.Text;
            string phoneNumber = txbPhoneNumber.Text;
            int id = int.Parse(txbidCustomer.Text);


            if (CustomerDAO.Instance.UpdateCustomer(id, nameCustomer, datetimeCustomer, genderCustomer, addressCustomer, idCardCustomer, phoneNumber))
            {
                MessageBox.Show("Sửa Khách hàng thành công!");
                LoadTableCustomer();
            }
            else
            {
                MessageBox.Show("Sửa khách hàng thất bại!!!");
            }
        }
    }
}
