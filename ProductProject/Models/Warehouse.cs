using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductProject.Models
{
    public class Warehouse
    {
        public List<Product> Products { get; set; }
        public Warehouse()
        {
            Products = new List<Product>();
        }
        public void Add(
            string name,
            string category,
            decimal price,
            double quantity)
        {
            ValidateName(name);
            var product = new Product(
                name,
                category,
                price,
                quantity);
            Products.Add(product);
        }

        private void ValidateName(string name)
        {
            var exists = Products.Any(p => p.Name == name);
            if (exists)
            {
                throw new ArgumentException();
            }
        }

        public void Update(
            string name,
            decimal price,
            double quantity)
        {
            var product = FindByName(name);
            if (product == null)
            {
                return;
            }

            product.Price = price;
            product.Quantity = quantity;
        }

        public void Delete(string name)
        {
            var product = FindByName(name);
            if (product == null)
            {
                return;
            }

            Products.Remove(product);
        }

        public void ShowAll()
        {
            foreach (var product in Products)
            {
                Console.WriteLine(product.ToString());
            }
        }


        private Product FindByName(string name)
        {
            var product = Products.FirstOrDefault(p => p.Name == name);
            return product;
        }
    }
}
