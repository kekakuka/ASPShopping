using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asp_assignment.Data;
using asp_assignment.Models;
using Microsoft.AspNetCore.Authorization;
using asp_assignment.Models.WebsiteViewModels;

namespace asp_assignment.Controllers
{
    [AllowAnonymous]
    public class MemberSouvenirsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MemberSouvenirsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MemberSouvenirs
        public async Task<IActionResult> Index(int? id,int? page,string searchName, string searchMinPrice, string searchMaxPrice, string sortOrder)
        {
            ViewData["sign"] = sortOrder;
            ViewData["CurrentSearchName"] = searchName;
            ViewData["CurrentSearchMin"] = searchMinPrice;
            ViewData["CurrentSearchMax"] = searchMaxPrice;
            ViewData["PriceSortOrder"] = sortOrder == "glyphicon glyphicon-arrow-up" ? "glyphicon glyphicon-arrow-down" : "glyphicon glyphicon-arrow-up";
           
                 
            var viewModel = new SouvenirInCategory();
            var souvenirs = from s in _context.Souvenirs select s;
            viewModel.Categories = await _context.Categories.AsNoTracking().ToListAsync();
            if (id != null)
            {
                ViewData["CategoryID"] = id.Value;
                souvenirs = souvenirs.Where(s => s.CategoryID == id);
            }

            switch (sortOrder)
            {
                case "glyphicon glyphicon-arrow-up": souvenirs=souvenirs.OrderBy(s=>s.Price);break;
                case "glyphicon glyphicon-arrow-down": souvenirs=souvenirs.OrderByDescending(s=>s.Price);break;
            }

            if (!String.IsNullOrEmpty(searchName))
            {
                souvenirs = souvenirs.Where(s => s.Name.Contains(searchName));
            }
            if (!String.IsNullOrEmpty(searchMinPrice))
            {
                souvenirs = souvenirs.Where(s => s.Price >= Convert.ToDecimal(searchMinPrice));
            }
            if (!String.IsNullOrEmpty(searchMaxPrice))
            {
                souvenirs = souvenirs.Where(s => s.Price <= Convert.ToDecimal(searchMaxPrice));
            }
            viewModel.Souvenirs = await PaginatedList<Souvenir>.CreateAsync(souvenirs, page ?? 1, 6);

            return View(viewModel);
        }

        // GET: MemberSouvenirs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var souvenir = await _context.Souvenirs
                .Include(s => s.Category)
               
                .SingleOrDefaultAsync(m => m.SouvenirID == id);
            if (souvenir == null)
            {
                return NotFound();
            }

            return View(souvenir);
        }

        // GET: MemberSouvenirs/Create
        //public IActionResult Create()
        //{
        //    ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID");
        //    ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID");
        //    return View();
        //}

        //// POST: MemberSouvenirs/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("SouvenirID,Name,PathOfFile,Description,Price,CategoryID,SupplierID")] Souvenir souvenir)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(souvenir);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", souvenir.CategoryID);
        //    ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID", souvenir.SupplierID);
        //    return View(souvenir);
        //}

        //// GET: MemberSouvenirs/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var souvenir = await _context.Souvenirs.SingleOrDefaultAsync(m => m.SouvenirID == id);
        //    if (souvenir == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", souvenir.CategoryID);
        //    ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID", souvenir.SupplierID);
        //    return View(souvenir);
        //}

        //// POST: MemberSouvenirs/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("SouvenirID,Name,PathOfFile,Description,Price,CategoryID,SupplierID")] Souvenir souvenir)
        //{
        //    if (id != souvenir.SouvenirID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(souvenir);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SouvenirExists(souvenir.SouvenirID))
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
        //    ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", souvenir.CategoryID);
        //    ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID", souvenir.SupplierID);
        //    return View(souvenir);
        //}

        //// GET: MemberSouvenirs/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var souvenir = await _context.Souvenirs
        //        .Include(s => s.Category)
        //        .Include(s => s.Supplier)
        //        .SingleOrDefaultAsync(m => m.SouvenirID == id);
        //    if (souvenir == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(souvenir);
        //}

        //// POST: MemberSouvenirs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var souvenir = await _context.Souvenirs.SingleOrDefaultAsync(m => m.SouvenirID == id);
        //    _context.Souvenirs.Remove(souvenir);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool SouvenirExists(int id)
        {
            return _context.Souvenirs.Any(e => e.SouvenirID == id);
        }
    }
}
