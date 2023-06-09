using Gamespirit.Data;
using Gamespirit.Repositories;
using Gamespirit.Repositories.Interfaces;
using Gamespirit.Services;
using Gamespirit.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Gamespirit.Areas.Identity.Data;
using DigitalSchoolWorkspace.Services;
using DigitalSchoolWorkspace.Repositories;

namespace Gamespirit
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
			builder.Services.AddDefaultIdentity<GamespiritUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddRoles<IdentityRole<Guid>>()
				.AddEntityFrameworkStores<ApplicationDbContext>();
			builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));



			builder.Services.AddScoped<IGameRepository, GameRepository>();
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<IGameService, GameService>();
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
			builder.Services.AddScoped<IRentHistoryService, RentHistoryService>();
			builder.Services.AddScoped<IRentHistoryRepository, RentHistoryRepository>();
			builder.Services.AddScoped<IRequestRepository, RequestRepository>();
			builder.Services.AddScoped<IRequestService, RequestService>();

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddRazorPages();
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
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.MapRazorPages();
			app.Run();
		}
	}
}