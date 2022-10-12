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

namespace flover_shop
{
    /// <summary>
    /// Логика взаимодействия для Input.xaml
    /// </summary>
    public partial class Input : Page
    {
        public Input()
        {
            InitializeComponent();
            //Login=admin Password=admin
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            ClassGlav.perehod.Navigate(new Glavna());
        }

        private void Inpu_Click(object sender, RoutedEventArgs e)
        {
          
            string parol = password.HasPassword(Password.Password.ToString());
            Users users = Base.BD.Users.FirstOrDefault(l => l.Login == Login.Text && l.Password == parol);
            if (users != null)
            {

                if (users.Role == 1)
                {
                    ClassGlav.shapka.Navigate(new Hat_menu());
                    ClassGlav.perehod.Navigate(new Admin());
                }
                else if (users.Role == 2)
                {
                    ClassGlav.shapka.Navigate(new Hat_menu());
                    ClassGlav.perehod.Navigate(new Glavna());
                }
            }
            else
            {
                MessageBox.Show("Данного пользователя нет");

            }
        }
    }
}
