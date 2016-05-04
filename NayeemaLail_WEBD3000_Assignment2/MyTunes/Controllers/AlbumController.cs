using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MyTunes.Models;
using PagedList;


namespace MyTunes.Controllers
{
    public class AlbumController : Controller
    {
        private MyTunesContext db = new MyTunesContext();

        // GET: Album
        
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.ArtistSortParm = String.IsNullOrEmpty(sortOrder) ? "artist_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var albums = db.Albums.Include(a => a.Artist);
            if (!String.IsNullOrEmpty(searchString))
            {
                albums = albums.Where(a => a.Title.Contains(searchString)
                                       || a.Artist.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    albums = albums.OrderByDescending(a => a.Title);
                    break;
                case "artist_desc":
                    albums = albums.OrderByDescending(a => a.Artist.Name);
                    break;
                default:
                    albums = albums.OrderBy(a => a.Title);
                    break;
            }

            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(albums.ToPagedList(pageNumber, pageSize));
        }


        // GET: Album/Details/5
        public ActionResult Details(int? id, int? page)
        {

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            var onePageOfTracks = album.Tracks.OrderBy(t => t.Name).ToPagedList(pageNumber, 20); // will only contain 25 products max because of the pageSize
            ViewBag.OnePageOfTracks = onePageOfTracks;
            return View(album);
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name","ReleaseDate");
            return View();
        }

        // POST: Album/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,Title,ArtistId,ReleaseDate")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", "ReleaseDate",album.ArtistId);
            return View(album);
        }

        // GET: Album/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", "ReleaseDate",album.ArtistId);
            return View(album);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumId,Title,ArtistId,ReleaseDate")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", "ReleaseDate", album.ArtistId);
            return View(album);
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
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
