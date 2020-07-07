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
    public class UserFeedbacksController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/UserFeedbacks
        public IQueryable<UserFeedback> GetUserFeedbacks()
        {
            return db.UserFeedbacks;
        }

        // GET: api/UserFeedbacks/5
        [ResponseType(typeof(UserFeedback))]
        public async Task<IHttpActionResult> GetUserFeedback(int id)
        {
            UserFeedback userFeedback = await db.UserFeedbacks.FindAsync(id);
            if (userFeedback == null)
            {
                return NotFound();
            }

            return Ok(userFeedback);
        }

        // PUT: api/UserFeedbacks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserFeedback(int id, UserFeedback userFeedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userFeedback.Id)
            {
                return BadRequest();
            }

            db.Entry(userFeedback).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserFeedbackExists(id))
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

        // POST: api/UserFeedbacks
        [ResponseType(typeof(UserFeedback))]
        public async Task<IHttpActionResult> PostUserFeedback(UserFeedback userFeedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserFeedbacks.Add(userFeedback);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userFeedback.Id }, userFeedback);
        }

        // DELETE: api/UserFeedbacks/5
        [ResponseType(typeof(UserFeedback))]
        public async Task<IHttpActionResult> DeleteUserFeedback(int id)
        {
            UserFeedback userFeedback = await db.UserFeedbacks.FindAsync(id);
            if (userFeedback == null)
            {
                return NotFound();
            }

            db.UserFeedbacks.Remove(userFeedback);
            await db.SaveChangesAsync();

            return Ok(userFeedback);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserFeedbackExists(int id)
        {
            return db.UserFeedbacks.Count(e => e.Id == id) > 0;
        }
    }
}