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
    public class PatientsController : Controller
    {
        private readonly apka2Context _context;

        public PatientsController(apka2Context context)
        {
            _context = context;
        }


        private double CountBSA(decimal Weight, decimal Height)
        {
            return Math.Sqrt((double)(Weight * Height / 3600));
        }


        // GET: Patients
        public async Task<IActionResult> Index()
        {
            var doctorId = getSessionUserId();
            if (doctorId == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (getIsAdmin() == 1)
            {
                return View(await _context.Patient.ToListAsync());
            }
            return View(_context.Patient.Where(s => s.DoctorId == doctorId));
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var doctorId = getSessionUserId();
            if (doctorId == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id == null || _context.Patient == null)
            {
                return NotFound();
            }

            ViewData["clinicalCenters"] = _context.ClinicalCenter;

            var patient = getIsAdmin() == 1 ? await _context.Patient
                .FirstOrDefaultAsync(m => m.Id == id)
                : await _context.Patient
                .FirstOrDefaultAsync(m => m.Id == id && m.DoctorId == doctorId);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            List<SelectListItem> clinicalCenters = new List<SelectListItem>();
            foreach (ClinicalCenter clinicalCenter in _context.ClinicalCenter)
            {
                clinicalCenters.Add(
                    new SelectListItem { Value = clinicalCenter.Id.ToString(), Text = clinicalCenter.City + " " + clinicalCenter.Street });
            }

            List<string> clinicalDiagnosis = new List<string>();
            foreach (ClinicalDiagnosis cliDiag in _context.ClinicalDiagnosis)
            {
                clinicalDiagnosis.Add(cliDiag.Name);
            }

            ViewData["cliCents"] = clinicalCenters;
            ViewData["cliDiag"] = clinicalDiagnosis;
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Initials,BirthDate,HospitalizationDate,StartOfCKRTDate,ClinicalCenterId,ClinicalDiagnose,HasLiverFailure,Weight,Height,DateOfDeath,Remarks")] Patient patient)
        {
            int doctorId = getSessionUserId();
            if (doctorId == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (ModelState.IsValid)
            {
                patient.DoctorId = doctorId;
                patient.BSA = (decimal)CountBSA(patient.Weight, patient.Height);
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id == null || _context.Patient == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            if (getIsAdmin() == 0 && getSessionUserId() != patient.DoctorId)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }

            List<SelectListItem> clinicalCenters = new List<SelectListItem>();
            foreach (ClinicalCenter clinicalCenter in _context.ClinicalCenter)
            {
                clinicalCenters.Add(
                    new SelectListItem { Value = clinicalCenter.Id.ToString(), Text = clinicalCenter.City + " " + clinicalCenter.Street });
            }

            List<string> clinicalDiagnosis = new List<string>();
            foreach (ClinicalDiagnosis cliDiag in _context.ClinicalDiagnosis)
            {
                clinicalDiagnosis.Add(cliDiag.Name);
            }

            ViewData["cliCents"] = clinicalCenters;
            ViewData["cliDiag"] = clinicalDiagnosis;

            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Initials,BirthDate,HospitalizationDate,StartOfCKRTDate,ClinicalCenterId,ClinicalDiagnose,HasLiverFailure,Weight,Height,DateOfDeath,Remarks")] Patient patient)
        {
            if (getIsAdmin() == 0 && getSessionUserId() != patient.DoctorId)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    patient.BSA = (decimal)CountBSA(patient.Weight, patient.Height);
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Id))
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
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id == null || _context.Patient == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            if (getIsAdmin() == 0 && getSessionUserId() != patient.DoctorId)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (getSessionUserId() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (_context.Patient == null)
            {
                return Problem("Entity set 'apka2Context.Patient'  is null.");
            }
            var patient = await _context.Patient.FindAsync(id);
            if (patient != null)
            {
                if (getIsAdmin() == 0 && getSessionUserId() != patient.DoctorId)
                {
                    return RedirectToAction("AccessDenied", "Doctors");
                }
                _context.Patient.Remove(patient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
          return _context.Patient.Any(e => e.Id == id);
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
