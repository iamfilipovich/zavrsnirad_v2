using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

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

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Racunaj(String povrsina, String snaga, String duzina, String napon)
        {
            var u = float.Parse(napon);
            var l = float.Parse(duzina);
            var p = float.Parse(snaga);
            var s = float.Parse(povrsina);

            var otpor = _db.Parametri.Where(e => e.povrsina_presjeka == p).Select(e => e.otpor_vodica).FirstOrDefault();
            var padNapona = ((p * l * otpor) / (u * u)) * 100;
            ViewBag.padNapona = padNapona;

            return View();   
        }
    }


