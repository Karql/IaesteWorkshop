using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IaesteWorkshop.DB;
using IaesteWorkshop.Models;
using System.IO;

namespace IaesteWorkshop.Controllers
{
    public class MoviesController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Movies
        public async Task<ActionResult> Index()
        {
            var movies = db.Movies.Include(m => m.CoverImage);
            return View(await movies.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = await db.Movies.Include(s => s.CoverImage).FirstOrDefaultAsync(s => s.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.MovieFiles, "FileId", "FileName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,TrailerUrl,Cast,Direction,Genre,Duration")] Movie movie, HttpPostedFileBase coverImage)
        {
            if (ModelState.IsValid)
            {
                if (coverImage != null && coverImage.ContentLength > 0)
                {
                    var movieFile = new MovieFile
                    {
                        FileName = System.IO.Path.GetFileName(coverImage.FileName),
                        ContentType = coverImage.ContentType,
                    };
                    using (var reader = new System.IO.BinaryReader(coverImage.InputStream))
                    {
                        movieFile.Content = reader.ReadBytes(coverImage.ContentLength);
                    }
                    movie.CoverImage = movieFile;
                }
                try
                {
                    db.Movies.Add(movie);

                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {

                    return View(movie);
                }
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = await db.Movies.Include(s => s.CoverImage).FirstOrDefaultAsync(s => s.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Description,TrailerUrl,Cast,Direction,Genre,Duration")] Movie movie, HttpPostedFileBase coverImage)
        {
            if (ModelState.IsValid)
            {
                if (coverImage != null && coverImage.ContentLength > 0)
                {
                    var movieFile = new MovieFile
                    {
                        FileName = System.IO.Path.GetFileName(coverImage.FileName),
                        ContentType = coverImage.ContentType,
                        MovieId = movie.Id
                    };
                    using (var reader = new System.IO.BinaryReader(coverImage.InputStream))
                    {
                        movieFile.Content = reader.ReadBytes(coverImage.ContentLength);
                    }
                    var movieCoverBefore =await db.MovieFiles.FindAsync(movie.Id);
                    if (movieCoverBefore != null)
                    {//delete
                        db.Entry(movieCoverBefore).State = EntityState.Deleted;
                    }
                    movie.CoverImage = movieFile;
                    db.MovieFiles.Add(movieFile);
                }

                db.Entry(movie).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = await db.Movies.Include(s => s.CoverImage).FirstOrDefaultAsync(s => s.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Movie movie = await db.Movies.Include(s => s.CoverImage).FirstOrDefaultAsync(s => s.Id == id);
            db.Movies.Remove(movie);
            if (movie.CoverImage != null)
                db.MovieFiles.Remove(movie.CoverImage);
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
