using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class Bill
    {
        public Bill(int id, int idCustomer ,DateTime dateCheckin, DateTime? dateCheckOut, int idRoom , int status)
        {
            this.ID = id;
            this.IDCustomer = idCustomer;
            this.DateCheckIn = dateCheckin;
            this.DateCheckOut = dateCheckOut;
            this.IDRoom = idRoom;
            this.Status = status;
        }

        public Bill(DataRow row)
        {
           
            this.ID = (int)row["idCustomer"];
            this.ID = (int)row["id"];
            this.DateCheckIn = (DateTime)row["dateCheckin"];

            var dateCheckOutTemp = row["dateCheckOut"];
            if (dateCheckOutTemp.ToString() != "")
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;
            this.Status = (int)row["idRoom"];
            this.Status = (int)row["status"];

            
        }

        private int iD;
        private int iDCustomer;
        private DateTime dateCheckIn;
        private DateTime? dateCheckOut;
        private int iDRoom;
        private int status;

        public int ID { get => iD; set => iD = value; }
        public int IDCustomer { get => iDCustomer; set => iDCustomer = value; }
        public DateTime DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
      
        public int IDRoom { get => iDRoom; set => iDRoom = value; }
        public int Status { get => status; set => status = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
    }
}
