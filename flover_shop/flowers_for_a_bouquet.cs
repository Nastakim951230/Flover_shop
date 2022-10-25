using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace flover_shop
{
    public partial class Flowers
    {
        public string name_flowers
        {
            get
            {
                return "Название: " + Name_flower + "";
            }
        }
        public string kolvo_flower
        {
            get
            {
                return "Количество: " + Kolvo + "";
            }
        }
        public string price_flower
        {
            get
            {
                return "Цена: " + Price + " руб.";
            }
        }
        public string Itog
        {
            get
            {
                int kol=Convert.ToInt32(Kolvo);
                int price=Convert.ToInt32(Price);
                int itog = kol * price;
                return "Итог: " + itog + " руб.";
            }
        }

        public SolidColorBrush KolvoFlowerColor
        {
            
            get
            {
                var brushConverter = new BrushConverter();

                if (Kolvo == 0)
                {
                    return (SolidColorBrush)(Brush)brushConverter.ConvertFrom("#FFF7A6A6");
                }
                else if ((Kolvo > 1)&&(Kolvo <=9))
                {
                    return (SolidColorBrush)(Brush)brushConverter.ConvertFrom("#FFF7F4A6");
                }
                else
                {
                    return (SolidColorBrush)(Brush)brushConverter.ConvertFrom("#FFF9DFF5");
                    
                }

            }
        }

    }
}
