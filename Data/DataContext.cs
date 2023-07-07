using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DONET_RPG.Data
{
    public class DataContext : DbContext
    {
        static readonly string connectionString = "Server=localhost; User ID=root; Password=Pokas@131293; Database=DotnetRPG;";
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<Character> Characters => Set<Character>();

    }
}