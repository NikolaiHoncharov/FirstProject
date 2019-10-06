using DataBaseLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer
{
    public class EFDBContext : DbContext 
    {
        public DbSet<Directory> Directories { get; set; }
        public DbSet<Material> Materials { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }
    }
    /// <summary>
    /// For Migrations
    /// </summary>
    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AspProjectDB;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataBaseLayer"));

            return new EFDBContext(optionsBuilder.Options);
        }
    }

}
