using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Password.xaml
    /// </summary>
    public partial class Password : Window
    {
        Users users;
        int id;
        
        public Password(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        public bool isFormPassword(string a)
        {
            Regex r = new Regex("(?=.*?[A-Z])(?=(.*?[a-z]){3,})(?=(.*?[0-9]){2,})(?=.*?[#?!@$%^&*-]).{8,}");
            if (r.IsMatch(a))
            {
                return true;
            }
            else
            {
                string[] str = new string[5];
                str[0] = "(?=.*?[A-Z])";
                str[1] = "(?=(.*?[a-z]){3,})";
                str[2] = "(?=(.*?[0-9]){2,})";
                str[3] = "(?=.*?[#?!@$%^&*-])";
                str[4] = ".{8,}";
                for (int i = 0; i < str.Length; i++)
                {
                    string st = str[i];
                    r = new Regex(st);
                    if (r.IsMatch(a))
                    {

                    }
                    else
                    {
                        if (i == 0)
                        {
                            MessageBox.Show("В пароле должно быть хотябы не менее 1 заглавного латинского символа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        }
                        else if (i == 1)
                        {
                            MessageBox.Show("В пароле должно быть хотябы не менее 3 строчных латинских символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else if (i == 2)
                        {
                            MessageBox.Show("В пароле должно быть хотябы не менее 2 цифры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else if (i == 3)
                        {
                            MessageBox.Show("В пароле должно быть хотябы не менее 1 спец символов (#?!@$%^&*-)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else if (i == 4)
                        {
                            MessageBox.Show("Длина пароля должна быть не менее 8 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }
                }
                return false;
            }
        }
        public bool PasswordStar(string a)
        {
            List<Users> use = Base.BD.Users.Where(x => x.ID == id).ToList();
            foreach (Users u in use)
            {
                users = u;
            }
            string parol = password.HasPassword(tbStParol.Text);
            if (users.Password==parol)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Пароль не совпадает", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public bool PasswordNew(string a, string b)
        {
            if(a == b)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Новый пароль не совпадает", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        private void btnPassword_Click(object sender, RoutedEventArgs e)
        {

            if (PasswordStar(tbStParol.Text))
            {
                string parolNew1 = password.HasPassword(tbNew2Parol.Password.ToString());
                string parolNew2 = password.HasPassword(tbNewParol.Password.ToString());
                if (PasswordNew(parolNew2, parolNew1))
                {
                    string parol = tbNew2Parol.Password.ToString();
                    if (isFormPassword(parol))
                    {
                        
                        users.Password = parolNew2;
                        Base.BD.SaveChanges();  // сохраняем изменения в БД
                        this.Close();
                    }
                }
            }
            
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
