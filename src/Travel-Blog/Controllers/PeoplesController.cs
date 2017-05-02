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
    public class PeoplesController : Controller
    {
        //private TravelppRepoContext db = new TravelppRepoContext();
        private IPeopleRepository ppRepo;

        public PeoplesController (IPeopleRepository thisPpRepo = null)
        {
            if (thisPpRepo == null)
            {
                this.ppRepo = new EFPeopleRepository();
            }
            else
            {
                this.ppRepo = thisPpRepo;
            }
        }
        public IActionResult Index()
        {
            return View(ppRepo.Peoples.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisPeople = ppRepo.Peoples.FirstOrDefault(peoples => peoples.PeopleId == id);
            ViewBag.Experience = ppRepo.Peoples
                .Include(people => people.ExperiencesPeoples)
                .ThenInclude(experiencesPeoples => experiencesPeoples.Experience)
                .ThenInclude(experience => experience.Place)
                .Where(people => people.PeopleId == id).ToList();
         
            return View(thisPeople);
        }
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create(People people)
        {
            ppRepo.Create(people);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisPeople = ppRepo.Peoples.FirstOrDefault(peoples => peoples.PeopleId == id);
            return View(thisPeople);
        }

        [HttpPost]
        public IActionResult Edit(People people)
        {
            ppRepo.Edit(people);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisPeople = ppRepo.Peoples.FirstOrDefault(peoples => peoples.PeopleId == id);
            return View(thisPeople);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPeople = ppRepo.Peoples.FirstOrDefault(peoples => peoples.PeopleId == id);
            ppRepo.DeleteConfirmed(thisPeople);
            return RedirectToAction("Index");
        }
        
    }
}
