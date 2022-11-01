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
    public partial class Flower_Bougurt 
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

        private void flover_id_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<Bouquet_flowers> FCT = Base.BD.Bouquet_flowers.Where(x => x.Id_bouquet == index).ToList();
            
            string flower = "";
            foreach (Bouquet_flowers ftc in FCT)
            {
                flower +=" "+ ftc.Flowers.Name_flower + ",кол-во:"+ftc.Kolvo+" \n";
            }
            tb.Text = "Букет состоит:\n"+ flower.Substring(0, flower.Length - 2); 
        }
    }
}
