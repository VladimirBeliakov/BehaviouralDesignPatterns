using System;
using Factory.IngredientFactory;
using Factory.Pizzas;

namespace Factory.PizzaFactories
{
    public class PizzaFactory : IPizzaFactory
    {
        private readonly IIngredientFactory _ingredientFactory;

        public PizzaFactory(IIngredientFactory ingredientFactory)
        {
            _ingredientFactory = ingredientFactory;
        }

        public Pizza CreatePizza(PizzaStyle pizzaStyleType)
        {
            switch (pizzaStyleType)
            {
                case PizzaStyle.Pepperoni:
                    return new PepperoniPizza(_ingredientFactory);
                case PizzaStyle.Cheese:
                    return new CheesePizza(_ingredientFactory);
                case PizzaStyle.Greek:
                    return new GreekPizza(_ingredientFactory);
                case PizzaStyle.Mushroom:
                    return new MushroomPizza(_ingredientFactory);
                case PizzaStyle.Street:
                    return new StreetPizza(_ingredientFactory);
                case PizzaStyle.Veggie:
                    return new VeggiePizza(_ingredientFactory);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}