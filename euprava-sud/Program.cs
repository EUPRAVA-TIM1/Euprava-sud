using euprava_sud.Data;
using euprava_sud.Repository;
using euprava_sud.Repository.Interfaces;
using euprava_sud.Service;
using euprava_sud.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions( o =>
{
    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    o.JsonSerializerOptions.MaxDepth = 10;
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DBConnectionString")));
/*builder.Services.AddDatabaseDeveloperPageExceptionFilter();*/

builder.Services.AddScoped<IOpstinaRepository, OpstinaRepository>();
builder.Services.AddScoped<IDokumentRepository, DokumentRepository>();
builder.Services.AddScoped<IGradjaninRepository, GradjaninRepository>();
builder.Services.AddScoped<IOdlukaSudijeRepository, OdlukaSudijeRepository>();
builder.Services.AddScoped<IPredmetRepository, PredmetRepository>();
builder.Services.AddScoped<IPrekrsajnaPrijavaRepository, PrekrsajnaPrijavaRepository>();
builder.Services.AddScoped<IRocisteRepository, RocisteRepository>();
builder.Services.AddScoped<ISudijaRepository, SudijaRepository>();
builder.Services.AddScoped<ISudRepository, SudRepository>();
/*builder.Services.AddScoped<IOpstinaRepository, GenericRepository>();*/
builder.Services.AddScoped<IOpstinaService, OpstinaService>();
builder.Services.AddScoped<IDokumentService, DokumentService>();
builder.Services.AddScoped<IGradjaninService, GradjaninService>();
builder.Services.AddScoped<IOdlukaSudijeService, OdlukaSudijeService>();
builder.Services.AddScoped<IPredmetService, PredmetService>();
builder.Services.AddScoped<IPrekrsajnaPrijavaService, PrekrsajnaPrijavaService>();
builder.Services.AddScoped<IRocisteService, RocisteService>();
builder.Services.AddScoped<ISudijaService, SudijaService>();
builder.Services.AddScoped<ISudService, SudService>();

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
