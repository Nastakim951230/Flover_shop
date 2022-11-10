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
    /// Логика взаимодействия для Delet_Updatu_bouqut.xaml
    /// </summary>
    public partial class Delet_Updatu_bouqut 
    {
        public Delet_Updatu_bouqut(int id_role)
        {
            InitializeComponent();
            te.Text = id_role.ToString();
        }
    }
}
