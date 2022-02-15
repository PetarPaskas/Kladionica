using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        //public ICollection<KlubParovi> KlubParovi { get; set; }
        public ICollection<Par> ParoviPrvi { get; set; }
        public ICollection<Par> ParoviDrugi { get; set; }

        public static void Configure(EntityTypeBuilder<Klub> builder)
        {
            builder.ToTable("Klubovi");

            builder.HasKey(k => k.KlubId);

            builder.Property(k => k.Pol)
                .HasDefaultValue("M")
                .IsRequired();

            builder.Property(k => k.Naziv)
                .IsRequired();

            builder.HasOne(k => k.Sport)
                .WithMany(s => s.Klubovi)
                .HasForeignKey(k => k.SportId)
                .IsRequired();

            builder.HasOne(k => k.Drzava)
                .WithMany(d => d.Klubovi)
                .HasForeignKey(k => k.DrzavaId)
                .IsRequired();
        }
    }
}
