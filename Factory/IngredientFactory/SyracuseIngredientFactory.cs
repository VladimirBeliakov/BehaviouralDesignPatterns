using Factory.Ingredients;
using Factory.Ingredients.SyracuseStyleIngredients;

namespace Factory.IngredientFactory
{
	public class SyracuseIngredientFactory : IIngredientFactory
	{
		public Dough CreateDough()
		{
			return new SyracuseStyleDough();
		}

		public Sauce CreateSauce()
		{
			return new SyracuseStyleSauce();
		}

		public Cheese CreateCheese()
		{
			return new SyracuseStyleCheese();
		}

		public Veggie CreateVeggie()
		{
			return new SyracuseStyleVeggie();
		}

		public Pepperoni CreatePepperoni()
		{
			return new SyracuseStylePepperoni();
		}

		public Mushroom CreateMushrooms()
		{
			return new SyracuseStyleMushroom();
		}
	}
}