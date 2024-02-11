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

namespace PKClub_Леготкин.Pages.Add
{
    /// <summary>
    /// Логика взаимодействия для AddRent.xaml
    /// </summary>
    public partial class AddRent : Page
    {
        Rent Rent;
        public AddRent(Rent _rent = null)
        {
            InitializeComponent();
            Rent = _rent;
            if(Rent != null)
            {
                tb_numComp.Text = Rent.numComp.ToString();
                tb_date.SelectedDate = Rent.Date;
                tb_time.Text = Rent.Date.ToString("HH:mm");
                tb_fio.Text = Rent.FIO;
                foreach (Hall item in MainWindow.AllHall)
                {
                    ComboBoxItem Item = new ComboBoxItem();
                    Item.Content = item.Name;
                    Item.Tag = item.id;
                    if (Rent.idHall == item.id) Item.IsSelected = true;
                    tb_club.Items.Add(Item);
                }
                bthAdd.Content = "Изменить";
            }
            else
            {
                foreach (Hall item in MainWindow.AllHall)
                {
                    ComboBoxItem Item = new ComboBoxItem();
                    Item.Content = item.Name;
                    Item.Tag = item.id;
                    tb_club.Items.Add(Item);
                }
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.rent);
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (tb_club.SelectedItem == null)
            {
                MessageBox.Show("Укажите клуб");
                return;
            }
            try
            {
                if (Convert.ToInt32(tb_numComp.Text) < 0)
                {
                    MessageBox.Show("Введите номер компьютера");
                    return;
                }
            }
            catch { MessageBox.Show("Введите номер компьютера"); return; }
            if (tb_date.SelectedDate == null)
            {
                MessageBox.Show("Укажите дату аренды");
                return;
            }
            if (!CheckTime(tb_time.Text))
            {
                MessageBox.Show("Некорректно указано время аренды");
                return;
            }
            if (tb_fio.Text.Length == 0)
            {
                MessageBox.Show("Укажите ФИО");
                return;
            }
            if (Rent == null)
            {
                Rent newRent = new Rent();
                newRent.numComp = Convert.ToInt32(tb_numComp.Text);
                newRent.idHall = Convert.ToInt32(((ComboBoxItem)tb_club.SelectedItem).Tag);
                newRent.FIO = tb_fio.Text;
                string[] dateTime = tb_date.SelectedDate.ToString().Split(' ');
                string[] date = dateTime[0].Split('.');

                string[] time = tb_time.Text.Split(':');

                newRent.Date = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), 00);

                newRent.Save();
                MessageBox.Show("Аренда добавлена.");
            }
            else
            {
                Rent newRent = new Rent();
                newRent.id = Rent.id;
                newRent.numComp = Convert.ToInt32(tb_numComp.Text);
                newRent.idHall = Convert.ToInt32(((ComboBoxItem)tb_club.SelectedItem).Tag);
                newRent.FIO = tb_fio.Text;
                string[] dateTime = tb_date.SelectedDate.ToString().Split(' ');
                string[] date = dateTime[0].Split('.');

                string[] time = tb_time.Text.Split(':');

                newRent.Date = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), 00);

                newRent.Save(true);
                MessageBox.Show("Аренда изменена.");
            }
            MainWindow.AllRent = new Rent().AllRent();
            MainWindow.init.OpenPages(MainWindow.pages.rent);
        }
        public bool CheckTime(string str)
        {
            string[] str1 = str.Split(':');
            if (str1.Length == 2)
            {
                if (str1[0].Trim() != "" && str1[1].Trim() != "")
                {
                    if (int.Parse(str1[0]) >= 0 && int.Parse(str1[0]) <= 23)
                    {
                        if (int.Parse(str1[1]) >= 0 && int.Parse(str1[1]) <= 59)
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
    }
}
