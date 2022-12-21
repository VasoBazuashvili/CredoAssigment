using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalculator
{ 
    public class Food
    {
        public double Calories { get; set; }
        public double Fats { get; set; }
        public Food(double calories, double fats)
        {
            Calories = calories;
            Fats = fats;
        }
    }
}
