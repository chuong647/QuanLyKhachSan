using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAO
{
    public class BillDAO //Lấy ra billInfo
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }

        public void CheckOut(int idBill)
        {
            string query = " UPDATE Bill Set DateCheckOut = GETDATE(), Status = 1 where id = " + idBill;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public int GetUncheckBillIDByRoomID(int idRoom) //lấy ra idBill từ idRoom
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idRoom = " + idRoom + " AND Status = 0");

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]); // lấy row 0 là row đầu tiên là row id
                return bill.ID;
            }

            return -1;
        }
        public bool InsertBill(int idCustomer, int idRoom)
        {
            string query = string.Format("USP_InsertBill @idCustomer = {0} , @idRoom = {1} ", idCustomer, idRoom);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;

        }
    }
}
