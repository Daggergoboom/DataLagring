using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\matth\\source\\repos\\DataStorage_Assignment\\Data\\Databases\\LocalDataBase.mdf;Integrated Security=True;Connect Timeout=30");

            return new DataContext(optionsBuilder.Options);
        }
    }