#region Using namespaces

using EFCore_Example.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

#endregion

namespace EFCore_Example.Infrastructure
{
    public class ClownsContext : DbContext
    {
        public ClownsContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<CircusEntity> Circuses { get; set; }

        public DbSet<ClownEntity> Clowns { get; set; }

        public DbSet<ClownPerformanceEntity> ClownPerformances { get; set; }

        public DbSet<CircusEventEntity> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=exampledb;Trusted_Connection=True;");
        }
    }
}