using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalculator
{
    public class FoodDailyValueCalculator
    {
        private Food? _food;
        private double _dailyCalories;
        public DailyValue Calculate(Food food, double dailyCalories)
        {
            if (dailyCalories == 0)
            {
                throw new InvalidDailyCaloriesException();
            }
            _food = food;
            _dailyCalories = dailyCalories;

            return new DailyValue
            {
                Calories = (int)CalculateCalories(),
                Fats = CalculateFats()
            };
        }
        private double CalculateFats()
        {
            var dailyFatValue = FoodConstants.FatPerCalorie * _dailyCalories;
            return _food.Fats / dailyFatValue;
        }

        private double CalculateCalories()
        {
            return _food.Calories / _dailyCalories;
        }
    }
}
