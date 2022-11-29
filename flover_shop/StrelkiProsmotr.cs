using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flover_shop
{
    class StrelkiProsmotr: INotifyPropertyChanged // класс, который наследуется от интерфейса INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;  //событие, для изменения значения одного из массивов свойств, описанных ниже
        static int kolvo = 5; //количество объектов для отображения (1 2 3 4 5)
        public int[] NPage { get; set; } = new int[kolvo];// массив с номерами отображаемых страниц    
        public string[] Visible { get; set; } = new string[kolvo];//массив свойст, отвечающий за видимость номера страницы, Visible - видимый, Hidden - скрытый
        public string[] Bold { get; set; } = new string[kolvo];//массив свойств, отвечающий за выделение номера текущей страницы

        int sohrkolvo; // переменная, в которой буде храниться количество страниц
        public int CountPages//свойство в котором хранится общее кол-во страц, при изменении данного свойства будет определяться, скрыт будет номер той или итой страницы или нет (в зависимости об общего кол-ва записей в списке) 
        {
            get => sohrkolvo;
            set
            {
                sohrkolvo = value;
                for (int i = 1; i < kolvo; i++)//цикл для определения видимости номеров страниц
                {
                    if (CountPages <= i)
                    {
                        Visible[i] = "Hidden";//если страниц меньше, чем кнопок - скрываем лишние
                    }
                    else
                    {
                        Visible[i] = "Visible";// а если их опять стало больше, то показываем назад
                    }
                }
            }
        }
        int countpage;//количество записей на странице
        public int CountPage  //свойство, в котором хранится количество записей на странице, при изменении данного свойства будет изменяться общее количесво страниц для отображения
        {
            get => countpage;
            set
            {
                countpage = value;
                if (Countlist % value == 0)
                {
                    CountPages = Countlist / value;//определение количества страниц
                }
                else
                {
                    CountPages = Countlist / value + 1;//в случае нецелого числа прибавляем 1 к итоговому количеству страниц
                }
            }
        }
        int countlist; // количество записей в списке

        public int Countlist //свойство, в котором хранится общее количество записей в списке, при изменении данного свойства будет изменяться общее количесво страниц для отображения
        {
            get => countlist;
            set
            {
                countlist = value;
                if (value % CountPage == 0)
                {
                    CountPages = value / CountPage;//определение количества страниц
                }
                else
                {
                    CountPages = 1 + value / CountPage;
                }
            }
        }


        int str;//текущая страница
        public int CurrentPage  // свойство, в котором будет хранится текущая страница, при изменении которого будет меняться вся отрисовка меню с номерами страниц
        {
            get => str;
            set
            {
                str = value;
                if (str < 1)
                {
                    str = 1;
                }
                if (str >= CountPages)
                {
                    str = CountPages;
                }
                //отрисовка меню с номерами страниц, рассмотрим три возможных случая                            
                for (int i = 0; i < kolvo; i++)
                {
                    if (str < (1 + kolvo / 2) || CountPages < kolvo) NPage[i] = i + 1;//если страница в начале списка
                    else if (str > CountPages - (kolvo / 2 + 1)) NPage[i] = CountPages - (kolvo - 1) + i;//если страница в конце списка
                    else NPage[i] = str + i - (kolvo / 2);//если страница в середине списка
                }
                for (int i = 0; i < kolvo; i++)//выделяем активную страницу жирным
                {
                    if (NPage[i] == str) Bold[i] = "ExtraBold";
                    else Bold[i] = "Regular";
                }
                //вызываем созбытие, связанное с изменением свойств, используемых в привязке на странице
                PropertyChanged(this, new PropertyChangedEventArgs("NPage"));
                PropertyChanged(this, new PropertyChangedEventArgs("Visible"));
                PropertyChanged(this, new PropertyChangedEventArgs("Bold"));
            }
        }

        public StrelkiProsmotr() // контруктор
        {
            for (int i = 0; i < kolvo; i++)  // показываем исходное меню ( 1 2 3 4 5)
            {
                if (i == 0)
                {
                    Visible[i] = "Visible";
                    Bold[i] = "ExtraBold";
                }
                else
                {
                    Visible[i] = "Hidden";
                    Bold[i] = "Regular";
                }

                NPage[i] = i + 1;

            }
            str = 1;  // по умолчанию 1-ая страница будет текущей
            countlist = 1;  // по умолчанию в общем списке будет только одна запись
        }
    }
}
