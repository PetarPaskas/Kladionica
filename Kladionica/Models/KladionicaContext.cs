using Kladionica.Models.Entity_Models;
using Microsoft.EntityFrameworkCore;

namespace Kladionica.Models
{
    public class KladionicaContext : DbContext
    {
        public DbSet<Drzava> Drzave { get; set; }
        public DbSet<Klub> Klubovi { get; set; }
        //public DbSet<KlubParovi> KlubParovi { get; set; }
        public DbSet<Liga> Lige { get; set; }
        public DbSet<Par> Parovi { get; set; }
        public DbSet<Singl> Singlovi { get; set; }
        public DbSet<Sport> Sportovi { get; set; }
        public DbSet<Tiket> Tiketi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string connString = "Data Source=localhost;Initial Catalog=Kladionica;Integrated Security=SSPI";
            options.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Drzava.Configure(builder.Entity<Drzava>());
            Klub.Configure(builder.Entity<Klub>());
            Liga.Configure(builder.Entity<Liga>());
            Par.Configure(builder.Entity<Par>());
            Singl.Configure(builder.Entity<Singl>());
            Sport.Configure(builder.Entity<Sport>());
            Tiket.Configure(builder.Entity<Tiket>());
            //Kladionica.Models.Entity_Models.KlubParovi.Configure(builder.Entity<KlubParovi>());
        }
    }
}
