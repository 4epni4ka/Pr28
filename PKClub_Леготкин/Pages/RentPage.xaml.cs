using DBConnection;
using MySql.Data.MySqlClient;
using PKClub_Леготкин.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PKClub_Леготкин.Pages
{
    /// <summary>
    /// Логика взаимодействия для RentPage.xaml
    /// </summary>
    public partial class RentPage : Page
    {
        public RentPage()
        {
            InitializeComponent();
            CreateUI();
        }
        public void CreateUI()
        {
            parent.Children.Clear();
            foreach (Rent rent in MainWindow.AllRent)
                parent.Children.Add(new Elements.RentItem(rent));
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.init.Close();
        }

        private void Click_Hall(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.hall);
        }

        private void AddRent(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.addRent);
        }

        public bool sortName = false;
        private void Sort_Name(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * from pkclub.rent ORDER BY FIO;";
            if (sortName)
            {
                query = "SELECT * from pkclub.rent ORDER BY FIO DESC;";
                sortName = false;
            }
            else sortName = true;
            Sort_Query(query);
        }

        public bool sortClub = false;
        private void Sort_Club(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * from pkclub.rent ORDER BY idHall;";
            if (sortClub)
            {
                query = "SELECT * from pkclub.rent ORDER BY idHall DESC;";
                sortClub = false;
            }
            else sortClub = true;
            Sort_Query(query);
        }

        private void Sort_Clear(object sender, RoutedEventArgs e)
        {
            MainWindow.AllRent = new Rent().AllRent();
            CreateUI();
        }
        public void Sort_Query(string query)
        {
            List<Rent> allRent = new List<Rent>();

            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader rentQuery = Connection.Query(query, connection);
            while (rentQuery.Read())
            {
                allRent.Add(new Rent(
                     rentQuery.GetInt32(0),
                     rentQuery.GetInt32(1),
                     rentQuery.GetInt32(2),
                     rentQuery.GetDateTime(3),
                     rentQuery.GetString(4)));
            }
            MainWindow.AllRent = allRent;
            Connection.CloseConnection(connection);
            CreateUI();
        }
    }
}
