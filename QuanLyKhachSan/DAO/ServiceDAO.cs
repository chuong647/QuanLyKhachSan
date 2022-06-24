using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAO
{
    public class ServiceDAO
    {
        private static ServiceDAO instance;

        public static ServiceDAO Instance 
        {
            get { if (instance == null) instance = new ServiceDAO(); return ServiceDAO.instance; }
            private set => instance = value;
        }
        private ServiceDAO() { }

        public List<Service> LoadServiceList()
        {
            List<Service> ServiceList = new List<Service>(); //Chuyển từng Rows thành List<Room> //Xây hàm dụng để dataRow đưa vào

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetService");

            foreach (DataRow item in data.Rows) //Đưa item = từng cột trong csdl vào DataRow
            {
                Service table = new Service(item);
                ServiceList.Add(table);
            }

            return ServiceList;
        }

        public bool InsertService(string nameService, float priceService)
        {

            string query = string.Format("INSERT Service ( NameService, Price) VALUES ( N'{0}', {1})", nameService, priceService);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}

