namespace Kladionica.Models.Entity_Models
{
    public class KlubParovi
    {
        public int KlubParId { get; set; }
        public int ParId { get; set; }
        public int KlubId { get; set; }

        public Klub Klub { get; set; }
        public Par Par { get; set; }
    }
}
