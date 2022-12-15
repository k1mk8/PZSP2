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
    public class ServeysController : Controller
    {
        private readonly apka2Context _context;

        public ServeysController(apka2Context context)
        {
            _context = context;
        }

        // GET: Serveys
        public async Task<IActionResult> Index()
        {
              return View(await _context.Servey.ToListAsync());
        }

        // GET: Serveys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Servey == null)
            {
                return NotFound();
            }

            var servey = await _context.Servey
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servey == null)
            {
                return NotFound();
            }

            return View(servey);
        }

        // GET: Serveys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Serveys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,DoctorId,ServeyDate,ECMO,Anuria,ArterialHypertension,Overhydration,AKI,Creatinine,Urea,IonDisorder,MetabolicAcidosis,ExogenousPoison,SepticShock,LowerNephroneSyndrom,Anticoagulation,TypeOfVascularAccess,CatheterThickness,CatheterLength,VascularAccessSite")] Servey servey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servey);
        }

        // GET: Serveys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Servey == null)
            {
                return NotFound();
            }

            var servey = await _context.Servey.FindAsync(id);
            if (servey == null)
            {
                return NotFound();
            }
            return View(servey);
        }

        // POST: Serveys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,DoctorId,ServeyDate,ECMO,Anuria,ArterialHypertension,Overhydration,AKI,Creatinine,Urea,IonDisorder,MetabolicAcidosis,ExogenousPoison,SepticShock,LowerNephroneSyndrom,Anticoagulation,TypeOfVascularAccess,CatheterThickness,CatheterLength,VascularAccessSite")] Servey servey)
        {
            if (id != servey.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServeyExists(servey.Id))
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
            return View(servey);
        }

        // GET: Serveys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Servey == null)
            {
                return NotFound();
            }

            var servey = await _context.Servey
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servey == null)
            {
                return NotFound();
            }

            return View(servey);
        }

        // POST: Serveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Servey == null)
            {
                return Problem("Entity set 'apka2Context.Servey'  is null.");
            }
            var servey = await _context.Servey.FindAsync(id);
            if (servey != null)
            {
                _context.Servey.Remove(servey);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServeyExists(int id)
        {
          return _context.Servey.Any(e => e.Id == id);
        }
    }
}
