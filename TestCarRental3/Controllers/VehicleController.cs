using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestCarRental3.Models;
using TestCarRental3.Datainmemory;
using TestCarRental3.Contracts;

namespace TestCarRental3.Controllers 
{
    public class VehicleController : Controller
    {
        IRepository<Product> context;


        public VehicleController(IRepository<Product> productContext)
        {
            context = productContext;
            
        }
        public ActionResult Index()
        {

            List<Product> products = context.Collection().ToList();
            return View(products);

        }

        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);

        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string Id)
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
        [HttpPost]
        public ActionResult Edit(Product product, string Id)
        {
            Product productToEdit = context.Find(Id);
            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                productToEdit.car_brand = product.car_brand;
                productToEdit.car_model = product.car_model;
                productToEdit.YearOfManufacturing = product.YearOfManufacturing;
                productToEdit.image = product.image;
                productToEdit.capacity = product.capacity;
                productToEdit.doors = product.doors;
                productToEdit.Engine = product.Engine;
                productToEdit.Gearbox = product.Gearbox;
                productToEdit.status = product.status;
                productToEdit.hire_cost = product.hire_cost;

                context.Commit();

                return RedirectToAction("Index");

            }
        } 
        
        public ActionResult Delete(string Id)
        {
            Product productToDelete = context.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }

        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product productToDelete = context.Find(Id);
            if (productToDelete == null)
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


