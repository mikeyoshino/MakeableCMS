using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MakeableCMS.Models;

namespace MakeableCMS.Controllers
{
    [Authorize]
    public class AppOsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AppOs
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageAll))
            {
                return View("List", db.AppOses.ToList());
            }
            else
            {
                return View("ReadOnlyList", db.AppOses.ToList());
            }
        }

        // GET: AppOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppOs appOs = db.AppOses.Find(id);
            if (appOs == null)
            {
                return HttpNotFound();
            }
            return View(appOs);
        }

        // GET: AppOs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] AppOs appOs)
        {
            if (ModelState.IsValid)
            {
                db.AppOses.Add(appOs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appOs);
        }

        // GET: AppOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppOs appOs = db.AppOses.Find(id);
            if (appOs == null)
            {
                return HttpNotFound();
            }
            return View(appOs);
        }

        // POST: AppOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] AppOs appOs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appOs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appOs);
        }

        // GET: AppOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppOs appOs = db.AppOses.Find(id);
            if (appOs == null)
            {
                return HttpNotFound();
            }
            return View(appOs);
        }

        // POST: AppOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppOs appOs = db.AppOses.Find(id);
            db.AppOses.Remove(appOs);
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
