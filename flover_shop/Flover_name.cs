using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flover_shop
{
    public partial class Bouquet
    {
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
