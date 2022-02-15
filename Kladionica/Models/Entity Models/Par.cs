using System.Collections.Generic;

namespace Kladionica.Models.Entity_Models
{
    public class Par
    {
        public int ParId { get; set; }
        public int LigaId { get; set; }
        public int SinglId { get; set; }

        public Liga Liga { get; set; }
        public Singl Singl { get; set; }
        public ICollection<KlubParovi> KlubParovi { get; set; }

    }
}
