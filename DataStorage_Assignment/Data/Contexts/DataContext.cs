using Microsoft.EntityFrameworkCore;
using Data.Entities;

namespace Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CustomerEntity> Customers { get; set; } = null!;
        public DbSet<UserEntity> Users { get; set; } = null!;
        public DbSet<StatusTypeEntity> StatusTypes { get; set; } = null!;
        public DbSet<ProjectEntity> Projects { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ Seed StatusTypes
            modelBuilder.Entity<StatusTypeEntity>().HasData(
                new StatusTypeEntity { Id = 1, StatusName = "Not Started" },
                new StatusTypeEntity { Id = 2, StatusName = "Ongoing" },
                new StatusTypeEntity { Id = 3, StatusName = "Finished" }
            );

            // ✅ Seed Customers
            modelBuilder.Entity<CustomerEntity>().HasData(
                new CustomerEntity { Id = 1, CustomerName = "Acme Corporation" },
                new CustomerEntity { Id = 2, CustomerName = "Globex Corporation" },
                new CustomerEntity { Id = 3, CustomerName = "Initech" }
            );

            // ✅ Seed Users
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
                new UserEntity { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" },
                new UserEntity { Id = 3, FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com" }
            );
        }
    }
}
