using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.DAO
{
    public class DisplayMenuDAO
    {
        private static DisplayMenuDAO instance;

        public static DisplayMenuDAO Instance
        {
            get { if (instance == null) instance = new DisplayMenuDAO(); return instance; }
            private set { instance = value; }
        }

        private DisplayMenuDAO() { }

        public object menu()
        {
            string query = "select IDFood, NameFood, Price from Food where Status='stocking'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public object bill(int idbill)
        {
            string query = "select Food.IDFood, Food.NameFood, SUM(Food.Price) as 'Thành Tiền', SUM(Number) as N'Số Lượng' from InforBill, Food where IDBill = InForBill.IDBill and InforBill.IDFood = Food.IDFood and IDBill = " + idbill + " Group By Food.NameFood , Food.Price, Food.IDFood";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void addFood(int idbill,int idfood)
        {
            string query = "insert into InforBill values(" + idfood + "," + idbill + ",1)";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        
        public void deleteFood(int idbill,int idfood)
        {
            string query = "delete from InforBill where IDBill=" + idbill + " and IDFood=" + idfood + "";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public string totalprice(int idbill)
        {
            string query = "select SUM(Food.Price) as 'Thành Tiền' from InforBill, Food where InforBill.IDFood = Food.IDFood and IDBill = " + idbill + " Group By IDBill";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            string total = result.Rows[0].ItemArray[0].ToString();
            return total;
        }

        public void back(int idbill)
        {
            string query1 = "delete from InforBill where IDBill=" + idbill + "";
            string query2 = "delete from Bill where IDBill=" + idbill + "";
            DataProvider.Instance.ExecuteNonQuery(query1);
            DataProvider.Instance.ExecuteNonQuery(query2);
        }

        public void upPrice(int idbill,int totalprice)
        {
            string query = "update Bill set TotalPrice=" + totalprice + " where IDBill=" + idbill + "";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void upKho(int idbill)
        {
            string query1 = "select InforFood.ID, SUM(InforFood.Number) from Bill, InforBill, Food, InforFood, Kho where Bill.IDBill = " + idbill + " and InforBill.IDFood = Food.IDFood and InforBill.IDBill = Bill.IDBill and Food.IDFood = InforFood.IDFood and InforFood.ID = Kho.ID Group By InforFood.ID";
            DataTable result = DataProvider.Instance.ExecuteQuery(query1);

            int len = result.Rows.Count;

            for(int i = 0; i < len; i++)
            {
                string query2 = "update Kho set Number=Number-" + int.Parse(result.Rows[i].ItemArray[1].ToString()) + " where ID=" + int.Parse(result.Rows[i].ItemArray[0].ToString()) + "";
                DataProvider.Instance.ExecuteNonQuery(query2);
            }
        }
    }
}
