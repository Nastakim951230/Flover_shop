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

            cmbSort.SelectedIndex = 0;  // выбранное по умолчанию значение в списке с видами сортировки ("Без сортировки")

            TBCoint.Text = "Количество записей: " + Base.BD.Flowers.ToList().Count;

        }

        private void Add_Flover_Click(object sender, RoutedEventArgs e)
        {
            ClassGlav.Admin.Navigate(new Page.Add_flower());
        }

        private void Delet_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Вы точно хотите удалить этот цветок?", "Вопрос", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;  // получаем доступ к Button из шаблона
                int index = Convert.ToInt32(btn.Uid);  // получаем числовой Uid элемента списка (в разметке предварительно нужно связать номер ячейки с номером кота в базе данных)


                // создаем объект, который содержит информацию о коте, который нужно удалить
                Flowers flower = Base.BD.Flowers.FirstOrDefault(x => x.Id_Flower == index);

                Base.BD.Flowers.Remove(flower); // удаление кота из базы            
                Base.BD.SaveChanges();  // сохранение изменений в базе данных

                ClassGlav.Admin.Navigate(new Flover());
            }
            else
            {

            }
           
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

        void Filter()  // метод для одновременной фильтрации, поиска и сортировки
        {
            List<Flowers> flowerList = new List<Flowers>();  // пустой список, который далее будет заполнять элементами, удавлетворяющими условиям фильтрации, поиска и сортировки

            flowerList = Base.BD.Flowers.ToList();

            // поиск совпадений по названием цветов
            if (!string.IsNullOrWhiteSpace(tbSearch.Text))  // если строка не пустая и если она не состоит из пробелов
            {
                flowerList = flowerList.Where(x => x.Name_flower.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
            }


            // выбор элементов только с фото
            if (cbPhoto.IsChecked == true)
            {
                flowerList = flowerList.Where(x => x.Pfoto_flower != null).ToList();
            }

            // сортировка
            switch (cmbSort.SelectedIndex)
            {
                case 1:
                    {
                        flowerList.Sort((x, y) => x.Name_flower.CompareTo(y.Name_flower));
                    }
                    break;
                case 2:
                    {
                        flowerList.Sort((x, y) => x.Name_flower.CompareTo(y.Name_flower));
                        flowerList.Reverse();
                    }
                    break;
            }

            Flowersof.ItemsSource = flowerList;
            if (flowerList.Count == 0)
            {
                MessageBox.Show("нет записей");
            }
            TBCoint.Text = "Количество записей " + flowerList.Count;
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cbPhoto_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }
    }
}
