using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using apka2.Data;
using apka2.Models;
using Microsoft.AspNetCore.Authentication;

namespace apka2.Controllers
{
    public class SurveysController : Controller
    {
        private readonly apka2Context _context;

        private int getSessionUserId()
        {
            var sessionId = HttpContext.Session.GetInt32(SessionData.SessionKeyUserId);
            if (sessionId == null)
            {
                return 0;
            }
            return (int)sessionId;
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

        public SurveysController(apka2Context context)
        {
            _context = context;
        }

        // GET: Surveys
        public async Task<IActionResult> Index()
        {
            var doctorId = getSessionUserId();
            if (doctorId == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            ViewData["patients"] = _context.Patient;

            if (getIsAdmin() == 1)
            {
                return View(await _context.Survey.ToListAsync());
            }
            return View(_context.Survey.Where(s => s.DoctorId == doctorId));
        }

        // GET: Surveys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var doctorId = getSessionUserId();
            if (doctorId == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id == null || _context.Survey == null)
            {
                return NotFound();
            }

            var survey = getIsAdmin() == 1 ? await _context.Survey
                .FirstOrDefaultAsync(m => m.Id == id)
                : await _context.Survey
                .FirstOrDefaultAsync(m => m.Id == id && m.DoctorId == doctorId);
            if (survey == null)
            {
                return NotFound();
            }

            return View(survey);
        }

        // GET: Surveys/Create
        public IActionResult Create()
        {
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }

            List<SelectListItem> patients = new List<SelectListItem>();
            foreach (Patient patient in _context.Patient)
            {
                patients.Add(
                    new SelectListItem { Value = patient.Id.ToString(), Text = patient.Initials + " " + patient.BirthDate.ToShortDateString() });
            }

            ViewData["patients"] = patients;

            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,DoctorId,SurveyDate,ECMO,Anuria,ArterialHypertension,Overhydration,AKI,Creatinine,Urea,IonDisorder,MetabolicAcidosis,ExogenousPoison,SepticShock,LowerNephroneSyndrom,Anticoagulation,TypeOfVascularAccess,CatheterThickness,CatheterLength,VascularAccessSite")] Survey survey)
        {
            int doctorId = getSessionUserId();
            if (doctorId == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (ModelState.IsValid)
            {
                survey.DoctorId = doctorId;
                _context.Add(survey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(survey);
        }

        // GET: Surveys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null || _context.Survey == null)
            {
                return NotFound();
            }

            var survey = await _context.Survey.FindAsync(id);
            if (survey == null)
            {
                return NotFound();
            }

            if (getIsAdmin() == 0 && getSessionUserId() != survey.DoctorId)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }

            return View(survey);
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,DoctorId,SurveyDate,ECMO,Anuria,ArterialHypertension,Overhydration,AKI,Creatinine,Urea,IonDisorder,MetabolicAcidosis,ExogenousPoison,SepticShock,LowerNephroneSyndrom,Anticoagulation,TypeOfVascularAccess,CatheterThickness,CatheterLength,VascularAccessSite")] Survey survey)
        {
            if (getIsAdmin() == 0 && getSessionUserId() != survey.DoctorId)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id != survey.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(survey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyExists(survey.Id))
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
            return View(survey);
        }

        // GET: Surveys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Survey == null)
            {
                return NotFound();
            }

            var survey = await _context.Survey
                .FirstOrDefaultAsync(m => m.Id == id);
            if (survey == null)
            {
                return NotFound();
            }

            if (getIsAdmin() == 0 && getSessionUserId() != survey.DoctorId)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }

            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Survey == null)
            {
                return Problem("Entity set 'apka2Context.Survey'  is null.");
            }
            var survey = await _context.Survey.FindAsync(id);
            if (survey != null)
            {
                if (getIsAdmin() == 0 && getSessionUserId() != survey.DoctorId)
                {
                    return RedirectToAction("AccessDenied", "Doctors");
                }
                _context.Survey.Remove(survey);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurveyExists(int id)
        {
          return _context.Survey.Any(e => e.Id == id);
        }
    }
}
