using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfratProject.ServiceReference2;

namespace EfratProject
{
    internal class Global
    {
        public static Service1Client sharat = new Service1Client();


        public static customers CustomerEnter;// המשתמש שנכנס כרגע
        public static List<hazmana> recepit = new List<hazmana>();
    }
}
