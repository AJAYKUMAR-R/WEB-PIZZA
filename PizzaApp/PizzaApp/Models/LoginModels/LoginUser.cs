using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models.LoginModels
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(15, ErrorMessage = "Name Should Be Less Than 15 character")] 
        public string? CustName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [RegularExpression(@"^[7-9]{1}[0-9]{9}$", ErrorMessage = "Pasword IncorrectFormat")]
        public string? Custmobile { get; set; }
          
    }
}
