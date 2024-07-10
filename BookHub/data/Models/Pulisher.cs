using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookHub.data.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}