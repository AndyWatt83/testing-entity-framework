using System.Collections.Generic;

namespace SampleDatabase.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tagline { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
