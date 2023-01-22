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
    public class ClinicalDiagnosesController : Controller
    {
        private readonly apka2Context _context;

        public ClinicalDiagnosesController(apka2Context context)
        {
            _context = context;
        }

        // GET: ClinicalDiagnoses
        public async Task<IActionResult> Index()
        {
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            return View(await _context.ClinicalDiagnosis.ToListAsync());
        }

        // GET: ClinicalDiagnoses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id == null || _context.ClinicalDiagnosis == null)
            {
                return NotFound();
            }

            var clinicalDiagnosis = await _context.ClinicalDiagnosis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinicalDiagnosis == null)
            {
                return NotFound();
            }

            return View(clinicalDiagnosis);
        }

        // GET: ClinicalDiagnoses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClinicalDiagnoses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Remarks")] ClinicalDiagnosis clinicalDiagnosis)
        {
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (ModelState.IsValid)
            {
                _context.Add(clinicalDiagnosis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clinicalDiagnosis);
        }

        // GET: ClinicalDiagnoses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id == null || _context.ClinicalDiagnosis == null)
            {
                return NotFound();
            }

            var clinicalDiagnosis = await _context.ClinicalDiagnosis.FindAsync(id);
            if (clinicalDiagnosis == null)
            {
                return NotFound();
            }
            return View(clinicalDiagnosis);
        }

        // POST: ClinicalDiagnoses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Remarks")] ClinicalDiagnosis clinicalDiagnosis)
        {
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id != clinicalDiagnosis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clinicalDiagnosis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClinicalDiagnosisExists(clinicalDiagnosis.Id))
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
            return View(clinicalDiagnosis);
        }

        // GET: ClinicalDiagnoses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id == null || _context.ClinicalDiagnosis == null)
            {
                return NotFound();
            }

            var clinicalDiagnosis = await _context.ClinicalDiagnosis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinicalDiagnosis == null)
            {
                return NotFound();
            }

            return View(clinicalDiagnosis);
        }

        // POST: ClinicalDiagnoses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (_context.ClinicalDiagnosis == null)
            {
                return Problem("Entity set 'apka2Context.ClinicalDiagnosis'  is null.");
            }
            var clinicalDiagnosis = await _context.ClinicalDiagnosis.FindAsync(id);
            if (clinicalDiagnosis != null)
            {
                _context.ClinicalDiagnosis.Remove(clinicalDiagnosis);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClinicalDiagnosisExists(int id)
        {
          return _context.ClinicalDiagnosis.Any(e => e.Id == id);
        }

        private int getSessionUserId()
        {
            var sessionId = HttpContext.Session.GetInt32(SessionData.SessionKeyUserId);
            if (sessionId == null)
            {
                return 0;
            }
            return (int)sessionId;
        }
    }
}
