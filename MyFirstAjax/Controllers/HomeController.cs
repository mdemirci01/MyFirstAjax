using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstAjax.Data;
using MyFirstAjax.Models;

namespace MyFirstAjax.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
        public HomeController(ApplicationDbContext context)
        {
            this.db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetCitiesByCountryId(int countryId)
        {
            return Json(db.Cities.Where(c => c.CountryId == countryId).ToList());
        }

        public IActionResult Contact()
        {
            var feedback = new Feedback();
            ViewBag.Countries = new SelectList(db.Countries.ToList(),"Id","Name", feedback.CountryId);
            ViewBag.Cities = new SelectList(db.Cities.Where(c => c.CountryId == feedback.CountryId).ToList(), "Id", "Name", feedback.CityId);
            return View(feedback);
        }

        [HttpPost]
        public IActionResult Contact(Feedback feedback)
        {
            if (ModelState.IsValid) { 
                feedback.CreatedAt = DateTime.Now;
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Countries = new SelectList(db.Countries.ToList(), "Id", "Name", feedback.CountryId);
            ViewBag.Cities = new SelectList(db.Cities.Where(c => c.CountryId == feedback.CountryId).ToList(), "Id", "Name", feedback.CityId);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
