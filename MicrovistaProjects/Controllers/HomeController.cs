using MicrovistaProjects.Models;
using MicrovistaProjects.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicrovistaProjects.Controllers
{
    public class HomeController : Controller
    {
        MicrovistaEntities db = new MicrovistaEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Authenticate user using the database
                var user = db.tblLogins.FirstOrDefault(u => u.User == model.User && u.Password == model.Password);

                if (user != null)
                {
                    // Redirect to a secure page upon successful login
                    return RedirectToAction("Index", "CrudMVC");
                }

                ModelState.AddModelError("", "Invalid username or password");
            }

            return View(model);
        }
    }
}
