using System;
using System.Linq;
using System.Web.Mvc;
using zero.EF;

namespace ZeroHunger.Controllers
{
    public class RestaurantController : Controller
    {
        zeroEntities3 db = new zeroEntities3();

        public ActionResult Index()
        {
            var user = (User)Session["User"];
            if (user != null)
            {

                var requests = (from u in db.Collectrequests
                                where
                              u.RestaurantId == user.Id
                                select u).ToList();


                return View(requests);
            }
            return View();
        }
        [HttpGet ]
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(string foodDetails, DateTime preserveUntil)
        {
            var user = (User)Session["User"];
            if (db.Users.Find(user.Id) == null)
            {
                throw new Exception("Restaurant user not found in database!");
            }
            else
            {
                var req = new Collectrequest
                {
                    RestaurantId = user.Id,
                    Food = foodDetails,
                    Preserveuntil = preserveUntil,
                    StatusId = 1,
                    EmpId = null

                };
                db.Collectrequests.Add(req);
              

                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
