using System;

namespace Kladionica.Models.Entity_Models
{
    public class Singl
    {
        public int SinglId { get; set; }
        public decimal ReferentnaKvota { get; set; }
        public decimal Kvota { get; set; }
        public bool Dobitan { get; set; }
        public decimal DeltaProcenat { get; set; }
        public DateTime? Datum { get; set; }
        public string Opis { get; set; }

        public int ParId { get; set; }
        public Par Par { get; set; }
    }
}
