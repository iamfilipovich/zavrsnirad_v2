using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ParametriController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ParametriController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(ViewData["PadNapona"] as string))
            {
                ViewData["PadNapona"] = ""; // Default value
            }

            IEnumerable<Parametri> objParametriList = _db.Parametri.ToList();
            return View(objParametriList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HandleButtonClick()
        {
            var povrsina = Convert.ToDouble(Request.Form["povrsina"]);
            var otpor = _db.Parametri.Where(e => e.povrsina_presjeka == povrsina).Select(e => e.otpor_vodica).FirstOrDefault();
            var snaga = Convert.ToInt32(Request.Form["snaga"]);
            var duzina = Convert.ToInt32(Request.Form["duzina"]);
            var napon = Convert.ToInt32(Request.Form["napon"]);

            if (povrsina == 0)
            {
                ViewData["WarningMessage"] = "Površina ima vrijednost 0. Upišite novu vrijednost.";
            } else if (snaga == 0 )
            {
                ViewData["WarningMessage"] = "Snaga ima vrijednost 0. Upišite novu vrijednost.";
            } else if (duzina == 0 )
            {
                ViewData["WarningMessage"] = "Dužina ima vrijednost 0. Upišite novu vrijednost.";
            } else if (napon == 0)
            {
                ViewData["WarningMessage"] = "Napon ima vrijednost vrijednost 0. Upišite novu vrijednost.";
            } else if (napon == 400)
            {
                ViewData["povrsina"] = povrsina;
                ViewData["snaga"] = snaga;
                ViewData["duzina"] = duzina;
                ViewData["napon"] = napon;

                double padNapona = ((snaga * duzina * otpor) / (napon * napon)) * 100;
                ViewData["PadNapona"] = padNapona;
            }
            else
            {
                ViewData["povrsina"] = povrsina;
                ViewData["snaga"] = snaga;
                ViewData["duzina"] = duzina;
                ViewData["napon"] = napon;

                double padNapona = ((2 * snaga * duzina * otpor) / (napon * napon)) * 100;
                ViewData["PadNapona"] = padNapona;
            }
            return View("Index");
        }
    }
}