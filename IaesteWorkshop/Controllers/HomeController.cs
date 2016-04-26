using IaesteWorkshop.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace IaesteWorkshop.Controllers
{
    public class HomeController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            ViewBag.MenuItem = "index";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.MenuItem = "contact";

            return View();
        }

        public async Task<ActionResult> Reviews(int? page = null)
        {
            ViewBag.MenuItem = "reviews";
            int pageNumber = Math.Max(1, page ?? 1);
            int pageSize = 6;

            var moviesQ = db.Movies.Include(x => x.CoverImage)
                .Include(x => x.Reviews)
                .Where(x => x.Reviews.Any())
                .OrderByDescending(x => x.Id);

            ViewBag.TotalPages = (await moviesQ.CountAsync() + pageSize - 1) / pageSize;
            ViewBag.CurrentPage = pageNumber;
            var model = await moviesQ
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return View(model);
        }

        public async Task<ActionResult> Single(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.MenuItem = "single";
            var movie = await db.Movies.Include(s => s.CoverImage).FirstOrDefaultAsync(s => s.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        public async Task<ActionResult> Videos(int? page = null)
        {
            ViewBag.MenuItem = "videos";
            int pageNumber = Math.Max(1, page ?? 1);
            int pageSize = 12;

            var moviesQ = db.Movies.Include(x => x.CoverImage).OrderByDescending(x => x.Id);

            ViewBag.TotalPages = (await moviesQ.CountAsync() + pageSize - 1) / pageSize;
            ViewBag.CurrentPage = pageNumber;
            var model = await moviesQ
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return View(model);
        }

        [ActionName("404")]
        public ActionResult Error404()
        {
            ViewBag.MenuItem = "404";

            return View("Error404");
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