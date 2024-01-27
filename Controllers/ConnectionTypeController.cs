using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SNGPL.Data;
using SNGPL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace TopBusToursLondon.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ConnectionTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ConnectionTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var connectionTypes = _db.ConnectionTypes.ToList();

            return View(connectionTypes);
        }

        public IActionResult Upsert(int? id)
        {
            ConnectionType connectionType = new ConnectionType();

            if (id == null)
            {
                //create
                return View(connectionType);
            }
            //update
            connectionType = _db.ConnectionTypes.FirstOrDefault(u => u.Id == id);
            if (connectionType == null)
            {
                return NotFound();
            }
            return View(connectionType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ConnectionType connectionType)
        {
            if (ModelState.IsValid)
            {
                if (connectionType.Id == 0)
                {
                    //create
                    _db.ConnectionTypes.Add(connectionType);
                }
                else
                {
                    _db.ConnectionTypes.Update(connectionType);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(connectionType);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var connectionTypeFromDb = await _db.ConnectionTypes.FirstOrDefaultAsync(u => u.Id == id);
            if (connectionTypeFromDb == null)
            {
                return NotFound();
            }
            else
            {
                _db.ConnectionTypes.Remove(connectionTypeFromDb);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> IsAlreadyExists(string Name, int id)
        {
            if (id > 0)
                return Json(true);

            return Json(!await _db.ConnectionTypes.AnyAsync(c => c.Name == Name));
        }
    }
}