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
    /// Логика взаимодействия для Hat_menu_admin.xaml
    /// </summary>
    public partial class Hat_menu_admin 
    {
        public static int id_user;
        public Hat_menu_admin()
        {
            InitializeComponent();
            Users users = Base.BD.Users.FirstOrDefault(i => i.ID == id_user);
            if (users != null)
            {
                Flower_Bougurt.id_role = users.Role;
                Name_use.Text = users.Name;
                Surname_use.Text = users.Surname;

            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Flower_Bougurt.vyhod = 3;
            ClassGlav.shapka.Navigate(new Hat());
            ClassGlav.perehod.Navigate(new Glavna());
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
           
            ClassGlav.Admin.Navigate(new Admin_User());
        }

        private void btBoequet_Click(object sender, RoutedEventArgs e)
        {
            Flower_Bougurt.id_role = 1;
            ClassGlav.Admin.Navigate(new Flower_Bougurt());
        }

        private void btFlower_Click(object sender, RoutedEventArgs e)
        {
            ClassGlav.Admin.Navigate(new Flover());
        }

        private void btZakaz_Click(object sender, RoutedEventArgs e)
        {
            ClassGlav.Admin.Navigate(new Page.Orders());
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
