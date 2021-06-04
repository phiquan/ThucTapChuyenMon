using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.DAO
{
    public class ReviewBillDAO
    {

        private static ReviewBillDAO instance;

        public static ReviewBillDAO Instance
        {
            get { if (instance == null) instance = new ReviewBillDAO(); return instance; }
            private set { instance = value; }
        }

        private ReviewBillDAO() { }

        public object Review(int id,string date,string time)
        {
            string query = "select * from Bill where IDStaff=" + id + " and DateBill='" + date + "' and TimeBill>='" + time + "'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
