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
    /// Логика взаимодействия для Flower_Bougurt.xaml
    /// </summary>
    public partial class Flower_Bougurt : Page
    {
        public static int id_role;
        public static int vyhod;
        public Flower_Bougurt()
        {
            InitializeComponent();
            Flower.ItemsSource = Base.BD.Bouquet.ToList();

            if (id_role==2)
            {
                Add_Bouquet.Visibility = Visibility.Collapsed;
            }
            if (id_role==1)
            {
                Add_Bouquet.Visibility = Visibility.Visible;
            }
            if (vyhod==3)
            {
                Add_Bouquet.Visibility = Visibility.Collapsed;
            }
            
            
        }

        private void Add_Bouquet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
