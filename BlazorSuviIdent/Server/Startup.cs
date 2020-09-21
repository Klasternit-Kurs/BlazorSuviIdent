using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;

namespace BlazorSuviIdent.Server
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<Baza>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("Baza")));

			services.AddIdentity<IdentityUser, IdentityRole>()
				.AddUserManager<UserManager<IdentityUser>>()
				.AddSignInManager<SignInManager<IdentityUser>>()
				.AddRoleManager<RoleManager<IdentityRole>>()
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<Baza>();

			services.AddIdentityServer()
				.AddApiAuthorization<IdentityUser, Baza>();

			services.AddAuthentication()
				.AddIdentityServerJwt();

			services.AddSignalR();
			services.AddControllersWithViews();
			services.AddRazorPages();
		}
		
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
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

			app.UseIdentityServer();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
				endpoints.MapControllers();
				endpoints.MapHub<Hubs.UserMan>("um");
				endpoints.MapFallbackToFile("index.html");
			});
		}
	}
}
