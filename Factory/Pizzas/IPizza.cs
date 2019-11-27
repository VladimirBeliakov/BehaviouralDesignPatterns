using System;
using Factory.Ingredients;

namespace Factory.Pizzas
{
    public abstract class Pizza
    {
        protected Dough Dough;
        protected Sauce Sauce;
        protected Cheese Cheese;
        protected Mushroom Mushroom;
        protected Pepperoni Pepperoni;
        protected Veggie Veggie;
        
        public abstract void Prepare();

        public void Bake()
        {
            Console.WriteLine("Baking the pizza");
        }

        public void Cut()
        {
            Console.WriteLine("Cutting the pizza");
        }

        public void Box()
        {
            Console.WriteLine("Boxing the pizza");
        }
    }
}