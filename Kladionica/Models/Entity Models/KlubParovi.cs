using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kladionica.Models.Entity_Models
{
    public class KlubParovi
    {
        public int KlubParId { get; set; }
        public int ParId { get; set; }
        public int KlubId { get; set; }

        public Klub Klub { get; set; }
        public Par Par { get; set; }

        //public static void Configure(EntityTypeBuilder<KlubParovi> builder)
        //{
        //    builder.ToTable("KlubParovi");

        //    builder.HasKey(kp => kp.KlubParId);

        //    builder.HasAlternateKey(kp => new { kp.ParId, kp.KlubId });

        //    builder.HasOne(kp => kp.Klub)
        //        .WithMany(k => k.KlubParovi)
        //        .HasForeignKey(kp => kp.KlubId)
        //        .IsRequired();

        //    builder.HasOne(kp => kp.Par)
        //        .WithMany(p => p.KlubParovi)
        //        .HasForeignKey(kp => kp.ParId)
        //        .IsRequired();

        //}
    }
}
