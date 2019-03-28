using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asp_assignment.Data;
using asp_assignment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authorization;
using asp_assignment.Models.ShoppingCartViewModels;

namespace asp_assignment.Controllers
{
    [Authorize(Roles = "Admin,Member")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public OrdersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        [Authorize(Roles = "Admin")]
        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.Include(i => i.User).AsNoTracking().ToListAsync());
        }

       // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.Include(i => i.User).AsNoTracking().SingleOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            var orderSouvenirs = _context.OrderSouvenirs.Where(detail => detail.Order.OrderID == order.OrderID).Include(detail => detail.Souvenir).ToList();

            order.OrderSouvenirs = orderSouvenirs;
           
            return View(order);
        }

        // GET: Orders/Create
        public async Task<IActionResult> Create()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var viewShoppingCart = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(_context),
                CartTotal = cart.GetSubTotal(_context)
            };
            ViewData["Total"] ="Grand Total: $"+ viewShoppingCart.Total.ToString();
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            //var model = new ApplicationUser
            //{

            //    Email = user.Email,
            //    Address = user.Address,
            //    MobilePhoneNumber = user.MobilePhoneNumber,
            //    HomePhoneNumber = user.HomePhoneNumber,
            //    WorkPhoneNumber = user.WorkPhoneNumber,
            //    FullName = user.FullName

            //};
            return View(user);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("OrderID,OrderStatus,OrderDate,UserID")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(order);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", order.UserID);
        //    return View(order);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,Address,MobilePhoneNumber")]Order order)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {

                ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);
                List<CartItem> items = cart.GetCartItems(_context);
                List<OrderSouvenir> orderSouvenirs = new List<OrderSouvenir>();
                foreach (CartItem item in items)
                {

                    OrderSouvenir detail = CreateOrderDetailForThisItem(item);
                    detail.Order = order;
                    orderSouvenirs.Add(detail);
                    _context.Add(detail);

                }
                order.OrderStatus = OrderStatus.Waiting;
                order.User = user;
                order.OrderDate = DateTime.Today;
                order.SubTotal = ShoppingCart.GetCart(this.HttpContext).GetSubTotal(_context);
                order.OrderSouvenirs = orderSouvenirs;
                order.GST = order.SubTotal * 15 / 100;
                order.Total = order.SubTotal + order.GST;
                _context.SaveChanges();


                return RedirectToAction("Purchased", new RouteValueDictionary(
                new { action = "Purchased", id = order.OrderID }));
            }
         

            return View(order);
        }

        private OrderSouvenir CreateOrderDetailForThisItem(CartItem item)
        {

            OrderSouvenir detail = new OrderSouvenir();


            detail.Quantity = item.Count;
            detail.Souvenir = item.Souvenir;
            detail.UnitPrice = item.Souvenir.Price;

            return detail;

        }
        public async Task<IActionResult> Purchased(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.Include(i => i.User).AsNoTracking().SingleOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            var OrderSouvenirs = _context.OrderSouvenirs.Where(detail => detail.Order.OrderID == order.OrderID).Include(detail => detail.Souvenir).ToList();

            order.OrderSouvenirs= OrderSouvenirs;
            ShoppingCart.GetCart(this.HttpContext).EmptyCart(_context);
            return View(order);
        }

        // GET: Orders/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = await _context.Orders.SingleOrDefaultAsync(m => m.OrderID == id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", order.UserID);
        //    return View(order);
        //}

        //// POST: Orders/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("OrderID,OrderStatus,OrderDate,UserID")] Order order)
        //{
        //    if (id != order.OrderID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(order);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OrderExists(order.OrderID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", order.UserID);
        //    return View(order);
        //}
        [Authorize(Roles = "Admin")]
        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id,bool? saveChangesError)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var order = await _context.Orders
            //    .Include(o => o.User)
            //    .SingleOrDefaultAsync(m => m.OrderID == id);
            var order = await _context.Orders.Include(i => i.User).AsNoTracking().SingleOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                "Delete failed.Only can delete shipped order. Please ship the order and try again";
            }
            var orderSouvenirs = _context.OrderSouvenirs.Where(detail => detail.Order.OrderID == order.OrderID).Include(detail => detail.Souvenir).ToList();

            order.OrderSouvenirs = orderSouvenirs;
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(m => m.OrderID == id);
            if (order.OrderStatus==OrderStatus.Shipped)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
          
           
           
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Shipped(int id)
        {

            var order = await _context.Orders.SingleOrDefaultAsync(o => o.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            order.OrderStatus = OrderStatus.Shipped;
            _context.Update(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //private bool OrderExists(int id)
        //{
        //    return _context.Orders.Any(e => e.OrderID == id);
        //}
    }
}
