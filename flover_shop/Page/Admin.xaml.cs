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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin 
    {
       
        public Admin()
        {
            InitializeComponent();
            Flower_Bougurt.id_role = 1;
            DataGrid.Navigate(new Flower_Bougurt());
            ClassGlav.Admin = DataGrid;
            
        }
    }
}
