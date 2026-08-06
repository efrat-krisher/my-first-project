 using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HostProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceHost service = new ServiceHost(typeof(ServerProject.Service1));
            service.Open();
            Console.WriteLine("this is my server , run now");
            Console.ReadLine();
        }
    }
}

