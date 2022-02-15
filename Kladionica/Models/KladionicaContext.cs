using Kladionica.Models.Entity_Models;
using Microsoft.EntityFrameworkCore;

namespace Kladionica.Models
{
    public class KladionicaContext : DbContext
    {
        public DbSet<Drzava> Drzave { get; set; }
        public DbSet<Klub> Klubovi { get; set; }
        public DbSet<KlubParovi> KlubParovi { get; set; }
        public DbSet<Liga> Lige { get; set; }
        public DbSet<Par> Parovi { get; set; }
        public DbSet<Singl> Singlovi { get; set; }
        public DbSet<Sport> Sportovi { get; set; }
        public DbSet<Tiket> Tiketi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
