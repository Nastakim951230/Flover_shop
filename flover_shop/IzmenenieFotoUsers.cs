using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flover_shop
{
    public partial class Image
    {
        public static System.Windows.Visibility Btn_image = System.Windows.Visibility.Collapsed;
        public static System.Windows.Visibility btn_image
        {
            get
            {
                return Btn_image;
            }
            set
            {
                Btn_image = value;
            }
        }
    }
}
