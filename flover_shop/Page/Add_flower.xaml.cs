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
    /// Логика взаимодействия для Add_flower.xaml
    /// </summary>
    public partial class Add_flower
    {
        Flowers flow;  // объект, в котором будет хранится данные о новом или отредактированном коте
        bool flagUpdate = false; // для определения, создаем мы новый объект или редактируем старый
        string path=null;  // путь к картинке/
        
        public Add_flower()
        {

            InitializeComponent();
            
        }

      
        private void add_flower_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (add_kolvo_flower.Text == "" || add_name_flower.Text == "" || add_price_flower.Text == "")
                {
                    MessageBox.Show("Обязательные поля не заполнены", "Ошибка", MessageBoxButton.OK);
                }
                else
                {
                    if (flagUpdate == false)
                    {
                        flow = new Flowers();
                    }
                    flow.Name_flower = add_name_flower.Text;
                    flow.Kolvo = Convert.ToInt32(add_kolvo_flower.Text);
                    flow.Price = Convert.ToInt32(add_price_flower.Text);
                    flow.Pfoto_flower = path;
                    if (flagUpdate == false)
                    {
                        Base.BD.Flowers.Add(flow);
                    }
                    Base.BD.SaveChanges();
                    MessageBox.Show("Информация добавлена");
                    ClassGlav.Admin.Navigate(new Flover());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void add_photo_flower_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();  // создаем объект диалогового окна
            OFD.ShowDialog();  // открываем диалоговое окно
            path = OFD.FileName;  // извлекаем полный путь к картинке
            string[] arrayPath = path.Split('\\');  // разделяем путь к картинке в массив
            path = "\\" + arrayPath[arrayPath.Length - 2] + "\\" + arrayPath[arrayPath.Length - 1];

            BitmapImage img = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
            pfoto_flower_add.Source = img;

        }
    }
}
