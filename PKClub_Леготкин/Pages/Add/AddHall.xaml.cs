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
    /// Логика взаимодействия для AddHall.xaml
    /// </summary>
    public partial class AddHall : UserControl
    {
        public Hall Hall;
        public AddHall(Hall _hall = null)
        {
            InitializeComponent();
            Hall = _hall;
            if(Hall != null)
            {
                tb_name.Text = Hall.Name;
                tb_address.Text = Hall.Address;
                tb_time.Text = Hall.TimeWork;
                bthAdd.Content = "Изменить";
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.hall);
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (tb_name.Text.Length == 0)
            {
                MessageBox.Show("Введите название клуба");
                return;
            }
            if (tb_address.Text.Length == 0)
            {
                MessageBox.Show("Введите адресс клуба");
                return;
            }
            if (!CheckTime(tb_time.Text))
            {
                MessageBox.Show("Некорректно указано время работы");
                return;
            }
            if (Hall == null)
            {
                Hall newHall = new Hall(0, tb_name.Text, tb_address.Text, tb_time.Text);

                newHall.Save();
                MessageBox.Show("Клуб добавлен.");
            }
            else
            {
                Hall newHall = new Hall(Hall.id, tb_name.Text, tb_address.Text, tb_time.Text);

                newHall.Save(true);
                MessageBox.Show("Клуб изменён.");
            }
            MainWindow.AllHall = new Hall().AllHall();
            MainWindow.init.OpenPages(MainWindow.pages.hall);
        }
        public bool CheckTime(string str)
        {
            try
            {
                string[] str0 = str.Split('-');
                string[] str1 = str0[0].Split(':');
                string[] str2 = str0[1].Split(':');
                if (str1.Length == 2)
                {
                    if (str1[0].Trim() != "" && str1[1].Trim() != "" && str2[0].Trim() != "" && str2[1].Trim() != "")
                    {
                        if (int.Parse(str1[0]) >= 0 && int.Parse(str1[0]) <= 23 && int.Parse(str2[0]) >= 0 && int.Parse(str2[0]) <= 23)
                        {
                            if (int.Parse(str1[1]) >= 0 && int.Parse(str1[1]) <= 59 && int.Parse(str2[1]) >= 0 && int.Parse(str2[1]) <= 59)
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
            catch { return false; }
        }
    }
}
