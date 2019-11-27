using Factory.IngredientFactory;

namespace Factory.Pizzas
{
    public class PepperoniPizza : Pizza
    {
        private readonly IIngredientFactory _ingredientFactory;
        
        public PepperoniPizza(IIngredientFactory ingredientFactory)
        {
            _ingredientFactory = ingredientFactory;
        }

        public override void Prepare()
        {
            Dough = _ingredientFactory.CreateDough();
            Cheese = _ingredientFactory.CreateCheese();
            Sauce = _ingredientFactory.CreateSauce();
            Pepperoni = _ingredientFactory.CreatePepperoni();
        }
    }
}