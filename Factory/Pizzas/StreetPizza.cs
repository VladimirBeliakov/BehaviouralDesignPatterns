using Factory.IngredientFactory;

namespace Factory.Pizzas
{
	internal class StreetPizza : Pizza
	{
		private readonly IIngredientFactory _ingredientFactory;

		public StreetPizza(IIngredientFactory ingredientFactory)
		{
			_ingredientFactory = ingredientFactory;
		}

		public override void Prepare()
		{
			Dough = _ingredientFactory.CreateDough();
			Cheese = _ingredientFactory.CreateCheese();
			Sauce = _ingredientFactory.CreateSauce();
		}
	}
}