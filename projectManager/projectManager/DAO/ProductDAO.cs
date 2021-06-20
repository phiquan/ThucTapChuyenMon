using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManager.DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance;

        public static ProductDAO Instance
        {
            get { if (instance == null) instance = new ProductDAO(); return instance; }
            private set { instance = value; }
        }

        private ProductDAO() { }

        public object product()
        {
            string query = "SELECT * FROM Food";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void Update(int id,string name,int price)
        {
            string query = "Update Food Set NameFood=N'" + name + "', Price=" + price + " Where IDFood=" + id + "";
            DataProvider.Instance.ExucuteNonQuery(query);
        }

        public void Add(int id,string name,int price)
        {
            string query = "insert into Food values(" + id + ",N'" + name + "'," + price + ",'stocking')";
            DataProvider.Instance.ExucuteNonQuery(query);
        }

        public void Delete(int id)
        {
            /*string query1 = "delete from InforFood where IDFood=" + id + "";
            DataProvider.Instance.ExucuteNonQuery(query1);
            string query2 = "delete from Food where IDFood=" + id + "";
            DataProvider.Instance.ExucuteNonQuery(query2);*/

            string query = "update Food set Status='Sold out' where IDFood=" + id + "";
            DataProvider.Instance.ExucuteNonQuery(query);
        }

        
    }
}
