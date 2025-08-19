using System.Linq;
using System.Web.Mvc;
using zero.EF;


namespace ZeroHunger.Controllers
{
    public class AccountController : Controller
    {
        zeroEntities3 db = new zeroEntities3();

        [HttpGet]
        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
           
            var user = (from u in db.Users
                        where
                      u.Username.Equals(username) &&
                      u.Password.Equals(password)
                        select u).SingleOrDefault();
            if (user != null)
            {
                Session["User"] = user;
                if (user.Role == "Admin") return RedirectToAction("Index", "Admin");
                if (user.Role == "Restaurant") return RedirectToAction("Index", "Restaurant");
                if (user.Role == "Employee") return RedirectToAction("Index", "Employee");
            }

            TempData["Msg"] = "Username and password is invalid";
            TempData["Class"] = "danger";
            return View();
        }

       
    }
}
