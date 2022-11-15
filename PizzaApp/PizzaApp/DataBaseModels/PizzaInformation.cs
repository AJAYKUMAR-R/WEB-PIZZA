using System;
using System.Collections.Generic;

namespace PizzaApp.DataBaseModels
{
    public partial class PizzaInformation
    {
        public string Pizzaid { get; set; } = null!;
        public string Pizzaname { get; set; } = null!;
        public string Pizzadescription { get; set; } = null!;
        public int? Pizzaprice { get; set; }
        public string? Pizzaimg { get; set; }
    }
}
