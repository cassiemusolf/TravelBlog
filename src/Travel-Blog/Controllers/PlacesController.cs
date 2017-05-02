using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelBlog.Models;


namespace TravelBlog.Controllers
{
    public class PlacesController : Controller
    {
        private IPlaceRepository placeRepo;

        public PlacesController(IPlaceRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.placeRepo = new EFPlaceRepository();
            }
            else
            {
                this.placeRepo = thisRepo;
            }
        }

        private TravelDbContext db = new TravelDbContext();
        public IActionResult Index()
        {
            return View(placeRepo.Places.ToList());
        }
        public IActionResult Details(int id)
        {
            var thisPlace = placeRepo.Places.Include(places => places.Experiences).FirstOrDefault(places => places.PlaceId == id);
            return View(thisPlace);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Place place)
        {
            placeRepo.Places.Add(place);
            placeRepo.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisPlace = db.Places.FirstOrDefault(places => places.PlaceId == id);
            return View(thisPlace);
        }

        [HttpPost]
        public IActionResult Edit(Place place)
        {
            db.Entry(place).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete (int id)
        {
            var thisPlace = db.Places.FirstOrDefault(places => places.PlaceId == id);
            return View(thisPlace);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPlace = db.Places.FirstOrDefault(places => places.PlaceId == id);
            db.Places.Remove(thisPlace);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
