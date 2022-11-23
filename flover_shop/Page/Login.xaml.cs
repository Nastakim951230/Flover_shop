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
using System.Windows.Shapes;

namespace flover_shop.Page
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Users users;
        int id;
        public Login(int id)
        {
            InitializeComponent();
            this.id = id;
            List<Users> use = Base.BD.Users.Where(x => x.ID == id).ToList();
            foreach (Users u in use)
            {
                users = u;
            }
            tbLogin.Text = users.Login;
        }
        public bool isFormLogin(string a)
        {
            Users users = Base.BD.Users.FirstOrDefault(l => l.Login == a);
            if (users == null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Данный логин нельзя использовать, выберите другой", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (isFormLogin(tbLogin.Text))
            {
                users.Login = tbLogin.Text;
                Base.BD.SaveChanges();  // сохраняем изменения в БД
                this.Close();
            }
        }

        private void NEXT_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
