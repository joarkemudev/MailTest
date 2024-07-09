using MailTest.Models;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    public Startup(Iconfiguration Configuration)
    {
        Configuration = Configuration;
    }

    public Iconfiguration Configuration {get;}
    
    public void ConfigurationServices(IServiveCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21 ))));

        services.AddControllersWhithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnviroment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            
        });
    }

}