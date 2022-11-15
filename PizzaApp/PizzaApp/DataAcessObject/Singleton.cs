using PizzaApp.DataBaseModels;
namespace PizzaApp.DataAcessObject
{
    public sealed class Singleton
    {
       
        private static PizzaAppContext Pizza = new PizzaAppContext();
   

        private Singleton()
        {

        }

        public static PizzaAppContext Instance
        {
            get
            {
                return Pizza;
            }
        }


    }
}
