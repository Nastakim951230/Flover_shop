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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            Base.BD = new BaseDana();
            Okno.Navigate(new Glavna());
            ClassGlav.perehod = Okno;

        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Okno.Navigate(new Registratsia());
        }
    }
}
