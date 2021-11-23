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
    public class PembayaransController : Controller
    {
        private readonly UCPPenjualanSapiContext _context;

        public PembayaransController(UCPPenjualanSapiContext context)
        {
            _context = context;
        }

        // GET: Pembayarans
        public async Task<IActionResult> Index()
        {
            var uCPPenjualanSapiContext = _context.Pembayaran.Include(p => p.IdtranksaksiNavigation);
            return View(await uCPPenjualanSapiContext.ToListAsync());
        }

        // GET: Pembayarans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayaran
                .Include(p => p.IdtranksaksiNavigation)
                .FirstOrDefaultAsync(m => m.Idpembayaran == id);
            if (pembayaran == null)
            {
                return NotFound();
            }

            return View(pembayaran);
        }

        // GET: Pembayarans/Create
        public IActionResult Create()
        {
            ViewData["Idtranksaksi"] = new SelectList(_context.Transaksi, "Idtransaksi", "Idtransaksi");
            return View();
        }

        // POST: Pembayarans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idpembayaran,Idtranksaksi,Totalembayaran")] Pembayaran pembayaran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pembayaran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idtranksaksi"] = new SelectList(_context.Transaksi, "Idtransaksi", "Idtransaksi", pembayaran.Idtranksaksi);
            return View(pembayaran);
        }

        // GET: Pembayarans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayaran.FindAsync(id);
            if (pembayaran == null)
            {
                return NotFound();
            }
            ViewData["Idtranksaksi"] = new SelectList(_context.Transaksi, "Idtransaksi", "Idtransaksi", pembayaran.Idtranksaksi);
            return View(pembayaran);
        }

        // POST: Pembayarans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idpembayaran,Idtranksaksi,Totalembayaran")] Pembayaran pembayaran)
        {
            if (id != pembayaran.Idpembayaran)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pembayaran);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PembayaranExists(pembayaran.Idpembayaran))
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
            ViewData["Idtranksaksi"] = new SelectList(_context.Transaksi, "Idtransaksi", "Idtransaksi", pembayaran.Idtranksaksi);
            return View(pembayaran);
        }

        // GET: Pembayarans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayaran
                .Include(p => p.IdtranksaksiNavigation)
                .FirstOrDefaultAsync(m => m.Idpembayaran == id);
            if (pembayaran == null)
            {
                return NotFound();
            }

            return View(pembayaran);
        }

        // POST: Pembayarans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pembayaran = await _context.Pembayaran.FindAsync(id);
            _context.Pembayaran.Remove(pembayaran);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PembayaranExists(int id)
        {
            return _context.Pembayaran.Any(e => e.Idpembayaran == id);
        }
    }
}
