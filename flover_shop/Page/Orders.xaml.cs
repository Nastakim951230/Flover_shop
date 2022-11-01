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

namespace flover_shop.Page
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders 
    {
        public Orders()
        {
            InitializeComponent();
            Delivery_type.Navigate(new Delivery());
            ClassGlav.delivery_type = Delivery_type;

        }

        private void Delivery_Click(object sender, RoutedEventArgs e)
        {
            ClassGlav.delivery_type.Navigate(new Delivery());
        }

        private void Self_call_Click(object sender, RoutedEventArgs e)
        {
            ClassGlav.delivery_type.Navigate(new Page.Self_call());
        }
    }
}
