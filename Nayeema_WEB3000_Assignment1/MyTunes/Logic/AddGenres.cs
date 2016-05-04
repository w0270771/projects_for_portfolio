using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTunes.Models;

namespace MyTunes.Logic
{
    public class AddGenres
    {
        public bool AddGenre(string GenreName)
        {
            var myGenre = new Genre();
            myGenre.Name = GenreName;


            using (MyTunesContext _db = new MyTunesContext())
            {
                // Add Track to DB.
                _db.Genres.Add(myGenre);
                _db.SaveChanges();
            }
            // Success.
            return true;
        }
    }
}