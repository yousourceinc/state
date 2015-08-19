using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouSource.State
{
    class Program
    {
        static void Main(string[] args)
        {
            var light = new TrafficLight();
            light.Start();

            Console.ReadLine(); 
        }
    }
}
