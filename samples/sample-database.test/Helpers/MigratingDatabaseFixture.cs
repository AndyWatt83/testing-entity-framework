using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using SampleDatabase.Context;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SampleDatabase.Test
{
    public class MigratingDatabaseFixture : IDisposable
    {
        private bool disposedValue;
        private BlogContext _blogContext;
        private readonly DbContextOptions<BlogContext> _dbContextOptions;

        public MigratingDatabaseFixture()
        {
            _dbContextOptions = new DbContextOptionsBuilder<BlogContext>()
               .UseNpgsql("Host=localhost;Port=5432;Username=local_dev;Password=local_dev;Database=blogging_demo")
               .Options;

            _blogContext = new BlogContext(_dbContextOptions);
        }

        public async Task SetMigration(string migrationName)
        {
            await DatabaseContext.GetService<IMigrator>().MigrateAsync(migrationName);
        }

        public void RunScript(string fileLocation)
        {
            var script = File.ReadAllText(fileLocation);
            _blogContext.Database.ExecuteSqlRaw(script);
        }

        public BlogContext DatabaseContext => _blogContext;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // This should delete the test database.
                    _blogContext.Database.ExecuteSqlRaw(@"delete from ""Blogs""");
                }
                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
