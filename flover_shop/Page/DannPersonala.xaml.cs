using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace flover_shop.Page
{
    /// <summary>
    /// Логика взаимодействия для DannPersonala.xaml
    /// </summary>
    public partial class DannPersonala : Window
    {
        Сlients client;
        Users users;
        int id;
        public DannPersonala(int id)
        {
            InitializeComponent();
            this.id = id;
            List<Users> use = Base.BD.Users.Where(x => x.ID == id).ToList();
            foreach(Users u in use)
            {
                users=u;
            }
            tbName.Text =users.Name;
            tbFamili.Text = users.Surname;
            tbOthestvo.Text = users.Otchestvo;
            if(users.Floor==1)
            {
                GenderG.IsChecked = true;
            }
            else
            {
                GenderM.IsChecked = true;
            }
            String s = String.Format("{0:dd.MM.yyyy}", users.Date_of_Birth);
            Dateofbirth.Text = s;
            List<Сlients> cli=Base.BD.Сlients.Where(x=>x.id_user==id).ToList();
            foreach(Сlients clien in cli)
            {
                client = clien;
            }
            telefon.Text = client.Telefon;
            email.Text = client.email;

        }
        public bool isFormEmail(string a)
        {
            Regex m = new Regex("^[-\\w.]+@([A-z0-9][-A-z0-9]+\\.)+[A-z]{2,4}$");
            if (m.IsMatch(a))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Был не правильно введен email", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
        }

        public bool isFormTelef(string a)
        {
            Regex m = new Regex("[8](\\d{10})");
            if (m.IsMatch(a))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Был не правильно введен номер телефона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
        }
        private void Izmenenie_Click(object sender, RoutedEventArgs e)
        {
            if (isFormTelef(telefon.Text))
            {
                if (email.Text != "")
                {
                    if (isFormEmail(email.Text))
                    {
                        List<Users> use = Base.BD.Users.Where(x => x.ID == id).ToList();
                        foreach (Users u in use)
                        {
                            users = u;
                        }
                        users.Name = tbName.Text;
                        users.Surname = tbFamili.Text;
                        users.Otchestvo = tbOthestvo.Text;

                        if (GenderG.IsChecked == true)
                        {
                            users.Floor = 1;

                        }
                        else
                        {
                            users.Floor = 2;
                        }
                        users.Date_of_Birth = (DateTime)Dateofbirth.SelectedDate;
                        List<Сlients> cli = Base.BD.Сlients.Where(x => x.id_user == id).ToList();
                        foreach (Сlients clien in cli)
                        {
                            client = clien;
                        }
                        client.Telefon = telefon.Text;
                        client.email = email.Text;
                        Base.BD.SaveChanges();  // сохраняем изменения в БД
                        this.Close();
                    }
                }
                else
                {
                    List<Users> use = Base.BD.Users.Where(x => x.ID == id).ToList();
                    foreach (Users u in use)
                    {
                        users = u;
                    }
                    users.Name = tbName.Text;
                    users.Surname = tbFamili.Text;
                    users.Otchestvo = tbOthestvo.Text;

                    if (GenderG.IsChecked == true)
                    {
                        users.Floor = 1;

                    }
                    else
                    {
                        users.Floor = 2;
                    }
                    users.Date_of_Birth = (DateTime)Dateofbirth.SelectedDate;
                    List<Сlients> cli = Base.BD.Сlients.Where(x => x.id_user == id).ToList();
                    foreach (Сlients clien in cli)
                    {
                        client = clien;
                    }
                    client.Telefon = telefon.Text;
                    client.email = null;
                    Base.BD.SaveChanges();  // сохраняем изменения в БД
                    this.Close();
                }
            }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
