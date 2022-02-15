using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Kladionica.Models.Entity_Models
{
    public class Sport
    {
        public int SportId { get; set; }
        public string Naziv { get; set; }
        public int SportCode { get; set; }

        public ICollection<Klub> Klubovi { get; set; }

        public static void Configure(EntityTypeBuilder<Sport> builder)
        {
            builder.ToTable("Sportovi");

            builder.HasKey(s => s.SportId);

            builder.HasIndex(s => s.SportCode)
                .IsUnique();
        }
    }
}
