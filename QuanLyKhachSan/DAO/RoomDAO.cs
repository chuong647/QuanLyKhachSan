using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAO
{
    public class RoomDAO
    {
        private static RoomDAO instance;

        public static RoomDAO Instance 
        {
            get { if (instance == null) instance = new RoomDAO(); return RoomDAO.instance; }
            private set { RoomDAO.instance = value; }
        }
        private RoomDAO() { }

        public static int TableWidth = 80;
        public static int TableHeight = 80;

        public List<Room> LoadRoomList()
        {
            List<Room> RoomList = new List<Room>(); //Chuyển từng Rows thành List<Room> //Xây hàm dụng để dataRow đưa vào

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Room ");

            foreach (DataRow item in data.Rows) //Đưa item vào DataRow
            {
                Room table = new Room(item);
                RoomList.Add(table);
            }

            return RoomList;
        }
        public List<Room> GetRoomByRoomTypeID(int id)
        {
            List<Room> list = new List<Room>();

            string query = "select * from Room where idRoomType = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                list.Add(room);
            }

            return list;
        }
    }
}
