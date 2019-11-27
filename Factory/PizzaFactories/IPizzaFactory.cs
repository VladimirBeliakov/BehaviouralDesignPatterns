using Factory.Pizzas;

namespace Factory.PizzaFactories
{
    public interface IPizzaFactory
    {
        Pizza CreatePizza(PizzaStyle pizzaStyleType);
    }
}