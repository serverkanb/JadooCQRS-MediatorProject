using JadooProject.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace JadooProject.DataAccess.Context
{
    public class JadooContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-1IHFPICF;database=JadooProjectDb;trusted_connection=true;multipleactiveresultsets=true;trustservercertificate=true");
        }

        public DbSet<Service> Services { get; set; }

        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<TravelStep> TravelSteps { get; set; }
        public DbSet<Testimonial> TestimOnials { get; set; }
        public DbSet<PartnerBrand> PartnerBrands { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
    }
}
