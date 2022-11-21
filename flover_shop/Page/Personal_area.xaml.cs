using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public static int IzmenenieFoto;
        Сlients client;
        
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
                    client = ftc;
                  
                }
                telefo.Text = "Номер телефона: " + client.Telefon;
                if (client.email == null)
                {
                    email.Text = "Email:Данные отсутствуют";
                }
                else
                {
                    email.Text = "Email: " + client.email;
                }
                ball.Text = "Ваши баллы: " + client.points;
                List<Image> k = Base.BD.Image.Where(x => x.Id_Client == client.Id_clients).ToList();
                if (k.Count != 0)  // если список с фото не пустой, начинает переводить байтовый массив в изображение
                {

                    byte[] Bar = k[k.Count - 1].Image1;   // считываем изображение из базы (считываем байтовый массив двоичных данных) - выбираем последнее добавленное изображение
                    showImage(Bar, imUser);  // отображаем картинку
                }
                Images.ItemsSource = Base.BD.Image.Where(x => x.Id_Client == client.Id_clients).ToList();
            
            }
           
        }

        private void ChangePhoto_Click(object sender, RoutedEventArgs e)
        {

            Image.btn_image = Visibility.Visible;
            Images.ItemsSource = Base.BD.Image.Where(x => x.Id_Client == client.Id_clients).ToList();
        }

        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               

                Image u = new Image();  // создание объекта для добавления записи в таблицу, где хранится фото
                u.Id_Client = client.Id_clients;  // присваиваем значение полю idUser (id авторизованного пользователя)

                OpenFileDialog OFD = new OpenFileDialog();  // создаем диалоговое окно
                //OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);  // выбор папки для открытия
                OFD.ShowDialog();  // открываем диалоговое окно             
                string path = OFD.FileName;  // считываем путь выбранного изображения
                System.Drawing.Image SDI = System.Drawing.Image.FromFile(path);  // создаем объект для загрузки изображения в базу
                ImageConverter IC = new ImageConverter();  // создаем конвертер для перевода картинки в двоичный формат
                byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));  // создаем байтовый массив для хранения картинки
                u.Image1 = Barray;  // заполяем поле photoBinary полученным байтовым массивом
                Base.BD.Image.Add(u);  // добавляем объект в таблицу БД
            
                MessageBox.Show("Фотография добавлена");
                
                ClassGlav.Glav.Navigate(new Page.Personal_area()); // перезагружаем страницу

            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void AddPhotosListView_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Photos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Image> images = Base.BD.Image.Where(x => x.Id_Client == client.Id_clients).ToList();
                int id = images[images.Count - 1].Id_Photo;
                string pathbase = images[images.Count - 1].Path;
                byte[] img = images[images.Count - 1].Image1;

                Image imag = Base.BD.Image.FirstOrDefault(x => x.Id_Photo == id);

                Base.BD.Image.Remove(imag); // удаление кота из базы            
                Base.BD.SaveChanges();  // сохранение изменений в базе данных


                OpenFileDialog OFD = new OpenFileDialog();  // создаем диалоговое окно
                OFD.Multiselect = true;  // открытие диалогового окна с возможностью выбора нескольких элементов
                if (OFD.ShowDialog() == true)  // пока диалоговое окно открыто, будет в цикле записывать каждое выбранное изображение в БД
                {
                    foreach (string file in OFD.FileNames)  // цикл организован по именам выбранных файлов
                    {
                        Image u = new Image();  // создание объекта для добавления записи в таблицу, где хранится фото
                        u.Id_Client = client.Id_clients;  // присваиваем значение полю idUser (id авторизованного пользователя)
                        string path = file;  // считываем путь выбранного изображения
                        System.Drawing.Image SDI = System.Drawing.Image.FromFile(file);  // создаем объект для загрузки изображения в базу
                        ImageConverter IC = new ImageConverter();  // создаем конвертер для перевода картинки в двоичный формат
                        byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));  // создаем байтовый массив для хранения картинки
                        u.Image1 = Barray;  // заполяем поле photoBinary полученным байтовым массивом
                        Base.BD.Image.Add(u);  // добавляем объект в таблицу БД
                    }
                    Base.BD.SaveChanges();
                    MessageBox.Show("Фотографии добавлены");

                    Image imagesBase = new Image();
                    imagesBase.Id_Client = client.Id_clients;
                    imagesBase.Path = pathbase;
                    imagesBase.Image1 = img;
                    Base.BD.Image.Add(imagesBase);  // добавляем объект в таблицу БД
                    Base.BD.SaveChanges();
                    ClassGlav.Glav.Navigate(new Page.Personal_area()); // перезагружаем страницу
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

     

        private void izmenit_Click(object sender, RoutedEventArgs e)
        {
            Button tb = (Button)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<Image> images = Base.BD.Image.Where(x => x.Id_Photo == index).ToList();
            string pathbase = images[images.Count - 1].Path;
            byte[] img = images[images.Count - 1].Image1;

            Image imag = Base.BD.Image.FirstOrDefault(x => x.Id_Photo == index);

            Base.BD.Image.Remove(imag); // удаление кота из базы            
            Base.BD.SaveChanges();  // сохранение изменений в базе данных

            Image imagesBase = new Image();
            imagesBase.Id_Client = client.Id_clients;
            imagesBase.Path = pathbase;
            imagesBase.Image1 = img;
            Base.BD.Image.Add(imagesBase);  // добавляем объект в таблицу БД
            Base.BD.SaveChanges();
            Image.btn_image=Visibility.Collapsed;
            ClassGlav.Glav.Navigate(new Page.Personal_area()); // перезагружаем страницу
        }
    }
}
