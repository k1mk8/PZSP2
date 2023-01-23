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
using System.Collections;
using Microsoft.AspNetCore.Http;

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
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            return View(await _context.ProcedureSession.ToListAsync());
        }

        // GET: ProcedureSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
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
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
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
            TempData["startingDate"] = procedure.ProcedureDate;
            TempData["procedureTime"] = procedure.ProcedureTime;

            return View();
        }

        // POST: ProcedureSessions/CreateInitial
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInitial([Bind("HeparinBolusDose,ACT,HeparinDose,FraxiparinDose,FraxiparinDosingTiming,AntiXa,CitratesConcentration,CalciumCompensationPercent,IonizedCalcium,TotalCalcium,HCO3,Citrate,CalciumCompensationMol,QBDose,QDDose,Predilution,Postdilution,UFDose,TMP")] ProcedureSession procedureSession)
        {
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            procedureSession.ProcedureId = (int)TempData["procedureId"];
            procedureSession.SessionType = (string)TempData["anticoagulation"];
            procedureSession.Initial = true;
            procedureSession.StartSessionDate = (DateTime)TempData["startingDate"];
            TempData["startingDate"] = TempData["startingDate"];
            TempData["procedureTime"] = TempData["procedureTime"];
            TempData["end"] = false;


            if (ModelState.IsValid)
            {
                _context.Add(procedureSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CreateNext),
                    new {id = procedureSession.ProcedureId});
            }
            return View(procedureSession);
        }

        // GET: ProcedureSessions/CreateNext/4
        public async Task<IActionResult> CreateNextAsync(int? id)
        {
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id == null || _context.Procedure == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedure.FindAsync(id);
            if (procedure == null)
            {
                return NotFound();
            }

            if ((bool)TempData["end"])
                return RedirectToAction("End", "Procedures", new { id });
            

            TempData["procedureId"] = procedure.Id;
            ViewData["procedureId"] = procedure.Id;
            TempData["anticoagulation"] = procedure.Anticoagulation;
            ViewData["anticoagulation"] = procedure.Anticoagulation;
            TempData["startingDate"] = TempData["startingDate"];
            int procedureTime = (int)TempData["procedureTime"];

            IQueryable<ProcedureSession> sessions = _context.ProcedureSession.
                Where(m => m.ProcedureId == id);
            int numOfSessions = sessions.Count();
            int hours;

            if (procedureTime >= 6 && numOfSessions == 1)
                hours = 6;
            else if (procedureTime >= 24 && numOfSessions == 2)
                hours = 24;
            else if (procedureTime >= 48 && numOfSessions == 3)
                hours = 48;
            else
                hours = procedureTime;

            ViewData["hours"] = hours;
            TempData["procedureTime"] = procedureTime;

            return View();
        }

        // POST: ProcedureSessions/CreateNext
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNext([Bind("HeparinBolusDose,ACT,HeparinDose,FraxiparinDose,FraxiparinDosingTiming,AntiXa,CitratesConcentration,CalciumCompensationPercent,IonizedCalcium,TotalCalcium,HCO3,Citrate,CalciumCompensationMol,QBDose,QDDose,Predilution,Postdilution,UFDose,TMP")] ProcedureSession procedureSession)
        {
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            procedureSession.ProcedureId = (int)TempData["procedureId"];
            procedureSession.SessionType = (string)TempData["anticoagulation"];

            IQueryable<ProcedureSession> sessions = _context.ProcedureSession.
                Where(m => m.ProcedureId == procedureSession.ProcedureId);
            int numOfSessions = sessions.Count();
            DateTime start = (DateTime)TempData["startingDate"];
            int procedureTime = (int)TempData["procedureTime"];

            TempData["end"] = false;

            if (procedureTime >= 6 && numOfSessions == 1)
                procedureSession.StartSessionDate = start.AddHours(6);
            else if (procedureTime >= 24 && numOfSessions == 2)
                procedureSession.StartSessionDate = start.AddHours(24);
            else if (procedureTime >= 48 && numOfSessions == 3)
                procedureSession.StartSessionDate = start.AddHours(48);
            else
            {
                procedureSession.StartSessionDate = start.AddHours(procedureTime);
                TempData["end"] = true;
            }

            if (ModelState.IsValid)
            {
                _context.Add(procedureSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CreateNext),
                    new { id = procedureSession.ProcedureId });
            }
            return View(procedureSession);
        }

        // GET: ProcedureSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProcedureId,SessionType,StartSessionDate,HeparinBolusDose,ACT,HeparinDose,FraxiparinDose,FraxiparinDosingTiming,AntiXa,CitratesConcentration,CalciumCompensationPercent,IonizedCalcium,TotalCalcium,HCO3,Citrate,CalciumCompensationMol,QBDose,QDDose,Predilution,Postdilution,UFDose,TMP")] ProcedureSession procedureSession)
        {
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
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
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
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
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
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
            return RedirectToAction(nameof(Details), "Procedures",
                    new { id = procedureSession.ProcedureId });
        }

        private bool ProcedureSessionExists(int id)
        {
          return _context.ProcedureSession.Any(e => e.Id == id);
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
