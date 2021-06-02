using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.DAO
{
    public class DisplaySatffDAO
    {
        private static DisplaySatffDAO instance;

        public static DisplaySatffDAO Instance
        {
            get { if (instance == null) instance = new DisplaySatffDAO(); return instance; }
            private set { instance = value; }
        }

        private DisplaySatffDAO() { }

        public object menu()
        {
            string query = "select * from Food";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        
    }
}
