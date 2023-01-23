﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using apka2.Data;
using apka2.Models;
using Microsoft.AspNetCore.Identity;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace apka2.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly apka2Context _context;

        private string hashPassword(string password)
        {
            var sha = SHA256.Create();
            var hashedPassword = sha.ComputeHash(Encoding.Default.GetBytes(password));
            return Convert.ToBase64String(hashedPassword);
        }

        public DoctorsController(apka2Context context)
        {
            _context = context;
        }

		// GET: Doctors
		public async Task<IActionResult> Index()
        {
            if (getIsAdmin() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            return View(await _context.Doctor.ToListAsync());
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (getIsAdmin() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id == null || _context.Doctor == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        public async Task<IActionResult> Accept(int? id)
        {
            if (getIsAdmin() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id == null || _context.Doctor == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            doctor.IsAccepted = true;
            _context.Update(doctor);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            if (getIsAdmin() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SecondName,Surname,IsAdmin,Username,Password,Description")] Doctor doctor)
        {
            if (getIsAdmin() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (ModelState.IsValid)
            {
                doctor.Password = hashPassword(doctor.Password);
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAccount([Bind("Id,Name,SecondName,Surname,IsAdmin,Username,Password,Description")] Doctor doctor)
        {
            var potential_conflict_user = await _context.Doctor
                .FirstOrDefaultAsync(m => m.Username == doctor.Username);
            if (potential_conflict_user != null)
            {
                ModelState.AddModelError(string.Empty, "Nazwa użytkownika zajęta");
                return View();
            }

            doctor.IsAccepted = false;

            if (ModelState.IsValid)
            {
                doctor.Password = hashPassword(doctor.Password);

                var admins = _context.Doctor
                    .Where(m => m.IsAdmin == true);

                _context.Add(doctor);
                await _context.SaveChangesAsync();

                if (admins != null)
                {
                    SmtpClient client = new SmtpClient("smtpServer");
                    client.Credentials = new NetworkCredential("login", "password");
                    MailMessage mailMessage = new MailMessage();

                    foreach (var admin in admins)
                    {
                        if (admin.EmailAddress != null)
                        {
                            mailMessage.To.Add(admin.EmailAddress);
                        }
                    }
                    mailMessage.Subject = "Prośba o potwierdzenie rejestracji użytkownika";
                    mailMessage.Body = "Do systemu wpłynęła prośba o rejestrację użytkownika " + doctor.Username;
                    mailMessage.From = new MailAddress("noreply@continet", "ContiNET");

                    try
                    {
                        client.Send(mailMessage);
                        return RedirectToAction(nameof(ConfirmRegistration));

                    }
                    catch (SmtpException)
                    {
                        return RedirectToAction("LogIn");
                    }
                    catch (InvalidOperationException)
                    {
                        return RedirectToAction("LogIn");
                    }
                }
            }
            return View(doctor);
        }

        public IActionResult ConfirmRegistration()
        {
            return View();
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (getIsAdmin() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id == null || _context.Doctor == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SecondName,Surname,IsAdmin,Username,Password,Description")] Doctor doctor)
        {
            if (getIsAdmin() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    doctor.Password = hashPassword(doctor.Password);
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.Id))
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
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (getIsAdmin() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (id == null || _context.Doctor == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (getIsAdmin() == 0)
            {
                return RedirectToAction("AccessDenied", "Doctors");
            }
            if (_context.Doctor == null)
            {
                return Problem("Entity set 'apka2Context.Doctor'  is null.");
            }
            var doctor = await _context.Doctor.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctor.Remove(doctor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
          return _context.Doctor.Any(e => e.Id == id);
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(string Username, string Password)
        {
            var person = await _context.Doctor
                .FirstOrDefaultAsync(p => p.Username == Username);

            if (person == null)
            {
                ModelState.AddModelError(string.Empty, "Użytkownik nie istnieje");
                return View();
            }

            Password = hashPassword(Password);
            if (Password != person.Password)
            {
                ModelState.AddModelError(string.Empty, "Błędny login lub hasło");
                return View();
            }
            if (person.IsAccepted == false)
            {
                ModelState.AddModelError(string.Empty, "Użytkownik nie został zaakceptowany");
                return View();
            }

            HttpContext.Session.SetInt32(SessionData.SessionKeyUserId, person.Id);
            var b = person.IsAdmin ? 1 : 0;
            HttpContext.Session.SetInt32(SessionData.SessionKeyIsAdmin, b); 
            return RedirectToAction("MyAccount");
        }

        public async Task<IActionResult> MyAccount()
        {
            if (!IsUserLoggedIn())
            {
                return RedirectToAction("LogIn");
            }

            var user = await _context.Doctor
                .FirstOrDefaultAsync(m => m.Id == HttpContext.Session.GetInt32(SessionData.SessionKeyUserId));
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public bool IsUserLoggedIn()
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetInt32(SessionData.SessionKeyUserId).ToString()))
            {
                return false;
            }

            return true;
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove(SessionData.SessionKeyUserId);
            HttpContext.Session.Remove(SessionData.SessionKeyIsAdmin);
            return RedirectToAction("LogIn");
        }

        public IActionResult AccessDenied()
        {
            return View();
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
