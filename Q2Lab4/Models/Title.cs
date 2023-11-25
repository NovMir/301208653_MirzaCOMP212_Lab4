using System;
using System.Collections.Generic;

namespace Q2Lab4.Models
{
    public partial class Title
    {
        public Title()
        {
            Authors = new HashSet<Author>();
        }

        public string Isbn { get; set; } = null!;
        public string Title1 { get; set; } = null!;
        public int EditionNumber { get; set; }
        public string Copyright { get; set; } = null!;

        public virtual ICollection<Author> Authors { get; set; }
    }
}
