using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManager.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set { instance = value; }
        }

        private BillDAO() { }

        public object bill(string date)
        {
            string query = "select IDBill, NameStaff, DateBill, TimeBill, TotalPrice from Bill, Staff where DateBill = '" + date + "' and Staff.IDStaff = Bill.IDStaff";
            DataTable result =  DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
    }
}
