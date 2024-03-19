using Microsoft.EntityFrameworkCore;
using ToDoList.DataAccess.Contracts;
using ToDoList.DataAccess.DBContexts;
using ToDoList.DataAccess.Repositories;

namespace ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            if(builder.Environment.IsDevelopment())
            {
                var confbuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);
            }
            else
            {
                var confbuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
            }
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));

            #region Repositories
                builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
                builder.Services.AddScoped<IToDoElementRepository, ToDoElementRepository>();
            #endregion
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}



