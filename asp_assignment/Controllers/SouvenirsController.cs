using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asp_assignment.Data;
using asp_assignment.Models;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace asp_assignment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SouvenirsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnv;
        public SouvenirsController(ApplicationDbContext context, IHostingEnvironment hEnv)
        {
            _context = context;
            _hostingEnv = hEnv;
        }

        // GET: Souvenirs
        public async Task<IActionResult> Index(string searchName)
        {
            ViewData["CurrentSearchName"] = searchName;
            var souvenirs = from s in _context.Souvenirs select s;          
            if (!String.IsNullOrEmpty(searchName))
            {
                souvenirs = souvenirs.Where(s => s.Name.Contains(searchName));
            }
            return View(await souvenirs.ToListAsync());
        }

        // GET: Souvenirs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var souvenir = await _context.Souvenirs
                .Include(s => s.Category)
                .Include(s => s.Supplier)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.SouvenirID == id);
            if (souvenir == null)
            {
                return NotFound();
            }

            return View(souvenir);
        }

        // GET: Souvenirs/Create
        public async Task<IActionResult> Create()
        {
            var category = await _context.Categories.SingleOrDefaultAsync(m => m.Name == "Maori Gift");
            PopulateCategorySupplierDropDownList(category.CategoryID);
            return View();
        }

        // POST: Souvenirs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SouvenirID,Name,Description,Price,CategoryID,SupplierID")] Souvenir souvenir, IList<IFormFile> _files)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var relativeName = "";
                    var fileName = "";
                    if (_files.Count < 1)
                    {
                        relativeName = "/Images/Default.jpg";
                    }
                    else
                    {
                        foreach (var file in _files)
                        {
                            fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition)
                                .FileName.Trim('"');
                            relativeName = "/Images/SouvenirImages/" + DateTime.Now.ToString("ddMMyyyy-HHmmssffffff") + fileName;
                            using (FileStream fs = System.IO.File.Create(_hostingEnv.WebRootPath + relativeName))
                            {
                                await file.CopyToAsync(fs);
                                fs.Flush();
                            }
                        }
                    }
                    souvenir.PathOfFile = relativeName;
                    _context.Add(souvenir);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            PopulateCategorySupplierDropDownList(souvenir.CategoryID, souvenir.SupplierID);
            return View(souvenir);
        }

        private void PopulateCategorySupplierDropDownList(object selectedCategory = null, object selectedSupplier = null)
        {
            var categoriesQuery = from c in _context.Categories
                                  orderby c.Name
                                  select c;
            ViewBag.CategoryID = new SelectList(categoriesQuery.AsNoTracking(), "CategoryID", "Name", selectedCategory);
            var suppliersQuery = from s in _context.Suppliers
                                 orderby s.FullName
                                 select s;
            ViewBag.SupplierID = new SelectList(suppliersQuery.AsNoTracking(), "SupplierID", "FullName", selectedSupplier);

        }

      

        // GET: Souvenirs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var souvenir = await _context.Souvenirs.SingleOrDefaultAsync(m => m.SouvenirID == id);
            if (souvenir == null)
            {
                return NotFound();
            }
            PopulateCategorySupplierDropDownList(souvenir.CategoryID, souvenir.SupplierID);
            Category category = souvenir.Category;
            return View(souvenir);
        }

        // POST: Souvenirs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, IList<IFormFile> _files, byte[] rowVersion)
        {
            if (id == null)
            {
                return NotFound();
            }
            var relativeName = "";
            var fileName = "";
            var souvenir = await _context.Souvenirs.SingleOrDefaultAsync(s => s.SouvenirID == id);
            if (souvenir==null)
            {
                Souvenir deleteSouvenir = new Souvenir();
                await TryUpdateModelAsync(deleteSouvenir);
                ModelState.AddModelError("", "The Souvenir is deleted by another user.");
                PopulateCategorySupplierDropDownList(deleteSouvenir.CategoryID, deleteSouvenir.SupplierID);
                return View(deleteSouvenir);
            }
            if (_files.Count < 1)
            {
                relativeName = souvenir.PathOfFile;
            }
            else
            {
                foreach (var file in _files)
                {
                    fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition)
                        .FileName.Trim('"');
                    relativeName = "/Images/SouvenirImages/" + DateTime.Now.ToString("ddMMyyyy-HHmmssffffff") + fileName;
                    using (FileStream fs = System.IO.File.Create(_hostingEnv.WebRootPath + relativeName))
                    {
                        await file.CopyToAsync(fs);
                        fs.Flush();
                    }
                }
            }                  
            souvenir.PathOfFile = relativeName;

            _context.Entry(souvenir).Property("RowVersion").OriginalValue = rowVersion;
            if (await TryUpdateModelAsync(souvenir, "", s => s.Name, s => s.Description, s => s.CategoryID, s => s.SupplierID, s => s.Price))
            {
                try
                {
                   
                    _context.Update(souvenir);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues =(Souvenir)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry==null)
                    {
                        ModelState.AddModelError("", "The Souvenir is deleted by another user.");
                    }
                    else
                    {
                        var databaseValues = (Souvenir)databaseEntry.ToObject();
                        if (databaseValues.Name!=clientValues.Name)
                        {
                            ModelState.AddModelError("Name", $"Currennt Value:{databaseValues.Name}");
                        }
                        if (databaseValues.Description != clientValues.Description)
                        {
                            ModelState.AddModelError("Description", $"Currennt Value:{databaseValues.Description}");
                        }
                        if (databaseValues.Price != clientValues.Price)
                        {
                            ModelState.AddModelError("Price", $"Currennt Value:{databaseValues.Price}");
                        }
                        if (databaseValues.PathOfFile != clientValues.PathOfFile)
                        {
                            ModelState.AddModelError("Image", $"Currennt Value:{databaseValues.PathOfFile}");
                        }
                        if (databaseValues.CategoryID != clientValues.CategoryID)
                        {
                            ModelState.AddModelError("CategoryID ", $"Currennt Value:{databaseValues.CategoryID }");
                        }
                        if (databaseValues.SouvenirID != clientValues.SouvenirID)
                        {
                            ModelState.AddModelError("SouvenirID", $"Currennt Value:{databaseValues.SupplierID}");
                        }
                        ModelState.AddModelError("", "The record is changed by another user.If you still want to edit Click save button");
                        souvenir.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }                 
                }
               
            }
            PopulateCategorySupplierDropDownList(souvenir.CategoryID, souvenir.SupplierID);
            return View(souvenir);
        }



        // GET: Souvenirs/Delete/5
        public async Task<IActionResult> Delete(int? id,bool? concurrencyError)
        {
            if (id == null)
            {
                return NotFound();
            }

            var souvenir = await _context.Souvenirs
                .Include(s => s.Category)
                .Include(s => s.Supplier)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.SouvenirID == id);
            if (souvenir == null)
            {
                if (concurrencyError.GetValueOrDefault())
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            if (concurrencyError.GetValueOrDefault())
            {
                ViewData["ConcurrencyErrorMessage"] =
                    "The record you attempted to delete was changed.If you still want to delete it, click the delete button again. ";
            }
            return View(souvenir);
        }

        // POST: Souvenirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Souvenir souvenir)
        {
           
           
            try
            {
                if (await _context.Souvenirs.AnyAsync(s=>s.SouvenirID==souvenir.SouvenirID))
                {
                    _context.Souvenirs.Remove(souvenir);
                    await _context.SaveChangesAsync();
                }
                
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
               
                return RedirectToAction(nameof(Delete), new { concurrencyError = true, id = souvenir.SouvenirID });
            }
            catch (DbUpdateException)
            {
                TempData["SouvenirUsed"] = "The Souvenir is in previous orders. Delete those orders and try again.";
                return RedirectToAction("Delete");
            }
         


        }

        private bool SouvenirExists(int id)
        {
            return _context.Souvenirs.Any(e => e.SouvenirID == id);
        }
    }
}
