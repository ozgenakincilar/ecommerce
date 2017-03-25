using System.Collections.Generic;

namespace NS.Business.Cart
{
    public interface ICartOperations
    {
        List<ICartItem> GetAllCart();
        decimal TotalPrice();
        int TotalItemCount();
        void AddToCart(ICartItem cartItem);
        void RemoveFromCart(ICartItem cartItem);
        void UpdateItemQuantityInCart(ICartItem cartItem);
        void EmptyCart();
    }
}
