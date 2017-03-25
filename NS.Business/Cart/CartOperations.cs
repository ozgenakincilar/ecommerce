using NS.Business.Helpers;
using System.Collections.Generic;
using System.Linq;
using System;

namespace NS.Business.Cart
{
    public class CartOperations : ICartOperations
    {
        public const string CartSessionStorageKey = "CurrentCart";
        public void AddToCart(ICartItem cartItem)
        {
            var currentCart = GetAllCart();

            if (currentCart == null)
                currentCart = new List<ICartItem>();

            if (currentCart.Any(x => x.ProductId == cartItem.ProductId))
            {
                var product = currentCart.FirstOrDefault(x => x.ProductId == cartItem.ProductId);

                product.Quantity += cartItem.Quantity;
            }
            else
            {
                currentCart.Add(cartItem);
            }

            SessionHelper.SetSessionObject(currentCart, CartSessionStorageKey);
        }

        public void EmptyCart()
        {
            SessionHelper.SetSessionObject(new List<ICartItem>(), CartSessionStorageKey);
        }

        public List<ICartItem> GetAllCart()
        {
            return SessionHelper.GetSessionAsObject<List<ICartItem>>(CartSessionStorageKey);
        }

        public void RemoveFromCart(ICartItem cartItem)
        {
            var currentCart = GetAllCart();

            if (currentCart.Any(x => x.ProductId == cartItem.ProductId))
            {
                var product = currentCart.FirstOrDefault(x => x.ProductId == cartItem.ProductId);

                currentCart.Remove(product);

                SessionHelper.SetSessionObject(currentCart, CartSessionStorageKey);
            }
        }

        public int TotalItemCount()
        {
            var currentCart = GetAllCart();

            if (currentCart == null) return 0;

            return currentCart.Count;
        }

        public decimal TotalPrice()
        {
            var currentCart = GetAllCart();

            if (currentCart == null) return 0;

            return currentCart.Sum(x => x.UnitPrice * x.Quantity);
        }

        public void UpdateItemQuantityInCart(ICartItem cartItem)
        {
            var currentCart = GetAllCart();

            if (currentCart == null)
                currentCart = new List<ICartItem>();

            if (currentCart.Any(x => x.ProductId == cartItem.ProductId))
            {
                var product = currentCart.FirstOrDefault(x => x.ProductId == cartItem.ProductId);

                product.Quantity = cartItem.Quantity;
            }

            SessionHelper.SetSessionObject(currentCart, CartSessionStorageKey);
        }
    }
}
