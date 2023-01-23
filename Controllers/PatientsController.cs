using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using apka2.Data;
using apka2.Models;
using Excel = Microsoft.Office.Interop.Excel;
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

        // GET
        [HttpGet]
        public async Task<IActionResult> ExportDataToExcel()
        {
            Excel.Application excelApp;
            Excel.Workbook excelWorkbook;
            Excel.Worksheet patientsWorksheet, surveysWorksheet, proceduresWorksheet, proceduresSessionsWorksheet;
            object missingValues = System.Reflection.Missing.Value;
            excelApp = new Excel.Application();
            excelApp.Visible = false;
            excelWorkbook = (Excel.Workbook)(excelApp.Workbooks.Add(Missing.Value));

            patientsWorksheet = (Excel.Worksheet)excelWorkbook.ActiveSheet;
            patientsWorksheet.Name = "Pacjenci";

            List<Patient> patients = await _context.Patient.ToListAsync();

            patientsWorksheet.Cells[1, 1] = "Inicjały";
            patientsWorksheet.Cells[1, 2] = "Data urodzenia";
            patientsWorksheet.Cells[1, 3] = "Data hospitalizacji";
            patientsWorksheet.Cells[1, 4] = "Data rozpoczęcia CKRT";
            patientsWorksheet.Cells[1, 5] = "Niewydolność wątroby";
            patientsWorksheet.Cells[1, 6] = "Masa ciała";
            patientsWorksheet.Cells[1, 7] = "Wzrost";
            patientsWorksheet.Cells[1, 8] = "Data zgonu";
            patientsWorksheet.Cells[1, 9] = "Uwagi";

            for (int rowNumber = 0 ; rowNumber < patients.Count; rowNumber++)
            {
                patientsWorksheet.Cells[rowNumber + 2, 1] = patients[rowNumber].Initials;
                patientsWorksheet.Cells[rowNumber + 2, 2] = patients[rowNumber].BirthDate;
                patientsWorksheet.Cells[rowNumber + 2, 3] = patients[rowNumber].HospitalizationDate;
                patientsWorksheet.Cells[rowNumber + 2, 4] = patients[rowNumber].StartOfCKRTDate;
                patientsWorksheet.Cells[rowNumber + 2, 5] = patients[rowNumber].HasLiverFailure;
                patientsWorksheet.Cells[rowNumber + 2, 6] = patients[rowNumber].Weight;
                patientsWorksheet.Cells[rowNumber + 2, 7] = patients[rowNumber].Height;
                patientsWorksheet.Cells[rowNumber + 2, 8] = patients[rowNumber].DateOfDeath;
                patientsWorksheet.Cells[rowNumber + 2, 9] = patients[rowNumber].Remarks;
            }


            surveysWorksheet = excelWorkbook.Sheets.Add(Missing.Value, Missing.Value, 1, Missing.Value);
            surveysWorksheet.Name = "Ankiety medyczne";
            List<Models.Survey> surveys = await _context.Survey.ToListAsync();

            surveysWorksheet.Cells[1, 1] = "ID Pacjenta";
            surveysWorksheet.Cells[1, 2] = "ID Lekarza";
            surveysWorksheet.Cells[1, 3] = "Data ankiety";
            surveysWorksheet.Cells[1, 4] = "ECMO";
            surveysWorksheet.Cells[1, 5] = "Bezmocz / skąpomocz";
            surveysWorksheet.Cells[1, 6] = "Nadciśnienie tętnicze";
            surveysWorksheet.Cells[1, 7] = "Przewodnienie";
            surveysWorksheet.Cells[1, 8] = "Obecność AKI";
            surveysWorksheet.Cells[1, 9] = "Kreatynina";
            surveysWorksheet.Cells[1, 10] = "Mocznik";
            surveysWorksheet.Cells[1, 11] = "Zaburzenia jonowe";
            surveysWorksheet.Cells[1, 12] = "Kwasica metaboliczna";
            surveysWorksheet.Cells[1, 13] = "Zatrucie egzogenne";
            surveysWorksheet.Cells[1, 14] = "Wstrząs septyczny";
            surveysWorksheet.Cells[1, 15] = "Zespół zmiażdżenia";
            surveysWorksheet.Cells[1, 16] = "Antykoagulacja";
            surveysWorksheet.Cells[1, 17] = "Rodzaj dostępu naczyniowego";
            surveysWorksheet.Cells[1, 18] = "Grubość cewnika";
            surveysWorksheet.Cells[1, 19] = "Długość cewnika";
            surveysWorksheet.Cells[1, 20] = "Miejsce założenia dostępu naczyniowego";

            for (int rn = 0; rn < surveys.Count; rn++)
            {
                surveysWorksheet.Cells[rn + 2, 1] = surveys[rn].PatientId;
                surveysWorksheet.Cells[rn + 2, 2] = surveys[rn].DoctorId;
                surveysWorksheet.Cells[rn + 2, 3] = surveys[rn].SurveyDate;
                surveysWorksheet.Cells[rn + 2, 4] = surveys[rn].ECMO;
                surveysWorksheet.Cells[rn + 2, 5] = surveys[rn].Anuria;
                surveysWorksheet.Cells[rn + 2, 6] = surveys[rn].ArterialHypertension;
                surveysWorksheet.Cells[rn + 2, 7] = surveys[rn].Overhydration;
                surveysWorksheet.Cells[rn + 2, 8] = surveys[rn].AKI;
                surveysWorksheet.Cells[rn + 2, 9] = surveys[rn].Creatinine;
                surveysWorksheet.Cells[rn + 2, 10] = surveys[rn].Urea;
                surveysWorksheet.Cells[rn + 2, 11] = surveys[rn].IonDisorder;
                surveysWorksheet.Cells[rn + 2, 12] = surveys[rn].MetabolicAcidosis;
                surveysWorksheet.Cells[rn + 2, 13] = surveys[rn].ExogenousPoison;
                surveysWorksheet.Cells[rn + 2, 14] = surveys[rn].SepticShock;
                surveysWorksheet.Cells[rn + 2, 15] = surveys[rn].LowerNephroneSyndrom;
                surveysWorksheet.Cells[rn + 2, 16] = surveys[rn].Anticoagulation;
                surveysWorksheet.Cells[rn + 2, 17] = surveys[rn].TypeOfVascularAccess;
                surveysWorksheet.Cells[rn + 2, 18] = surveys[rn].CatheterThickness;
                surveysWorksheet.Cells[rn + 2, 19] = surveys[rn].CatheterLength;
                surveysWorksheet.Cells[rn + 2, 20] = surveys[rn].VascularAccessSite;

            }


            proceduresWorksheet = excelWorkbook.Sheets.Add(Missing.Value, Missing.Value, 1, Missing.Value);
            proceduresWorksheet.Name = "Zabiegi";
            List<Procedure> procedures = await _context.Procedure.ToListAsync();

            proceduresWorksheet.Cells[1, 1] = "ID Ankiety";
            proceduresWorksheet.Cells[1, 2] = "Zakończono zabieg";
            proceduresWorksheet.Cells[1, 3] = "Antykoagulacja";
            proceduresWorksheet.Cells[1, 4] = "Data rozpoczęcia";
            proceduresWorksheet.Cells[1, 5] = "ECMO";
            proceduresWorksheet.Cells[1, 6] = "Filtr";
            proceduresWorksheet.Cells[1, 7] = "Czas trwania zabiegu [h]";
            proceduresWorksheet.Cells[1, 8] = "Metoda oczyszczania pozaustrojowego";
            proceduresWorksheet.Cells[1, 9] = "Koncentrat cytrynianów";
            proceduresWorksheet.Cells[1, 10] = "Nieplanowe zakończenie";
            proceduresWorksheet.Cells[1, 11] = "Przyczyna zakończenia";
            proceduresWorksheet.Cells[1, 12] = "Zwrot krwi";
            proceduresWorksheet.Cells[1, 13] = "Zgon pacjenta";
            proceduresWorksheet.Cells[1, 14] = "Data i godzina zgonu";
            proceduresWorksheet.Cells[1, 15] = "Uwagi";

            for (int rn = 0; rn < procedures.Count; rn++)
            {
                proceduresWorksheet.Cells[rn + 2, 1] = procedures[rn].SurveyId;
                proceduresWorksheet.Cells[rn + 2, 2] = procedures[rn].WasEnded;
                proceduresWorksheet.Cells[rn + 2, 3] = procedures[rn].Anticoagulation;
                proceduresWorksheet.Cells[rn + 2, 4] = procedures[rn].ProcedureDate;
                proceduresWorksheet.Cells[rn + 2, 5] = procedures[rn].ECMO;
                proceduresWorksheet.Cells[rn + 2, 6] = procedures[rn].Filter;
                proceduresWorksheet.Cells[rn + 2, 7] = procedures[rn].ProcedureTime;
                proceduresWorksheet.Cells[rn + 2, 8] = procedures[rn].ExtracorporealClearingMethod;
                proceduresWorksheet.Cells[rn + 2, 9] = procedures[rn].CitrateConcentrate;
                proceduresWorksheet.Cells[rn + 2, 10] = procedures[rn].UnplanedTermination;
                proceduresWorksheet.Cells[rn + 2, 11] = procedures[rn].TerminationReason;
                proceduresWorksheet.Cells[rn + 2, 12] = procedures[rn].BloodReturn;
                proceduresWorksheet.Cells[rn + 2, 13] = procedures[rn].PatientDeath;
                proceduresWorksheet.Cells[rn + 2, 14] = procedures[rn].DeathDate;
                proceduresWorksheet.Cells[rn + 2, 15] = procedures[rn].Remarks;
            }


            proceduresSessionsWorksheet = excelWorkbook.Sheets.Add(Missing.Value, Missing.Value, 1, Missing.Value);
            proceduresSessionsWorksheet.Name = "Punkty kontrolne zabiegów";
            List<ProcedureSession> proceduresSessions = await _context.ProcedureSession.ToListAsync();

            proceduresSessionsWorksheet.Cells[1, 1] = "ID Zabiegu";
            proceduresSessionsWorksheet.Cells[1, 2] = "Typ sesji zabiegu";
            proceduresSessionsWorksheet.Cells[1, 3] = "Ustawienia początkowe";
            proceduresSessionsWorksheet.Cells[1, 4] = "Czas rozpoczęcia";
            proceduresSessionsWorksheet.Cells[1, 5] = "Heparyna - bolus początkowy [mg]";
            proceduresSessionsWorksheet.Cells[1, 6] = "ACT [s]";
            proceduresSessionsWorksheet.Cells[1, 7] = "Dawka heparyny [mg/h]";
            proceduresSessionsWorksheet.Cells[1, 8] = "Dawka fraxaparyny [mg/h]";
            proceduresSessionsWorksheet.Cells[1, 9] = "Interwał czasowy podawania fraxaparyny";
            proceduresSessionsWorksheet.Cells[1, 10] = "Anty-Xa";
            proceduresSessionsWorksheet.Cells[1, 11] = "Stężenie cytrynianów [mmol/l]";
            proceduresSessionsWorksheet.Cells[1, 12] = "Kompensacja wapnia [%]";
            proceduresSessionsWorksheet.Cells[1, 13] = "Wapń zjonizowany [mg/dl lub mmol/l]";
            proceduresSessionsWorksheet.Cells[1, 14] = "Wapń całkowity [mg/dl lub mmol/l]";
            proceduresSessionsWorksheet.Cells[1, 15] = "HCO3 [mmol/l]";
            proceduresSessionsWorksheet.Cells[1, 16] = "Cytrynian [mmol/l]";
            proceduresSessionsWorksheet.Cells[1, 17] = "Kompensacja wapnia [mg/dl lub mmol/l]";
            proceduresSessionsWorksheet.Cells[1, 18] = "QB [mg/min]";
            proceduresSessionsWorksheet.Cells[1, 19] = "QD [mg/h]";
            proceduresSessionsWorksheet.Cells[1, 20] = "Predylucja [mg/h]";
            proceduresSessionsWorksheet.Cells[1, 21] = "Postdylucja [mg/h]";
            proceduresSessionsWorksheet.Cells[1, 22] = "UF [mg/h]";
            proceduresSessionsWorksheet.Cells[1, 23] = "TMP [mmhg]";

            for (int rn = 0; rn < proceduresSessions.Count; rn++)
            {
                proceduresSessionsWorksheet.Cells[rn + 2, 1] = proceduresSessions[rn].ProcedureId;
                proceduresSessionsWorksheet.Cells[rn + 2, 2] = proceduresSessions[rn].SessionType;
                proceduresSessionsWorksheet.Cells[rn + 2, 3] = proceduresSessions[rn].Initial;
                proceduresSessionsWorksheet.Cells[rn + 2, 4] = proceduresSessions[rn].StartSessionDate;
                proceduresSessionsWorksheet.Cells[rn + 2, 5] = proceduresSessions[rn].HeparinBolusDose;
                proceduresSessionsWorksheet.Cells[rn + 2, 6] = proceduresSessions[rn].ACT;
                proceduresSessionsWorksheet.Cells[rn + 2, 7] = proceduresSessions[rn].HeparinDose;
                proceduresSessionsWorksheet.Cells[rn + 2, 8] = proceduresSessions[rn].FraxiparinDose;
                proceduresSessionsWorksheet.Cells[rn + 2, 9] = proceduresSessions[rn].FraxiparinDosingTiming;
                proceduresSessionsWorksheet.Cells[rn + 2, 10] = proceduresSessions[rn].AntiXa;
                proceduresSessionsWorksheet.Cells[rn + 2, 11] = proceduresSessions[rn].CitratesConcentration;
                proceduresSessionsWorksheet.Cells[rn + 2, 12] = proceduresSessions[rn].CalciumCompensationPercent;
                proceduresSessionsWorksheet.Cells[rn + 2, 13] = proceduresSessions[rn].IonizedCalcium;
                proceduresSessionsWorksheet.Cells[rn + 2, 14] = proceduresSessions[rn].TotalCalcium;
                proceduresSessionsWorksheet.Cells[rn + 2, 15] = proceduresSessions[rn].HCO3;
                proceduresSessionsWorksheet.Cells[rn + 2, 16] = proceduresSessions[rn].Citrate;
                proceduresSessionsWorksheet.Cells[rn + 2, 17] = proceduresSessions[rn].CalciumCompensationMol;
                proceduresSessionsWorksheet.Cells[rn + 2, 18] = proceduresSessions[rn].QBDose;
                proceduresSessionsWorksheet.Cells[rn + 2, 19] = proceduresSessions[rn].QDDose;
                proceduresSessionsWorksheet.Cells[rn + 2, 20] = proceduresSessions[rn].Predilution;
                proceduresSessionsWorksheet.Cells[rn + 2, 21] = proceduresSessions[rn].Postdilution;
                proceduresSessionsWorksheet.Cells[rn + 2, 22] = proceduresSessions[rn].UFDose;
                proceduresSessionsWorksheet.Cells[rn + 2, 23] = proceduresSessions[rn].TMP;

            }


            excelWorkbook.Close(true, missingValues, missingValues);
            excelApp.Quit();
            return RedirectToAction(nameof(Index));
        }
    }
}
