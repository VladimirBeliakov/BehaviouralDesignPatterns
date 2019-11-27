using Factory.IngredientFactory;

namespace Factory.Pizzas
{
	internal class MushroomPizza : Pizza
	{
		private readonly IIngredientFactory _ingredientFactory;

		public MushroomPizza(IIngredientFactory ingredientFactory)
		{
			_ingredientFactory = ingredientFactory;
		}

		public override void Prepare()
		{
			Dough = _ingredientFactory.CreateDough();
			Cheese = _ingredientFactory.CreateCheese();
			Sauce = _ingredientFactory.CreateSauce();
			Mushroom = _ingredientFactory.CreateMushrooms();
		}
	}
}