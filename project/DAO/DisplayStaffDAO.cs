using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.DAO
{
    public class DisplayStaffDAO
    {
        private static DisplayStaffDAO instance;

        public static DisplayStaffDAO Instance
        {
            get { if (instance == null) instance = new DisplayStaffDAO(); return instance; }
            private set { instance = value; }
        }

        private DisplayStaffDAO() { }

        public void createBill(int id,string date,string time)
        {
            string query = "insert into Bill(IDStaff,DateBill,TimeBill) values(" + id + ",'" + date + "','" + time + "')";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public string getIdBill(string date, string time)
        {
            string query = "select * from Bill Where DateBill = '" + date + "' and TimeBill = '" + time + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            string id = result.Rows[0].ItemArray[0].ToString();
            return id;
        }
    }
}
