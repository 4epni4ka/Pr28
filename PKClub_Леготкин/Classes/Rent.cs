using DBConnection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKClub_Леготкин.Classes
{
    public class Rent
    {
        public int id {  get; set; }
        public int idHall { get; set; }
        public int numComp { get; set; }
        public DateTime Date { get;set; }
        public string FIO { get; set; }
        public Rent() { }
        public Rent(int id, int idHall, int numComp, DateTime Date, string FIO)
        {
            this.id = id;
            this.idHall = idHall;
            this.numComp = numComp;
            this.Date = Date;
            this.FIO = FIO;
        }
        public List<Rent> AllRent()
        {
            List<Rent> allRent = new List<Rent>();

            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader rentQuery = Connection.Query("SELECT * from pkclub.rent;", connection);
            while (rentQuery.Read())
            {
                allRent.Add(new Rent(
                     rentQuery.GetInt32(0),
                     rentQuery.GetInt32(1),
                     rentQuery.GetInt32(2),
                     rentQuery.GetDateTime(3),
                     rentQuery.GetString(4)));
            }
            Connection.CloseConnection(connection);
            return allRent;
        }
        public void Save(bool Update = false)
        {
            if (Update)
            {
                MySqlConnection connection = Connection.OpenConnection();
                MySqlDataReader dataReader = Connection.Query("UPDATE pkclub.rent " + "SET " +
                    $"idHall = '{this.idHall}', " +
                    $"numComp = '{this.numComp}', " +
                    $"date = '{this.Date}', " +
                    $"FIO = '{this.FIO}' " +
                    $"WHERE id = '{this.id}';", connection);

                Connection.CloseConnection(connection);
            }
            else
            {
                MySqlConnection connection = Connection.OpenConnection();
                MySqlDataReader dataReader = Connection.Query("INSERT INTO pkclub.rent" +
                "(idHall," +
                "numComp, " +
                "date, " +
                "FIO) " +
                "VALUES (" +
                $"'{this.idHall}', " +
                $"'{this.numComp}', " +
                $"'{this.Date}', " +
                $"'{this.FIO}');", connection);

                Connection.CloseConnection(connection);
            }
        }
        public void Delete()
        {
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query($"DELETE FROM pkclub.rent WHERE id = '{this.id}';", connection);
            Connection.CloseConnection(connection);
        }
    }
}