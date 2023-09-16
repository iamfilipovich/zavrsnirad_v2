using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ParametriController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ParametriController (ApplicationDbContext db)
        {
            _db = db;
        }

        
        public IActionResult Index()
        {
            IEnumerable<Parametri> objParametriList = _db.Parametri.ToList();
            return View(objParametriList);
        }
        
        /*
        povpres = izforme
        padnapona = funkcijakojaracunapadnaponanaosnovupovpres()
        racunaj(padnapona, povpres, nap, snaga) {
        int result = padnapona+povpres+nap+snaga
                return result 
        }
        */

        //GET
        public IActionResult Racunaj(float parametarDb)
        {      

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Racunaj(float? povrsina_presjeka)
        {
            var parametarFromDb = _db.Parametri.Find(povrsina_presjeka);

            return View();
        }
    }
}
