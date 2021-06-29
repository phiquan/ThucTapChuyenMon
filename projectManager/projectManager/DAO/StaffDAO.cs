using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManager.DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance;

        public static StaffDAO Instance
        {
            get { if (instance == null) instance = new StaffDAO(); return instance; }
            private set { instance = value; }
        }

        private StaffDAO() { }

        public object staff()
        {
            string query = "SELECT IDStaff,NameStaff,Email,Pass,Gender FROM Staff where Status='1'";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public void Delete(int id)
        {

            string query = "Update Staff Set Status='0' Where IDStaff=" + id + "";
            DataProvider.Instance.ExucuteNonQuery(query);
        }

        public void Update(int id, string name, string email, string pass, string gender)
        {
            string query = "Update Staff Set NameStaff=N'" + name + "' , Email='" + email + "' , Pass='" + pass + "' , Gender='" + gender + "' Where IDStaff=" + id + "";
            DataProvider.Instance.ExucuteNonQuery(query);
        }

        public void Add(string name, string email, string pass, string gender)
        {           
            string query = "Insert into Staff values(N'" + name + "','" + email + "','" + pass + "','" + gender + "','1')";
            DataProvider.Instance.ExucuteNonQuery(query);
        }

        public bool checkAdd(string email)
        {
            string query = "SELECT * FROM Staff where Email='" + email + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return (result.Rows.Count) == 0;
        }
    }
}
