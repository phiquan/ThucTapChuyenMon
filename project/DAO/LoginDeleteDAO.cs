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

        public void upKho(int idbill)
        {
            string query1 = "select InforFood.ID, SUM(InforFood.Number) from Bill, InforBill, Food, InforFood, Kho where Bill.IDBill = " + idbill + " and InforBill.IDFood = Food.IDFood and InforBill.IDBill = Bill.IDBill and Food.IDFood = InforFood.IDFood and InforFood.ID = Kho.ID Group By InforFood.ID";
            DataTable result = DataProvider.Instance.ExecuteQuery(query1);

            int len = result.Rows.Count;

            for (int i = 0; i < len; i++)
            {
                string query2 = "update Kho set Number=Number+" + int.Parse(result.Rows[i].ItemArray[1].ToString()) + " where ID=" + int.Parse(result.Rows[i].ItemArray[0].ToString()) + "";
                DataProvider.Instance.ExecuteNonQuery(query2);
            }
        }
    }
}
