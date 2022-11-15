using System;
using System.Collections.Generic;

namespace PizzaApp.DataBaseModels
{
    public partial class RegisterTable
    {
        public RegisterTable()
        {
            CustomerRecords = new HashSet<CustomerRecord>();
        }

        public int CustId { get; set; }
        public string CustName { get; set; } = null!;
        public string Custmobile { get; set; } = null!;
        public string CustAddres { get; set; } = null!;
        public long CustPinCode { get; set; }

        public virtual ICollection<CustomerRecord> CustomerRecords { get; set; }
    }
}
