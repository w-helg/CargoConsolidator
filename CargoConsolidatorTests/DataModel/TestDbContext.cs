using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoConsolidatorTests.DataModel
{
    internal class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options) 
            : base(options) => Database.EnsureCreated();

        public DbSet<Storage> Storages => Set<Storage>();
        public DbSet<Cargo> Cargos => Set<Cargo>();
        public DbSet<Item> Items => Set<Item>();
    }
}
