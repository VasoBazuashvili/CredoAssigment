using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductProject.Models
{

    public class Product
    {
        public string Name { get;  private set; }
        public string Category { get; private set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }

        public Product(
            string name,
            string category,
            decimal price,
            double quantity)
        {
            ValidateName(name);
            ValidateCategory(category);
            ValidatePrice(price);
            ValidateQuantity(quantity);

            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
        }
        private void ValidateQuantity(double quantity)
        {
            // ...
        }

        private void ValidatePrice(decimal price)
        {
            if (price <= 0)
            {
                throw new ArgumentException(nameof(price));
            }
        }

        private void ValidateCategory(string category)
        {
            // ...
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }
        }

        public void Update(decimal price, double quantity)
        {
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Name: {Name} Category: {Category} Price: {Price} Quantity: {Quantity}";
        }
    }
}
