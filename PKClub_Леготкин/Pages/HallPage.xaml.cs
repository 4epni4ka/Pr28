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
    /// Логика взаимодействия для HallPage.xaml
    /// </summary>
    public partial class HallPage : Page
    {
        public HallPage()
        {
            InitializeComponent();
            CreateUI();
        }
        public void CreateUI()
        {
            parent.Children.Clear();
            foreach (Hall hall in MainWindow.AllHall)
                parent.Children.Add(new Elements.HallItem(hall));
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.init.Close();
        }

        private void AddHall(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.addHall);
        }

        private void Click_Rent(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.rent);
        }

        public bool sortName = false;
        private void Sort_Name(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * from pkclub.hall ORDER BY Name;";
            if (sortName)
            {
                query = "SELECT * from pkclub.hall ORDER BY Name DESC;";
                sortName = false;
            }
            else sortName = true;
            Sort_Query(query);
        }
        private void Sort_Clear(object sender, RoutedEventArgs e)
        {
            MainWindow.AllHall = new Hall().AllHall();
            CreateUI();
        }
        public void Sort_Query(string query)
        {
            List<Hall> allHall = new List<Hall>();

            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader hallQuery = Connection.Query(query, connection);
            while (hallQuery.Read())
            {
                allHall.Add(new Hall(
                     hallQuery.GetInt32(0),
                     hallQuery.GetString(1),
                     hallQuery.GetString(2),
                     hallQuery.GetString(3)));
            }
            MainWindow.AllHall = allHall;
            Connection.CloseConnection(connection);
            CreateUI();
        }
    }
}
