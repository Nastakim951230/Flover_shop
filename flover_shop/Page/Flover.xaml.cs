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
        StrelkiProsmotrFlower sp = new StrelkiProsmotrFlower();
        List<Flowers> FlowersFilter = new List<Flowers>();
        public Flover()
        {
            InitializeComponent();
            FlowersFilter = Base.BD.Flowers.ToList();
            Flowersof.ItemsSource = Base.BD.Flowers.ToList();
            
            sp.CountPageFlower = Base.BD.Flowers.ToList().Count;
            DataContext = sp;
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

        private void kolvo_zapice_flower_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                sp.CountPageFlower = Convert.ToInt32(kolvo_zapice_flower.Text); // если в текстовом поле есnь значение, присваиваем его свойству объекта, которое хранит количество записей на странице
            }
            catch
            {
                sp.CountPageFlower = FlowersFilter.Count; // если в текстовом поле значения нет, присваиваем свойству объекта, которое хранит количество записей на странице количество элементов в списке
            }
            sp.CountlistFlower = FlowersFilter.Count;  // присваиваем новое значение свойству, которое в объекте отвечает за общее количество записей
            Flowersof.ItemsSource = FlowersFilter.Skip(0).Take(sp.CountPageFlower).ToList();  // отображаем первые записи в том количестве, которое равно CountPage
            sp.CurrentPage = 1; // текущая страница - это страница 1
        }
    

        private void GoPageFlower_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;

            switch (tb.Uid)  // определяем, куда конкретно было сделано нажатие
            {
                case "prev":
                    sp.CurrentPage--;
                    break;
                case "next":
                    sp.CurrentPage++;
                    break;
                case "prev1":
                    sp.CurrentPage = 1;
                    break;
                case "next1":
                    {
                        List <Flowers> fl= Base.BD.Flowers.ToList();
                        int a=fl.Count;
                        int b = Convert.ToInt32(kolvo_zapice_flower.Text);
                        
                        if (a % b == 0)
                        {
                            sp.CurrentPage = a / b;
                        }
                        else
                        {
                            sp.CurrentPage = a / b+1;
                        }

                    }
                    break;
                default:
                    sp.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }
            Flowersof.ItemsSource = FlowersFilter.Skip(sp.CurrentPage * sp.CountPageFlower - sp.CountPageFlower).Take(sp.CountPageFlower).ToList();
        }
    }
}
