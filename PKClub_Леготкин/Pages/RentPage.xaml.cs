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
    }
}
