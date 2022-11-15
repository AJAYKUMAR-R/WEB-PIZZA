using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models.RegisterModels
{
    public class RegisterDetails
    {
        public int CustId { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(15, ErrorMessage = "Name Should Be Less Than 15 character")]
        public string? CustName { get; set; }
        [Required(ErrorMessage = "Mobile is Required")]
        [RegularExpression(@"^[7-9]{1}[0-9]{9}$", ErrorMessage = "Not valid Phone Number")]
        public string? Custmobile { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string? CustAddres { get; set; }
        [Required(ErrorMessage = "Pincode is Required")]
        public long? CustPinCode { get; set; }
    }
}
