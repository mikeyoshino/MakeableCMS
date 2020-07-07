using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakeableCMS.Models;
using MakeableCMS.ViewModel;
using System.Data.Entity;
using System.Web.Helpers;
using System.Net;
using System.Threading.Tasks;

namespace MakeableCMS.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Application
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageAll))
            {
                var app = _context.Applications.Include("Category").ToList();
                return View("List",app);
            }
            else
            {
                var app = _context.Applications.Include("Category").ToList();
                return View("ReadOnlyList",app);
            }


        }

        public ActionResult Create()
        {
            var categories = _context.Categories.ToList();
            var appOs = _context.AppOses.ToList();

            var viewModel = new ApplicationViewModel
            {
                AppOses = appOs,
                Category = categories
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Application application, HttpPostedFileBase ImageFile)
        {
            if (!ModelState.IsValid)
            {
                var categories = _context.Categories.ToList();
                var appOs = _context.AppOses.ToList();

                var viewModel = new ApplicationViewModel
                {
                    AppOses = appOs,
                    Category = categories
                };
                return View(viewModel);
            }

            if (application.Id == 0)
            {
                //Add image to database
                string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                application.ImagePath = "~/Image/" + fileName;

                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
 
                ImageFile.SaveAs(fileName);

                application.PostDate = DateTime.Now;
                application.IsLastUpdate = false;
                _context.Applications.Add(application);
            }
            else
            {
                var applicationInDb = _context.Applications.Single(s => s.Id == application.Id);

                applicationInDb.Name = application.Name;
                applicationInDb.AppOs = application.AppOs;
                applicationInDb.CategoryId = application.CategoryId;
                applicationInDb.AppStoreRating = application.AppStoreRating;
                applicationInDb.IsLastUpdate = true;
                applicationInDb.PostDate = DateTime.Now;
                applicationInDb.UserfulRate = application.UserfulRate;
                applicationInDb.AppUrl = application.AppUrl;
                applicationInDb.Description = application.Description;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Application");
        }

        // GET: Applications/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppOsId = new SelectList(_context.AppOses, "Id", "Name", application.AppOsId);
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", application.CategoryId);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,AppStoreRating,AppOsId,PostDate,IsLastUpdate,UserfulRate,AppUrl,CategoryId,ImagePath")] Application application)
        {
            if (ModelState.IsValid)
            {
                application.IsLastUpdate = true;
                application.PostDate = DateTime.Now;
                _context.Entry(application).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AppOsId = new SelectList(_context.AppOses, "Id", "Name", application.AppOsId);
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");
            return View(application);
        }



        public ActionResult Delete(int? id)
        {

            var application = _context.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }

            return View(application);
        }

        public ActionResult Details(int Id)
        {

            var application = _context.Applications
                .Include(i => i.Category)
                .Include(i => i.AppOs)
                .SingleOrDefault(x => x.Id == Id);
            if (application == null)
            {
                return HttpNotFound();
            }

            return PartialView("Details", application);
        }
    }
}