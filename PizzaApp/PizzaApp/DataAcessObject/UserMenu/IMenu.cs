using PizzaApp.DataBaseModels;

namespace PizzaApp.DataAcessObject.UserMenu
{
    public interface IMenu
    {
        Task<IEnumerable<PizzaInformation>>  ReadAllPizza();

        IEnumerable<PizzaInformation> FilterPizza(string pizzaname);
    }
}
