using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeSheetManagementProject.Models;


namespace TimeSheetManagementProject.Controllers
{

    public class LoginPageController : Controller
    {
        
        // GET: Login
        
        
        public ActionResult Login()
        {
            /*List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = "--select--" });
            list.Add(new SelectListItem { Text = "Admin" });
            list.Add(new SelectListItem { Text = "Manager" });
            list.Add(new SelectListItem { Text = "Employee" });
            
            ViewData["list"] = list;*/

            return View();
        }
        [HttpPost]
        
        public ActionResult Login(User lg)
        {
            using (DBEntities db = new DBEntities())
            {
                var result = db.tblLogins.Where(x => x.UserName == lg.UserName && x.Password == lg.Password).FirstOrDefault();


                if(result!=null)
                {
                    
                   /* Session["UserId"] = lg.UserName;
                    if (lg.Role == "Admin" && result!= null)
                    {
                        return RedirectToAction("Index", "Admin");

                    }
                    else if (lg.Role == "Manager" && result != null)
                    {
                        return RedirectToAction("Index", "Manager");
                    }
                    else if (lg.Role == "Employee" && result != null)
                    {
                        return RedirectToAction("Index", "Employee");
                    }
                    else
                    {
                        TempData["msg"] = "Incorrect UserName/Password";
                    }*/

                    if(result.Role=="Admin")
                    {
                        return RedirectToAction("Index","Admin");
                    }
                    else if(result.Role=="Manager")
                    {
                        return RedirectToAction("Index", "Manager");

                    }
                    else if(result.Role=="Employee")
                    {
                        return RedirectToAction("Index", "Employee");
                    }
                    else
                    {
                        TempData["msg"] = "Incorrect UserName/Password";
                    }
                }
                else
                {
                    TempData["msg"] = "Incorrect UserName/Password";
                }

             
                return View(lg);
            }
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "LoginPage");
        }
        
    }
}