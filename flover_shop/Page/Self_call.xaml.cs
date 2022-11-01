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
    /// Логика взаимодействия для Self_call.xaml
    /// </summary>
    public partial class Self_call 
    {
        public Self_call()
        {
            InitializeComponent();
            self_call.ItemsSource = Base.BD.Payment.Where((s => s.Id_self_call != null && s.Stage_of_work != 2)).ToList();
        }

        private void name_bouquet_self_call_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<Basket> FCT = Base.BD.Basket.Where(x => x.Id_Basket == index).ToList();

            string name = "";

            int id_bouquet = 0;
            foreach (Basket ftc in FCT)
            {
                id_bouquet = Convert.ToInt32(ftc.Id_Bouquet);
                List<Bouquet> BQT = Base.BD.Bouquet.Where(x => x.Id_bouquet == id_bouquet).ToList();
                foreach (Bouquet bQT in BQT)
                {
                    name = bQT.Name_bouquet;
                }
            }
            tb.Text = "Букет: " + name + "";
        }

        private void FIO_self_call_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<Basket> FCT = Base.BD.Basket.Where(x => x.Id_Basket == index).ToList();
            string name = "";
            string familio = "";
            string othestvo = "";
            int id_cluen = 0;
            int id_users = 0;
            foreach (Basket ftc in FCT)
            {
                id_cluen = Convert.ToInt32(ftc.Id_Client);
                List<Сlients> CLN = Base.BD.Сlients.Where(x => x.Id_clients == id_cluen).ToList();
                foreach (Сlients сlients in CLN)
                {
                    id_users = Convert.ToInt32(сlients.id_user);
                    List<Users> US = Base.BD.Users.Where(x => x.ID == id_users).ToList();
                    foreach (Users u in US)
                    {
                        name = u.Name;
                        familio = u.Surname;
                        othestvo = u.Otchestvo;
                    }
                }

            }
            tb.Text = "Ф.И.О:\n " + familio + " " + name + " " + othestvo + "";
        }
    }
}
