using PizzaApp.DataBaseModels;

namespace PizzaApp.DataAcessObject.Cart
{
    public interface ICart
    {
         Task<PizzaInformation> FilterRecord(string pizzaname);

         Task<bool> AddBill(CustomerRecord record);
    }
}
