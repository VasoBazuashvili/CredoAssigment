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
            Console.WriteLine("hello");
            BurgerBuilder burgerBuilder = new BurgerBuilder();
            var burger1 =  burgerBuilder.Start().WithBun().WithLettuce().WithCheese().WithPickles().Build();
            Console.ReadLine();
        }
        
    }
}
