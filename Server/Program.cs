using ElectronicJournal.Server.DataBase;
using ElectronicJournal.Server.Services.Students;
using ElectronicJournal.Server.Services.Teachers;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJournal.Server
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

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddScoped<ITeachersService, TeachersService>();
			builder.Services.AddScoped<IStudentsService, StudentsService>();

			builder.Services.AddAutoMapper(typeof(Program));
			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});


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