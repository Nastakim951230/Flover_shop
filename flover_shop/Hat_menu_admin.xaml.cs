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
    public partial class Hat_menu_admin : Page
    {
        public Hat_menu_admin()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ClassGlav.shapka.Navigate(new Hat());
            ClassGlav.perehod.Navigate(new Glavna());
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            ClassGlav.Admin.Navigate(new Admin_User());
        }
    }
}
