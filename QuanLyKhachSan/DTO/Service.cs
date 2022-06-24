using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class Service
    {
        public Service(int id, string nameService, int priceService)
        {
            this.ID = id;
            this.NameService = nameService;
            this.PriceService = priceService;
        }
        public Service(DataRow row) //lấy từ các trường dữ liệu trong sql
        {
            this.ID = (int) row["id"];
            this.NameService = row["NameService"].ToString();
            this.PriceService = (int)row["Price"];
        }

        private int priceService;
        private string nameService;
        private int iD;

        public string NameService { get => nameService; set => nameService = value; }
        public int PriceService { get => priceService; set => priceService = value; }
        public int ID { get => iD; set => iD = value; }
    }
}
