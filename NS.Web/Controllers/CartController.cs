using AutoMapper;
using NS.Business.Cart;
using NS.Web.Models.Cart;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NS.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartOperations _cartOperations;
        public CartController(ICartOperations cartOperations)
        {
            _cartOperations = cartOperations;
        }

        public ActionResult Index()
        {
            var cartItems = _cartOperations.GetAllCart();

            var cartItemViewModels = new List<CartItemViewModel>();

            if (cartItems != null && cartItems.Any())
            {
                cartItemViewModels = cartItems.Select(x => Mapper.Map<CartItemViewModel>(x)).ToList();
            }

            return View(cartItemViewModels);
        }

        public ActionResult TotalItemCount()
        {
            var cartTotalItemCountViewModel = new CartTotalItemCountViewModel();

            cartTotalItemCountViewModel.TotalItemCount = _cartOperations.TotalItemCount();

            return PartialView(cartTotalItemCountViewModel);
        }

        public ActionResult DeleteFromCart(int? productId)
        {
            if (!productId.HasValue)
                return RedirectToAction("Index");

            var currentCart = _cartOperations.GetAllCart();

            var cartItem = currentCart.FirstOrDefault(x => x.ProductId == productId);

            if (cartItem != null)
            {
                _cartOperations.RemoveFromCart(cartItem);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCartItem(CartItemViewModel cartItemViewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var currentCart = _cartOperations.GetAllCart();

            var cartItem = currentCart.FirstOrDefault(x => x.ProductId == cartItemViewModel.ProductId);

            if (cartItem != null)
            {
                cartItem.Quantity = cartItemViewModel.Quantity;

                _cartOperations.UpdateItemQuantityInCart(cartItem);
            }

            return RedirectToAction("Index");
        }
    }
}