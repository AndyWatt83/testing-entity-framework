using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SampleDatabase.Context
{
    class BlogContextFactory : IDesignTimeDbContextFactory<BlogContext>
    {
        public BlogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
            optionsBuilder.UseSqlite("Data Source=Database/blogging.db");

            return new BlogContext(optionsBuilder.Options);
        }
    }
}
