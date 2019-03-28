using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using asp_assignment.Data;
using asp_assignment.Models;
using Microsoft.AspNetCore.Authorization;

namespace asp_assignment.Controllers
{
    [AllowAnonymous]
    public class ShoppingCartController : Controller
    {
        ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            // Return the view
            return View(cart);
        }

        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
           
            // Retrieve the album from the database
            var addedSouvenirs = _context.Souvenirs
                .Single(souvenir => souvenir.SouvenirID == id);
            addedSouvenirs.Category = _context.Categories.Single(c => c.CategoryID == addedSouvenirs.CategoryID);
            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedSouvenirs, _context);
            // Go back to the main store page for more shopping
            return Redirect(Request.Headers["Referer"].ToString());

        }

       
        public ActionResult RemoveFromCart(int id)
        {
          
            var cart = ShoppingCart.GetCart(this.HttpContext);
            int itemCount = cart.RemoveFromCart(id, _context);
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public ActionResult ClearCart()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.EmptyCart(_context);
            return Redirect(Request.Headers["Referer"].ToString());
        }

    }
}