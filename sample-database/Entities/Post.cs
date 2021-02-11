using System;

namespace SampleDatabase.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        // public string AuthorName { get; set; }
        public DateTime Date { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
