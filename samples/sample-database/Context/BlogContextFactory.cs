using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SampleDatabase.Context
{
    class BlogContextFactory : IDesignTimeDbContextFactory<BlogContext>
    {
        public BlogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=local_dev;Password=local_dev;Database=blogging_demo");

            return new BlogContext(optionsBuilder.Options);
        }
    }
}
