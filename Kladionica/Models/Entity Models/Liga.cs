using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Kladionica.Models.Entity_Models
{
    public class Liga
    {
        public int LigaId { get; set; }
        public char Pol { get; set; }
        public byte LigaCode { get; set; }

        public int DrzavaId { get; set; }
        public Drzava Drzava { get; set; }

        public ICollection<Par> Parovi { get; set; }

        public static void Configure(EntityTypeBuilder<Liga> builder)
        {
            builder.ToTable("Lige");

            builder.HasKey(l => l.LigaId);

            builder.Property(l => l.Pol)
                .HasDefaultValue("M")
                .IsRequired();

            builder.Property(l => l.LigaCode)
                .IsRequired();

            builder.HasOne(l => l.Drzava)
                .WithMany(d => d.Lige)
                .HasForeignKey(l => l.DrzavaId);
        }
    }
}
