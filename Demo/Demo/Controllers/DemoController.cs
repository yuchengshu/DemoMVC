using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class DemoController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();
        // GET: Demo
        public ActionResult Index()
        {
            //NorthwindEntities db = new NorthwindEntities();
            return View(db.Categories.ToList());
        }

        // GET: Demo/Details/5
        public ActionResult Details(int id)
        {
            Categories category = new Categories();
            category.CategoryID = id;
            
           // NorthwindEntities db = new NorthwindEntities();
            var data=db.Categories.Find(id);
            //db.Categories.Find();
            return View(data);
        }

        // GET: Demo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Demo/Create
        [HttpPost]
        public ActionResult Create(Categories category)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Demo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Demo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var a = collection[3];
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Demo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Demo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
