using Conduzze.SimaoRossy.Data.Contextt;
using Microsoft.EntityFrameworkCore;
using Conduzze.SimaoRossy.Data.Repository;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<Context>(options =>
         options.UseSqlServer(
             Configuration.GetConnectionString("DefaultConnection"),
             b => b.MigrationsAssembly("Conduzze.SimaoRossy.MVC")
         ));

        services.AddControllersWithViews().AddRazorRuntimeCompilation(); 

        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddCors(options =>
        {
            options.AddPolicy("All", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
        });

        services.AddTransient<DepartamentoRepository>();
        services.AddTransient<DivisaoRepository>();
        services.AddTransient<SetorRepository>();
        services.AddTransient<FuncionarioRepository>();
    }

    public void Configure(WebApplication app, IWebHostEnvironment environment)
    {
        app.MapControllers();
        app.UseAuthorization();

        app.MapControllerRoute(
        "default",
        "{api}/{controller}/{action}/{id}");
    }
}