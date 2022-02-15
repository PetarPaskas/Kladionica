using System.Collections.Generic;

namespace Kladionica.Models.Entity_Models
{
    public class Sport
    {
        public int SportId { get; set; }
        public string Naziv { get; set; }
        public int SportCode { get; set; }

        public ICollection<Klub> Klubovi { get; set; }
    }
}
