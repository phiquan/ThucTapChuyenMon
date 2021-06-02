using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManager.DAO
{
    public class WarehouseDAO
    {
        private static WarehouseDAO instance;

        public static WarehouseDAO Instance
        {
            get { if (instance == null) instance = new WarehouseDAO(); return instance; }
            private set { instance = value; }
        }

        private WarehouseDAO() { }

        public object warehouse()
        {
            string query = "select * from Kho";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void add(int id,string name,int number)
        {
            string query = "insert into Kho values(" + id + ",N'" + name + "'," + number + ")";
            DataProvider.Instance.ExucuteNonQuery(query);
        }

        public bool checkId(int id)
        {
            string query = "select * from Kho where ID=" + id + "";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count == 0;  
        }

        public void Delete(int id)
        {
            string query = "Delete from Kho where ID=" + id + "";
            DataProvider.Instance.ExucuteNonQuery(query);
        }
        public bool checkFood(int id)
        {
            string query = "select * from InforFood, Kho where InforFood.ID = Kho.ID and Kho.ID = " + id + "";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count == 0;
        }

        public void Update(int id,string name,int number)
        {
            string query = "Update Kho Set Name=N'" + name + "', Number=" + number + " where ID=" + id + "";
            DataProvider.Instance.ExucuteNonQuery(query);
        }


    }
}
