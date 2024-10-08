using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Diplom_popitka1.Models
{
    public partial class RepairRequests
    {
        public RepairRequests()
        {
            Notes = new HashSet<Notes>();
            Reviews = new HashSet<Reviews>();
        }

        public int IdRequest { get; set; }
        public int? IdMotoCl { get; set; }
        public string? Status { get; set; }
        public string? Problem { get; set; }
        public string? Report { get; set; }
        public string? Places { get; set; }
        public byte[]? Photo { get; set; }
        public int? IdMechanic { get; set; }
        public DateTime? DateRequest { get; set; }
        public DateTime? DateRequestEnd { get; set; }

        public virtual Mechanics IdMechanicNavigation { get; set; }
        public virtual MotorcyclesToClient IdMotoClNavigation { get; set; }
        public virtual ICollection<Notes> Notes { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
