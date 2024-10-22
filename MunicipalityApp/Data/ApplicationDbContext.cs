using Microsoft.EntityFrameworkCore;
using MunicipalityApp.Models;

namespace MunicipalityApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for all entities
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Meter> Meters { get; set; }
        public DbSet<MeterReading> MeterReadings { get; set; }
        public DbSet<MeterReader> MeterReaders { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Fault> Faults { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<CommunityServiceUpdate> CommunityServiceUpdates { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Role -> Users (One-to-Many)
            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);

            // Customer -> Bills (One-to-Many)
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Bills)
                .WithOne(b => b.Customer)
                .HasForeignKey(b => b.CustomerId);

            // Bill -> Payments (One-to-Many)
            modelBuilder.Entity<Bill>()
                .HasMany(b => b.Payments)
                .WithOne(p => p.Bill)
                .HasForeignKey(p => p.BillId);

            // Customer -> Payments (One-to-Many)
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Payments)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId);

            // Customer -> Faults (One-to-Many)
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Faults)
                .WithOne(f => f.Customer)
                .HasForeignKey(f => f.CustomerId);

            // Meter -> MeterReadings (One-to-Many)
            modelBuilder.Entity<Meter>()
                .HasMany(m => m.MeterReadings)
                .WithOne(mr => mr.Meter)
                .HasForeignKey(mr => mr.MeterId);

            // MeterReader -> MeterReadings (One-to-Many)
            modelBuilder.Entity<MeterReader>()
                .HasMany(mr => mr.MeterReadings)
                .WithOne(m => m.CapturedBy)
                .HasForeignKey(m => m.CapturedById);

            // Customer -> Meters (One-to-Many, separate for WaterMeterId and ElectricityMeterId)
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.WaterMeter)
                .WithMany(m => m.WaterCustomers)
                .HasForeignKey(c => c.WaterMeterId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.ElectricityMeter)
                .WithMany(m => m.ElectricityCustomers)
                .HasForeignKey(c => c.ElectricityMeterId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

            // Tariff configuration (e.g., Unique Constraints if needed)
            modelBuilder.Entity<Tariff>()
                .HasIndex(t => new { t.UtilityType, t.ActiveFrom })
                .IsUnique(); // Prevent overlapping tariff periods for the same utility
        }
    }
}
