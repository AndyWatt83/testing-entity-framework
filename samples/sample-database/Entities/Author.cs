using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDatabase.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
