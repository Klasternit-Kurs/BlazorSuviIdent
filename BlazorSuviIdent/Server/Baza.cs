using BlazorSuviIdent.Server.Modeli;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuviIdent.Server
{
	public class Baza : ApiAuthorizationDbContext<IdentityUser>
	{

		DbSet<NekiMojJuzer> NekiMojJuzers { get; set; }

		public Baza(
			DbContextOptions<Baza> options,
			IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions) {}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<IdentityRole>().HasData(
				new IdentityRole { Id = Guid.NewGuid().ToString(), Name="Admin", NormalizedName="ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() },
				new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER", ConcurrencyStamp = Guid.NewGuid().ToString() }
				);
		}
	}
}
