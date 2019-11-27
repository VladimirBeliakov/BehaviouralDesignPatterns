using Factory.IngredientFactory;

namespace Factory.Pizzas
{
    public class CheesePizza : Pizza
    {
        private readonly IIngredientFactory _ingredientFactory;

        public CheesePizza(IIngredientFactory ingredientFactory)
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