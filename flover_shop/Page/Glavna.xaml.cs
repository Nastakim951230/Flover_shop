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
    /// Логика взаимодействия для Glavna.xaml
    /// </summary>
    public partial class Glavna 
    {
        public static int id_role;
       
        public Glavna()
        {
            InitializeComponent();
            if(id_role == 2)
            {
              
                Flower.Navigate(new Page.Personal_area());
                ClassGlav.Glav = Flower;
            }
            else
            {
                Flower.Navigate(new Flower_Bougurt());
                ClassGlav.Glav = Flower;
            }
          
            
        }
    }
}
