using PizzaApp.Models.RegisterModels;

namespace PizzaApp.DataAcessObject.Register
{
    public interface IRegister
    {
        bool AddCustomer(RegisterDetails user);

    }
}
