using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoraunt.Data
{
    public class RestorauntDbContext : DbContext
    {
        public RestorauntDbContext(DbContextOptions<RestorauntDbContext> options): base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Position> Properties { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Section> Sections { get; set; }
    }
}
