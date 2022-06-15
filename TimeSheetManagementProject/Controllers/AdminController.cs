using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeSheetManagementProject.Models;

namespace TimeSheetManagementProject.Controllers
{
    public class AdminController : Controller
    {
        private DBEntities db = new DBEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(Project p)
        {
            using (DBEntities db = new DBEntities())
            {
                db.Projects.Add(p);
                if (db.SaveChanges() > 0)
                {
                    ViewBag.msg = "Inserted Successfully";
                    ModelState.Clear();
                   
                    return RedirectToAction("Index", "Admin");
                    
                }
                return View(p);
            }
        }

        public ActionResult Signin()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "--select--" });
            list.Add(new SelectListItem { Text = "Manager" });
            list.Add(new SelectListItem { Text = "Employee" });
            ViewData["list"] = list;
            return View();
        }

        [HttpPost]
        public ActionResult Signin(tblLogin lg)
        {
            using (DBEntities db = new DBEntities())
            {
                db.tblLogins.Add(lg);
                if (db.SaveChanges() > 0)
                {
                    ViewBag.msg = "Inserted Successfully";
                    ModelState.Clear();
                    return RedirectToAction("Login", "LoginPage");
                }

            }
            return View();
        }

        public ActionResult ViewProjects()
        {
            //var projects=db.Projects.Include(x)
            var projects = db.Projects;
            return View(projects.ToList());
            //return View();
        }

    }
}