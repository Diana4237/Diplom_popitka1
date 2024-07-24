using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Diplom_popitka1.Models
{
    public partial class TakeMotoToWork
    {
        public int IdTakemoto { get; set; }
        public string Model { get; set; }
        public string Mileage { get; set; }
    }
}
