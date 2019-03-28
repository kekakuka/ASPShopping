using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_assignment.Data;
using asp_assignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace asp_assignment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminApplicationUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminApplicationUsersController(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationUser> members = ReturnAllMembers().Result;
            return View(members);
        }

        public async Task<IEnumerable<ApplicationUser>> ReturnAllMembers()
        {
            var users = await _userManager.GetUsersInRoleAsync("Member");
            return users;
        }
        public async Task<IActionResult> EnableDisable(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            IEnumerable<ApplicationUser> members = ReturnAllMembers().Result;
            ApplicationUser member = (ApplicationUser)members.Single(u => u.Id == id);
            if (member == null)
            {
                return NotFound();
            }
            member.Enabled = !member.Enabled;
            _context.Update(member);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        // GET: ApplicationUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.Users
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }



        // GET: ApplicationUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,ApplicationUser model)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            if (ModelState.IsValid)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.MobilePhoneNumber = model.MobilePhoneNumber;
                user.Address = model.Address;
                user.HomePhoneNumber = model.HomePhoneNumber;
                user.EmailConfirmed = model.EmailConfirmed;
                user.WorkPhoneNumber = model.WorkPhoneNumber;
                try
                {

                    _context.Update(user);
                    await _context.SaveChangesAsync();
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
 "Try again, and if the problem persists, " +
 "see your system administrator.");
                }

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ApplicationUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.Users
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationUser = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            _context.Users.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}