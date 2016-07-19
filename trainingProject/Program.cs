using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trainingProject
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Rational first = new Rational(2, 5);
            Rational second = new Rational(2, 5);
            Console.WriteLine((first == second).ToString());
            Console.WriteLine((first + 2.5).ToString());
            Console.ReadKey();
        }
    }
}



