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
    }
}
