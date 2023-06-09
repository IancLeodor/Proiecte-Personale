using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using System;


public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {


        //services.AddDbContext<SamuraiContext>(opt =>
        //opt.UseSqlServer(Configuration.GetConnectionString("SamuraiConn")));
       // .EnableSensitiveDataLogging()
       // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        services.AddControllers();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}