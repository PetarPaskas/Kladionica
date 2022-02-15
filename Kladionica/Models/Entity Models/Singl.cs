using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Kladionica.Models.Entity_Models
{
    public class Singl
    {
        public int SinglId { get; set; }
        public decimal ReferentnaKvota { get; set; }
        public decimal Kvota { get; set; }
        public bool? Dobitan { get; set; }

        //Configure get; as a computed
        public decimal DeltaProcenat { get; set; }
        public DateTime? Datum { get; set; }
        public string Opis { get; set; }
        public decimal? Suma { get; set; }

        public int? TiketId { get; set; }
        public int ParId { get; set; }
        public Tiket Tiket { get; set; }

        //Ovaj relationship je u Par konfigurisan
        public Par Par { get; set; }

        public static void Configure(EntityTypeBuilder<Singl> builder)
        {
            builder.ToTable("Singlovi");

            builder.HasKey(s => s.SinglId);

            builder.Ignore(s => s.DeltaProcenat);

            builder.HasOne(s => s.Tiket)
                .WithMany(t => t.Singlovi)
                .HasForeignKey(s => s.TiketId);

            builder.Property(s => s.ReferentnaKvota)
                .HasConversion<decimal>();

            builder.Property(s => s.Kvota)
                .HasConversion<decimal>();

            builder.Property(s => s.Suma)
                .HasConversion<decimal>();

        }
    }
}
