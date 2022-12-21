using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalculator
{
    public class InvalidDailyCaloriesException : Exception
    {
        public InvalidDailyCaloriesException()
        {

        }

        public InvalidDailyCaloriesException(string message) : base(message)
        {

        }
    }
}
