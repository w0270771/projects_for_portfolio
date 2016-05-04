using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyTunes.Models;
using PagedList;
using System.Data.Entity.Infrastructure;
using MyTunes.ViewModels;

namespace MyTunes.Controllers
{
    public class ArtistController : Controller
    {
        private MyTunesContext db = new MyTunesContext();

        // GET: Artist
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? id, int? albumID, int? ArtistPage, int? AlbumPage, int? TrackPage)
        {
            /*ViewBag.CurrentSort = sortOrder;

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
            
            var artists = from a in db.Artists
                          select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                artists = artists.Where(a => a.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    artists = artists.OrderByDescending(a => a.Name);
                    break;
               
                default:
                    artists = artists.OrderBy(a => a.Name);
                    break;
            }

            int pageSize = 7;
            int pageNumber = (page ?? 1);

            return View(artists.ToPagedList(pageNumber, pageSize));*/

            int artistPageNumber = (ArtistPage ?? 1);
            int albumPageNumber = (AlbumPage ?? 1);
            int trackPageNumber = (TrackPage ?? 1);

            var viewModel = new ArtistIndexData();
                viewModel.Artists = db.Artists
                    .Include(i => i.Albums)
                    .Include(i => i.Albums.Select(c => c.Tracks))
                    .OrderBy(i => i.Name).ToPagedList(artistPageNumber, 5); 

                if (id != null)
                {
                    ViewBag.ArtistID = id.Value;
                    viewModel.Albums = viewModel.Artists.Where(
                        i => i.ArtistId == id.Value).Single().Albums; 
                }

                if (albumID != null)
                {
                    ViewBag.AlbumID = albumID.Value;
                    viewModel.Tracks = viewModel.Albums.Where(
                        x => x.AlbumId == albumID).Single().Tracks; 
                }

                return View(viewModel);
            }


        // GET: Artist/Details/5
        public ActionResult Details(int? id, int? page)
        {

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }

            var onePageOfAlbums = artist.Albums.OrderBy(a =>a.Title).ToPagedList(pageNumber, 20); // will only contain 25 products max because of the pageSize
            ViewBag.OnePageOfAlbums = onePageOfAlbums;

            return View(artist);
        }

        // GET: Artist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistId,Name")] Artist artist)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Artists.Add(artist);
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

            return View(artist);
        }

        // GET: Artist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistId,Name")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Artist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
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
