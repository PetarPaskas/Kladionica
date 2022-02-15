using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Kladionica.Models.Entity_Models
{
    public class Par
    {
        public int ParId { get; set; }
        public int LigaId { get; set; }
        public int SinglId { get; set; }
        public int KlubPrviId { get; set; }
        public int KlubDrugiId { get; set; }

        public Liga Liga { get; set; }
        public Singl Singl { get; set; }
        public Klub KlubPrvi { get; set; }
        public Klub KlubDrugi { get; set; }
        //public ICollection<KlubParovi> KlubParovi { get; set; }

        public static void Configure(EntityTypeBuilder<Par> builder)
        {
            builder.ToTable("Parovi");

            builder.HasKey(p => p.ParId);

            builder.HasOne(p => p.Liga)
                .WithMany(l => l.Parovi)
                .HasForeignKey(p => p.LigaId)
                .OnDelete(DeleteBehavior.NoAction);

            //Postaviti koji je principal, a koji dependant
            builder.HasOne(p => p.Singl)
                 .WithOne(s => s.Par)
                 .HasForeignKey<Par>(p => p.SinglId);

            builder.HasOne(p => p.KlubPrvi)
                .WithMany(k => k.ParoviPrvi)
                .HasForeignKey(p => p.KlubPrviId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.KlubPrvi)
                .WithMany(k => k.ParoviPrvi)
                .HasForeignKey(p => p.KlubPrviId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
