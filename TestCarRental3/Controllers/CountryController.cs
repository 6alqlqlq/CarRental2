using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCarRental3.Contracts;
using TestCarRental3.Models;

namespace TestCarRental3.Controllers
{
    public class CountryController : Controller
    {
        IRepository<Country> context;


        public CountryController(IRepository<Country> countryContext)
        {
            context = countryContext;

        }
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            // index 
            List<Country> countrys = context.Collection().ToList();

            return View(countrys.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult Create()
        {
            Country country = new Country();
            return View(country);

        }
        [HttpPost]
        public ActionResult Create(Country country)
        {
            if (!ModelState.IsValid)
            {
                return View(country);
            }
            else
            {
                context.Insert(country);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string Id)
        {
            Country country = context.Find(Id);
            if (country == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(country);
            }
        }
        [HttpPost]
        public ActionResult Edit(Country country, string Id)
        {
            Country countryToEdit = context.Find(Id);
            if (countryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(country);
                }
                countryToEdit.Id = country.Id;
                countryToEdit.CountryName = country.CountryName;
                

                context.Commit();

                return RedirectToAction("Index");

            }
        }

        public ActionResult Delete(string Id)
        {
            Country countryToDelete = context.Find(Id);
            if (countryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(countryToDelete);
            }

        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Country countryToDelete = context.Find(Id);
            if (countryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}
