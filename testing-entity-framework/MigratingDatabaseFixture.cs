using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;
using System.Threading.Tasks;

namespace TestingEntityFramework
{
    public class MigratingDatabaseFixture<T> : IDisposable where T : DbContext
    {
        private bool disposedValue;
        private T _dataTrackerContext;
        private readonly DbContextOptions<T> _dbContextOptions;

        public MigratingDatabaseFixture(T context)
        {
            _dbContextOptions = new DbContextOptionsBuilder<T>()
               .UseNpgsql("Host=localhost;Port=5432;Username=local_dev;Password=local_dev;Database=data_tracker")
               .Options;

            _dataTrackerContext = context;
        }

        public async Task SetMigration(string migrationName)
        {
            await DatabaseContext.GetService<IMigrator>().MigrateAsync(migrationName);
        }

        public T DatabaseContext => _dataTrackerContext;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // This should delete the test database.
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
