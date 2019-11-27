using Factory.Ingredients;
using Factory.Ingredients.ChampaignStyleIngredients;

namespace Factory.IngredientFactory
{
	public class ChampaignIngredientFactory : IIngredientFactory
	{
		public Dough CreateDough()
		{
			return new ChampaignStyleDough();
		}

		public Sauce CreateSauce()
		{
			return new ChampaignStyleSauce();
		}

		public Cheese CreateCheese()
		{
			return new ChampaignStyleCheese();
		}

		public Veggie CreateVeggie()
		{
			return new ChampaignStyleVeggie();
		}

		public Pepperoni CreatePepperoni()
		{
			return new ChampaignStylePepperoni();
		}

		public Mushroom CreateMushrooms()
		{
			return new ChampaignStyleMushroom();
		}
	}
}