using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MakeableCMS.Models;

namespace MakeableCMS.Controllers.Api
{
    public class CategoryController : ApiController
    {
        private ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();

        }

        //Get /api/DisabilityTypes
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }


        //Get /Api/DisabilityTypes/1
        public Category GetCategory(int id)
        {
            var category = _context.Categories.SingleOrDefault(m => m.Id == id);
            if (category == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return category;
        }

        //Post /Api/DisabilityTypes
        [HttpPost]
        public Category CreatecCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        //Put /Api/DisabilityTypes/1
        public void UpdateCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            //Get a record based on Id
            var catInDb = _context.Categories.SingleOrDefault(m => m.Id == id);

            //Check if record is emty or valid if it is empty throw exception.
            if (catInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //Update database
            catInDb.Name = category.Name;
            catInDb.Description = category.Description;

            _context.SaveChanges();
        }


        //Delete /Api/DisabilityTypes/1
        [HttpDelete]
        public void DeteleCategory(int id)
        {
            var catInDb = _context.Categories.SingleOrDefault(m => m.Id == id);
            if (catInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Categories.Remove(catInDb);
            _context.SaveChanges();
        }
    }
}
