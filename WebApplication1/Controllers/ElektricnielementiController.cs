using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ElektricnielementiController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ElektricnielementiController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Elektricnielementi> objElektricniList = _db.Elektricnielementi.ToList();
            return View(objElektricniList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Elektricnielementi obj)
        {
            if(ModelState.IsValid) { 
            _db.Elektricnielementi.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0) 
            {
                return NotFound();
            }

            var elementiFromDb = _db.Elektricnielementi.Find(id);
            
            if(elementiFromDb == null)
            {
                return NotFound();
            }
            return View(elementiFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Elektricnielementi obj)
        {
            if (ModelState.IsValid)
            {
                _db.Elektricnielementi.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var elementiFromDb = _db.Elektricnielementi.Find(id);

            if (elementiFromDb == null)
            {
                return NotFound();
            }
            return View(elementiFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Elektricnielementi.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Elektricnielementi.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
