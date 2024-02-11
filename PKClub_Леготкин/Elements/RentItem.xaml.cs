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

namespace PKClub_Леготкин.Elements
{
    /// <summary>
    /// Логика взаимодействия для RentItem.xaml
    /// </summary>
    public partial class RentItem : UserControl
    {
        Rent Rent;
        public RentItem(Rent _rent)
        {
            InitializeComponent();
            Rent = _rent;
            Ifio.Content = Rent.FIO;
            Ihall.Content = "Клуб: " + (MainWindow.AllHall.Find(x => x.id == Rent.idHall)).Name;
            Itime.Content = "Дата и время аренды: " + Rent.Date.ToString("HH:mm dd.MM.yyyy");
            InumComp.Content = "Номер компьютера: " + Rent.numComp.ToString();
        }

        private void EditRent(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Add.AddRent(Rent));
        }

        private void DeleteRent(object sender, RoutedEventArgs e)
        {
            Rent.Delete();
            MessageBox.Show("Информация об аренде удалена.");

            MainWindow.AllRent = new Rent().AllRent();
            MainWindow.init.OpenPages(MainWindow.pages.rent);
        }
    }
}
