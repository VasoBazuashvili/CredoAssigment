using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurgerBuilder;

namespace BurgerBuilder
{
    public class BurgerBuilder
    {
        private Burger _burger;
        public BurgerBuilder Start()
        {
            _burger = new Burger();
            return this;
        }
        public BurgerBuilder WithBun()
        {
            _burger.Ingredients.Add("Bun");
            return this;
        }
        public BurgerBuilder WithLettuce()
        {
            _burger.Ingredients.Add("Lettuce");
            return this;
        }
        public BurgerBuilder WithCheese()
        {
            _burger.Ingredients.Add("Cheese");
            return this;
        }

        public BurgerBuilder WithPickles()
        {
            _burger.Ingredients.Add("Pickles");
            return this;
        }

        public BurgerBuilder WithBeef()
        {
            _burger.Ingredients.Add("Beef");
            return this;
        }

        public BurgerBuilder WithChicken()
        {
            _burger.Ingredients.Add("Chicken");
            return this;
        }
        public Burger Build()
        {
            return _burger;
        }
    }
}
