using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookHub.data.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}