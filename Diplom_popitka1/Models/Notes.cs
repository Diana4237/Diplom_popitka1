using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Diplom_popitka1.Models
{
    public partial class Notes
    {
        public int IdNote { get; set; }
        public int? IdRequest { get; set; }
        public string Content { get; set; }
        public byte[]? Execution { get; set; }
        public DateTime? DateTime { get; set; }
        public int? IdMechanic { get; set; }

        public virtual Mechanics IdMechanicNavigation { get; set; }
        public virtual RepairRequests IdRequestNavigation { get; set; }
    }
}
