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
    public class CityController : Controller
    {
        IRepository<City> context;


        public CityController(IRepository<City> cityContext)
        {
            context = cityContext;

        }
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            // index 
            List<City> citys = context.Collection().ToList();

            return View(citys.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult Create()
        {
            City city = new City();
            return View(city);

        }
        [HttpPost]
        public ActionResult Create(City city)
        {
            if (!ModelState.IsValid)
            {
                return View(city);
            }
            else
            {
                context.Insert(city);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string Id)
        {
            City city = context.Find(Id);
            if (city == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(city);
            }
        }
        [HttpPost]
        public ActionResult Edit(City city, string Id)
        {
            City cityToEdit = context.Find(Id);
            if (cityToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(city);
                }
                cityToEdit.Id = city.Id;
                cityToEdit.CityName= city.CityName;
                cityToEdit.CountryID = city.CountryID;
               
                context.Commit();

                return RedirectToAction("Index");

            }
        }

        public ActionResult Delete(string Id)
        {
            City cityToDelete = context.Find(Id);
            if (cityToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(cityToDelete);
            }

        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            City cityToDelete = context.Find(Id);
            if (cityToDelete == null)
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
