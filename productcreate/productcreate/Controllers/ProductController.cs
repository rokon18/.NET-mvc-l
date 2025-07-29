
using productcreate.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace productcreate.Controllers
{
    public class ProductController : Controller
    {
        efEntities db = new efEntities();
        // GET: Student
        public ActionResult Index()
        {
            var data = db.Products.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product s)
        {
            db.Products.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete( int id)
        {
            var data = db.Products.Find(id);
            return View(data);

        }
        [HttpPost]
        public ActionResult Delete(int id, string click)
        {
            if(click == "yes")
            {
                if (click != null)
                {
                    var data = db.Products.Find(id);
                    db.Products.Remove(data);
                    db.SaveChanges();
                    
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Products.Find(id);
            return View(data);

        }
        [HttpPost]
        public ActionResult Edit( Product p)
        {
           db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Restock()
        {
            var data = (from product in db.Products
                        where product.QTy < 10
                        select product).ToList();

            return View(data);
        }

    }
}