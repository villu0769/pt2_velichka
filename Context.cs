using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velichka_Zhelyazkova_11zh.Data.Models;

namespace Velichka_Zhelyazkova_11zh.Data
{
	public class Context : DbContext
	{
		public DbSet<Book> Books {get;set;}
		public DbSet<Reader> Readers { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public Context(DbContextOptions options) : base(options)
		{

		}

		public Context()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Configuration.connectionString);
			}
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Reader>().HasMany(x => x.Books).WithMany(x=>x.Readers);

			modelBuilder.Entity<Book>().HasMany(x=>x.Genres);
			modelBuilder.Entity<Genre>().HasMany(x => x.Readers);
		}

	}
}
