using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return CustomerDAO.instance; }
            private set => instance = value;
        }
        private CustomerDAO() { }

        public List<Customer> LoadCustomer()
        {
            List<Customer> CustomerList = new List<Customer>(); //Chuyển từng Rows thành List<Room> //Xây hàm dụng để dataRow đưa vào

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_LoadCustomer");

            foreach (DataRow item in data.Rows) //Đưa item vào DataRow
            {
                Customer table = new Customer(item);
                CustomerList.Add(table);
            }

            return CustomerList;
        }

        public bool InsertCustomer(string nameCustomer, string datetimeCustomer, string genderCustomer, string addressCustomer, string idCardCustomer, string phoneNumber)
        {
          //  INSERT INTO Customer([NameCustomer], [DateTimeCustomer], [GenderCustomer], [AddressCustomer], [idCardCustomer], [PhoneNumber]) VALUES( N'Nguyễn Văn B', '02/01/1996', N'Nam', N'Bạc Liêu', '385758646', '0964429603')

            string query = string.Format("INSERT INTO Customer([NameCustomer], [DateTimeCustomer], [GenderCustomer], [AddressCustomer], [idCardCustomer], [PhoneNumber]) VALUES (N'{0}', N'{1}', N'{2}', N'{3}',N'{4}', N'{5}')", nameCustomer, datetimeCustomer, genderCustomer, addressCustomer, idCardCustomer, phoneNumber);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateCustomer(int id, string nameCustomer, string datetimeCustomer, string genderCustomer, string addressCustomer, string idCardCustomer, string phoneNumber)
        {
            string query = string.Format("UPDATE Customer SET NameCustomer = N'{0}', DateTimeCustomer = N'{1}', GenderCustomer = N'{2}', AddressCustomer = N'{3}', idCardCustomer = N'{4}', PhoneNumber = N'{5}' WHERE id = {6}", nameCustomer, datetimeCustomer, genderCustomer, addressCustomer, idCardCustomer, phoneNumber, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
