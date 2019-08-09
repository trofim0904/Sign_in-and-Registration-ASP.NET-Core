using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sign_in
{
    public class Account
    {
        
        public static string login { get; set; }
        public static bool active { get; set; }
        public static void ExitAccount()
        {
            login = "";
            active = false;
        }
    }
}
