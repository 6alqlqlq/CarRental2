using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCarRental3.Contracts;
using TestCarRental3.Models;

namespace TestCarRental3.Controllers
{
    public class HomeController : Controller
    {

        IRepository<Contact> context;
                
        public HomeController(IRepository<Contact> contactContext)
        {
            context = contactContext;
        }

        public ActionResult ControlPanel()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
           Contact contact = new Contact();
            return View(contact);

        }
        [HttpPost]
        public ActionResult Contact (Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }
            else
            {
                context.Insert(contact);
                context.Commit();
                return RedirectToAction("Contact");
            }
        }

    }
}