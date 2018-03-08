using GeekyMoney.Data.Model;
using Microsoft.EntityFrameworkCore;


namespace GeekyMoney.Data
{
    public class GeekyMoneyContext : DbContext
    {
        public DbSet<RealEstateProperty> RealEstateProperty { get; set; }
        public DbSet<Mortgage> Mortgage { get; set; }
        public DbSet<Fee> Fee { get; set; }
        public DbSet<Scenario> Scenario { get; set; }
        public DbSet<RentalRate> RentalRate { get; set; }
        public DbSet<BlendedRentalRate> BlendedRentalRate { get; set; }

        public GeekyMoneyContext(DbContextOptions<GeekyMoneyContext> options)
            : base(options)
        {

        }
    }
}
