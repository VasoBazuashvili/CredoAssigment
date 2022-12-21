using FoodCalculator;
using NUnit.Framework;

namespace FoodCalcTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(2400, 0.0396)]
        [TestCase(4800, 0.0198)]
        [TestCase(1000, 0.095)]
        public void ShouldCalculateCorrectCaloriesPercent(int dailyCalories, double expectedCaloriesPercent)
        {
            var calculator = new FoodDailyValueCalculator();
            var apple = new Apple();
            var dailyValue = calculator.Calculate(apple, 2400);
            Assert.AreEqual(expectedCaloriesPercent, dailyValue.Calories, 0.001);
        }
        [TestCase(2400, 0.3, 0.0038)]
        [TestCase(2400, 5, 0.0641)]
        public void ShouldCalculateCorrectFatsPercent(
        int dailyCalories, double fats, double expectedFatsPercent)
        {
            var calculator = new FoodDailyValueCalculator();
            var food = new Food(1, fats);
            var dailyValue = calculator.Calculate(food, dailyCalories);

            Assert.AreEqual(expectedFatsPercent, dailyValue.Fats, 0.0001);
        }

    }
}