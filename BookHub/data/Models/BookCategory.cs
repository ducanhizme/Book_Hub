using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookHub.data.Models
{
    public class BookCategory

    {
        public int BookCategoryId { get; set; }
        public int BookId { get; set; }
        public int CategoryId { get; set; }

        // Navigation properties
        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; }
    }
}