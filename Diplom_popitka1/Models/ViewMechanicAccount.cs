namespace Diplom_popitka1.Models
{
    public class ViewMechanicAccount
    {
        public int IdRequest { get; set; }
        public int? IdMotoCl { get; set; }
        public string? ModelMotoCl { get; set; }
        public string nameCl { get; set; }
        public string? Status { get; set; }
        public string? Problem { get; set; }
        public string? Report { get; set; }
        public string? Places { get; set; }
        public byte[]? Photo { get; set; }
        public int? IdMechanic { get; set; }
        public DateTime? DateRequest { get; set; }
        public DateTime? DateRequestEnd { get; set; }
        public List<Notes> notes { get; set; }
    }
}
