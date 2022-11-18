using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flover_shop
{
    public partial class Bouquet
    {
        public static System.Windows.Visibility Btn_Admin=System.Windows.Visibility.Collapsed;
        public static System.Windows.Visibility btn_admin
        {
            get
            {
                return Btn_Admin;
            }
            set
            {
                Btn_Admin=value;
            }
        }


        public string name_bouquet
        {
            get
            {
                return "Букет '" + Name_bouquet + "'";
            }
        }

        public string price_bouquet
        {
            get
            {
                return "Цена: " + Price+ " руб.";
            }
        }
    }
}
