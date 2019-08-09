using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sign_in
{
    public class UserModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
    }
}
