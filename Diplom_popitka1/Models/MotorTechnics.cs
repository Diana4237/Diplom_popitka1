using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Diplom_popitka1.Models
{
    public partial class MotorTechnics
    {
        public int IdMotorTechnics { get; set; }
        public int? IdTypeMotorTechnics { get; set; }
        public string DefinitionMotorTechnics { get; set; }
        public int? EngineCapacity { get; set; }
        public int? Tact { get; set; }
        public string Transmission { get; set; }
        public decimal? Cost { get; set; }
        public int? Quantity { get; set; }
        public string Purpose { get; set; }

        public virtual TypeMotorTechnics IdTypeMotorTechnicsNavigation { get; set; }
    }
}
