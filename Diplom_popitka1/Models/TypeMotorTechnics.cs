using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Diplom_popitka1.Models
{
    public partial class TypeMotorTechnics
    {
        public TypeMotorTechnics()
        {
            MotorTechnics = new HashSet<MotorTechnics>();
        }

        public int IdTypeMotorTechnics { get; set; }
        public string NameTypeMotorTechnics { get; set; }

        public virtual ICollection<MotorTechnics> MotorTechnics { get; set; }
    }
}
