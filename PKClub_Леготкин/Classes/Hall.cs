using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnection;

namespace PKClub_Леготкин.Classes
{
    public class Hall
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TimeWork {  get; set; }
        public Hall() { }
        public Hall(int id, string Name, string Address, string TimeWork)
        {
            this.id = id;
            this.Name = Name;
            this.Address = Address;
            this.TimeWork = TimeWork;
        }
        public List<Hall> AllHall()
        {
            List<Hall> allHall = new List<Hall>();

            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader hallQuery = Connection.Query("SELECT * from pkclub.hall;", connection);
            while (hallQuery.Read())
            {
                allHall.Add(new Hall(
                     hallQuery.GetInt32(0),
                     hallQuery.GetString(1),
                     hallQuery.GetString(2),
                     hallQuery.GetString(3)));
            }
            Connection.CloseConnection(connection);
            return allHall;
        }
        public void Save(bool Update = false)
        {
            if (Update)
            {
                MySqlConnection connection = Connection.OpenConnection();
                MySqlDataReader dataReader = Connection.Query("UPDATE pkclub.hall " + "SET " +
                    $"Name = '{this.Name}', " +
                    $"Address = '{this.Address}', " +
                    $"TimeWork = '{this.TimeWork}' " +
                    $"WHERE id = '{this.id}';", connection);

                Connection.CloseConnection(connection);
            }
            else
            {
                MySqlConnection connection = Connection.OpenConnection();
                MySqlDataReader dataReader = Connection.Query("INSERT INTO pkclub.hall" +
                "(Name," +
                "Address, " +
                "TimeWork) " +
                "VALUES (" +
                $"'{this.Name}', " +
                $"'{this.Address}', " +
                $"'{this.TimeWork}');", connection);

                Connection.CloseConnection(connection);
            }
        }
        public void Delete()
        {
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query($"DELETE FROM pkclub.hall WHERE id = '{this.id}';", connection);
            Connection.CloseConnection(connection);
        }
    }
}
