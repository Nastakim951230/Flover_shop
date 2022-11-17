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
    /// Логика взаимодействия для Hat_menu.xaml
    /// </summary>
    public partial class Hat_menu 
    {
        public Hat_menu()
        {
            InitializeComponent();
            Glavna.id_role = 2;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ClassGlav.shapka.Navigate(new Hat());
            ClassGlav.perehod.Navigate(new Glavna());
        }

        private void btnBoequet_Click(object sender, RoutedEventArgs e)
        {
            Flower_Bougurt.id_role = 2;
            ClassGlav.Glav.Navigate(new Flower_Bougurt());
        }

        private void PersonalArea_Click(object sender, RoutedEventArgs e)
        {
            ClassGlav.Glav.Navigate(new Page.Personal_area());
        }
    }
}
