using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeSheetManagementProject.Models;

namespace TimeSheetManagementProject.Controllers
{
    public class EmployeeController : Controller
    {
        private DBEntities db = new DBEntities();

        // GET: Employee
        public ActionResult Index()
        {
            var timeSheetDetails = db.TimeSheetDetails.Include(t => t.Project).Include(t => t.tblLogin);
            return View(timeSheetDetails.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheetDetail timeSheetDetail = db.TimeSheetDetails.Find(id);
            if (timeSheetDetail == null)
            {
                return HttpNotFound();
            }
            return View(timeSheetDetail);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName");
            ViewBag.Id = new SelectList(db.tblLogins, "Id", "UserName");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TimeSheetId,DaysOfWeek,hours,ProjectId,Id")] TimeSheetDetail timeSheetDetail)
        {
            if (ModelState.IsValid)
            {
                db.TimeSheetDetails.Add(timeSheetDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", timeSheetDetail.ProjectId);
            ViewBag.Id = new SelectList(db.tblLogins, "Id", "UserName", timeSheetDetail.Id);
            return View(timeSheetDetail);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheetDetail timeSheetDetail = db.TimeSheetDetails.Find(id);
            if (timeSheetDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", timeSheetDetail.ProjectId);
            ViewBag.Id = new SelectList(db.tblLogins, "Id", "UserName", timeSheetDetail.Id);
            return View(timeSheetDetail);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TimeSheetId,DaysOfWeek,hours,ProjectId,Id")] TimeSheetDetail timeSheetDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeSheetDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", timeSheetDetail.ProjectId);
            ViewBag.Id = new SelectList(db.tblLogins, "Id", "UserName", timeSheetDetail.Id);
            return View(timeSheetDetail);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheetDetail timeSheetDetail = db.TimeSheetDetails.Find(id);
            if (timeSheetDetail == null)
            {
                return HttpNotFound();
            }
            return View(timeSheetDetail);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeSheetDetail timeSheetDetail = db.TimeSheetDetails.Find(id);
            db.TimeSheetDetails.Remove(timeSheetDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
