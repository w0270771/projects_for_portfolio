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
    public class TrackController : Controller
    {
        private MyTunesContext db = new MyTunesContext();

        // GET: Track
       public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page){
            ViewBag.CurrentSort = sortOrder;

            ViewBag.AlbumNameSortParm = String.IsNullOrEmpty(sortOrder) ? "album_name_desc" : "";
            ViewBag.GenreSortParm = String.IsNullOrEmpty(sortOrder) ? "genre_desc" : "";
            ViewBag.MediaSortParm = String.IsNullOrEmpty(sortOrder) ? "media_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.ComposerSortParm = String.IsNullOrEmpty(sortOrder) ? "composer_desc" : "";
            ViewBag.MillisecondsSortParm = sortOrder == "Number" ? "milliseconds_desc" : "Number";
            ViewBag.BytesSortParm = sortOrder == "Integer" ? "bytes_desc" : "Integer";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var tracks = db.Tracks.Include(t => t.Album).Include(t => t.Genre).Include(t => t.MediaType);
            if (!String.IsNullOrEmpty(searchString))
            {
                tracks = tracks.Where(t => t.Album.Title.Contains(searchString)
                                       || t.MediaType.Name.Contains(searchString)
                                       || t.Genre.Name.Contains(searchString)
                                       || t.Name.Contains(searchString)
                                       || t.Composer.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "album_name_desc":
                    tracks = tracks.OrderByDescending(t => t.Album.Title);
                    break;
                case "genre_desc":
                    tracks = tracks.OrderByDescending(t => t.Genre.Name);
                    break;
                case "media_desc":
                    tracks = tracks.OrderByDescending(t => t.MediaType.Name);
                    break;
                case "name_desc":
                    tracks = tracks.OrderByDescending(t => t.Name);
                    break;
                case "composer_desc":
                    tracks = tracks.OrderByDescending(t => t.Composer);
                    break;
                case "Number":
                    tracks = tracks.OrderBy(t => t.Milliseconds);
                    break;
                case "milliseconds_desc":
                    tracks = tracks.OrderByDescending(t => t.Milliseconds);
                    break;
                case "Integer":
                    tracks = tracks.OrderBy(t => t.Bytes);
                    break;
                case "bytes_desc":
                    tracks = tracks.OrderByDescending(t => t.Bytes);
                    break;
                case "Price":
                    tracks = tracks.OrderBy(t => t.UnitPrice);
                    break;
                case "price_desc":
                    tracks = tracks.OrderByDescending(t => t.UnitPrice);
                    break;
                default:
                    tracks = tracks.OrderBy(t => t.Name);
                    break;
            }

            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(tracks.ToPagedList(pageNumber, pageSize));

        }

        // GET: Track/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // GET: Track/Create
        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "Title");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            ViewBag.MediaTypeId = new SelectList(db.MediaTypes, "MediaTypeId", "Name");
            return View();
        }

        // POST: Track/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrackId,Name,AlbumId,MediaTypeId,GenreId,Composer,Milliseconds,Bytes,UnitPrice")] Track track)
        {
            if (ModelState.IsValid)
            {
                db.Tracks.Add(track);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "Title", track.AlbumId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", track.GenreId);
            ViewBag.MediaTypeId = new SelectList(db.MediaTypes, "MediaTypeId", "Name", track.MediaTypeId);
            return View(track);
        }

        // GET: Track/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "Title", track.AlbumId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", track.GenreId);
            ViewBag.MediaTypeId = new SelectList(db.MediaTypes, "MediaTypeId", "Name", track.MediaTypeId);
            return View(track);
        }

        // POST: Track/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrackId,Name,AlbumId,MediaTypeId,GenreId,Composer,Milliseconds,Bytes,UnitPrice")] Track track)
        {
            if (ModelState.IsValid)
            {
                db.Entry(track).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "Title", track.AlbumId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", track.GenreId);
            ViewBag.MediaTypeId = new SelectList(db.MediaTypes, "MediaTypeId", "Name", track.MediaTypeId);
            return View(track);
        }

        // GET: Track/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // POST: Track/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Track track = db.Tracks.Find(id);
            db.Tracks.Remove(track);
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
