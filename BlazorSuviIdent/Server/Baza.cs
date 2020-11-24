using BlazorSuviIdent.Shared;
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

		public Baza(
			DbContextOptions<Baza> options,
			IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions) {}
		public DbSet<Osoba> Osobas { get; set; }
		public DbSet<Zklj> Zkljz { get; set; }

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
