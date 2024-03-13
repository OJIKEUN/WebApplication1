using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WebApplication1.Models;

namespace WebApplication1.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		public DbSet<Departemen> Departemens { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
	    public DbSet<WebApplication1.Models.StockBarang> StockBarang { get; set; } = default!;
	    public DbSet<WebApplication1.Models.Barang> Barang { get; set; } = default!;
        public object StockBarangs { get; internal set; }
    }
}	