using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManager.DAO
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

        public bool LoginManager(string userName, string passWord)
        {
            string query = "SELECT * FROM Manager WHERE Email='" + userName + "' AND Pass='" + passWord + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        public void ChangePass(string pass)
        {
            string query = "update Manager set Pass='" + pass + "' where IDMa=1";
            DataProvider.Instance.ExucuteNonQuery(query);
        }

        public bool checkPass(string pass)
        {
            string query = "select * from Manager where Pass='" + pass + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }
    }
}
