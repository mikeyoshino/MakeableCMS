using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MakeableCMS.Models;

namespace MakeableCMS.Controllers.Api
{
    public class AppOsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AppOs
        public IQueryable<AppOs> GetAppOses()
        {
            return db.AppOses;
        }

        // GET: api/AppOs/5
        [ResponseType(typeof(AppOs))]
        public async Task<IHttpActionResult> GetAppOs(int id)
        {
            AppOs appOs = await db.AppOses.FindAsync(id);
            if (appOs == null)
            {
                return NotFound();
            }

            return Ok(appOs);
        }

        // PUT: api/AppOs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAppOs(int id, AppOs appOs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appOs.Id)
            {
                return BadRequest();
            }

            db.Entry(appOs).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppOsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AppOs
        [ResponseType(typeof(AppOs))]
        public async Task<IHttpActionResult> PostAppOs(AppOs appOs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AppOses.Add(appOs);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = appOs.Id }, appOs);
        }

        // DELETE: api/AppOs/5
        [ResponseType(typeof(AppOs))]
        public async Task<IHttpActionResult> DeleteAppOs(int id)
        {
            AppOs appOs = await db.AppOses.FindAsync(id);
            if (appOs == null)
            {
                return NotFound();
            }

            db.AppOses.Remove(appOs);
            await db.SaveChangesAsync();

            return Ok(appOs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppOsExists(int id)
        {
            return db.AppOses.Count(e => e.Id == id) > 0;
        }
    }
}