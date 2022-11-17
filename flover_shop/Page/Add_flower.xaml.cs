using Microsoft.Win32;
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
using System.Drawing;
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
        byte[] Barray_flower = null;
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
        public Add_flower(Flowers flowers)
        {

            InitializeComponent();
            flagUpdate = true;
            flow = flowers;
            add_name_flower.Text = flow.Name_flower;
            add_kolvo_flower.Text = Convert.ToString(flow.Kolvo);
            add_price_flower.Text= Convert.ToString(flow.Price);


            List<Flowers> u = Base.BD.Flowers.Where(x => x.Id_Flower == flow.Id_Flower).ToList();
            if (flow.Pfoto_flower != null)
            {
                byte[] Bar = u[u.Count - 1].Pfoto_flower;
                showImage(Bar, pfoto_flower_add);

            }
           
        }
        public Add_flower()
        {

            InitializeComponent();
            
        }

        private byte[] photo()
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();  // создаем диалоговое окно
                                                            //OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);  // выбор папки для открытия
                OFD.ShowDialog();  // открываем диалоговое окно             
                path = OFD.FileName;  // считываем путь выбранного изображения

                System.Drawing.Image SDI = System.Drawing.Image.FromFile(path);  // создаем объект для загрузки изображения в базу
                ImageConverter IC = new ImageConverter();  // создаем конвертер для перевода картинки в двоичный формат
                Barray_flower = (byte[])IC.ConvertTo(SDI, typeof(byte[]));  // создаем байтовый массив для хранения картинки
                showImage(Barray_flower, pfoto_flower_add);
                return Barray_flower;
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
                return null;
            }
        }
        private void add_photo_flower_Click(object sender, RoutedEventArgs e)
        {


            photo();
        }
        private void add_flower_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Вы точно хотите добавить этот цветок?", "Вопрос", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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
                        if (flagUpdate == true && path == null)
                        {
                            Barray_flower = flow.Pfoto_flower;
                        }
                        flow.Name_flower = add_name_flower.Text;
                        flow.Kolvo = Convert.ToInt32(add_kolvo_flower.Text);
                        flow.Price = Convert.ToInt32(add_price_flower.Text);
                        flow.Pfoto_flower = Barray_flower;
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
            else
            {

            }

        }
     

        private void Nazad_flower_Click(object sender, RoutedEventArgs e)
        {
            ClassGlav.Admin.Navigate(new Flover());
        }
    }
}
