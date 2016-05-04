using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTunes.Models;

namespace MyTunes.Logic
{
    public class AddArtists
    {
        public bool AddArtist(string ArtistName)
        {
            var myArtist = new Artist();
            myArtist.Name = ArtistName;
            

            using (MyTunesContext _db = new MyTunesContext())
            {
                // Add Track to DB.
                _db.Artists.Add(myArtist);
                _db.SaveChanges();
            }
            // Success.
            return true;
        }
    }
}