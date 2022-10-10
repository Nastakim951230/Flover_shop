using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace flover_shop
{
    internal class password
    {
        public static string HasPassword(string password)
        {
            MD5 md5 = MD5.Create();
            byte[] b= Encoding.ASCII.GetBytes(password);
            byte[] has= md5.ComputeHash(b);

            StringBuilder sb= new StringBuilder();
            foreach(var a in has)
            {
                sb.Append(a.ToString("X2"));
            }
            return Convert.ToString(sb);
        }
    }
}
