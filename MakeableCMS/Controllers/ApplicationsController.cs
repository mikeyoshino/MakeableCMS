using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MakeableCMS.Models;

namespace MakeableCMS.Controllers
{
    public class ApplicationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Applications
        public async Task<ActionResult> Index()
        {
            var applications = db.Applications.Include(a => a.AppOs).Include(a => a.Category);
            return View(await applications.ToListAsync());
        }

        // GET: Applications/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = await db.Applications.FindAsync(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // GET: Applications/Create
        public ActionResult Create()
        {
            ViewBag.AppOsId = new SelectList(db.AppOses, "Id", "Name");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ImagePath,Name,Description,AppStoreRating,AppOsId,PostDate,IsLastUpdate,UserfulRate,AppUrl,CategoryId")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Applications.Add(application);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AppOsId = new SelectList(db.AppOses, "Id", "Name", application.AppOsId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", application.CategoryId);
            return View(application);
        }

        // GET: Applications/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = await db.Applications.FindAsync(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppOsId = new SelectList(db.AppOses, "Id", "Name", application.AppOsId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", application.CategoryId);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ImagePath,Name,Description,AppStoreRating,AppOsId,PostDate,IsLastUpdate,UserfulRate,AppUrl,CategoryId")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AppOsId = new SelectList(db.AppOses, "Id", "Name", application.AppOsId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", application.CategoryId);
            return View(application);
        }

        // GET: Applications/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = await db.Applications.FindAsync(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Application application = await db.Applications.FindAsync(id);
            db.Applications.Remove(application);
            await db.SaveChangesAsync();
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
