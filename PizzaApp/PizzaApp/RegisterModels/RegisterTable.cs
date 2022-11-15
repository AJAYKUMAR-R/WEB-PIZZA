using System;
using System.Collections.Generic;

namespace PizzaApp.RegisterModels
{
    public partial class RegisterTable
    {
        public int CustId { get; set; }
        public string? CustName { get; set; }
        public string? Custmobile { get; set; }
        public string? CustAddres { get; set; }
        public long? CustPinCode { get; set; }
    }
}
