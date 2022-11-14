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
    public partial class Flover 
    {
        public Flover()
        {
            InitializeComponent();
            Flowersof.ItemsSource = Base.BD.Flowers.ToList();
            
        }

        private void Add_Flover_Click(object sender, RoutedEventArgs e)
        {
            ClassGlav.Admin.Navigate(new Page.Add_flower());
        }

        private void Delet_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;  // получаем доступ к Button из шаблона
            int index = Convert.ToInt32(btn.Uid);  // получаем числовой Uid элемента списка (в разметке предварительно нужно связать номер ячейки с номером кота в базе данных)

           
            // создаем объект, который содержит информацию о коте, который нужно удалить
            Flowers flower = Base.BD.Flowers.FirstOrDefault(x => x.Id_Flower == index);
            
            Base.BD.Flowers.Remove(flower); // удаление кота из базы            
            Base.BD.SaveChanges();  // сохранение изменений в базе данных

            ClassGlav.Admin.Navigate(new Flover());
        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;  // получаем доступ к Button из шаблона
            int index = Convert.ToInt32(btn.Uid);   // получаем числовой Uid элемента списка (в разметке предварительно нужно связать номер ячейки с номером кота в базе данных)

            // создаем объект, который содержит кота, информацию о котором нужно отредактировать
            Flowers flowers = Base.BD.Flowers.FirstOrDefault(x => x.Id_Flower == index);

            // переход на страницу с редактированием (на ту же самую, где и добавляли кота)
            ClassGlav.Admin.Navigate(new Page.Add_flower(flowers));
        }
    }
}
