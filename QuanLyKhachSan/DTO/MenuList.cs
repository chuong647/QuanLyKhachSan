using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class MenuList
    {
        public MenuList(string nameService, int count,  float totalPrice = 0)
        {
          
            this.NameService = nameService;
            this.Count = count;
            this.TotalPrice = totalPrice;
        }

        public MenuList(DataRow row)
        {
           
            this.NameService = row["NameService"].ToString();
            this.Count = (int)row["intCount"];
            this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }

        private float totalPrice;
        private int count;
        private string nameService;
        

        
        public string NameService { get => nameService; set => nameService = value; }
        public int Count { get => count; set => count = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
