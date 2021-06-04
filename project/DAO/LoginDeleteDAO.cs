using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.DAO
{
    public class LoginDeleteDAO
    {
        private static LoginDeleteDAO instance;

        public static LoginDeleteDAO Instance
        {
            get { if (instance == null) instance = new LoginDeleteDAO(); return instance; }
            private set { instance = value; }
        }

        private LoginDeleteDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query = "SELECT * FROM Manager WHERE Email='" + userName + "' AND Pass='" + passWord + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        public void DeleteBill(int id)
        {
            string query1 = "delete from InforBill where IDBill=" + id + "";
            DataProvider.Instance.ExecuteNonQuery(query1);
            string query2 = "delete from Bill where IDBill=" + id + "";
            DataProvider.Instance.ExecuteNonQuery(query2);
        }
    }
}
