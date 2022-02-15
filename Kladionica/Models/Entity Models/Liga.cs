namespace Kladionica.Models.Entity_Models
{
    public class Liga
    {
        public int LigaId { get; set; }
        public char Pol { get; set; }
        public byte LigaCode { get; set; }

        public int DrzavaId { get; set; }
        public Drzava Drzava { get; set; }
    }
}
