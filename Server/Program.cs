using ElectronicJurnal.Server.DataBase;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJurnal.Server
{
	public class Program
	{
		public static void Main(string[] args)
		{

			var builder = WebApplication.CreateBuilder(args);


			builder.Services.AddControllersWithViews();
			builder.Services.AddRazorPages();
			var connectionString = builder.Configuration.GetConnectionString("mySql");

			builder.Services.AddDbContextPool<ApplicationDbContext>
				(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseBlazorFrameworkFiles();
			app.UseStaticFiles();

			app.UseRouting();


			app.MapRazorPages();
			app.MapControllers();
			app.MapFallbackToFile("index.html");

			app.Run();
		}
	}
}