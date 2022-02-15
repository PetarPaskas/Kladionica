using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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


        public static void Configure(EntityTypeBuilder<Drzava> builder)
        {
            builder.ToTable("Drzave");

            builder.HasKey(x => x.DrzavaId);

            builder.Property(x => x.Naziv)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.HasIndex(d => d.DrzavaCode)
                .IsUnique();
        }
    }
}
