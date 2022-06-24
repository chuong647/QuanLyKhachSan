using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }

        private BillInfoDAO() { }

        public List<BillInfo> GetListBillInfo(int id) //id của Bill
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM BillInfo WHERE idBill= " + id);

            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item); //từ cái item khi nhấn button đưa vô
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }
        public bool InsertBillInfo(int idBill, int idService, int intCount)
        {
           // string query = string.Format("INSERT INTO BillInfo([idBill], [idService], [intCount], [DateService]) Values ( {0} , {1} , {2} , GETDATE() )", idBill, idService, intCount );

            string query = string.Format("USP_InsertBillInfo @idBill = {0} , @idService = {1} , @intCount = {2} ", idBill, idService, intCount);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
