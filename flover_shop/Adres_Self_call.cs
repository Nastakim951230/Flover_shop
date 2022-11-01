using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flover_shop
{
    public partial class Self_call
    {
        public string Adres_self_call
        {
            get
            {
                return "Адрес:\n  г. " + City_self_call + "\n ул. " + Street_self_call + "\n дом " + Home_self_call + "";
            }
        }
    }
}
