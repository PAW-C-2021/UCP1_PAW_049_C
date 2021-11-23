using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCPPraktikam1.Models;

namespace UCPPraktikam1.Controllers
{
    public class SapisController : Controller
    {
        private readonly UCPPenjualanSapiContext _context;

        public SapisController(UCPPenjualanSapiContext context)
        {
            _context = context;
        }

        // GET: Sapis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sapi.ToListAsync());
        }

        // GET: Sapis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sapi = await _context.Sapi
                .FirstOrDefaultAsync(m => m.IdSapi == id);
            if (sapi == null)
            {
                return NotFound();
            }

            return View(sapi);
        }

        // GET: Sapis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sapis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSapi,NamaSapi,Stocksapi,HargaSapi")] Sapi sapi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sapi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sapi);
        }

        // GET: Sapis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sapi = await _context.Sapi.FindAsync(id);
            if (sapi == null)
            {
                return NotFound();
            }
            return View(sapi);
        }

        // POST: Sapis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSapi,NamaSapi,Stocksapi,HargaSapi")] Sapi sapi)
        {
            if (id != sapi.IdSapi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sapi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SapiExists(sapi.IdSapi))
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
            return View(sapi);
        }

        // GET: Sapis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sapi = await _context.Sapi
                .FirstOrDefaultAsync(m => m.IdSapi == id);
            if (sapi == null)
            {
                return NotFound();
            }

            return View(sapi);
        }

        // POST: Sapis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sapi = await _context.Sapi.FindAsync(id);
            _context.Sapi.Remove(sapi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SapiExists(int id)
        {
            return _context.Sapi.Any(e => e.IdSapi == id);
        }
    }
}
