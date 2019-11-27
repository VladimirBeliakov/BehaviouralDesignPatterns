using Factory.Ingredients;

namespace Factory.IngredientFactory
{
	public interface IIngredientFactory
	{
		Dough CreateDough();
		Sauce CreateSauce();
		Cheese CreateCheese();
		Veggie CreateVeggie();
		Pepperoni CreatePepperoni();
		Mushroom CreateMushrooms();
	}
}