﻿using System;
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

        public void AddToCart(int userId, int bookId, int quantity, bool update)
        {
            using (var context = new AppContext())
            {
                var cart = GetCartByUserId(userId);
                if (cart == null)
                {
                    cart = CreateCart(userId);
                }

                var cartItem = context.CartItems.FirstOrDefault(ci => ci.CartId == cart.CartId && ci.BookId == bookId);
                if (cartItem != null)
                {
                    if (update)
                    {
                        cartItem.Quantity = quantity;
                    }
                    else
                    {
                        cartItem.Quantity += quantity;
                    }
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

        public Cart CreateCart(int userId)
        {
            using (var context = new AppContext())
            {
                Cart cart = new Cart { UserId = userId, CreatedAt = DateTime.Now };
                context.Carts.Add(cart);
                context.SaveChanges();
                return cart;
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

        public void RemoveCartItem(int userId, int bookId)
        {
            using (var context = new AppContext())
            {
                var cart = GetCartByUserId(userId);
                if (cart != null)
                {
                    var cartItem =
                        context.CartItems.FirstOrDefault(ci => ci.CartId == cart.CartId && ci.BookId == bookId);
                    if (cartItem != null)
                    {
                        context.CartItems.Remove(cartItem);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}