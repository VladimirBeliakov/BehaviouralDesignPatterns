using System;
using Factory.IngredientFactory;
using Factory.Pizzas;
using Factory.Pizzas.SyracusePizzas;

namespace Factory.PizzaFactories
{
	public class SyracusePizzaFactory : IPizzaFactory
	{
		private readonly SyracuseIngredientFactory _ingredientFactory = new SyracuseIngredientFactory();
		
		public Pizza CreatePizza(PizzaStyle pizzaStyleType)
		{
			switch (pizzaStyleType)
			{
				case PizzaStyle.Veggie:
					return new VeggiePizza(_ingredientFactory);
				case PizzaStyle.Street:
					return new StreetPizza(_ingredientFactory);
				case PizzaStyle.Mushroom:
					return new MushroomPizza(_ingredientFactory);
				case PizzaStyle.Cheese:
					return new CheesePizza(_ingredientFactory);
				case PizzaStyle.Greek:
					return new GreekPizza(_ingredientFactory);
				case PizzaStyle.Pepperoni:
					return new PepperoniPizza(_ingredientFactory);
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}