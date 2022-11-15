using Microsoft.AspNetCore.Mvc;
using PizzaApp.DataAcessObject.Cart;
using PizzaApp.DataAcessObject.Login;
using PizzaApp.DataAcessObject.UserMenu;
using PizzaApp.Models;
using PizzaApp.Models.LoginModels;
using PizzaApp.Models.RegisterModels;
using PizzaApp.DataBaseModels;
using PizzaApp.DataAcessObject.Register;
using System.Text.Json;

namespace PizzaApp.Controllers
{
    public class HomeController : Controller
    {

        //Login Controller Binding Object For Login
        public IActionResult Login()
        {
            LoginUser login = new LoginUser();
            return View(login);
        }

        //At the Time of Logout Clearing the Seeison 
        //And Clearing Static Session Class Field
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            var User = HttpContext.Session.GetString("Username");
            SessionTrack.UserNameSession = User;
            SessionTrack.Orders.Clear();
            return RedirectToAction("Index");  
        }

        //Validating The User For Login
        public   IActionResult LoginResult(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                ILogin login = new Login();
                RegisterTable check;
                check =  login.UserCredential(loginUser.CustName, loginUser.Custmobile);
                if (check != null)
                {
                    HttpContext.Session.SetString("Username",check.CustName);
                    HttpContext.Session.SetString("userid",check.CustId.ToString());
                    var User = HttpContext.Session.GetString("Username");
                    SessionTrack.UserNameSession = User;
                    SessionTrack.SessionIdSession = HttpContext.Session.Id;
                    return Redirect("Index");
                }
                else
                {
                    ViewBag.Error = "UserNotFound";
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }
        }

        //Home Page Action
        public IActionResult Index()
        {
            return View();
        }

        //Binding the Register Model To The DataBase
        public IActionResult Register()
        {
            RegisterDetails user = new RegisterDetails();
            return View(user);
        }

        //Validating The Register User Using Anotation
        public IActionResult RegisterComplete(RegisterDetails user)
        {
            if (ModelState.IsValid)
            {
                IRegister register = new RegisterUser();
                bool check =  register.AddCustomer(user);
                if (check)
                {
                    return Redirect("Index");
                }
                else
                {
                    ViewBag.Error = "User Has Already Register with this Mobile Number";
                    return View("Register");
                }
            }
            else
            {
                return View("Register");
            }

            
        }

        //Loading the All Pizza details Using Ajax GET request return as Json Object
        //While loading the Page itself it Will Work For Get Request
        public async Task<JsonResult> MenuLoad()
        {
            IMenu menu = new MenuSearch();
            IEnumerable<PizzaInformation> information = await menu.ReadAllPizza();
            return Json(information);
        }

        //Menu View
        [HttpGet]
        public ActionResult Menu()
        {
            return View();   
        }

        //It will work for onkeyup event async POST Method for Searching in the Text
        [HttpPost]
        public  JsonResult Menu(string txtsearch)
        {
            IMenu menu = new MenuSearch();

            IEnumerable<PizzaInformation> information =  menu.FilterPizza(txtsearch);
           
            return Json(information);
        }

       //it Work For Get Request loading all pizzanames and calculate price from the Session or 
       //let it empty list and it goes to the Cart.js Cart 
       //it work  When The Get Request is came for this Action
       //Jquery document load itself it will calculate the Total price
       //After modelbinding after that js will load
        public IActionResult Cart()
        {
            //if the User Has not logged in Directly go to the Cart it will endded up
            //in Null reference error
            try
            {

                if (SessionTrack.UserNameSession != null && SessionTrack.SessionIdSession == HttpContext.Session.Id)
                {
                    var obj = HttpContext.Session.GetString("obj");
                    SessionTrack.Orders = JsonSerializer.Deserialize<List<PizzaInformation>>(obj);
                    return View(SessionTrack.Orders);
                }
                else
                {
                    return Redirect("Logout");
                }
            }
            catch
            {
                return View();
            }

        }
        //Delete Button
        //Delete Async Ajax Request :- and it will Return the json object 
        public IActionResult DeleteCart(string pizzaname)
        {
            if(SessionTrack.UserNameSession != null && SessionTrack.SessionIdSession == HttpContext.Session.Id)
            {
                var obj = HttpContext.Session.GetString("obj");
                SessionTrack.Orders = JsonSerializer.Deserialize<List<PizzaInformation>>(obj);
                foreach (var item in SessionTrack.Orders.ToList())
                {
                    if (item.Pizzaname == pizzaname)
                    {
                        SessionTrack.Orders.Remove(item);
                        break;
                    }
                   

                }
                HttpContext.Session.SetString("obj", JsonSerializer.Serialize(SessionTrack.Orders));
                return Json(SessionTrack.Orders);
            }
            else
            {
                return Redirect("Logout");
            }
        }


        //Save button Order bill to DataBAse by async save method
        public async Task<IActionResult> Save(string Total, string TotalQuantity)
        {
            //If it has 0 price it wont work
            if((Total == "0" || TotalQuantity == "0"))
            {
                return Json(1);
            }
            else
            {
               
                int userid = Convert.ToInt32(HttpContext.Session.GetString("userid"));
                CustomerRecord record = new CustomerRecord();
                record.CustId = userid;
                record.Quantity = Convert.ToInt32(TotalQuantity);
                record.TotalAmount = Convert.ToInt32(Total);
                ICart cart = new Cart();
                bool check = await cart.AddBill(record);
                if (check)
                {
                    var obj = HttpContext.Session.GetString("obj");
                    SessionTrack.Orders = JsonSerializer.Deserialize<List<PizzaInformation>>(obj);
                    SessionTrack.Orders.Clear();
                    HttpContext.Session.SetString("obj", JsonSerializer.Serialize(SessionTrack.Orders));
                    return Json(0);
                }
                else
                {
                    return Json(1);
                }
                
            }
            
        }


        //ORder button
        //After the Ajax Request from The Menu.js file by geting pizzaname
        //UserOrderd async  
        public async Task<IActionResult> CartLoad(string pizzaname)
        {
            if(SessionTrack.UserNameSession != null && SessionTrack.SessionIdSession == HttpContext.Session.Id )
            {
                ICart cart = new Cart();
                //Setting the List to Session by serilalizing the Session.Orders List 
                HttpContext.Session.SetString("obj", JsonSerializer.Serialize(SessionTrack.Orders));
                var objects = HttpContext.Session.GetString("obj");
                //Deserilalize the List and Stored it in Variable
                SessionTrack.Orders = JsonSerializer.Deserialize<List<PizzaInformation>>(objects);
                PizzaInformation pizza = await cart.FilterRecord(pizzaname);
                SessionTrack.Orders.Add(pizza);
                HttpContext.Session.SetString("obj", JsonSerializer.Serialize(SessionTrack.Orders));
                return Json(SessionTrack.Orders);
            }
            else
            {
                return Json(1);
            }
        }

        public IActionResult About()
        {
            return View();
        }

    }
}
