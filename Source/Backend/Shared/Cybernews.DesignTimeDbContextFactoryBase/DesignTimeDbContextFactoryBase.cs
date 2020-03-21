using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json;

namespace Cybernews.DesignTimeDbContextFactoryBase
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext>
        where TContext : DbContext
    {
        public TContext CreateDbContext(string[] args)
        {
            string connectionString = string.Empty;

            string json = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            dynamic config = JsonConvert.DeserializeObject<dynamic>(json);

            connectionString = config.ConnectionString;

            return CreateDbContext(connectionString);
        }

        public TContext CreateDbContext(string connectionString)
        {
            DbContextOptionsBuilder<TContext> optionsBuilder = new DbContextOptionsBuilder<TContext>();

            optionsBuilder.UseSqlServer(connectionString);

            DbContextOptions<TContext> options = optionsBuilder.Options;
            return CreateInstance(options);
        }

        protected abstract TContext CreateInstance(DbContextOptions<TContext> options);
    }
}
