using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Diplom_popitka1.Models
{
    public partial class Mechanics
    {
        public Mechanics()
        {
            Notes = new HashSet<Notes>();
            RepairRequests = new HashSet<RepairRequests>();
        }

        public int IdMechanic { get; set; }
        public string Fullname { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<Notes> Notes { get; set; }
        public virtual ICollection<RepairRequests> RepairRequests { get; set; }
    }
}
