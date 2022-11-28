using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurgerBuilder;

namespace BurgerBuilder
{
    public class Burger
    {
        public List<string> Ingredients { get; set; }
        public Burger()
        {
            Ingredients = new List<string>();
        }
    }
}
