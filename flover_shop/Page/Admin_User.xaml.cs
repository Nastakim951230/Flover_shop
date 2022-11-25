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
        string vybor;
        public Admin_User()
        {
            InitializeComponent();
            Admin_user.ItemsSource = Base.BD.Users.ToList();

            List<Floor_gender> BT = Base.BD.Floor_gender.ToList();

            // программное заполнение выпадающего списка
            cmbGender.Items.Add("Без фильтрации");  // первый элемент выпадающего списка, который сбрасывает фильтрацию
            for (int i = 0; i < BT.Count; i++)  // цикл для записи в выпадающий список всех пород котов из БД
            {
                cmbGender.Items.Add(BT[i].Floor);
            }
            cmbGender.SelectedIndex = 0;
            Poisk.SelectedIndex = 0;
            SurnameFilte.SelectedIndex = 0;
        }

        void Filter()  // метод для одновременной фильтрации, поиска и сортировки
        {
            List<Users> userList = new List<Users>();  // пустой список, который далее будет заполнять элементами, удавлетворяющими условиям фильтрации, поиска и сортировки

            userList = Base.BD.Users.ToList();
           
            // поиск совпадений 
           
            if (!string.IsNullOrWhiteSpace(TextSearc.Text))  // если строка не пустая и если она не состоит из пробелов
            {
                switch (Poisk.SelectedIndex)

                {
                    case 0:
                        {
                            userList = Base.BD.Users.ToList();
                        }
                        break;
                    case 1:
                        {
                            userList = userList.Where(x => x.Surname.ToLower().Contains(TextSearc.Text.ToLower())).ToList();
                        }
                        break;
                    case 2:
                        {
                            userList = userList.Where(s => s.Name.ToLower().Contains(TextSearc.Text.ToLower())).ToList();
                        }
                        break;
                    case 3:
                        {
                            userList = userList.Where(s => s.Otchestvo.ToLower().Contains(TextSearc.Text.ToLower())).ToList();
                        }
                        break;
                    case 4:
                        {
                            userList = userList.Where(s => s.Login.ToLower().Contains(TextSearc.Text.ToLower())).ToList();
                        }
                        break;
                    case 5:
                        {
                            userList = userList.Where(s => s.Floor_gender.Floor.ToLower().Contains(TextSearc.Text.ToLower())).ToList();

                        }
                        break;


                    case 6:
                        {
                            userList = userList.Where(s => s.Role_user_admin.Role.ToLower().Contains(TextSearc.Text.ToLower())).ToList();
                        }
                        break;
                }
            }
            switch (cmbGender.SelectedIndex)
            {
                case 0:
                    {
                        userList = userList.ToList();
                    }
           break ;
                    case 1:
                    {
                        userList=userList.Where(s => s.Floor == 1).ToList();
                    }
                    break;
                case 2:
                    {
                        userList = userList.Where(s => s.Floor == 2).ToList();
                    }
                    break;
            }
           

            // сортировка
            switch (SurnameFilte.SelectedIndex)
            {
                case 0:
                    {
                        userList.Sort((x, y) => x.Surname.CompareTo(y.Surname));
                    }
                    break;
                case 1:
                    {
                        userList.Sort((x, y) => x.Surname.CompareTo(y.Surname));
                        userList.Reverse();
                    }
                    break;
            }

            Admin_user.ItemsSource = userList;
            if (userList.Count == 0)
            {
                MessageBox.Show("нет записей");
            }
            
        }


        private void Searc_Click(object sender, RoutedEventArgs e)
        {
            Filter();
        }

      

        private void cmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void SurnameFilte_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void Viewbd_Click(object sender, RoutedEventArgs e)
        {
            Admin_user.ItemsSource = Base.BD.Users.ToList();
            cmbGender.SelectedIndex = 0;
            Poisk.SelectedIndex = 0;
            SurnameFilte.SelectedIndex = 0;
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

        private void TextSearc_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}
