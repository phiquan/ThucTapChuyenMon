using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance 
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }


        private DataProvider() { }

        private string connStr = "Data Source=DESKTOP-Q4GRQFB\\SQLEXPRESS;Initial Catalog=TTCM;Integrated Security=True";

        public DataTable ExecuteQuery(string query)
        {
            SqlConnection connection = new SqlConnection(connStr);

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            DataTable data = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(data);

            connection.Close();

            return data;
        }

        public void ExecuteNonQuery(string query)
        {
            SqlConnection connection = new SqlConnection(connStr);

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
