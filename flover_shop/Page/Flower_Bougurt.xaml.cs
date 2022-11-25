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
                Bouquet.btn_admin= Visibility.Collapsed;
            }
            if (id_role==1)
            {
                Add_Bouquet.Visibility = Visibility.Visible;
                Bouquet.btn_admin = Visibility.Visible;
            }
            if (vyhod==3)
            {
                Add_Bouquet.Visibility = Visibility.Collapsed;
                Bouquet.btn_admin = Visibility.Collapsed;
            }

            List<Flowers> BT = Base.BD.Flowers.ToList();
            // программное заполнение выпадающего списка
            cmbFlower.Items.Add("Все цветы");  // первый элемент выпадающего списка, который сбрасывает фильтрацию
            for (int i = 0; i < BT.Count; i++)  // цикл для записи в выпадающий список всех пород котов из БД
            {
                cmbFlower.Items.Add(BT[i].Name_flower);
            }

            cmbFlower.SelectedIndex = 0;  // выбранное по умолчанию значение в списке с породами котов ("Все породы")
            cmbSort.SelectedIndex = 0;  // выбранное по умолчанию значение в списке с видами сортировки ("Без сортировки")

            TBCoint.Text = "Количество записей: " + Base.BD.Bouquet_flowers.ToList().Count;

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
            if (MessageBox.Show("Вы точно хотите удалить этот букет?", "Вопрос", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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

        void Filter()  // метод для одновременной фильтрации, поиска и сортировки
        {
            List<Bouquet> flowerList = new List<Bouquet>();  // пустой список, который далее будет заполнять элементами, удавлетворяющими условиям фильтрации, поиска и сортировки

            // выбранное пользователем название породы
            string flower = cmbFlower.SelectedValue.ToString();
            int index = cmbFlower.SelectedIndex;
            int indexFlower = 0;
            int indexBouquet = 0;
            if (index != 0)
            {
                List<Flowers> tcv = Base.BD.Flowers.Where(x => x.Name_flower == flower).ToList();
                foreach (Flowers tc in tcv)
                {
                    indexFlower = tc.Id_Flower;
                    List<Bouquet_flowers> FCT = Base.BD.Bouquet_flowers.Where(x => x.Id_bouquet == indexFlower).ToList();

                    foreach (Bouquet_flowers ftc in FCT)
                    {
                        indexBouquet = ftc.Id_bouquet;
                    }
                }

            }
                if (index != 0)
            {
                
                flowerList = Base.BD.Bouquet.Where(x => x.Id_bouquet == indexBouquet).ToList();
            }
            else  // если выбран пункт "Все породы", то сбрасываем фильтрацию:
            {
                flowerList = Base.BD.Bouquet.ToList();
            }


            // поиск совпадений по именам котов
            if (!string.IsNullOrWhiteSpace(tbSearch.Text))  // если строка не пустая и если она не состоит из пробелов
            {
                flowerList = flowerList.Where(x => x.Name_bouquet.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
            }


            // выбор элементов только с фото
            if (cbPhoto.IsChecked == true)
            {
                flowerList = flowerList.Where(x => x.Photo_bouquet != null).ToList();
            }

            // сортировка
            switch (cmbSort.SelectedIndex)
            {
                case 1:
                    {
                        flowerList.Sort((x, y) => x.Name_bouquet.CompareTo(y.Name_bouquet));
                    }
                    break;
                case 2:
                    {
                        flowerList.Sort((x, y) => x.Name_bouquet.CompareTo(y.Name_bouquet));
                        flowerList.Reverse();
                    }
                    break;
            }

            Flower.ItemsSource = flowerList;
            if (flowerList.Count == 0)
            {
                MessageBox.Show("нет записей");
            }
            TBCoint.Text = "Количество записей " + flowerList.Count;
        }

        private void cmbFlower_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
