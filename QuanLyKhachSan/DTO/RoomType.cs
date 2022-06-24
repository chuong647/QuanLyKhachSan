using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class RoomType
    {
        public RoomType(int id, string nameType, float price)
        {
            this.ID = id;
            this.NameType = nameType;
            this.Price = price;
        }

        public RoomType(DataRow row)
        {
            this.ID = (int)row["id"];
            this.NameType = row["NameType"].ToString();
            this.Price = (int)row["Price"];
        }

        private float price;
        private string nameType;
        private int iD;

        public int ID { get => iD; set => iD = value; }
        public string NameType { get => nameType; set => nameType = value; }
        public float Price { get => price; set => price = value; }
    }
}
