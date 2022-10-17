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
    /// Логика взаимодействия для Admin_User.xaml
    /// </summary>
    public partial class Admin_User : Page
    {
        public Admin_User()
        {
            InitializeComponent();
            Admin_user.ItemsSource = Base.BD.Users.ToList();
        }

        private void Searc_Click(object sender, RoutedEventArgs e)
        {
            //string poisk = "";
            //string tabl = "";
            //switch (Poisk.SelectedIndex)
            //{
            //    case 0:
            //        {

            //            tabl = "Surname";
            //            poisk = TextSearc.Text;
            //            Admin_user.ItemsSource = Base.BD.Users.Where(s => s.Surname == poisk);
            //        }
            //        break;
            //    case 1:
            //        {
            //            tabl = "Name";
            //        }
            //        break;
            //    case 2:
            //        {
            //            tabl = "Otchestvo";
            //        }
            //        break;
            //    case 3:
            //        {
            //            tabl = "Login";
            //        }
            //        break;
            //    case 4:
            //        {
            //            tabl = "Floor";

            //        }
            //        break;
            //    case 5:
            //        {
            //            tabl = "Date_of_Birth";
            //        }
            //        break;
            //    case 6:
            //        {
            //            tabl = "Role";
            //        }
            //        break;
            //}
        }

       

        

        private void Poisk_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
