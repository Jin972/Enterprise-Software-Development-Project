using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ESD_Project.Models;
using System.Web.Security;
using ESD_Project.Models.Code;

namespace ESD_Project.Controllers
{
    public class HomeController : Controller
    {
        private ESD_BbModel db = new ESD_BbModel();

        public ActionResult Index()
        {
            return View();
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

        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel user) 
        {
            //var acc = db.User.Where(s => s.Username.Equals(username) && s.Password.Equals(password)).ToList();
            if (Membership.ValidateUser(user.Username, user.Password) && ModelState.IsValid) 
            {
                //Session["Username"] = acc.FirstOrDefault().Username;
                //Session["Id"] = acc.FirstOrDefault().UserId;
                FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                var roleAdmin = db.User.Where(s => s.GroupId.Equals("Admin")).ToList();
                var roleManager = db.User.Where(s => s.GroupId.Equals("Manager")).ToList();
                var roleCoordinator = db.User.Where(s => s.GroupId.Equals("Coordinator")).ToList();
                var roleStudent = db.User.Where(s => s.GroupId.Equals("Student")).ToList();

                // Authorize the "Admin" right
                if (roleAdmin.Count() > 0) {
                    // direct to admin page if authorize successfully
                    return RedirectToAction("AdminPage");
                }

                // Authorize the "Manager" right
                if (roleManager.Count() > 0)
                {
                    // direct to Marketing Manager page if authorize successfully
                    return RedirectToAction("ManagerPage");
                }

                // Authorize the "Coordinator" right
                if (roleCoordinator.Count() > 0)
                {
                    // direct to Marketing Coordinator page if authorize successfully
                    return RedirectToAction("CoordinatorPage");
                }

                // Authorize the "Student" right
                if (roleStudent.Count() > 0)
                {
                    // direct to Student page if authorize successfully
                    return RedirectToAction("StudentPage");
                }
                else 
                {
                    ModelState.AddModelError( "","Your account have not the right to login. Please try againt with another account");
                }
            }
            else
            {
                ModelState.AddModelError("", "Your Username or Password is incorrect. Please re-enter!");
                return View();
            }
            return View();
        }

        public ActionResult Logout()
        {
            //Session.Clear();//remove session
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        // ----------------------------------------------------Dashboard Area-----------------------------------------------------
        // Administrator Page
        [Authorize]
        public ActionResult AdminPage() {
            return View();
        }
        // Marketing Manager Page
        [Authorize]
        public ActionResult ManagerPage()
        {

                return View();
        }

        // Marketing Coordinator Page
        [Authorize]
        public ActionResult CoordinatorPage()
        {

                return View();
        }

        // Student Page
        [Authorize]
        public ActionResult StudentPage()
        {
                return View();
        }
    }
}