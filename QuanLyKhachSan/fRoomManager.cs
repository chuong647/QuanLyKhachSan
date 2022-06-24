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
    public partial class fRoomManager : Form
    {
        public fRoomManager()
        {
            InitializeComponent();
            LoadList();
            
        }
        void LoadList()
        {
            LoadRoom();
            LoadServiceList();
        }

        void LoadServiceList()
        {
            List<Service> ServiceList = ServiceDAO.Instance.LoadServiceList();
            cbAddService.DataSource = ServiceList;
            cbAddService.DisplayMember = "NameService";
        }
        void LoadRoom()
        {
            flpRoom.Controls.Clear();
            List<Room> TableList = RoomDAO.Instance.LoadRoomList();
            foreach (Room item in TableList)    //với mỗi table nằm trong TableList tạo nút button
            {
                Button btn = new Button()
                {
                    Width = RoomDAO.TableWidth,
                    Height = RoomDAO.TableHeight
                };
                btn.Text = item.NameRoom + Environment.NewLine + item.Status;
                btn.Click += btn_click;
                btn.Tag = item;

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.Yellow;
                        break;
                }
                flpRoom.Controls.Add(btn);//add controls vào Table;
            }
        }

        void ShowBill(int id)
        {
            // List<BillInfo> listBillInfo = BillInfoDAO.Instance.GetListBillInfo(BillDAO.Instance.GetUncheckBillIDByRoomID(id));
            List<MenuList> listBillInfo = MenuListDAO.Instance.GetListMenuByRoom(id);
            lsvBill.Items.Clear();

            float totalPrice = 0;
            foreach (MenuList item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.NameService.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());


                totalPrice += item.TotalPrice;

                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");

            //Thread.CurrentThread.CurrentCulture = culture;

            txbTotalPrice.Text = totalPrice.ToString("c", culture);
            
        }
        private void btn_click(object sender, EventArgs e)
        {
            int RoomID = ((sender as Button).Tag as Room).ID;
            lsvBill.Tag = (sender as Button).Tag; //Lưu phòng khi chọn vào lsvBill
            ShowBill(RoomID);

            /*fCustomerInfomation open = new fCustomerInfomation();
            this.Hide();
            open.ShowDialog();
            this.Show();*/
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            fCustomerInfomation open = new fCustomerInfomation();
            this.Hide();
            open.ShowDialog();
            this.Show();

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Room room = lsvBill.Tag as Room;
            if (room == null)
            {
                MessageBox.Show("Hãy chọn Phòng");
                return;
            }
            int idBill = BillDAO.Instance.GetUncheckBillIDByRoomID(room.ID); //idbill = idroom khi chọn phòng
         //   int discount = (int)nmDisCount.Value;

            //  double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]);
            //  double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;

            if (idBill != -1)
            {
             //  if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0}\nTổng tiền - (Tổng tiền / 100) x Giảm giá\n=> {1} - ({1} / 100) x {2} = {3}", table.Name, totalPrice, discount, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
             if (MessageBox.Show("Bạn có chắc muốn thanh toán cho "+ room.NameRoom, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    //  BillDAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);
                    BillDAO.Instance.CheckOut(idBill);
                    ShowBill(room.ID);
                    LoadRoom();
                }
            }
        }

        private void btnadDV_Click(object sender, EventArgs e)
        {
            Room room = lsvBill.Tag as Room;

            int idBill = BillDAO.Instance.GetUncheckBillIDByRoomID(room.ID); //Lấy ra bàn hiện tại khi chọn
            int idService = (cbAddService.SelectedItem as Service).ID; //Lấy ra ID service
            int intCount = (int)numericUpDownCount.Value;

            if (room == null)
            {
                MessageBox.Show("Hãy chọn Phòng");
                return;
            }
            /*
            Room room = lsvBill.Tag as Room; //Lấy ra bàn hiện tại khi chọn
            int idBill = BillDAO.Instance.GetUncheckBillIDByRoomID(room.ID);
            int idService = int.Parse(cbidService.Text);
            int intCount = (int)numericUpDownCount.Value;
            BillInfoDAO.Instance.InsertBillInfo( idBill, idService, intCount);*/
            if (idBill == -1)
            {
                MessageBox.Show("Phòng này chưa có khách!");
            }
            else
            {
                if(BillInfoDAO.Instance.InsertBillInfo(idBill, idService, intCount))
                {
                    MessageBox.Show("Thêm dịch vụ vào thành công!");
                    ShowBill(room.ID);
                }
                else
                {
                    MessageBox.Show("Thêm dịch vụ thất bại!");
                }
            }
            
        }
        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            fDatPhong open = new fDatPhong();
            this.Hide();
            open.ShowDialog();
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadRoom();
        }
    }
}
