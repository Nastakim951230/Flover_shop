﻿using System;
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
    public partial class Registratsia : Page
    {
       
        public Registratsia()
        {
            InitializeComponent();
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
           

            if (Surname.Text=="" || Name.Text==""|| Dateofbirth.Text=="" || Login.Text=="" || Female.IsChecked == false && Male.IsChecked==false|| Password.Password.ToString()=="" || Telefon.Text=="")
            {
                    MessageBox.Show("Обязательные поля не заполнены", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            }
            else
            {
                string s=Password.Password.ToString();
                Regex r = new Regex("(?=.*?[A-Z])(?=(.*?[a-z]){3,})(?=(.*?[0-9]){2,})(?=.*?[#?!@$%^&*-]).{8,}");
               if(r.IsMatch(s))
                {
                    int gender=0;
                    if (Female.IsChecked==true)
                    {
                         gender = 1;
                    }
                    else if (Male.IsChecked==true)
                    {
                         gender = 2;
                    }
                   string parol = password.HasPassword(Password.Password.ToString());
                    Users users = new Users() { Surname=Surname.Text, Name=Name.Text,Otchestvo= Othestvo.Text, Floor = gender, Date_of_Birth=(DateTime)Dateofbirth.SelectedDate, Login= Login.Text, Password=parol,Role=2};
                    Base.BD.Users.Add(users);
                    Base.BD.SaveChanges();
                    

                    //Сlients client =new Сlients() { id_user=, Telefon = Telefon.Text, email =Email.Text, points=0};
                    //Base.BD.Сlients.Add(client);
                    //Base.BD.SaveChanges();
                    MessageBox.Show("Пользователь зарегестрирован"); // комментарй
                    ClassGlav.perehod.GoBack();
                }
               else
                {
                    string [] str=new string[5];
                    str[0] = "(?=.*?[A-Z])";
                    str[1] = "(?=(.*?[a-z]){3,})";
                    str[2] = "(?=(.*?[0-9]){2,})";
                    str[3] = "(?=.*?[#?!@$%^&*-])";
                    str[4] = ".{8,}";
                    for (int i=0; i<str.Length; i++)
                    {
                        string st=str[i];
                        r = new Regex(st);
                        if (r.IsMatch(s))
                        {

                        }
                        else
                        {
                            if (i==0)
                            {
                                MessageBox.Show("В пароле должно быть хотябы не менее 1 заглавного латинского символа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                            else if (i==1)
                            {
                                MessageBox.Show("В пароле должно быть хотябы не менее 3 строчных латинских символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else if (i==2)
                            {
                                MessageBox.Show("В пароле должно быть хотябы не менее 2 цифры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else if (i==3)
                            {
                                MessageBox.Show("В пароле должно быть хотябы не менее 1 спец символов (#?!@$%^&*-)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else if (i==4)
                            {
                                MessageBox.Show("Длина пароля должна быть не менее 8 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                        }
                    }
                }
            }
                
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            ClassGlav.perehod.GoBack();
        }

        private void Pass_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
