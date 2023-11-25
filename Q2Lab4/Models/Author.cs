using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Q2Lab4.Models
{
    public partial class Author
    {
        public Author()
        {
            Isbns = new HashSet<Title>();
        }

        public int AuthorId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<Title> Isbns { get; set; }
    }
}
