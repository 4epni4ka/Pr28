using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DBConnection
{
    public class Connection
    {
        public static MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection("server=LocalHost;database=pkclub;uid=root;pwd=root;");
            connection.Open();

            return connection;
        }
        public static MySqlDataReader Query(string Sql, MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand(Sql, connection);
            return command.ExecuteReader();
        }
        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
            MySqlConnection.ClearPool(connection);
        }
    }
}
