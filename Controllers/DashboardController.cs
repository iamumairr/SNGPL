using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SNGPL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNGPL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public DashboardController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Feedbacks()
        {
            var feedbacks = _db.Feedbacks.ToList();
            return View(feedbacks);
        }

        public IActionResult DeleteFeedback(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var feedback = _db.Feedbacks.FirstOrDefault(u => u.Id == id);
            if (feedback == null)
            {
                return NotFound();
            }
            else
            {
                _db.Feedbacks.Remove(feedback);
                _db.SaveChanges();
                return RedirectToAction(nameof(Feedbacks));
            }
        }

        [HttpGet]
        public IActionResult AllUsers()
        {
            var users = _db.ApplicationUser.ToList();

            return View(users);
        }

        public IActionResult DeleteUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _db.ApplicationUser.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                _db.ApplicationUser.Remove(user);
                _db.SaveChanges();
                return RedirectToAction(nameof(AllUsers));
            }
        }

        [HttpGet]
        public IActionResult ConnectionForms()
        {
            var connectionForms = _db.ConnectionForms.ToList();

            return View(connectionForms);
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var connectionForm = _db.ConnectionForms.FirstOrDefault(u => u.Id == id);
            if (connectionForm == null)
            {
                return NotFound();
            }
            else
            {
                _db.ConnectionForms.Remove(connectionForm);
                _db.SaveChanges();
                return RedirectToAction(nameof(ConnectionForms));
            }
        }
    }
}