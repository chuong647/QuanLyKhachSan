using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAO
{
    public class MenuListDAO
    {
        private static MenuListDAO instance;

        public static MenuListDAO Instance
        {
            get { if (instance == null) instance = new MenuListDAO(); return MenuListDAO.instance; }
            private set { MenuListDAO.instance = value; }
        }

        private MenuListDAO() { }

        public List<MenuList> GetListMenuByRoom(int idRoom)
        {
            List<MenuList> listMenu = new List<MenuList>();

            string query = "SELECT s.NameService, bi.intCount, s.Price, s.Price*bi.intCount AS totalPrice FROM dbo.BillInfo AS bi, dbo.Bill AS b, dbo.Service AS s WHERE bi.idBill = b.id AND bi.idService = s.id AND b.Status = 0 AND b.idRoom = " + idRoom;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MenuList menu = new MenuList(item);

                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
