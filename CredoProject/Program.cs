using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredoProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Calculator Program
            try
            {
                double num1 = 0;
                double num2 = 0;

                Console.WriteLine("-------------");
                Console.WriteLine("Calculato Program");
                Console.WriteLine("--------------");
                Console.WriteLine("Enter first number: ");

                num1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter second number: ");
                num2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Math operation: ");

                Console.WriteLine("\t+ : Add");
                Console.WriteLine("\t- : Subtract");
                Console.WriteLine("\t* : Multiply");
                Console.WriteLine("\t/ : Divide");
                Console.Write("Enter Math operation ");

                switch (Console.ReadLine())
                {
                    case "+":
                        
                        Console.WriteLine(num1 + num2);
                        break;
                    case "-":
                        
                        Console.WriteLine(num1 - num2);
                        break;
                    case "*":
                        
                        Console.WriteLine(num1 * num2);
                        break;
                    case "/":

                        Console.WriteLine( num1 / num2);
                        break;
                    default:
                        Console.WriteLine("That was not a valid option");
                        break;
                }
                if(num2 == 0)
                {
                    Console.WriteLine("Cannot divide by zero");
                }
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
            


        }
        //Fibonacci algorithm
        public static int Fibonacci(int n)
        {
            if ((n == 0) || (n == 1))
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }

        }
    }
}
