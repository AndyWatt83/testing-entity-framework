using Microsoft.EntityFrameworkCore;
using SampleDatabase.Entities;

namespace SampleDatabase.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Blog>()
            .HasData(
                new Blog()
                {
                    Id = 23,
                    Name = "I Heart Entity Framework",
                    Tagline = "Stick your SQL up your datacontext"
                },
                new Blog()
                {
                    Id = 24,
                    Name = "Photos of my face",
                    Tagline = "My life is awesome"
                }
            );

            modelBuilder.Entity<Post>().HasData(
                new Post() { Id = 1, BlogId = 23, Title = "", Content = "", AuthorName = "" },
                new Post() { Id = 2, BlogId = 23, Title = "", Content = "", AuthorName = "" },
                new Post() { Id = 3, BlogId = 23, Title = "", Content = "", AuthorName = "" },
                new Post() { Id = 4, BlogId = 24, Title = "", Content = "", AuthorName = "" },
                new Post() { Id = 5, BlogId = 24, Title = "", Content = "", AuthorName = "" },
                new Post() { Id = 6, BlogId = 24, Title = "", Content = "", AuthorName = "" }
            );
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
