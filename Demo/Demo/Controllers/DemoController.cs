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
                InsertData(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void InsertData(Categories category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        // GET: Demo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Demo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Categories cat)
        {
            try
            {
                Categories newcat = db.Categories.Find(id);
                // var item = collection[1].ToString();
                //newcat.CategoryID = cat.CategoryID;
                newcat.CategoryName = cat.CategoryName;
                newcat.Description = cat.Description;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
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
                DeleteItem(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void DeleteItem(int id)
        {
            Categories category = new Categories();
            category.CategoryID = id;
            var data = db.Categories.Find(id);
            db.Categories.Remove(data);
            db.SaveChanges();
        }
    }
}
