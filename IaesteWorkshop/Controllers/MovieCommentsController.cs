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
using IaesteWorkshop.DB;
using IaesteWorkshop.Models;

namespace IaesteWorkshop.Controllers
{
    public class MovieCommentsController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/MovieComments/1
        public IQueryable<MovieComment> GetMovieComments(int id)
        {
            return db.MovieComments.Where(x => x.MovieId == id);
        }

        //// GET: api/MovieComments/5
        //[ResponseType(typeof(MovieComment))]
        //public async Task<IHttpActionResult> GetMovieComment(int id)
        //{
        //    MovieComment movieComment = await db.MovieComments.FindAsync(id);
        //    if (movieComment == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(movieComment);
        //}

        // PUT: api/MovieComments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMovieComment(int id, MovieComment movieComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movieComment.Id)
            {
                return BadRequest();
            }

            db.Entry(movieComment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieCommentExists(id))
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

        // POST: api/MovieComments
        [ResponseType(typeof(MovieComment))]
        public async Task<IHttpActionResult> PostMovieComment(MovieComment movieComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MovieComments.Add(movieComment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = movieComment.Id }, movieComment);
        }

        // DELETE: api/MovieComments/5
        [ResponseType(typeof(MovieComment))]
        public async Task<IHttpActionResult> DeleteMovieComment(int id)
        {
            MovieComment movieComment = await db.MovieComments.FindAsync(id);
            if (movieComment == null)
            {
                return NotFound();
            }

            db.MovieComments.Remove(movieComment);
            await db.SaveChangesAsync();

            return Ok(movieComment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieCommentExists(int id)
        {
            return db.MovieComments.Count(e => e.Id == id) > 0;
        }
    }
}