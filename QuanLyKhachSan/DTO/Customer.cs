using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class Customer
    {
        public Customer(int id, string nameCustomer, DateTime datetimeCustomer, string genderCustomer, string addressCustomer, string idCardCustomer, string phoneNumber)
        {
            this.ID = id;
            this.NameCustomer = nameCustomer;
            this.DateTimeCustomer = datetimeCustomer;
            this.GenderCustomer = genderCustomer;
            this.AddressCustomer = addressCustomer;
            this.IDCardCustomer = idCardCustomer;
            this.PhoneNumber = phoneNumber;

        }
        public Customer(DataRow row) //lấy từ các trường dữ liệu trong sql
        {
            this.ID = (int)row["id"];
            this.NameCustomer = row["Tên KH"].ToString();
            this.DateTimeCustomer = (DateTime)row["Ngày sinh"];
            this.GenderCustomer = row["Giới tính"].ToString();
            this.AddressCustomer = row["Địa chỉ"].ToString();
            this.IDCardCustomer = row["Số CM"].ToString();
            this.PhoneNumber = row["Điện thoại"].ToString();
            
        }

        private int iD;
        private string nameCustomer;
        private DateTime dateTimeCustomer;
        private string genderCustomer;
        private string addressCustomer;
        private string iDCardCustomer;
        private string phoneNumber;

        public string NameCustomer { get => nameCustomer; set => nameCustomer = value; }
        public DateTime DateTimeCustomer { get => dateTimeCustomer; set => dateTimeCustomer = value; }
        public string GenderCustomer { get => genderCustomer; set => genderCustomer = value; }
        public string AddressCustomer { get => addressCustomer; set => addressCustomer = value; }
        public string IDCardCustomer { get => iDCardCustomer; set => iDCardCustomer = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int ID { get => iD; set => iD = value; }
    }
}

