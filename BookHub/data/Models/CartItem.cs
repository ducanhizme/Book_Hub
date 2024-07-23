using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookHub.data.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Book Book { get; set; }
    }
}