using System;
using System.Collections.Generic;
using System.Linq;
using BookHub.data.Models;

namespace BookHub.data.Repository
{
    public class CartRepository
    {
        
        public Cart GetCartByUserId(int userId)
        {
            using (var context = new AppContext())
            {
                return context.Carts.FirstOrDefault(c => c.UserId == userId);
            }
        }
        public void AddToCart(int userId, int bookId, int quantity)
        {
            using (var context = new AppContext())
            {
                var cart = GetCartByUserId(userId);
                if (cart == null)
                {
                    cart = new Cart { UserId = userId, CreatedAt = DateTime.Now };
                    context.Carts.Add(cart);
                    context.SaveChanges();
                }

                var cartItem = context.CartItems.FirstOrDefault(ci => ci.CartId == cart.CartId && ci.BookId == bookId);
                if (cartItem != null)
                {
                    cartItem.Quantity += quantity;
                }
                else
                {
                    cartItem = new CartItem
                    {
                        CartId = cart.CartId,
                        BookId = bookId,
                        Quantity = quantity
                    };
                    context.CartItems.Add(cartItem);
                }
                context.SaveChanges();
            }
        }

        public List<CartItem> GetCartItemsByUserId(int userId)
        {
            using (var context = new AppContext())
            {
                var cart = context.Carts.FirstOrDefault(c => c.UserId == userId);
                if (cart != null)
                {
                    var cartItems = context.CartItems.Where(ci => ci.CartId == cart.CartId).ToList();
                    return cartItems;
                }
                return new List<CartItem>();
            }
        }
        
        public void RemoveAllCartItemsByCartId(int cartId)
        {
            using (var context = new AppContext())
            {
                var cartItems = context.CartItems.Where(ci => ci.CartId == cartId).ToList();
                foreach (var item in cartItems)
                {
                    context.CartItems.Remove(item);
                }
                context.SaveChanges();
            }
        }
    }
}