using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Personal_area.xaml
    /// </summary>
    public partial class Personal_area 
    {
       
        public static int id;

        // метод для отображения изображения в личном кабинете. первый аргумент - байтовый массив, в котором хранится изображение в БД, второй аргумент - имя изображения в разметке
        void showImage(byte[] Barray, System.Windows.Controls.Image img)
        {
            BitmapImage BI = new BitmapImage();  // создаем объект для загрузки изображения
            using (MemoryStream m = new MemoryStream(Barray))  // для считывания байтового потока
            {
                BI.BeginInit();  // начинаем считывание
                BI.StreamSource = m;  // задаем источник потока
                BI.CacheOption = BitmapCacheOption.OnLoad;  // переводим изображение
                BI.EndInit();  // заканчиваем считывание
            }
            img.Source = BI;  // показываем картинку на экране (imUser – имя картиник в разметке)
            img.Stretch = Stretch.Uniform;
        }
        public Personal_area()
        {
            InitializeComponent();
            List<Users> use = Base.BD.Users.Where(x => x.ID == id).ToList();
            foreach (Users u in use)
            {
                Fio.Text = "" + u.Name + " " + u.Surname + " " + u.Otchestvo;
                String s = String.Format("{0:dd.MM.yyyy}", u.Date_of_Birth);
                if (u.Floor == 1)
                {
                    datarog.Text = "Пол: Ж | Дата рождения: " + s + "";
                }
                else
                {
                    datarog.Text = "Пол: M | Дата рождения: " + s + "";
                }
                
                List<Сlients> FCT = Base.BD.Сlients.Where(x => x.id_user == id).ToList();
                foreach (Сlients ftc in FCT)
                {
                    telefo.Text = "Номер телефона: " + ftc.Telefon;
                    if (ftc.email == null)
                    {
                        email.Text = "Email:Данные отсутствуют";
                    }
                    else
                    {
                        email.Text = "Email: " + ftc.email;
                    }
                    ball.Text = "Ваши баллы: " + ftc.points;
                    List<Image> k = Base.BD.Image.Where(x => x.Id_Client == ftc.Id_clients).ToList();
                    if (k.Count !=0 )  // если список с фото не пустой, начинает переводить байтовый массив в изображение
                    {

                        byte[] Bar = k[k.Count - 1].Image1;   // считываем изображение из базы (считываем байтовый массив двоичных данных) - выбираем последнее добавленное изображение
                        showImage(Bar, imUser);  // отображаем картинку
                    }
                }
            }
           
        }

        private void ChangePhoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPhotosListView_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Photos_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
