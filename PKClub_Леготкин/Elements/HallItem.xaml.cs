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
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace PKClub_Леготкин.Elements
{
    /// <summary>
    /// Логика взаимодействия для HallItem.xaml
    /// </summary>
    public partial class HallItem : UserControl
    {
        Hall Hall;
        public HallItem(Hall _hall)
        {
            InitializeComponent();
            Hall = _hall;
            Iname.Content = Hall.Name;
            Iaddress.Content = "Адресс: " + Hall.Address;
            Itime.Content = "Время работы: " + Hall.TimeWork;
            if (!MainWindow.User)
            {
                EditButton.Visibility = Visibility.Hidden;
                DeleteButton.Visibility = Visibility.Hidden;
            }
        }

        private void EditHall(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Add.AddHall(Hall));
        }

        private void DeleteHall(object sender, RoutedEventArgs e)
        {
            Hall.Delete();
            MessageBox.Show("Информация о клубе удалена.");

            MainWindow.AllHall = new Hall().AllHall();
            MainWindow.init.OpenPages(MainWindow.pages.hall);
        }
    }
}
