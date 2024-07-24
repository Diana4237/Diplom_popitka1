using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Diplom_popitka1.Models
{
    public partial class Logining
    {
        public int IdLoginUser { get; set; }
        public string Password { get; set; }
        public int? IdUser { get; set; }
        public int? IdRole { get; set; }

        public virtual Roles IdRoleNavigation { get; set; }
    }
}
