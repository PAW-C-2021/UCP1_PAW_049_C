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
    public class TransaksisController : Controller
    {
        private readonly UCPPenjualanSapiContext _context;

        public TransaksisController(UCPPenjualanSapiContext context)
        {
            _context = context;
        }

        // GET: Transaksis
        public async Task<IActionResult> Index()
        {
            var uCPPenjualanSapiContext = _context.Transaksi.Include(t => t.IdpembeliNavigation).Include(t => t.IdsapiNavigation);
            return View(await uCPPenjualanSapiContext.ToListAsync());
        }

        // GET: Transaksis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksi
                .Include(t => t.IdpembeliNavigation)
                .Include(t => t.IdsapiNavigation)
                .FirstOrDefaultAsync(m => m.Idtransaksi == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // GET: Transaksis/Create
        public IActionResult Create()
        {
            ViewData["Idpembeli"] = new SelectList(_context.Pembeli, "Idpembeli", "Idpembeli");
            ViewData["Idsapi"] = new SelectList(_context.Sapi, "IdSapi", "IdSapi");
            return View();
        }

        // POST: Transaksis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idtransaksi,Idsapi,Idpembeli,Jumlahsapi,Tgltransaksi")] Transaksi transaksi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaksi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idpembeli"] = new SelectList(_context.Pembeli, "Idpembeli", "Idpembeli", transaksi.Idpembeli);
            ViewData["Idsapi"] = new SelectList(_context.Sapi, "IdSapi", "IdSapi", transaksi.Idsapi);
            return View(transaksi);
        }

        // GET: Transaksis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksi.FindAsync(id);
            if (transaksi == null)
            {
                return NotFound();
            }
            ViewData["Idpembeli"] = new SelectList(_context.Pembeli, "Idpembeli", "Idpembeli", transaksi.Idpembeli);
            ViewData["Idsapi"] = new SelectList(_context.Sapi, "IdSapi", "IdSapi", transaksi.Idsapi);
            return View(transaksi);
        }

        // POST: Transaksis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idtransaksi,Idsapi,Idpembeli,Jumlahsapi,Tgltransaksi")] Transaksi transaksi)
        {
            if (id != transaksi.Idtransaksi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaksi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaksiExists(transaksi.Idtransaksi))
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
            ViewData["Idpembeli"] = new SelectList(_context.Pembeli, "Idpembeli", "Idpembeli", transaksi.Idpembeli);
            ViewData["Idsapi"] = new SelectList(_context.Sapi, "IdSapi", "IdSapi", transaksi.Idsapi);
            return View(transaksi);
        }

        // GET: Transaksis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksi
                .Include(t => t.IdpembeliNavigation)
                .Include(t => t.IdsapiNavigation)
                .FirstOrDefaultAsync(m => m.Idtransaksi == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // POST: Transaksis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaksi = await _context.Transaksi.FindAsync(id);
            _context.Transaksi.Remove(transaksi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaksiExists(int id)
        {
            return _context.Transaksi.Any(e => e.Idtransaksi == id);
        }
    }
}
