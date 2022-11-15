using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ProductProject.Models;

namespace ProductProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var warehouse = new Warehouse();
            var exit = false;
            while (!exit)
            {
                PrintMenu();
            }

            void PrintMenu()
            {
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Show all");
                Console.WriteLine("5. Exit");

                Console.Write("Please enter the menu index: ");
                var menuIndex = Console.ReadLine();

                if (menuIndex == "1")
                {
                    Register();
                }
                else if (menuIndex == "2")
                {
                    Update();
                }
                else if (menuIndex == "3")
                {
                    Delete();
                }
                else if (menuIndex == "4")
                {
                    ShowAll();
                }
                else if (menuIndex == "5")
                {
                    exit = true;
                }
            }


            void Register()
            {
                Console.Write("Name: ");
                var productName = Console.ReadLine();

                Console.Write("Category: ");
                var category = Console.ReadLine();

                Console.Write("Price: ");
                decimal.TryParse(Console.ReadLine(), out var price);

                Console.Write("Quantity: ");
                double.TryParse(Console.ReadLine(), out var quantity);

                warehouse.Add(productName, category, price, quantity);
            }

            void Update()
            {
                Console.Write("Name: ");
                var productName = Console.ReadLine();

                Console.Write("Price: ");
                decimal.TryParse(Console.ReadLine(), out var price);

                Console.Write("Quantity: ");
                double.TryParse(Console.ReadLine(), out var quantity);

                warehouse.Update(productName, price, quantity);
            }

            void Delete()
            {
                Console.Write("Name: ");
                var productName = Console.ReadLine();
                warehouse.Delete(productName);
            }

            void ShowAll()
            {
                warehouse.ShowAll();
            }

            //var http = new HttpClient();
            //var result = await http.GetAsync(new Uri("http://localhost/calculator/add"));

            //var content = await result.Content.ReadAsStringAsync();
        }
    }
}
