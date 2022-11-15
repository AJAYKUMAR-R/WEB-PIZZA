using PizzaApp.Models.RegisterModels;
using PizzaApp.DataBaseModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PizzaApp.DataAcessObject.Register
{
    public class RegisterUser : IRegister
    {
        private static PizzaAppContext _context = Singleton.Instance;

        public bool AddCustomer(RegisterDetails user)
        {
            
            RegisterTable register = new RegisterTable();
            register.CustName = user.CustName;
            register.Custmobile = user.Custmobile;
            register.CustAddres = user.CustAddres;
            register.CustPinCode = (long)user.CustPinCode;
            lock (_context)
            {
                RegisterTable? registerTable = _context.RegisterTables.Where(obj => obj.Custmobile == register.Custmobile).FirstOrDefault();
                if (registerTable == null)
                {
                    EntityEntry<RegisterTable> reg = _context.RegisterTables.Add(register);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
                
                
                
           
                
            
        }
    }
}