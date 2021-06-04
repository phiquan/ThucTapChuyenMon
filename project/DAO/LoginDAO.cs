using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.DAO
{
    public class LoginDAO
    {
        private static LoginDAO instance;

        public static LoginDAO Instance
        {
            get { if (instance == null) instance = new LoginDAO(); return instance; }
            private set { instance = value; }
        }

        private LoginDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query = "SELECT * FROM Staff WHERE Email='" + userName + "' AND Pass='" + passWord + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        public string getName(string user)
        {
            string query = "select * from Staff where Email=N'" + user + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            string fullname = result.Rows[0].ItemArray[1].ToString();
            return fullname;
        } 

        public string getId(string user)
        {
            string query = "select * from Staff where Email=N'" + user + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            string id = result.Rows[0].ItemArray[0].ToString();
            return id;
        }

        
    }
}
