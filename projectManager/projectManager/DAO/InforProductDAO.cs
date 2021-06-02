using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManager.DAO
{
    public class InforProductDAO
    {
        private static InforProductDAO instance;

        public static InforProductDAO Instance
        {
            get { if (instance == null) instance = new InforProductDAO(); return instance; }
            private set { instance = value; }
        }

        private InforProductDAO() { }

        public object InforProduct()
        {
            string query = "select NameFood as 'Tên Sản Phẩm',Name as 'Tên Sản Phẩm Cấu Thành',InforFood.Number as 'Số Lượng' from  Food, InforFood,  Kho where Food.IDFood = InforFood.IDFood and InforFood.ID = Kho.ID";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void Add(int idFood, int idKho, int number)
        {
            string query = "insert into InforFood values(" + idFood + "," + idKho + "," + number + ")";
            DataProvider.Instance.ExucuteNonQuery(query);
        }

        public object comboboxNameInfor()
        {
            string query = "select * from Kho";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public object comboboxName()
        {
            string query = "select * from Food";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        

    }
}
