using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeSheetManagementProject.Models;

namespace TimeSheetManagementProject.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
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
            using(DBEntities db = new DBEntities())
            {
                db.Projects.Add(p);
                if(db.SaveChanges()>0)
                {
                    ViewBag.msg = "Inserted Successfully";
                    ModelState.Clear();
                    return RedirectToAction("Index","Manager");
                }
                return View();
            }
        }

        public ActionResult Signin()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "--select--" });
            
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
    }
}