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

namespace IaesteWorkshop.Controllers
{
    public class MovieReviewsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: MovieReviews
        public async Task<ActionResult> Index()
        {
            var movieReviews = db.MovieReviews.Include(m => m.Movie);
            return View(await movieReviews.ToListAsync());
        }

        // GET: MovieReviews/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieReview movieReview = await db.MovieReviews.FindAsync(id);
            if (movieReview == null)
            {
                return HttpNotFound();
            }
            return View(movieReview);
        }

        // GET: MovieReviews/Create
        public ActionResult Create()
        {
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Title");
            return View();
        }

        // POST: MovieReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,MovieId,ReviewerName,ReviewerEmail,Review,ReviewType,Rating")] MovieReview movieReview, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                db.MovieReviews.Add(movieReview);
                await db.SaveChangesAsync();
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index");
            }

            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Title", movieReview.MovieId);
            
            return View(movieReview);
        }

        // GET: MovieReviews/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieReview movieReview = await db.MovieReviews.FindAsync(id);
            if (movieReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Title", movieReview.MovieId);
            return View(movieReview);
        }

        // POST: MovieReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,MovieId,ReviewerName,ReviewerEmail,Review,ReviewType,Rating")] MovieReview movieReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieReview).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Title", movieReview.MovieId);
            return View(movieReview);
        }

        // GET: MovieReviews/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieReview movieReview = await db.MovieReviews.FindAsync(id);
            if (movieReview == null)
            {
                return HttpNotFound();
            }
            return View(movieReview);
        }

        // POST: MovieReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MovieReview movieReview = await db.MovieReviews.FindAsync(id);
            db.MovieReviews.Remove(movieReview);
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
