using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ExamenParte2.Handlers {
    public class DatabaseHandler {
        protected SqlConnection connection;
        protected string connectionRoute;
        protected const string CONNECTION_NAME = "ExamenConnection";

        public DatabaseHandler() {
            connectionRoute = ConfigurationManager.ConnectionStrings[CONNECTION_NAME].ToString();
            connection = new SqlConnection(connectionRoute);
        }

        public DataTable CreateTableFromQuery(string query) {
            SqlCommand queryCommand = new SqlCommand(query, connection);
            SqlDataAdapter tableAdapter = new SqlDataAdapter(queryCommand);
            DataTable queryTable = new DataTable();
            connection.Open();
            tableAdapter.Fill(queryTable);
            connection.Close();
            return queryTable;
        }
    }
}