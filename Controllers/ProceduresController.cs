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
    public class ProceduresController : Controller
    {
        private readonly apka2Context _context;
        private int surveyId { get; set; }

        public ProceduresController(apka2Context context)
        {
            _context = context;
        }

        // GET: Procedures
        public async Task<IActionResult> Index()
        {
              return View(await _context.Procedure.ToListAsync());
        }

        // GET: Procedures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Procedure == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedure
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedure == null)
            {
                return NotFound();
            }

            return View(procedure);
        }

        // GET: Procedures/Create/4
        public async Task<IActionResult> CreateAsync(int? id)
        {
            if (id == null || _context.Survey == null)
            {
                return NotFound();
            }

            var survery = await _context.Survey.FindAsync(id);
            if (survery == null)
            {
                return NotFound();
            }

            this.surveyId = (int)id;
            Console.WriteLine(surveyId);

            ViewData["anticoagulation"] = survery.Anticoagulation;

            return survery.Anticoagulation switch
            {
                "Cytrynian" => RedirectToAction(nameof(Start_C)),
                _ => RedirectToAction(nameof(Start_HN_HD_BA)),
            };
        }

        // GET: Procedures/Start_C
        public IActionResult Start_C()
        {
            return View();
        }

        // GET: Procedures/Start_HN_HD_BA
        public IActionResult Start_HN_HD_BA()
        {
            return View();
        }



        // POST: Procedures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SurveyId,ProcedureDate,ECMO,Filter,ProcedureTime,ExtracorporealClearingMethod,CitrateConcentrate,UnplanedTermination,TerminationReason,BloodReturn,PatientDeath,DeathDate,Remarks")] Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(surveyId);
                procedure.SurveyId = this.surveyId;
                Console.WriteLine(procedure.SurveyId);

                _context.Add(procedure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procedure);
        }

        // GET: Procedures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Procedure == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedure.FindAsync(id);
            if (procedure == null)
            {
                return NotFound();
            }
            return View(procedure);
        }

        // POST: Procedures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SurveyId,ProcedureDate,ECMO,Filter,ProcedureTime,ExtracorporealClearingMethod,CitrateConcentrate,UnplanedTermination,TerminationReason,BloodReturn,PatientDeath,DeathDate,Remarks")] Procedure procedure)
        {
            if (id != procedure.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedureExists(procedure.Id))
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
            return View(procedure);
        }

        // GET: Procedures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Procedure == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedure
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedure == null)
            {
                return NotFound();
            }

            return View(procedure);
        }

        // POST: Procedures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Procedure == null)
            {
                return Problem("Entity set 'apka2Context.Procedure'  is null.");
            }
            var procedure = await _context.Procedure.FindAsync(id);
            if (procedure != null)
            {
                _context.Procedure.Remove(procedure);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedureExists(int id)
        {
          return _context.Procedure.Any(e => e.Id == id);
        }
    }
}
