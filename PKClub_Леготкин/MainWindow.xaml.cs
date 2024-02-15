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

namespace PKClub_Леготкин
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public static List<Hall> AllHall = new Hall().AllHall();
        public static List<Rent> AllRent = new Rent().AllRent();
        public static bool User = true;
        public enum pages
        {
            hall,
            rent,
            addHall,
            addRent
        }
        public MainWindow()
        {
            InitializeComponent();
            init = this;
            OpenPages(pages.hall);
        }
        public void OpenPages(pages _pages)
        {
            if (_pages == pages.hall)
            {
                MainWindow.AllHall = new Hall().AllHall();
                frame.Navigate(new Pages.HallPage());
            }
            if (_pages == pages.rent)
            {
                MainWindow.AllRent = new Rent().AllRent();
                frame.Navigate(new Pages.RentPage());
            }
            if (_pages == pages.addHall)
                frame.Navigate(new Pages.Add.AddHall());
            if (_pages == pages.addRent)
                frame.Navigate(new Pages.Add.AddRent());
        }
    }
}
