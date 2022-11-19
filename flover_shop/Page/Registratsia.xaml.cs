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
using System.Text.RegularExpressions;


namespace flover_shop
{
    /// <summary>
    /// Логика взаимодействия для Registratsia.xaml
    /// </summary>
    public partial class Registratsia 
    {
        Users usersadd;
        Сlients client;// объект, в котором будет хранится данные о новом или отредактированном коте
       
        public static int id_role;
        public void uploadFields()  // метод для заполнения списков
        {
            ComboBox_Roly.ItemsSource = Base.BD.Role_user_admin.ToList();
            ComboBox_Roly.SelectedValuePath = "ID_role";
            ComboBox_Roly.DisplayMemberPath = "Role";
            ComboBox_Roly.SelectedIndex=0;
        }


       
        public Registratsia()
        {
            InitializeComponent();
            Base.BD = new Data();
            uploadFields();
            if (id_role == 1)
            {
               
                admin.Visibility=Visibility.Visible;
            }
            else
            {
                
                admin.Visibility=Visibility.Collapsed;
               
            }


        }
  
       public bool isFormEmail(string a)
        {
            Regex m = new Regex("^[-\\w.]+@([A-z0-9][-A-z0-9]+\\.)+[A-z]{2,4}$");
            if (m.IsMatch(a))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Был не правильно введен email", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
        }

        public bool isFormTelef(string a)
        {
            Regex m = new Regex("[8](\\d{10})");
            if (m.IsMatch(a))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Был не правильно введен номер телефона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
        }
        
        public bool isFormLogin(string a)
        {
            Users users = Base.BD.Users.FirstOrDefault(l => l.Login == a);
            if(users == null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Данный логин нельзя использовать, выберите другой", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
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
        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if (Surname.Text == "" || Name.Text == "" || Dateofbirth.Text == "" || Login.Text == "" || Female.IsChecked == false && Male.IsChecked == false || Password.Password.ToString() == "" || Telefon.Text == "")
            {
                MessageBox.Show("Обязательные поля не заполнены", "Ошибка", MessageBoxButton.OK);
            }
            else
            {
                if (isFormLogin(Login.Text))
                {
                    if (isFormTelef(Telefon.Text))
                    {
                        if (Email.Text != "")
                        {
                            if (isFormEmail(Email.Text))
                            {


                                string s = Password.Password.ToString();
                                if (isFormPassword(s))
                                {
                                    int gender = 0;
                                    if (Female.IsChecked == true)
                                    {
                                        gender = 1;
                                    }
                                    else if (Male.IsChecked == true)
                                    {
                                        gender = 2;
                                    }
                                    int idRole = 0;
                                    if (id_role == 1)
                                    {
                                        idRole = ComboBox_Roly.SelectedIndex + 1;
                                    }
                                    else
                                    {
                                        idRole = 2;
                                    }

                                    string parol = password.HasPassword(Password.Password.ToString());

                                  
                                        usersadd = new Users();
                                    
                                    usersadd.Surname = Surname.Text;
                                    usersadd.Name = Name.Text;
                                    usersadd.Otchestvo = Othestvo.Text;
                                    usersadd.Floor = gender;
                                    usersadd.Login= Login.Text;
                                    usersadd.Password = parol;
                                    usersadd.Role=idRole;
                                    usersadd.Date_of_Birth = (DateTime)Dateofbirth.SelectedDate;
                                
                                        Base.BD.Users.Add(usersadd);
                                    
                                   
                                    Base.BD.SaveChanges();

                                   
                                        client = new Сlients();
                                    
                                    client.id_user = usersadd.ID;
                                    client.Telefon = Telefon.Text;
                                    if (client.email == "")
                                    {
                                        client.email = null;
                                    }
                                    else
                                    {
                                        client.email = Email.Text;
                                    }
                                   
                                    client.points = 0;
                                  
                                        Base.BD.Сlients.Add(client);
                                    
                                   
                                    Base.BD.SaveChanges();
                                    MessageBox.Show("Пользователь зарегестрирован");
                                    ClassGlav.perehod.Navigate(new Input());
                                }
                            }
                        }
                        else
                        {
                            string s = Password.Password.ToString();
                            if (isFormPassword(s))
                            {
                                int gender = 0;
                                if (Female.IsChecked == true)
                                {
                                    gender = 1;
                                }
                                else if (Male.IsChecked == true)
                                {
                                    gender = 2;
                                }
                                int idRole = 0;
                                if (id_role == 1)
                                {
                                    idRole = ComboBox_Roly.SelectedIndex + 1;
                                }
                                else
                                {
                                    idRole = 2;
                                }


                                string parol = password.HasPassword(Password.Password.ToString());
                               
                                    usersadd = new Users();
                                
                                usersadd.Surname = Surname.Text;
                                usersadd.Name = Name.Text;
                                usersadd.Otchestvo = Othestvo.Text;
                                usersadd.Floor = gender;
                                usersadd.Login = Login.Text;
                                usersadd.Password = parol;
                                usersadd.Role = idRole;
                               
                                usersadd.Date_of_Birth = (DateTime)Dateofbirth.SelectedDate;
                               
                                    Base.BD.Users.Add(usersadd);
                                

                                Base.BD.SaveChanges();
                               
                                    client = new Сlients();
                                
                                client.id_user = usersadd.ID;
                                client.Telefon = Telefon.Text;
                                if(client.email=="")
                                {
                                    client.email = null;
                                }
                                else
                                {
                                    client.email = Email.Text;
                                }
                               
                               
                                client.points = 0;
                                
                                    Base.BD.Сlients.Add(client);
                                
                                Base.BD.SaveChanges();
                                MessageBox.Show("Пользователь зарегестрирован");
                                ClassGlav.perehod.GoBack();
                            }
                        }

                    }
                }

            }



        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            if (id_role == 0)
            {
                ClassGlav.perehod.Navigate(new Glavna());
                
            }
            else
            {
                ClassGlav.perehod.GoBack();
            }
           
        }

        private void Pass_Click(object sender, RoutedEventArgs e)
        {
           
        }
       
       
    }
}
