using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTunes.Models;

namespace MyTunes.Logic
{
    public class AddAlbums
    {
        public bool AddAlbum(string AlbumName, string AlbumArtist)
        {
            var myAlbum = new Album();
            myAlbum.Title = AlbumName;
            myAlbum.ArtistId = Convert.ToInt32(AlbumArtist);

            using (MyTunesContext _db = new MyTunesContext())
            {
                // Add Track to DB.
                _db.Albums.Add(myAlbum);
                _db.SaveChanges();
            }
            // Success.
            return true;
        }
    }
}