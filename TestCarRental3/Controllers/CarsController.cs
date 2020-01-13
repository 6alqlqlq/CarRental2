using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCarRental3.Contracts;
using TestCarRental3.Models;

namespace TestCarRental3.Controllers
{
    public class CarsController : Controller
    {
        IRepository<Product> context;
        
        public CarsController(IRepository<Product> productContext)
        {
            context = productContext;
        }
        
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }
        public ActionResult Details(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }


    }
}