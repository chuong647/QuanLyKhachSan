using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class Room
    {
        public Room(int id, string nameRoom, string status, int idRoomType)
        {
            this.ID = id;
            this.NameRoom = nameRoom;
            this.Status = status;
            this.IdRoomType = idRoomType;
        }
        public Room (DataRow row)
        {
            this.ID = (int)row["id"];
            this.NameRoom = row["NameRoom"].ToString();
            this.Status = row["Status"].ToString();
            this.IdRoomType = (int)row["idRoomType"];
        }

        private int idRoomType;
        private string status;
        private string nameRoom;
        private int iD;

        public int ID { get => iD; set => iD = value; }
        public string NameRoom { get => nameRoom; set => nameRoom = value; }
        public string Status { get => status; set => status = value; }
        public int IdRoomType { get => idRoomType; set => idRoomType = value; }
    }
}
