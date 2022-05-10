using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationTask.Models;

namespace WebApplicationTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register_Table tb)
        {
            if(ModelState.IsValid)
            {
                TaskEntities db = new TaskEntities();
                db.Register_Table.Add(tb);
                db.SaveChanges();

                tb.UserName = string.Empty;
                tb.UserEmail = string.Empty;
                tb.Password = string.Empty;
                tb.Role = string.Empty;
            }
            return View(tb);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Your Home page.";

            return View();
        }
        public ActionResult Admin()
        {

            return View();
        }
        public ActionResult User()
        {

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                TaskEntities db = new TaskEntities();
                var user = (from userlist in db.Register_Table
                            where userlist.UserEmail == model.UserEmail && userlist.Password == model.Password
                            select new
                            {
                                userlist.Role,
                                userlist.UserName
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {
                    Session["UserName"] = user.FirstOrDefault().UserName;
                    if(user.FirstOrDefault().Role == "admin")
                    {
                        return RedirectToAction("Admin","Home");
                    }
                    else
                    {
                        return RedirectToAction("User", "Home");
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            }
            return View(model);
        }
    }
 
}
