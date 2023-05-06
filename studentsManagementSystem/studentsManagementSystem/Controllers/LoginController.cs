using studentsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace studentsManagementSystem.Controllers
{
    public class LoginController : Controller
    {

        private SystemManageEntities db = new SystemManageEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user objchk)
        {
            if(ModelState.IsValid)
            {
                using(SystemManageEntities db = new SystemManageEntities())
                {
                    var obj = db.user.Where(a => a.username.Equals(objchk.username) && a.password.Equals(objchk.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("", "The UserName or Password Incorrect");
                    }

                }
            }
            return View(objchk);

        }
        public ActionResult Logout()
        { 
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}