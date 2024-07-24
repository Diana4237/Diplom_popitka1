using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Diplom_popitka1.Models
{
    public partial class MotorcycleSparePartsStock
    {
        public int IdSpare { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
    }
}
