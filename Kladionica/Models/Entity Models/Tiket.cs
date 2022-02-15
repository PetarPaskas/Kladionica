using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Kladionica.Models.Entity_Models
{
    public class Tiket
    {
        public int TikedId { get; set; }
        public decimal? Suma { get; set; }
        public ICollection<Singl> Singlovi { get; set; }

        public static void Configure(EntityTypeBuilder<Tiket> builder)
        {
            builder.ToTable("Tiketi");

            builder.HasKey(t => t.TikedId);

            builder.Property(t => t.Suma)
                .HasConversion<decimal>();
        }

    }
}
