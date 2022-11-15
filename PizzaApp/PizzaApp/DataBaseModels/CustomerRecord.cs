using System;
using System.Collections.Generic;

namespace PizzaApp.DataBaseModels
{
    public partial class CustomerRecord
    {
        public int Orderid { get; set; }
        public int? CustId { get; set; }
        public int Quantity { get; set; }
        public int TotalAmount { get; set; }

        public virtual RegisterTable? Cust { get; set; }
    }
}
