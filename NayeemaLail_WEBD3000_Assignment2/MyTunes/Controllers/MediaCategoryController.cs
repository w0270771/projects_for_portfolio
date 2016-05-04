using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MyTunes.Models;
using System.Data.Entity.Infrastructure;

namespace MyTunes.Controllers
{
    public class MediaCategoryController : Controller
    {
        private MyTunesContext db = new MyTunesContext();

        // GET: MediaCategory
       public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
           

            var mediaCategories = from m in db.MediaCategories
                                  select m;
            switch (sortOrder)
            {
                case "name_desc":
                    mediaCategories = mediaCategories.OrderByDescending(m => m.Name);
                    break;
                default:
                    mediaCategories = mediaCategories.OrderBy(m => m.Name);
                    break;
            }
            //return View(mediaTypes.ToList());
            return View(db.MediaCategories.ToList());
        }

        // GET: MediaCategory/Details/5
        public ActionResult Details(int? id, string sortOrder)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaCategory mediaCategory = db.MediaCategories.Find(id);

            var mediaTypebyCategory = mediaCategory.MediaTypes.OrderBy(m => m.Name); // will only contain 25 products max because of the pageSize
            ViewBag.MediaTypebyCategory = mediaTypebyCategory;

            if (mediaCategory == null){
                return HttpNotFound();
            }
            return View(mediaCategory);
        }

        // GET: MediaCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MediaCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MediaCategoryId,Name")] MediaCategory mediaCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.MediaCategories.Add(mediaCategory);
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

            return View(mediaCategory);
        }

        // GET: MediaCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaCategory mediaCategory = db.MediaCategories.Find(id);
            if (mediaCategory == null)
            {
                return HttpNotFound();
            }
            return View(mediaCategory);
        }

        // POST: MediaCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MediaCategoryId,Name")] MediaCategory mediaCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mediaCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mediaCategory);
        }

        // GET: MediaCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaCategory mediaCategory = db.MediaCategories.Find(id);
            if (mediaCategory == null)
            {
                return HttpNotFound();
            }
            return View(mediaCategory);
        }

        // POST: MediaCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MediaCategory mediaCategory = db.MediaCategories.Find(id);
            db.MediaCategories.Remove(mediaCategory);
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
