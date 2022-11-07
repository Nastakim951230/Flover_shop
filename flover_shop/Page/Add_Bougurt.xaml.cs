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
        Flowers flow;  // объект, в котором будет хранится данные о новом или отредактированном коте
        bool flagUpdate = false; // для определения, создаем мы новый объект или редактируем старый
        string path = null;  // путь к картинке/

        public void uploadFields()  // метод для заполнения списков
        {
            Flower_bougurt.ItemsSource = Base.BD.Flowers.ToList();

        }

        public Add_Bougurt()
        {
            InitializeComponent();
            uploadFields();
        }

        private void add_photo_bougurt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void add_bougurt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
