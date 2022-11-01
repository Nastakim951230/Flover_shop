using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flover_shop
{
    public partial class  Delivery
    {
        public string Adres_delivery
        {
            get
            {
                return "Адрес:\n  г. " +City_delivery+ "\n ул. "+Street_delivery+"\n дом "+Home_delivery+" кв."+Kv_delivery+"";
            }
        }
    }
}
