using PizzaApp.DataBaseModels;

namespace PizzaApp.DataAcessObject.Login
{
    public interface ILogin
    {
       RegisterTable UserCredential(string UserName, string password);
    }
}
