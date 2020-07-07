using MakeableCMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakeableCMS.Models;
using System.Data.Entity;

namespace MakeableCMS.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Article
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageAll))
            {
                var article = _context.Articles.Include("Area").ToList();
                return View("List", article);
            }
            else
            {
                var article = _context.Articles.Include("Area").ToList();
                return View("ReadOnlyList", article);
            }


        }

        public ActionResult Create()
        {
            var areas = _context.Areas.ToList();
            var viewModel = new ApplicationViewModel
            {
                Areas = areas
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Article article)
        {
            if (!ModelState.IsValid)
            {
                var art = new Article();
                return View("Create", art);
            }

            if (article.Id == 0)
            {
                article.DateTime = DateTime.Now;
                _context.Articles.Add(article);
            }
            else
            {
                var articleInDb = _context.Articles.Single(s => s.Id == article.Id);

                articleInDb.Name = article.Name;
                articleInDb.AreaId = article.AreaId;
                articleInDb.Url = article.Url;
                articleInDb.Description = article.Description;
                articleInDb.DateTime = article.DateTime;


            }
            _context.SaveChanges();
            return RedirectToAction("Create", "Article");
        }
        public ActionResult Edit(int id)
        {
            var art = _context.Articles.SingleOrDefault(s => s.Id == id);
            if (art == null)
                return HttpNotFound();
            return View(art);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CategoryId,DateTime,Url")] Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(article).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        public ActionResult Delete(int? id)
        {

            var article = _context.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }

            return View(article);
        }
    }
}