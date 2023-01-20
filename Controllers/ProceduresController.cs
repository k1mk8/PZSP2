using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using apka2.Data;
using apka2.Models;
using apka2.Migrations;

namespace apka2.Controllers
{
    public class ProceduresController : Controller
    {
        private readonly apka2Context _context;

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
            ViewData["sessions"] = _context.ProcedureSession.
                Where(m => m.ProcedureId == id);
            return View(procedure);
        }

        // GET: Procedures/Start/4
        public async Task<IActionResult> Start(int? id)
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

            TempData["surveyId"] = survery.Id;
            TempData["anticoagulation"] = survery.Anticoagulation;
            ViewData["anticoagulation"] = survery.Anticoagulation;

            return View();
        }

        // POST: Procedures/Start
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Start([Bind("SurveyId,WasEnded,Anticoagulation,ProcedureDate,ECMO,Filter,ProcedureTime,ExtracorporealClearingMethod,CitrateConcentrate,UnplanedTermination,TerminationReason,BloodReturn,PatientDeath,DeathDate,Remarks")] Procedure procedure)
        {
            procedure.SurveyId = (int)TempData["surveyId"];
            procedure.WasEnded = false;
            procedure.Anticoagulation = (string)TempData["anticoagulation"];

            if (ModelState.IsValid)
            {
                _context.Add(procedure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procedure);
        }

        // GET: Procedures/End/5
        public async Task<IActionResult> End(int? id)
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

        // POST: Procedures/End/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> End(int id, [Bind("Id,Anticoagulation,SurveyId,ProcedureDate,ECMO,Filter,ProcedureTime,ExtracorporealClearingMethod,CitrateConcentrate,UnplanedTermination,TerminationReason,BloodReturn,PatientDeath,DeathDate,Remarks")] Procedure procedure)
        {

            if (id != procedure.Id)
            {
                return NotFound();
            }

            procedure.WasEnded = true;
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
                return RedirectToAction(nameof(Details), new { id });
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,WasEnded,Anticoagulation,SurveyId,ProcedureDate,ECMO,Filter,ProcedureTime,ExtracorporealClearingMethod,CitrateConcentrate,UnplanedTermination,TerminationReason,BloodReturn,PatientDeath,DeathDate,Remarks")] Procedure procedure)
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
                return RedirectToAction(nameof(Details), new { id });
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

                var sessions = _context.ProcedureSession.
                    Where(m => m.ProcedureId == id);

                foreach (var session in sessions)
                {
                    _context.ProcedureSession.Remove(session);
                }
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
