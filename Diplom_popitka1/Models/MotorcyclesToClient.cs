using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Diplom_popitka1.Models
{
    public partial class MotorcyclesToClient
    {
        public MotorcyclesToClient()
        {
            RepairRequests = new HashSet<RepairRequests>();
        }

        public int IdMotoCl { get; set; }
        public string Model { get; set; }
        public DateTime? YearRelease { get; set; }
        public int? Mileage { get; set; }
        public int? IdClient { get; set; }

        public virtual Clients IdClientNavigation { get; set; }
        public virtual ICollection<RepairRequests> RepairRequests { get; set; }
    }
}
