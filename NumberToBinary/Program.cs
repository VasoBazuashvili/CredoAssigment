using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ToBinary(2));
            Console.WriteLine(ToBinary(256));
            Console.WriteLine(ToBinary(33));
            Console.WriteLine(ToBinary(999));
        }
        static string ToBinary(int number)
        {
            return Convert.ToString(number, 2);
        }
    }
}
