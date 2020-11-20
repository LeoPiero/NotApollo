using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotApolloCore.Data;
using NotApolloCore.Models;

namespace NotApolloCore.Controllers
{
    public class ProgramOwnersController : Controller
    {
        private readonly NotApolloContext _context;

        public ProgramOwnersController(NotApolloContext context)
        {
            _context = context;
        }

        // GET: ProgramOwners
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProgramOwners.ToListAsync());
        }

        // GET: ProgramOwners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programOwners = await _context.ProgramOwners
                .FirstOrDefaultAsync(m => m.ProgramOwnerID == id);
            if (programOwners == null)
            {
                return NotFound();
            }

            return View(programOwners);
        }

        // GET: ProgramOwners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgramOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramOwnerID,Name,UserID,Department,EmailAddress,CreateDate,ProgramOwnerStatus")] ProgramOwners programOwners)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programOwners);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programOwners);
        }

        // GET: ProgramOwners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programOwners = await _context.ProgramOwners.FindAsync(id);
            if (programOwners == null)
            {
                return NotFound();
            }
            return View(programOwners);
        }

        // POST: ProgramOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgramOwnerID,Name,UserID,Department,EmailAddress,CreateDate,ProgramOwnerStatus")] ProgramOwners programOwners)
        {
            if (id != programOwners.ProgramOwnerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programOwners);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramOwnersExists(programOwners.ProgramOwnerID))
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
            return View(programOwners);
        }

        // GET: ProgramOwners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programOwners = await _context.ProgramOwners
                .FirstOrDefaultAsync(m => m.ProgramOwnerID == id);
            if (programOwners == null)
            {
                return NotFound();
            }

            return View(programOwners);
        }

        // POST: ProgramOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programOwners = await _context.ProgramOwners.FindAsync(id);
            programOwners.ProgramOwnerStatus = ProgramOwners.OwnerStatusCode.Inactive;

            //_context.ProgramOwners.Remove(programOwners);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramOwnersExists(int id)
        {
            return _context.ProgramOwners.Any(e => e.ProgramOwnerID == id);
        }
    }
}
