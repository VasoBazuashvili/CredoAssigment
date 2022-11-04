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

            Console.WriteLine("Hello");
            //var n = new
            //{
            //    english = "Welcome",
            //    dutch = "zdarova",
            //};
            //Console.WriteLine(n.dutch);
            
            //Calc _calculator = new Calc();
            //dynamic x = 5;
            //x = 10;
            //Console.WriteLine(x);
            // object y = "vasulika";
            //y = "ladulika";
            
            
           

            //Calculator Program
            //try
            //{
            //    double num1 = 0;
            //    double num2 = 0;

            //    Console.WriteLine("-------------");
            //    Console.WriteLine("Calculato Program");
            //    Console.WriteLine("--------------");
            //    Console.WriteLine("Enter first number: ");

            //    num1 = Convert.ToDouble(Console.ReadLine());
            //    Console.WriteLine("Enter second number: ");
            //    num2 = Convert.ToDouble(Console.ReadLine());
            //    Console.WriteLine("Enter Math operation: ");

            //    Console.WriteLine("\t+ : Add");
            //    Console.WriteLine("\t- : Subtract");
            //    Console.WriteLine("\t* : Multiply");
            //    Console.WriteLine("\t/ : Divide");
            //    Console.Write("Enter Math operation ");

            //    switch (Console.ReadLine())
            //    {
            //        case "+":

            //            Console.WriteLine(num1 + num2);
            //            break;
            //        case "-":

            //            Console.WriteLine(num1 - num2);
            //            break;
            //        case "*":

            //            Console.WriteLine(num1 * num2);
            //            break;
            //        case "/":

            //            Console.WriteLine( num1 / num2);
            //            break;
            //        default:
            //            Console.WriteLine("That was not a valid option");
            //            break;
            //    }
            //    if(num2 == 0)
            //    {
            //        Console.WriteLine("Cannot divide by zero");
            //    }
            //}
            //catch(DivideByZeroException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //catch(FormatException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            Console.ReadLine();

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter first number:");
                var n1Text = Console.ReadLine();

                if (!decimal.TryParse(n1Text, out var n1))
                {
                    Console.WriteLine($"{n1Text} is not a number");
                    continue;
                }

                Console.Write("Enter second number:");
                var n2Text = Console.ReadLine();

                if (!decimal.TryParse(n2Text, out var n2))
                {
                    Console.WriteLine($"{n2Text} is not a number");
                    continue;
                }

                Console.Write("Enter Math operation (+ - * /:");
                var mathOperation = Console.ReadLine();

                if (mathOperation == "+")
                {
                    Console.WriteLine($"{n1} + {n2} = {n1 + n2}");
                    continue;
                }

                if (mathOperation == "-")
                {
                    Console.WriteLine($"{n1} - {n2} = {n1 - n2}");
                    continue;
                }

                if (mathOperation == "*")
                {
                    Console.WriteLine($"{n1} * {n2} = {n1 * n2}");
                    continue;
                }

                if (mathOperation == "/")
                {
                    if (n2 == 0)
                    {
                        Console.WriteLine("Cannot divide by zero");
                        continue;
                    }

                    Console.WriteLine($"{n1} / {n2} = {n1 / n2}");
                }
            }
            

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
   
    
        //public static string Greet(string language)     {
        //    // Happy Codding :)


        //    var MyObject = new
        //    {

        //        english = "Welcome",
        //        czech = "Vitejte",
        //        danish = "Velkomst",
        //        dutch = "Welkom",
        //        estonian = "Tere tulemast",
        //        finnish = "Tervetuloa",
        //        flemish = "Welgekomen",
        //        french = "Bienvenue",
        //        german = "Willkommen",
        //        irish = "Failte",
        //        italian = "Benvenuto",
        //        latvian = "Gaidits",
        //        lithuanian = "Laukiamas",
        //        polish = "Witamy",
        //        spanish = "Bienvenido",
        //        swedish = "Valkommen",
        //        welsh = "Croeso"

                

        //};


        //    Console.WriteLine(object.);
        //}
       

}
