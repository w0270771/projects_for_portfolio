using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MyTunes.Models;
using PagedList;
using System.Data.Entity.Infrastructure;

namespace MyTunes.Controllers
{
    public class GenreController : Controller
    {
        private MyTunesContext db = new MyTunesContext();

        // GET: Genre
        //public ActionResult Index()
        //{
        //   return View(db.Genres.ToList());
        //}

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var genres = from g in db.Genres
                          select g;
            if (!String.IsNullOrEmpty(searchString))
            {
                genres = genres.Where(g => g.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    genres = genres.OrderByDescending(g => g.Name);
                    break;

                default:
                    genres = genres.OrderBy(g => g.Name);
                    break;
            }

            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(genres.ToPagedList(pageNumber, pageSize));

            //return View(tracks.ToList());
        }

        // GET: Genre/Details/5
        public ActionResult Details(int? id, int? page)
        {       

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
                       

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            var onePageOfTracks = genre.Tracks.OrderBy(g => g.Name).ToPagedList(pageNumber, 20); // will only contain 25 products max because of the pageSize
            ViewBag.OnePageOfTracks = onePageOfTracks;


            //return View(genre.ToPagedList(pageNumber, pageSize));
            return View(genre);
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreId,Name")] Genre genre)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Genres.Add(genre);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
          
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return RedirectToAction("Index");
            }
            
            

            return View(genre);
        }

        // GET: Genre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenreId,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        // GET: Genre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genre genre = db.Genres.Find(id);
            db.Genres.Remove(genre);
            db.SaveChanges();
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
