using System.Collections.Generic;

namespace Kladionica.Models.Entity_Models
{
    public class Klub
    {
        public int KlubId { get; set; }
        public string Naziv { get; set; }
        public char Pol { get; set; }

        public int SportId { get; set; }
        public int DrzavaId { get; set; }
        public Sport Sport { get; set; }
        public Drzava Drzava { get; set; }
        public ICollection<KlubParovi> KlubParovi { get; set; }
    }
}
