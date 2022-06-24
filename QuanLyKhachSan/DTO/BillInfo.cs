using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int billID, int serviceID, int count, DateTime dateService)
        {
            this.ID = id;
            this.BillID = billID;
            this.ServiceID = serviceID; ;
            this.Count = count;
            this.DateService = dateService;
            
        }

        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.BillID = (int)row["idbill"];
            this.ServiceID = (int)row["idService"];
            this.Count = (int)row["intCount"];
            this.DateService = (DateTime)row["DateService"];
        }

        private DateTime dateService;
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private int foodID;

        public int ServiceID
        {
            get { return foodID; }
            set { foodID = value; }
        }

        private int billID;

        public int BillID
        {
            get { return billID; }
            set { billID = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public DateTime DateService { get => dateService; set => dateService = value; }
    }

}
