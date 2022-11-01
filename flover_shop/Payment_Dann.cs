using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace flover_shop
{
    public partial class Payment
    {
        public string Data_zakaz
        {
            get
            {
                String s = String.Format("Дата оформления: {0:dd.MM.yyyy}", Date_of_registration);
                String k = String.Format("Срок заказа:{0:dd.MM.yyyy}", Order_term);
                return ""+s+"\n"+k+"";
            }
        }
        public SolidColorBrush StageOfWorkColor
        {

            get
            {
                var brushConverter = new BrushConverter();

                if (Stage_of_work == 0)
                {
                    return (SolidColorBrush)(Brush)brushConverter.ConvertFrom("#FFF9DFF5");
                }
                else if (Stage_of_work == 1)
                {
                    return (SolidColorBrush)(Brush)brushConverter.ConvertFrom("#FFF7F4A6");
                }
                else
                {
                    return null;

                }

            }
        }
    }
   
}
