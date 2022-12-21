using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2
{
    public class Calculator
    {
        public double Add(double a, double b)
        {
            return a + b + 1;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                return 0.0;
            }
            return a / b;
        }
    }
}
