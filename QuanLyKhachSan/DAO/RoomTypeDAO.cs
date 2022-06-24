using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAO
{
    public class RoomTypeDAO
    {
        private static RoomTypeDAO instance;

        public static RoomTypeDAO Instance
        {
            get { if (instance == null) instance = new RoomTypeDAO(); return RoomTypeDAO.instance; }
            private set { RoomTypeDAO.instance = value; }
        }

        private RoomTypeDAO() { }

        public List<RoomType> GetListRoomType()
        {
            List<RoomType> list = new List<RoomType>();

            string query = "select * from RoomType";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                RoomType roomtype = new RoomType(item);
                list.Add(roomtype);
            }

            return list;
        }

        public RoomType GetRoomTypeByID(int id)
        {
            RoomType roomtype = null;

            string query = "select * from Room where id = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                roomtype = new RoomType(item);
                return roomtype;
            }

            return roomtype;
        }
    }
}
