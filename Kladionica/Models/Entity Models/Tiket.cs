using System.Collections.Generic;

namespace Kladionica.Models.Entity_Models
{
    public class Tiket
    {
        public int TikedIt { get; set; }
        public decimal Suma { get; set; }
        public ICollection<Singl> Singlovi { get; set; }
    }
}
