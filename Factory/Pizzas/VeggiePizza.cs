using Factory.IngredientFactory;

namespace Factory.Pizzas
{
	internal class VeggiePizza : Pizza
	{
		private readonly IIngredientFactory _ingredientFactory;

		public VeggiePizza(IIngredientFactory ingredientFactory)
		{
			_ingredientFactory = ingredientFactory;
		}

		public override void Prepare()
		{
			Dough = _ingredientFactory.CreateDough();
			Cheese = _ingredientFactory.CreateCheese();
			Sauce = _ingredientFactory.CreateSauce();
			Veggie = _ingredientFactory.CreateVeggie();
		}
	}
}