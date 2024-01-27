using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SNGPL.Data;
using SNGPL.Models;
using SNGPL.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SNGPL.Controllers
{
    [Authorize(Roles = "Admin,Customer")]
    public class ConnectionFormController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _WebHostEnvironment;

        public ConnectionFormController(ApplicationDbContext db, IWebHostEnvironment WebHostEnvironment)
        {
            _db = db;
            _WebHostEnvironment = WebHostEnvironment;
        }

        public IActionResult Index()
        {
            var connectionForms = _db.ConnectionForms.ToList();
            return View();
        }

        [Authorize(Roles = "Customer")]
        [HttpGet]
        public IActionResult Create()
        {
            ConnectionFormVM connectionFormVM = new ConnectionFormVM()
            {
                ConnectionForm = new ConnectionForm(),
                connetionTypes = _db.ConnectionTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            return View(connectionFormVM);
        }

        [Authorize(Roles = "Customer")]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(ConnectionFormVM connectionFormVM)
        {
            if (ModelState.IsValid)
            {
                string wwwrootPath = _WebHostEnvironment.WebRootPath;
                string path = @"\Uploads\";

                string fileNameGBill = Path.GetFileNameWithoutExtension(connectionFormVM.ConnectionForm.NearestGasBillFile.FileName);
                string fileNameEBill = Path.GetFileNameWithoutExtension(connectionFormVM.ConnectionForm.ElectricityBillFile.FileName);

                string extensionGBill = Path.GetExtension(connectionFormVM.ConnectionForm.NearestGasBillFile.FileName);
                string extensionEBill = Path.GetExtension(connectionFormVM.ConnectionForm.ElectricityBillFile.FileName);

                connectionFormVM.ConnectionForm.NearestGasBillImage = fileNameGBill = fileNameGBill + DateTime.Now.ToString("yyyymmssfff") + extensionGBill;
                connectionFormVM.ConnectionForm.ElectricityBillImage = fileNameEBill = fileNameEBill + DateTime.Now.ToString("yyyyymmssfff") + extensionEBill;

                string pathforGBill = Path.Combine(wwwrootPath + path + fileNameGBill);
                string pathforEBill = Path.Combine(wwwrootPath + path + fileNameEBill);

                using (var fileStream = new FileStream(pathforGBill, FileMode.Create))
                {
                    connectionFormVM.ConnectionForm.NearestGasBillFile.CopyTo(fileStream);
                }

                using (var fileStream = new FileStream(pathforEBill, FileMode.Create))
                {
                    connectionFormVM.ConnectionForm.ElectricityBillFile.CopyTo(fileStream);
                }

                connectionFormVM.ConnectionForm.Status = "Submitted";
                connectionFormVM.ConnectionForm.DateSubmitted = DateTime.Now.Date;

                //for token
                Random generator = new Random();
                String token = generator.Next(0, 1000000).ToString("D6");
                TempData["Token"] = token;
                connectionFormVM.ConnectionForm.Token = Convert.ToInt32(token);

                _db.ConnectionForms.Add(connectionFormVM.ConnectionForm);
                _db.SaveChanges();
                return RedirectToAction(nameof(ApplicationSumitted));
            }
            return View();
        }

        public IActionResult ApplicationSumitted()
        {
            return View();
        }
    }
}