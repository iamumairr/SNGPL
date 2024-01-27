using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SNGPL.Data;
using SNGPL.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace SNGPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Portfolio()
        {
            return View();
        }

        public IActionResult HealthSafety()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Feedback()
        {
            Feedback feedback = new Feedback();
            return View(feedback);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Feedback(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                TempData["FeedbackUser"] = feedback.FullName;
                _db.Feedbacks.Add(feedback);
                _db.SaveChanges();

                return RedirectToAction("FeedbackResult");
            }
            return View(feedback);
        }

        public IActionResult FeedbackResult()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult TrackApplication()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult TrackApplication(string token)
        {
            var application = _db.ConnectionForms.FirstOrDefault(a => a.Token == Convert.ToInt32(token));
            TempData.Put("application", application);

            if (application == null)
            {
                return NotFound();
            }
            else
            {
                return RedirectToAction(nameof(ApplicationStatus));
            }
        }

        public IActionResult ApplicationStatus()
        {
            if (TempData["application"] != null)
            {
                ConnectionForm connectionForm = TempData.Get<ConnectionForm>("application");
                return View(connectionForm);
            }
            else
            {
                return NotFound();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}