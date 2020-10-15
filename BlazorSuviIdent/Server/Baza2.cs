using BlazorSuviIdent.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuviIdent.Server
{
	public class Baza2 : DbContext
	{
		public DbSet<Osoba> Osobas { get; set; }

		public Baza2(DbContextOptions<Baza2> options)
				: base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Osoba>().HasKey(b => b.ID);

			modelBuilder.Entity<Osoba>().HasData(new Osoba { ID = Guid.NewGuid().ToString(), Ime = "Pera", Prezime = "Peric" },
				new Osoba { ID = Guid.NewGuid().ToString(), Ime = "Neko", Prezime = "Nekic" });
		}
	}


}
