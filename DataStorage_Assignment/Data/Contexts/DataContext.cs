using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Entities.CustomerEntity> Customers { get; set; }
    public DbSet<Entities.ProductEntity> Products { get; set; }
    public DbSet<Entities.StatusTypeEntity> StatusTypes { get; set; }
    public DbSet<Entities.UserEntity> Users { get; set; }

    public DbSet<Entities.ProjectEntity> Projects { get; set; }
}
