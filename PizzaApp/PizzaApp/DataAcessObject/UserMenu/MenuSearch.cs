using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaApp.DataBaseModels;

namespace PizzaApp.DataAcessObject.UserMenu
{
    public class MenuSearch : IMenu
    {
        private static PizzaAppContext _context = Singleton.Instance;
       

        public  IEnumerable<PizzaInformation> FilterPizza(string pizzaname)
        {
            if(pizzaname == null)
                pizzaname = "";
            IEnumerable<PizzaInformation> information;
            lock(_context){
                List<PizzaInformation> pizzaInformation = _context.PizzaInformations.ToList();
                information = from info in pizzaInformation where info.Pizzaname.ToLower().StartsWith(pizzaname.ToLower()) select info;
            }
            return information;
        }


        public async Task<IEnumerable<PizzaInformation>> ReadAllPizza()
        {
            IEnumerable<PizzaInformation> information;
            information = await _context.PizzaInformations.ToListAsync();
            return information;
        }
    }
}
