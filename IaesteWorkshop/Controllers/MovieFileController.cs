using IaesteWorkshop.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace IaesteWorkshop.Controllers
{
    public class MovieFileController : Controller
    {
        private DBContext db = new DBContext();
        //
        // GET: /File/
        [OutputCache(VaryByParam = "id", Duration = int.MaxValue, Location = OutputCacheLocation.Client)]
        public async  Task<ActionResult> Index(int id)
        {
            var fileToRetrieve = await db.MovieFiles.FindAsync(id);
             return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
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