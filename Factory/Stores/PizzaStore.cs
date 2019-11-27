using Factory.PizzaFactories;
using Factory.Pizzas;

namespace Factory.Stores
{
	public class PizzaStore
	{
		private readonly IPizzaFactory _pizzaFactory;

		public PizzaStore(IPizzaFactory pizzaFactory)
		{
			_pizzaFactory = pizzaFactory;
		}
		
		public Pizza OrderPizza(PizzaStyle pizzaStyleType)
		{
			var pizza = CreatePizza(pizzaStyleType);
			
			pizza.Prepare();
			pizza.Bake();
			pizza.Cut();
			pizza.Box();

			return pizza;
		}

		protected Pizza CreatePizza(PizzaStyle pizzaStyle)
		{
			return _pizzaFactory.CreatePizza(pizzaStyle);
		}
	}
}