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
    public class ProcedureSessionsController : Controller
    {
        private readonly apka2Context _context;

        public ProcedureSessionsController(apka2Context context)
        {
            _context = context;
        }

        // GET: ProcedureSessions
        public async Task<IActionResult> Index()
        {
              return View(await _context.ProcedureSession.ToListAsync());
        }

        // GET: ProcedureSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProcedureSession == null)
            {
                return NotFound();
            }

            var procedureSession = await _context.ProcedureSession
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedureSession == null)
            {
                return NotFound();
            }

            return View(procedureSession);
        }

        // GET: ProcedureSessions/CreateInitial/4
        public async Task<IActionResult> CreateInitialAsync(int? id)
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

            TempData["procedureId"] = procedure.Id;
            ViewData["procedureId"] = procedure.Id;
            TempData["anticoagulation"] = procedure.Anticoagulation;
            ViewData["anticoagulation"] = procedure.Anticoagulation;

            return View();
        }

        // POST: ProcedureSessions/CreateInitial
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInitial([Bind("HeparinBolusDose,ACT,HeparinDose,FraxiparinDose,FraxiparinDosingTiming,AntiXa,CitratesConcentration,CalciumCompensationPercent,IonizedCalcium,TotalCalcium,HCO3,Citrate,CalciumCompensationMol,QBDose,QDDose,Predilution,Postdilution,UFDose,TMP")] ProcedureSession procedureSession)
        {
            procedureSession.ProcedureId = (int)TempData["procedureId"];
            procedureSession.SessionType = (string)TempData["anticoagulation"];
            procedureSession.initial = true;

            if (ModelState.IsValid)
            {
                _context.Add(procedureSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Procedures",
                    new {id = procedureSession.ProcedureId});
            }
            return View(procedureSession);
        }

        // GET: ProcedureSessions/CreateNext/4
        public async Task<IActionResult> CreateNextAsync(int? id)
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

            TempData["procedureId"] = procedure.Id;
            ViewData["procedureId"] = procedure.Id;
            TempData["anticoagulation"] = procedure.Anticoagulation;
            ViewData["anticoagulation"] = procedure.Anticoagulation;

            return View();
        }

        // POST: ProcedureSessions/CreateNext
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNext([Bind("HeparinBolusDose,ACT,HeparinDose,FraxiparinDose,FraxiparinDosingTiming,AntiXa,CitratesConcentration,CalciumCompensationPercent,IonizedCalcium,TotalCalcium,HCO3,Citrate,CalciumCompensationMol,QBDose,QDDose,Predilution,Postdilution,UFDose,TMP")] ProcedureSession procedureSession)
        {
            procedureSession.ProcedureId = (int)TempData["procedureId"];
            procedureSession.SessionType = (string)TempData["anticoagulation"];

            if (ModelState.IsValid)
            {
                _context.Add(procedureSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Procedures",
                    new { id = procedureSession.ProcedureId });
            }
            return View(procedureSession);
        }

        // GET: ProcedureSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProcedureSession == null)
            {
                return NotFound();
            }

            var procedureSession = await _context.ProcedureSession.FindAsync(id);
            if (procedureSession == null)
            {
                return NotFound();
            }
            return View(procedureSession);
        }

        // POST: ProcedureSessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProcedureId,SessionType,HeparinBolusDose,ACT,HeparinDose,FraxiparinDose,FraxiparinDosingTiming,AntiXa,CitratesConcentration,CalciumCompensationPercent,IonizedCalcium,TotalCalcium,HCO3,Citrate,CalciumCompensationMol,QBDose,QDDose,Predilution,Postdilution,UFDose,TMP")] ProcedureSession procedureSession)
        {
            if (id != procedureSession.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedureSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedureSessionExists(procedureSession.Id))
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
            return View(procedureSession);
        }

        // GET: ProcedureSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProcedureSession == null)
            {
                return NotFound();
            }

            var procedureSession = await _context.ProcedureSession
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedureSession == null)
            {
                return NotFound();
            }

            return View(procedureSession);
        }

        // POST: ProcedureSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProcedureSession == null)
            {
                return Problem("Entity set 'apka2Context.ProcedureSession'  is null.");
            }
            var procedureSession = await _context.ProcedureSession.FindAsync(id);
            if (procedureSession != null)
            {
                _context.ProcedureSession.Remove(procedureSession);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedureSessionExists(int id)
        {
          return _context.ProcedureSession.Any(e => e.Id == id);
        }
    }
}
