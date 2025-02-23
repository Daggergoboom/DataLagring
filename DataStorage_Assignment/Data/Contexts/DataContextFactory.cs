using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Contexts
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DataContext>();

            // Make sure to escape backslashes (\\) in a C# string literal
            const string connectionString =
                "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                "AttachDbFilename=C:\\Users\\matth\\source\\repos\\DataLagring\\DataStorage_Assignment\\Data\\Databases\\Test_Database.mdf;" +
                "Database=Test_Database;" +
                "Integrated Security=True;" +
                "Connect Timeout=30;";

            builder.UseSqlServer(connectionString);

            return new DataContext(builder.Options);
        }
    }
}