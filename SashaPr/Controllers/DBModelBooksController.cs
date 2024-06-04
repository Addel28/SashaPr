using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SashaPr.Data;
using SashaPr.Models;

namespace SashaPr.Controllers
{
    public class DBModelBooksController : Controller
    {
        private readonly SashaPrContext _context;

        public DBModelBooksController(SashaPrContext context)
        {
            _context = context;
        }

        // GET: DBModelBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.DBModelBook.ToListAsync());
        }

        // GET: DBModelBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dBModelBook = await _context.DBModelBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dBModelBook == null)
            {
                return NotFound();
            }

            return View(dBModelBook);
        }

        // GET: DBModelBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DBModelBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Author,Title,YearOfPub,Picture")] DBModelBook dBModelBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dBModelBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dBModelBook);
        }

        // GET: DBModelBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dBModelBook = await _context.DBModelBook.FindAsync(id);
            if (dBModelBook == null)
            {
                return NotFound();
            }
            return View(dBModelBook);
        }

        // POST: DBModelBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Author,Title,YearOfPub,Picture")] DBModelBook dBModelBook)
        {
            if (id != dBModelBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dBModelBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DBModelBookExists(dBModelBook.Id))
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
            return View(dBModelBook);
        }

        // GET: DBModelBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dBModelBook = await _context.DBModelBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dBModelBook == null)
            {
                return NotFound();
            }

            return View(dBModelBook);
        }

        // POST: DBModelBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dBModelBook = await _context.DBModelBook.FindAsync(id);
            if (dBModelBook != null)
            {
                _context.DBModelBook.Remove(dBModelBook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DBModelBookExists(int id)
        {
            return _context.DBModelBook.Any(e => e.Id == id);
        }
    }
}
