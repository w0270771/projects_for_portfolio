using System.Linq;
using System.Web.Mvc;
using MyTunes.Models;
using MyTunes.ViewModels;

namespace MyTunes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TrackByMediaType()
        {

            MyTunesContext db = new MyTunesContext();
           
            IQueryable<CountTrackByMediaType> data = from track in db.Tracks
                                                 group track by track.MediaType.Name into mediaTypeGroup
                                                 select new CountTrackByMediaType()
                                                 {
                                                     MediaType = mediaTypeGroup.Key,
                                                     TrackCount = mediaTypeGroup.Count()
                                                 };
            return View(data.ToList());

        }

        public ActionResult TrackByGenre()
        {

            MyTunesContext db = new MyTunesContext();

            IQueryable<CountTrackbyGenre> data = from track in db.Tracks
                                                 group track by track.Genre.Name into genreGroup
                                                 select new CountTrackbyGenre()
                                                 {
                                                     GenreType = genreGroup.Key,
                                                     TrackCount = genreGroup.Count()
                                                 };
            return View(data.ToList());
            
        }

        public ActionResult TrackByMediaCategory()
        {

            MyTunesContext db = new MyTunesContext();

            IQueryable<CountTrackByMediaCategory> data = from track in db.Tracks
                                                     group track by track.MediaType.MediaCategory.Name into mediaCategoryGroup
                                                     select new CountTrackByMediaCategory()
                                                     {
                                                         MediaCategory = mediaCategoryGroup.Key,
                                                         TrackCount = mediaCategoryGroup.Count()
                                                     };
            return View(data.ToList());

        }

        public ActionResult About(){

            MyTunesContext db = new MyTunesContext();

            int countALLTracks = (from track in db.Tracks
                                    select track).Count();
            ViewBag.AllTracks = countALLTracks;

            int countALLAlbums = (from album in db.Albums
                                  select album).Count();
            ViewBag.AllAlbums = countALLAlbums;

            int countALLArtists = (from artist in db.Artists
                                  select artist).Count();
            ViewBag.AllArtists = countALLArtists;

            var largestTrack = (from track in db.Tracks select track.Bytes).Max();
            ViewBag.LargestTrack = largestTrack;

            var longestTrack = (from track in db.Tracks select track.Milliseconds).Max();
            ViewBag.LongestTrack = longestTrack;

            var artistWithMostTrack = from artist in db.Tracks
                                      select artist.Name;

            ViewBag.ArtistWithTrack = artistWithMostTrack;

            return View();

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}