using Microsoft.Win32;
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
    /// Логика взаимодействия для Add_Bougurt.xaml
    /// </summary>
    public partial class Add_Bougurt 
    {
        Bouquet bouq;  // объект, в котором будет хранится данные о новом или отредактированном коте
        bool bouquetUpdate = false; // для определения, создаем мы новый объект или редактируем старый
        string path_bouquet = null;  // путь к картинке/

        public void uploadFields()  // метод для заполнения списков
        {
            Flower_bougurt.ItemsSource = Base.BD.Flowers.ToList();

        }
        public Add_Bougurt(Bouquet bouquet)
        {
            InitializeComponent();
            uploadFields();
            bouquetUpdate = true;  // отметка о том, что кота редактируем
            bouq = bouquet;  // ассоциируем выше созданный глобавльный объект с объектом в кострукторе для дальнейшего редактирования этих данных
            add_name_bougurt.Text = bouq.Name_bouquet;
            add_price_bougurt.Text=Convert.ToString(bouq.Price);

            List<Bouquet_flowers> fct = Base.BD.Bouquet_flowers.Where(x => x.Id_bouquet == bouq.Id_bouquet).ToList();

            // цикл для отображения кормов и их количества для кота:
            foreach (Flowers t in Flower_bougurt.Items)
            {
                if (fct.FirstOrDefault(x => x.Id_flower == t.Id_Flower) != null)
                {
                    t.kolvo = fct.Count;
                }
            }
            if (bouq.Photo_bouquet != null)
            {
                BitmapImage img = new BitmapImage(new Uri(bouq.Photo_bouquet, UriKind.RelativeOrAbsolute));
                pfoto_bougurt_add.Source = img;
            }
        }

        

        public Add_Bougurt()
        {
            InitializeComponent();
            uploadFields();
        }

        private void add_photo_bougurt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();  // создаем объект диалогового окна
            OFD.ShowDialog();  // открываем диалоговое окно
            path_bouquet = OFD.FileName;  // извлекаем полный путь к картинке
            string[] arrayPath = path_bouquet.Split('\\');  // разделяем путь к картинке в массив
            path_bouquet = "\\" + arrayPath[arrayPath.Length - 2] + "\\" + arrayPath[arrayPath.Length - 1];

            BitmapImage img = new BitmapImage(new Uri(path_bouquet, UriKind.RelativeOrAbsolute));
            pfoto_bougurt_add.Source = img;


        }

        private void add_bougurt_Click(object sender, RoutedEventArgs e)
        {
         
            try
            {
                if (add_name_bougurt.Text == "" || add_price_bougurt.Text == "")
                {
                    MessageBox.Show("Обязательные поля не заполнены", "Ошибка", MessageBoxButton.OK);
                }
                else
                {
                    if (bouquetUpdate == false)
                    {
                        bouq = new Bouquet();
                    }
                    if (bouquetUpdate == true && path_bouquet == null)
                    {
                        path_bouquet = bouq.Photo_bouquet;
                    }
                    bouq.Name_bouquet = add_name_bougurt.Text;
                    bouq.Price = Convert.ToInt32(add_price_bougurt.Text);
                    bouq.Photo_bouquet = path_bouquet;
                    if (bouquetUpdate == false)
                    {
                        Base.BD.Bouquet.Add(bouq);
                    }

                    List<Bouquet_flowers> feed = Base.BD.Bouquet_flowers.Where(x => bouq.Id_bouquet == x.Id_bouquet).ToList();

                    // если список не пустой, удаляем из него все корма для  этого кота
                    if (feed.Count > 0)
                    {
                        foreach (Bouquet_flowers t in feed)
                        {
                            Base.BD.Bouquet_flowers.Remove(t);
                        }
                    }


                    foreach (Flowers bf in Flower_bougurt.Items)
                    {
                        if (bf.kolvo > 0)
                        {
                            Bouquet_flowers FCT = new Bouquet_flowers() 
                            {
                                Id_bouquet = bouq.Id_bouquet,
                                Id_flower = bf.Id_Flower,
                                Kolvo = bf.kolvo
                            };
                            Base.BD.Bouquet_flowers.Add(FCT);
                        }
                    }
                    Base.BD.SaveChanges();
                    MessageBox.Show("Информация добавлена");
                 
                    ClassGlav.Admin.Navigate(new Flower_Bougurt());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Nazad_bougurt_Click(object sender, RoutedEventArgs e)
        {
            List<Bouquet_flowers> fct = Base.BD.Bouquet_flowers.Where(x => x.Id_bouquet == bouq.Id_bouquet).ToList();

            // цикл для отображения кормов и их количества для кота:
            foreach (Flowers t in Flower_bougurt.Items)
            {

                t.kolvo = 0;
                
            }
            ClassGlav.Admin.Navigate(new Flower_Bougurt());
        }
    }
}
