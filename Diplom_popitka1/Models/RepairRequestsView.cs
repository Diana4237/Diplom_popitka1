namespace Diplom_popitka1.Models
{
    public class RepairRequestsView
    {
        public int IdRequest { get; set; }
        public string nameMotoCl { get; set; }
        public string nameCl { get; set; }
        public string? Status { get; set; }
        public string? Problem { get; set; }
        public string? Report { get; set; }
        public string? Places { get; set; }
        public byte[]? Photo { get; set; }
        public int? nameMechanic { get; set; }
        public DateTime? DateRequest { get; set; }
        public DateTime? DateRequestEnd { get; set; }
    }
}
