using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Contexts
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            // Notice the "Database=Test_Database;" part added below
            var connectionString =
                "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                "AttachDbFilename=C:\\Users\\matth\\source\\repos\\DataLagring\\DataStorage_Assignment\\Data\\Databases\\Test_Database.mdf;" +
                "Database=Test_Database;" +
                "Integrated Security=True;" +
                "Connect Timeout=30;";

            optionsBuilder.UseSqlServer(connectionString);

            return new DataContext(optionsBuilder.Options);
        }
    }
}