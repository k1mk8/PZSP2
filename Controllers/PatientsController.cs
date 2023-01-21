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

namespace apka2.Controllers
{
    public class PatientsController : Controller
    {
        private readonly apka2Context _context;

        public PatientsController(apka2Context context)
        {
            _context = context;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
              return View(await _context.Patient.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Initials,BirthDate,HospitalizationDate,StartOfCKRTDate,HasLiverFailure,Weight,Height,DateOfDeath,Remarks")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Patient == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Initials,BirthDate,HospitalizationDate,StartOfCKRTDate,HasLiverFailure,Weight,Height,DateOfDeath,Remarks")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Patient == null)
            {
                return Problem("Entity set 'apka2Context.Patient'  is null.");
            }
            var patient = await _context.Patient.FindAsync(id);
            if (patient != null)
            {
                _context.Patient.Remove(patient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
          return _context.Patient.Any(e => e.Id == id);
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> ExportPatientsDataToExcel()
        {
            Excel.Application excelApp;
            Excel.Workbook excelWorkbook;
            Excel.Worksheet excelWorksheet;
            object missingValues = System.Reflection.Missing.Value;
            excelApp = new Excel.Application();
            excelApp.Visible = false;
            excelWorkbook = (Excel.Workbook)(excelApp.Workbooks.Add(Missing.Value));
            excelWorksheet = (Excel.Worksheet)excelWorkbook.ActiveSheet;

            List<Patient> patients = await _context.Patient.ToListAsync();

            excelWorksheet.Cells[1, 1] = "Inicjały";
            excelWorksheet.Cells[1, 2] = "Data urodzenia";
            excelWorksheet.Cells[1, 3] = "Data hospitalizacji";
            excelWorksheet.Cells[1, 4] = "Data rozpoczęcia CKRT";
            excelWorksheet.Cells[1, 5] = "Niewydolność wątroby";
            excelWorksheet.Cells[1, 6] = "Masa ciała";
            excelWorksheet.Cells[1, 7] = "Wzrost";
            excelWorksheet.Cells[1, 8] = "Data zgonu";
            excelWorksheet.Cells[1, 9] = "Uwagi";

            for (int rowNumber = 0 ; rowNumber < patients.Count; rowNumber++)
            {
                excelWorksheet.Cells[rowNumber + 2, 1] = patients[rowNumber].Initials;
                excelWorksheet.Cells[rowNumber + 2, 2] = patients[rowNumber].BirthDate;
                excelWorksheet.Cells[rowNumber + 2, 3] = patients[rowNumber].HospitalizationDate;
                excelWorksheet.Cells[rowNumber + 2, 4] = patients[rowNumber].StartOfCKRTDate;
                excelWorksheet.Cells[rowNumber + 2, 5] = patients[rowNumber].HasLiverFailure;
                excelWorksheet.Cells[rowNumber + 2, 6] = patients[rowNumber].Weight;
                excelWorksheet.Cells[rowNumber + 2, 7] = patients[rowNumber].Height;
                excelWorksheet.Cells[rowNumber + 2, 8] = patients[rowNumber].DateOfDeath;
                excelWorksheet.Cells[rowNumber + 2, 9] = patients[rowNumber].Remarks;
            }

            excelWorkbook.Close(true, missingValues, missingValues);
            excelApp.Quit();
            return RedirectToAction(nameof(Index));
        }
    }
}
