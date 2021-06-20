using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManager.DAO
{
    public class StatisticalDAO
    {
        private static StatisticalDAO instance;

        public static StatisticalDAO Instance
        {
            get { if (instance == null) instance = new StatisticalDAO(); return instance; }
            private set { instance = value; }
        }

        private StatisticalDAO() { }

        public object see()
        {
            string query = "select DateBill, SUM(TotalPrice) as 'TotalPrice' from Bill where DateBill>='2021-06-01' Group By DateBill";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
    }
}
