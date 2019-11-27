using Factory.IngredientFactory;

namespace Factory.Pizzas
{
    public class GreekPizza : Pizza
    {
        private readonly IIngredientFactory _ingredientFactory;

        public GreekPizza(IIngredientFactory ingredientFactory)
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