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
    /// Логика взаимодействия для Hat.xaml
    /// </summary>
    public partial class Hat 
    {
        public Hat()
        {
            InitializeComponent();
            Registratsia.id_role = 0;
        }
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
           ClassGlav.perehod.Navigate(new Registratsia());
        }

        private void Entrance_Click(object sender, RoutedEventArgs e)
        {
            ClassGlav.perehod.Navigate(new Input());
        }
    }
}
