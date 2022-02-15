using System.Collections.Generic;

namespace Kladionica.Models.Entity_Models
{
    public class Drzava
    {
        public int DrzavaId { get; set; }
        public int DrzavaCode { get; set; }
        public string Naziv { get; set; }

        public ICollection<Liga> Lige { get; set; }
        public ICollection<Klub> Klubovi { get; set; }
    }
}
