using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookHub.data.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Navigation properties
        public virtual Order Order { get; set; }
        public virtual Book Book { get; set; }
    }
}