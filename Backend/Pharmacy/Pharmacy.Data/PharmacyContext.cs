using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Data
{
    public class PharmacyContext : DbContext
    {
        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Sale> Sales{ get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
