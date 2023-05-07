using euprava_sud.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DBConnectionString")));
/*builder.Services.AddDatabaseDeveloperPageExceptionFilter();*/

var app = builder.Build();

// Configure the HTTP request pipeline.

/*app.UseAuthorization();*/

app.MapControllers();

/*app.UseSwagger();
app.UseSwaggerUI();*/
app.Run();


/*using euprava_sud;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
*/
