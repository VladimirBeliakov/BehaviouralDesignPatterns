using System;
using System.Collections.Generic;
using Factory;
using Factory.IngredientFactory;
using Factory.PizzaFactories;
using Factory.Pizzas;
using Factory.Stores;
using Iterator;

namespace Program
{
	internal static class Program
	{
		public static void Main(string[] args)
		{
//			runIterator();
			runFactory();
		}

		private static void runIterator()
		{
			var stringCollection =
				new StringCollection("item one", "item two", "item three");

			foreach (var item in stringCollection)
				Console.WriteLine(item);
		}

		private static void runFactory()
		{
			var pizzaStore = new PizzaStore(new PizzaFactory(new SyracuseIngredientFactory()));

			var pizza = pizzaStore.OrderPizza(PizzaStyle.Pepperoni);
		}
	}
}