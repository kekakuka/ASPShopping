using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_assignment.Data;
using asp_assignment.Models;
using asp_assignment.Models.ShoppingCartViewModels;
using Microsoft.AspNetCore.Mvc;
namespace asp_assignment.ViewComponents
{
    public class ShoppingCartViewModelViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCartViewModelViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(ReturnCurrentCartViewModel());
        }

        public ShoppingCartViewModel ReturnCurrentCartViewModel()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(_context),
                CartTotal = cart.GetSubTotal(_context)
            };
            return viewModel;
        }
    }
}
