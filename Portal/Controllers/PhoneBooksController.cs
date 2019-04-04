using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BLL;
using Portal.Models;

namespace Portal.Controllers
{
    public class PhoneBooksController : Controller
    {
        private readonly PortalContext _context;

        public PhoneBooksController(PortalContext context)
        {
            _context = context;
        }

        // GET: PhoneBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhoneBooks.ToListAsync());
        }

        // GET: PhoneBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneBooks = await _context.PhoneBooks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (phoneBooks == null)
            {
                return NotFound();
            }

            return View(phoneBooks);
        }

        // GET: PhoneBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhoneBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,PhoneNumber,EmailAddress")] PhoneBooks phoneBooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phoneBooks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phoneBooks);
        }

        // GET: PhoneBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneBooks = await _context.PhoneBooks.FindAsync(id);
            if (phoneBooks == null)
            {
                return NotFound();
            }
            return View(phoneBooks);
        }

        // POST: PhoneBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,PhoneNumber,EmailAddress")] PhoneBooks phoneBooks)
        {
            if (id != phoneBooks.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneBooksExists(phoneBooks.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(phoneBooks);
        }

        // GET: PhoneBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneBooks = await _context.PhoneBooks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (phoneBooks == null)
            {
                return NotFound();
            }

            return View(phoneBooks);
        }

        // POST: PhoneBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phoneBooks = await _context.PhoneBooks.FindAsync(id);
            _context.PhoneBooks.Remove(phoneBooks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneBooksExists(int id)
        {
            return _context.PhoneBooks.Any(e => e.ID == id);
        }
    }
}
