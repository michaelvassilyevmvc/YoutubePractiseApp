
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public class AppDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MascaradeDB;Username=postgres;Password='Q2w3e4r5!'");
        }

    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
