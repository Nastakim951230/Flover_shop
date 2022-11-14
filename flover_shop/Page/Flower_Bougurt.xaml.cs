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
            ClassGlav.Admin.Navigate(new Page.Add_Bougurt());
        }

        private void flover_id_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<Bouquet_flowers> FCT = Base.BD.Bouquet_flowers.Where(x => x.Id_bouquet == index).ToList();
          int i=FCT.Count;
            string flower = "";
            if (i==0)
            {
                tb.Text = "Данного букета нет в продаже";
                
            }
            else
            {
                foreach (Bouquet_flowers ftc in FCT)
                {

                    flower += " " + ftc.Flowers.Name_flower + ",кол-во:" + ftc.Kolvo + " \n";
                }
                tb.Text = "Букет состоит:\n" + flower.Substring(0, flower.Length - 2);
            }
        }

     

        private void Delet_bouquet_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить этот букет?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;  // получаем доступ к Button из шаблона
                int index = Convert.ToInt32(btn.Uid);  // получаем числовой Uid элемента списка (в разметке предварительно нужно связать номер ячейки с номером кота в базе данных)


                // создаем объект, который содержит информацию о коте, который нужно удалить
                Bouquet bouq = Base.BD.Bouquet.FirstOrDefault(x => x.Id_bouquet == index);

                Base.BD.Bouquet.Remove(bouq); // удаление кота из базы            
                Base.BD.SaveChanges();  // сохранение изменений в базе данных

                ClassGlav.Admin.Navigate(new Flower_Bougurt());
            }
            else
            {

            }
           
        }

        private void btnupdate_bouquet_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;  // получаем доступ к Button из шаблона
            int index = Convert.ToInt32(btn.Uid);   // получаем числовой Uid элемента списка (в разметке предварительно нужно связать номер ячейки с номером кота в базе данных)

            // создаем объект, который содержит кота, информацию о котором нужно отредактировать
            Bouquet bouquet = Base.BD.Bouquet.FirstOrDefault(x => x.Id_bouquet == index);

            // переход на страницу с редактированием (на ту же самую, где и добавляли кота)
            ClassGlav.Admin.Navigate(new Page.Add_Bougurt(bouquet)); // в конструктор страницы передаем объект, который был создан строкой выше
        }
    }
}
