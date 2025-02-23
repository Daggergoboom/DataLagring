using Business.Models;
using Business.Services;
using Data.Contexts;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectConsoleApp.Dialogs;

namespace ProjectConsoleApp
{
    class Program
    {
        private static ProjectService _projectService = null!;

        static async Task Main(string[] args)
        {
            // Initialize database context and repositories
            //           var options = new DbContextOptionsBuilder<DataContext>()
            // .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\matth\\source\\repos\\DataLagring\\DataStorage_Assignment\\Data\\Databases\\Local_Database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False")
            //                .Options;
            //           var context = new DataContext(options);
            //          var projectRepository = new ProjectRepository(context);
            //         _projectService = new ProjectService(projectRepository);

            var services = new ServiceCollection()
                .AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\matth\\source\\repos\\DataLagring\\DataStorage_Assignment\\Data\\Databases\\Test_Database.mdf;Integrated Security=True;Connect Timeout=30"))
                .AddScoped<StatusRepository>()
                .AddScoped<CustomerRepository>()
                .AddScoped<UserRepository>()
                .AddScoped<ProjectRepository>()

                // .AddScoped<StatusService>()
                .AddScoped<CustomerService>()
                // .AddScoped<ProductService>()
                // .AddScoped<UserService>()
                .AddScoped<ProjectService>()

                //.AddScoped<StatusTypeDialogs>()
                //.AddScoped<UserDialogs>()
                //.AddScoped<CustomerDialogs>()
                //.AddScoped<ProductDialogs>()
                // .AddScoped<ProjectDialogs>()
                .AddScoped<MainMenuDialog>();

            var serviceProvider = services.BuildServiceProvider();
            var menuDialog = serviceProvider.GetRequiredService<MainMenuDialog>();
            await menuDialog.ShowMainMenu();



        }
    }
}