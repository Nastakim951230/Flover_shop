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

namespace flover_shop
{
    /// <summary>
    /// Логика взаимодействия для Admin_User.xaml
    /// </summary>
    public partial class Admin_User 
    {
        public Admin_User()
        {
            InitializeComponent();
            Admin_user.ItemsSource = Base.BD.Users.ToList();
        }

        private void Searc_Click(object sender, RoutedEventArgs e)
        {
            string poisk = "";
            
            switch (Poisk.SelectedIndex)
            {
                case 0:
                    {

                      
                        
                        Admin_user.ItemsSource = Base.BD.Users.Where(s => s.Surname.ToLower().Contains(TextSearc.Text.ToLower())).ToList();
                    }
                    break;
                case 1:
                    {
                        poisk = TextSearc.Text;
                        Admin_user.ItemsSource = Base.BD.Users.Where(s => s.Name.ToLower().Contains(TextSearc.Text.ToLower())).ToList();
                    }
                    break;
                case 2:
                    {
                        poisk = TextSearc.Text;
                        Admin_user.ItemsSource = Base.BD.Users.Where(s => s.Otchestvo.ToLower().Contains(TextSearc.Text.ToLower())).ToList();
                    }
                    break;
                case 3:
                    {
                        poisk = TextSearc.Text;
                        Admin_user.ItemsSource = Base.BD.Users.Where(s => s.Login.ToLower().Contains(TextSearc.Text.ToLower())).ToList();
                    }
                    break;
                case 4:
                    {
                        poisk = TextSearc.Text;
                        Admin_user.ItemsSource = Base.BD.Users.Where(s => s.Floor_gender.Floor.ToLower().Contains(TextSearc.Text.ToLower())).ToList();

                    }
                    break;
                
                 
                case 5:
                    {
                        poisk = TextSearc.Text;
                        Admin_user.ItemsSource = Base.BD.Users.Where(s => s.Role_user_admin.Role.ToLower().Contains(TextSearc.Text.ToLower())).ToList();
                    }
                    break;
            }
        }

      

        private void cmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbGender.SelectedIndex == 0)
            {
                Admin_user.ItemsSource = Base.BD.Users.Where(s => s.Floor == 2).ToList();
            }
            if (cmbGender.SelectedIndex == 1)
            {
                Admin_user.ItemsSource = Base.BD.Users.Where(s => s.Floor == 1).ToList();
            }
        }

        private void SurnameFilte_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(SurnameFilte.SelectedIndex == 0)
            {
                Admin_user.ItemsSource = Base.BD.Users.OrderByDescending(s => s.Surname).ToList();
            }
            if(SurnameFilte.SelectedIndex == 1)
            {
                Admin_user.ItemsSource = Base.BD.Users.OrderBy(s => s.Surname).ToList();
            }
        }

        private void Viewbd_Click(object sender, RoutedEventArgs e)
        {
            Admin_user.ItemsSource = Base.BD.Users.ToList();
            TextSearc.Text = "";
        }

        private void Add_users_Click(object sender, RoutedEventArgs e)
        {
           
            ClassGlav.perehod.Navigate(new Registratsia());
        }


        private void btnDeletUser_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить этого пользователя?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;  // получаем доступ к Button из шаблона
                int index = Convert.ToInt32(btn.Uid);  // получаем числовой Uid элемента списка (в разметке предварительно нужно связать номер ячейки с номером кота в базе данных)


                // создаем объект, который содержит информацию о коте, который нужно удалить
                Users user = Base.BD.Users.FirstOrDefault(x => x.ID == index);

                Base.BD.Users.Remove(user); // удаление кота из базы            
                Base.BD.SaveChanges();  // сохранение изменений в базе данных

                ClassGlav.Admin.Navigate(new Admin_User());
            }
            else
            {
                
            }
           
        }
    }
}
