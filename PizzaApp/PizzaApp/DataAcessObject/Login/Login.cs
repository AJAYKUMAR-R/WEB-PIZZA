using PizzaApp.DataBaseModels;

namespace PizzaApp.DataAcessObject.Login
{
    public class Login : ILogin
    {
        private static PizzaAppContext _context = Singleton.Instance;
        public RegisterTable UserCredential(string userName,string password)
        {
                RegisterTable? register;
                
                //Locking the Thread For Dubble click From the User
                lock (_context){ 
                 register = _context.RegisterTables.Where(obj  => obj.CustName.Replace(" ", "").ToLower() == userName.Replace(" ", "").ToLower() && obj.Custmobile == password).FirstOrDefault();
                }
                if (register != null)
                {
                    return register;
                }
                else
                {
                    return null;
                }
           
            
             
          
        }

        
    }
}
