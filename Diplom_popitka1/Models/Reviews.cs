using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Diplom_popitka1.Models
{
    public partial class Reviews
    {
        public int IdReview { get; set; }
        public string TextReview { get; set; }
        public int? IdClient { get; set; }
        public int? Stars { get; set; }
        public int? IdRequest { get; set; }

        public virtual Clients IdClientNavigation { get; set; }
        public virtual RepairRequests IdRequestNavigation { get; set; }
    }
}
