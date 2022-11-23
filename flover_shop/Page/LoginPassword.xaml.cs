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
using System.Windows.Shapes;

namespace flover_shop.Page
{
    /// <summary>
    /// Логика взаимодействия для LoginPassword.xaml
    /// </summary>
    public partial class LoginPassword : Window
    {
        int id;
        public LoginPassword(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login windowPerson = new Login(id);  // создание объекта окна
            windowPerson.ShowDialog(); // октрытие созданного окна (дальнейший код не будет запущен, пока окно не будет закрыто)
            this.Close();
        }

        private void btnPassword_Click(object sender, RoutedEventArgs e)
        {
            Password windowPerson = new Password(id);  // создание объекта окна
            windowPerson.ShowDialog(); // октрытие созданного окна (дальнейший код не будет запущен, пока окно не будет закрыто)
            this.Close();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
