using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTunes.Models;

namespace MyTunes.Logic
{
    public class AddTracks
    {
        public bool AddTrack(string TrackName, string TrackPrice, string TrackAlbum,string TrackMediaType, string TrackGenre)
        {
            var myTrack = new Track();
            myTrack.Name = TrackName;
           
            myTrack.UnitPrice = Convert.ToDecimal(TrackPrice);
           
            myTrack.AlbumId = Convert.ToInt32(TrackAlbum);
          
            myTrack.MediaTypeId = Convert.ToInt32(TrackMediaType);

            myTrack.GenreId = Convert.ToInt32(TrackGenre);

            using (MyTunesContext _db = new MyTunesContext())
            {
                // Add Track to DB.
                _db.Tracks.Add(myTrack);
                _db.SaveChanges();
            }
            // Success.
            return true;
        }
    }

}
