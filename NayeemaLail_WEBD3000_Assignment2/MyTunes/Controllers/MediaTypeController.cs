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
    public class MediaTypeController : Controller
    {
        private MyTunesContext db = new MyTunesContext();

        // GET: MediaType
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.MediaSortParm = String.IsNullOrEmpty(sortOrder) ? "media_name_desc" : "";

            var mediaTypes = db.MediaTypes.Include(m => m.MediaCategory);
            switch (sortOrder)
            {
                case "name_desc":
                    mediaTypes = mediaTypes.OrderByDescending(m => m.Name);
                    break;

                case "media_name_desc":
                    mediaTypes = mediaTypes.OrderByDescending(m => m.MediaCategory.Name);
                    break;
                 default:
                    mediaTypes = mediaTypes.OrderBy(m => m.Name);
                    break;
            }
            return View(mediaTypes.ToList());

       
        }

        // GET: MediaType/Details/5
        public ActionResult Details(int? id, int? page)
        {

            var pageNumber = page ?? 1;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaType mediaType = db.MediaTypes.Find(id);
            if (mediaType == null)
            {
                return HttpNotFound();
            }

            var onePageOfTracks = mediaType.Tracks.OrderBy(m => m.Name).ToPagedList(pageNumber, 20); // will only contain 25 products max because of the pageSize
            ViewBag.OnePageOfTracks = onePageOfTracks;

            return View(mediaType);
        }

        // GET: MediaType/Create
        public ActionResult Create()
        {
            ViewBag.MediaCategoryId = new SelectList(db.MediaCategories, "MediaCategoryId", "Name");
            return View();
        }

        // POST: MediaType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MediaTypeId,Name,MediaCategoryId")] MediaType mediaType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.MediaTypes.Add(mediaType);
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

            ViewBag.MediaCategoryId = new SelectList(db.MediaCategories, "MediaCategoryId", "Name", mediaType.MediaCategoryId);
            return View(mediaType);
        }

        // GET: MediaType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaType mediaType = db.MediaTypes.Find(id);
            if (mediaType == null)
            {
                return HttpNotFound();
            }
            ViewBag.MediaCategoryId = new SelectList(db.MediaCategories, "MediaCategoryId", "Name", mediaType.MediaCategoryId);
            return View(mediaType);
        }

        // POST: MediaType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MediaTypeId,Name,MediaCategoryId")] MediaType mediaType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mediaType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MediaCategoryId = new SelectList(db.MediaCategories, "MediaCategoryId", "Name", mediaType.MediaCategoryId);
            return View(mediaType);
        }

        // GET: MediaType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaType mediaType = db.MediaTypes.Find(id);
            if (mediaType == null)
            {
                return HttpNotFound();
            }
            return View(mediaType);
        }

        // POST: MediaType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MediaType mediaType = db.MediaTypes.Find(id);
            db.MediaTypes.Remove(mediaType);
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
