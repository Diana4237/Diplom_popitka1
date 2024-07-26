using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Diplom_popitka1.Models;
namespace Diplom_popitka1
{
    public class DB
    {
        public DB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache(); // Кэширование в памяти
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20); // Время простоя сессии
                options.Cookie.HttpOnly = true; //  Защищает  от  скриптовых  атак
                options.Cookie.IsEssential = true; //  Включение  в  HTTP-заголовки  Cookie
            });
            services.AddOptions();
            string connection = Configuration.GetConnectionString("DefaultConnection");
             services.AddDbContext<diplom_popitca1Context>(options => options.UseSqlServer(connection));

            services.AddMvc();

        }
        public void Configure(WebApplication app, IWebHostEnvironment env, IServiceProvider serviceProvider)
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
            app.UseSession();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            /*app.MapGet("/", () => { });*/

            var dbContext = serviceProvider.GetService<diplom_popitca1Context>();
            SampleData.Initialize(dbContext, env);
        }
    
}
}
