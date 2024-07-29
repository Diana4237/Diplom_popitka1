using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Марка обязательна для заполнения.")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Год выпуска обязателен для заполнения.")]
        [Range(1900, 2100, ErrorMessage = "Введите корректный год выпуска.")]
        public DateTime? YearRelease { get; set; }
        [Required(ErrorMessage = "Пробег обязателен для заполнения.")]
        [Range(0, int.MaxValue, ErrorMessage = "Пробег не может быть отрицательным.")]
        public int? Mileage { get; set; }
        public int? IdClient { get; set; }
        public byte[] PhotoMoto { get; set; }

        public virtual Clients IdClientNavigation { get; set; }
        public virtual ICollection<RepairRequests> RepairRequests { get; set; }
    }
}
