using System;
using System.Collections.Generic;

namespace PizzaApp.RegisterModels
{
    public partial class PizzaInformation
    {
        public int Pizzaid { get; set; }
        public string Pizzaname { get; set; } = null!;
        public string Pizzadescription { get; set; } = null!;
        public int? Pizzaprice { get; set; }
        public string? Pizzaimg { get; set; }
    }
}
