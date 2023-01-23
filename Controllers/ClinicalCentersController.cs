using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using apka2.Data;
using apka2.Models;

namespace apka2.Controllers
{
    public class ClinicalCentersController : Controller
    {
        private readonly apka2Context _context;

        public ClinicalCentersController(apka2Context context)
        {
            _context = context;
        }

        // GET: ClinicalCenters
        public async Task<IActionResult> Index()
        {
            if (getIsAdmin() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            return View(await _context.ClinicalCenter.ToListAsync());
        }

        // GET: ClinicalCenters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (getIsAdmin() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id == null || _context.ClinicalCenter == null)
            {
                return NotFound();
            }

            var clinicalCenter = await _context.ClinicalCenter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinicalCenter == null)
            {
                return NotFound();
            }

            return View(clinicalCenter);
        }

        // GET: ClinicalCenters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClinicalCenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Street,BuildingNumber,LocalNumber,City,PostalCode,CenterDescription")] ClinicalCenter clinicalCenter)
        {
            if (getIsAdmin() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (ModelState.IsValid)
            {
                _context.Add(clinicalCenter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clinicalCenter);
        }

        // GET: ClinicalCenters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (getIsAdmin() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id == null || _context.ClinicalCenter == null)
            {
                return NotFound();
            }

            var clinicalCenter = await _context.ClinicalCenter.FindAsync(id);
            if (clinicalCenter == null)
            {
                return NotFound();
            }
            return View(clinicalCenter);
        }

        // POST: ClinicalCenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Street,BuildingNumber,LocalNumber,City,PostalCode,CenterDescription")] ClinicalCenter clinicalCenter)
        {
            if (getIsAdmin() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id != clinicalCenter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clinicalCenter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClinicalCenterExists(clinicalCenter.Id))
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
            return View(clinicalCenter);
        }

        // GET: ClinicalCenters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (getIsAdmin() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id == null || _context.ClinicalCenter == null)
            {
                return NotFound();
            }

            var clinicalCenter = await _context.ClinicalCenter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinicalCenter == null)
            {
                return NotFound();
            }

            return View(clinicalCenter);
        }

        // POST: ClinicalCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (getIsAdmin() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (_context.ClinicalCenter == null)
            {
                return Problem("Entity set 'apka2Context.ClinicalCenter'  is null.");
            }
            var clinicalCenter = await _context.ClinicalCenter.FindAsync(id);
            if (clinicalCenter != null)
            {
                _context.ClinicalCenter.Remove(clinicalCenter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClinicalCenterExists(int id)
        {
          return _context.ClinicalCenter.Any(e => e.Id == id);
        }
        private int getIsAdmin()
        {
            var isAdmin = HttpContext.Session.GetInt32(SessionData.SessionKeyIsAdmin);
            if (isAdmin == null)
            {
                return 0;
            }
            return (int)isAdmin;
        }
    }
}
