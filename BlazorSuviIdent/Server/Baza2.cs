using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuviIdent.Server
{
	public class Baza2 : DbContext
	{
		public Baza2(DbContextOptions<Baza2> options)
				: base(options) { }
		public DbSet<Bla> Blas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Bla>().HasKey(b => b.Asd);
		}
	}

	public class Bla
	{
		public int Asd { get; set; }
	}
}
