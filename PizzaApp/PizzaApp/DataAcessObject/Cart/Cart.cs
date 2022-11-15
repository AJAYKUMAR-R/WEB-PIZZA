
using Microsoft.EntityFrameworkCore;
using PizzaApp.DataBaseModels;

namespace PizzaApp.DataAcessObject.Cart
{
    public class Cart : ICart
    {
        private static PizzaAppContext _context = Singleton.Instance;


        public async Task<PizzaInformation> FilterRecord(string pizzaname)
        {
            if (pizzaname == null)
                pizzaname = "";
            PizzaInformation? pizzaInformation = await _context.PizzaInformations.Where(obj => obj.Pizzaname.ToLower().Trim() == pizzaname.ToLower().Trim()).FirstOrDefaultAsync();
            return pizzaInformation;
        }
         
        public async Task<bool> AddBill(CustomerRecord record)
        {
            try
            {
                await _context.CustomerRecords.AddAsync(record);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
       
    }
}
