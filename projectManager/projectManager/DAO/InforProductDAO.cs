using System;
using System.Collections.Generic;
using System.Data;
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

        public object InforProduct(int id)
        {
            string query = "select Kho.ID, NameFood as 'Tên Sản Phẩm',Name as 'Tên Sản Phẩm Cấu Thành',InforFood.Number as 'Số Lượng' from  Food, InforFood,  Kho where Food.IDFood = InforFood.IDFood and InforFood.ID = Kho.ID and Food.IDFood=" + id + "";
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

        public bool checkName(int id,int idKho)
        {
            string query = "select * from InforFood where IDFood=" + id + " and ID=" + idKho + "";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count == 0;
        }

        public void Update(int id,int KhoOld,int idKho, int number)
        {
            string query = "update InforFood Set ID=" + idKho + ", Number=" + number + " Where ID=" + KhoOld + " and IDFood=" + id + "";
            DataProvider.Instance.ExucuteNonQuery(query);
        }

        public void Delete(int id,int Kho)
        {
            string query = "delete from InforFood where IDFood=" + id + " and ID=" + Kho + "";
            DataProvider.Instance.ExucuteNonQuery(query);
        }


    }
}
