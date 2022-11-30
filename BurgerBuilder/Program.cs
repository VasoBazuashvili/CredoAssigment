using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurgerBuilder;


namespace BurgerBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            
            while (true)
            {
                Console.Write("1. Build Burger.\n2. Exit.\n");
                var answer = Console.ReadLine();
                Console.ReadKey();
                Console.Clear();
                if (answer == "1" || answer == "Build Burger")
                {
                    BurgerBuilder burgerBuilder = new BurgerBuilder();
                    var burger1 = burgerBuilder.Start().WithBun().WithLettuce().WithCheese().WithPickles().Build();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else if (answer == "2" || answer == "Exit")
                {
                    break;
                }
                
                else
                {
                    Console.Write("Invalid command.\n");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

            }
            Console.ReadLine();
        }
        
    }
}
