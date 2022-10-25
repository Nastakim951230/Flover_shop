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
    /// Логика взаимодействия для Flover.xaml
    /// </summary>
    public partial class Flover : Page
    {
        public Flover()
        {
            InitializeComponent();
            Flowersof.ItemsSource = Base.BD.Flowers.ToList();
            
        }

        private void Add_Flover_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
