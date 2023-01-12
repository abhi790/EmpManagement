using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace EmployeeManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connString = builder.Configuration.GetConnectionString("mySqlConn");
                builder.Services.AddDbContextPool<EmployeeManagement.Models.EmployeeDbContext>(o => o.UseMySql(connString,ServerVersion.AutoDetect(connString)));

            builder.Services.AddControllersWithViews();
            // builder.Services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
            builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            

            var app = builder.Build();

            app.UseStaticFiles();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}